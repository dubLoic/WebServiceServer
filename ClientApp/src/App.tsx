import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import { useEffect, useState } from 'react';
import Header from './components/header/Header'
import Data from './components/models/Data'
import Search from './components/body/search-panel/Search';
import MediaList from './components/body/display-panel/MediaList';
import MediaSearch from './components/models/MediaSearch';
import Media from './components/body/display-panel/Media';

const App: React.FC = () => {
    const location: string = window.location.pathname !== '/' ? window.location.pathname : Data.PATH_SEARCH_MOVIES;

    const [user, setUser] = useState('Visiteur')

    const [searchBar, setSearchBar] = useState<string | undefined>('')
    const [genre, setGenre] = useState<string | undefined>()
    const [message, setMessage] = useState<string>("Our selection for you :")
    const [search, setSearch] = useState<boolean>(false)
    const [medias, setMedias] = useState<Media[]>([])

    useEffect(() => {
        if (search) {
            getResult();
            setSearch(false);
        }
    }, [search])

    useEffect(() => {
        if ((!searchBar || searchBar === '') && (!genre || genre === "0"))
            getDefaultResults("Our selection for you :")
        else if (medias.length === 0)
            getDefaultResults("No result, check our selection for you :")
    }, [])

    const getDefaultResults = (msg: string) => {
        setMessage(msg);
        getDiscoverResult();
    }

    const updateSearchBarValue = (value: string | undefined) => {
        if (value !== undefined) {
            setGenre('');
            setSearchBar(value);
            setSearch(true);
        }
    }
    const updateGenre = (opt: string | undefined) => {
        if (opt) {
            setSearchBar('');
            setGenre(opt);
            setSearch(true);
        }
    }
    const getResult = async () => {
        let tmp = await fetchMedias();
        if (tmp !== "Nothing") {
            setMedias(tmp);
            setMessage("Results :")
        }
    }
    const getDiscoverResult = async () => {
        let tmp = await fetchDiscover();
        if (tmp !== "Nothing") {
            setMedias(tmp);
        }
    }

    const fetchMedias = async () => {
        let type: number = getMediaTypeByLocation();
        let url = "Search/"

        const requestOptions = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ mediaType: type, text: searchBar, genre: genre })
        };
        const res = await fetch(url, requestOptions);

        const data = await res.json();
        return data;
    }

    const fetchDiscover = async () => {
        let type: number = getMediaTypeByLocation();
        let url = "Search/" + type;

        const res = await fetch(url);

        const data = await res.json();
        return data;
    }

    const getMediaTypeByLocation = () => {
        if (location === Data.PATH_SEARCH_MOVIES) return 1;
        if (location === Data.PATH_SEARCH_TV) return 2;
        return 0;
    }

    const setSearchToDefault = () => {
        setSearchBar('');
        setGenre('');
        setMedias([]);
    }

    return (
        <Router>
            <div className="App">

                <Header location={location} onChangedTab={setSearchToDefault} user={user} />
                <Switch>
                    <Route path={[Data.PATH_SEARCH_MOVIES, '/']}>
                        <Search mediaType='Movie'
                            searchBarValue={searchBar}
                            selectValue={genre}
                            onChange={updateSearchBarValue}
                            onSelected={updateGenre} />

                        <MediaList medias={medias} message={message} />
                    </Route>

                    <Route path={Data.PATH_SEARCH_TV}>
                        <Search mediaType='TV Show'
                            searchBarValue={searchBar}
                            selectValue={genre}
                            onChange={updateSearchBarValue}
                            onSelected={updateGenre} />

                        <MediaList medias={medias} message={message} />
                    </Route>

                    <Route path={Data.PATH_FAVORITES}>

                    </Route>

                    <Route path={Data.PATH_SUGGESTIONS}>

                    </Route>
                </Switch>

            </div>
        </Router>
    );
}

export default App;
