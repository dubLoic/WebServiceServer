import React from 'react'
import Gender from './Gender'
import SearchBar from './SearchBar'

const Search: React.FC<Props> = ({mediaType, onChange, onSelected, searchBarValue, selectValue}) => {

    return (
        <div className="container">
            <h3>Search for a {mediaType}</h3>

            <SearchBar searchBarValue={searchBarValue} onChange={onChange} target='MediaTitle' label='Title or Director :' />

            <Gender selectValue={selectValue} onSelected={onSelected} />
        </div>
    )
}

interface Props{
    mediaType?: string;
    selectValue: string | undefined;
    searchBarValue: string | undefined;
    onChange: (val:string | undefined) => void
    onSelected: (val:string | undefined) => void
}

export default Search
