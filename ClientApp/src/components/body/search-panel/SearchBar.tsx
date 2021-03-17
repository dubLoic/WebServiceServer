import React from 'react'
import { useRef } from 'react';

const SearchBar:React.FC<Props> = ({target, label, onChange,searchBarValue}) => {
    const inputRef = useRef<HTMLInputElement>(null);
    return (
        <div>
            <label htmlFor={target}>{label}</label>
            <input ref={inputRef} onChange={() => onChange(inputRef.current?.value)} id={target} type="text" value={searchBarValue} />
        </div>
    )
}

interface Props{
    target: string;
    label:string;
    searchBarValue:string | undefined;
    onChange: (val:string | undefined) => void
}

export default SearchBar
