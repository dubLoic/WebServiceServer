import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import {useState} from 'react';
import Header from './components/header/Header'
import Data from './components/models/Data'
import Search from './components/body/search-panel/Search';
import MediaList from './components/body/display-panel/MediaList';
import MediaSearch from './components/models/MediaSearch';

const App : React.FC = () => {
  const location: string = window.location.pathname !== '/' ? window.location.pathname : Data.PATH_SEARCH_MOVIES;
  const [user, setUser] = useState('Visiteur')

  const [searchBar, setSearchBar] = useState<string | undefined>('')
  const [genre, setGenre] = useState<string | undefined>()

  const updateSearchBarValue = (value:string | undefined) => {
    if(value){
      setGenre('');
      setSearchBar(value);
      fetchMedias();
    }
  }
  const updateGenre = (opt: string | undefined) => {
    if(opt){
      setSearchBar('');
      setGenre(opt);
      fetchMedias();
    }
  }

  const fetchMedias = async () => {
    let type: number = getMediaTypeByLocation();
    let search: MediaSearch = {mediaType: type, text: searchBar, genre: genre};

      const res = await fetch("https://localhost:44342/search/"+search.toString());
    const data = await res.json();
    console.log(data);
  }

  const getMediaTypeByLocation = () => {
    if(location === Data.PATH_SEARCH_MOVIES) return 1;
    if(location === Data.PATH_SEARCH_TV) return 2;
    return 0;
  }

  return (
    <Router>
      <div className="App">

        <Header location={location} user={user} />
        <Switch>
          <Route path={Data.PATH_SEARCH_MOVIES}>
            <Search mediaType='Movie' 
                    searchBarValue={searchBar}
                    selectValue={genre}
                    onChange={updateSearchBarValue} 
                    onSelected={updateGenre} />
          </Route>

          <Route path={Data.PATH_SEARCH_TV}>
            <Search mediaType='TV Show' 
                    searchBarValue={searchBar} 
                    selectValue={genre}
                    onChange={updateSearchBarValue} 
                    onSelected={updateGenre} />
          </Route>

          <Route path={Data.PATH_FAVORITES}>
            <MediaList />
          </Route>

          <Route path={Data.PATH_SUGGESTIONS}>

          </Route>
        </Switch>

      </div>
    </Router>
  );
}

export default App;
