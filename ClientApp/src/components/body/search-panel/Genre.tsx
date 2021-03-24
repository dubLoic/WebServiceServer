import React from 'react'
import { useEffect } from 'react'
import { useRef } from 'react'
import { useState } from 'react'
import Option from './Option'


const Genre: React.FC<Props> = ({onSelected, selectValue}) => {

    const fetchGenders = async () => {
        const res = await fetch("Genre/")
        const data = await res.json()
        return data?.genres;
    }

    const [options, setOptions] = useState<any[]>([])

    useEffect(() => {
        const getGenders = async () => {
            const gendersFromServer: GenderObject[] = await fetchGenders();
            for (let index = 0; index < gendersFromServer.length; index++) {
                let newOption:Option = { id: gendersFromServer[index].id,  value: gendersFromServer[index].name, label: gendersFromServer[index].name}
                setOptions(options => [...options, newOption]);
            }
        }
        getGenders();
    }, [])


    const inputRef = useRef<HTMLSelectElement>(null);

    return (
        <label>Genre :
            <select ref={inputRef} onChange={() => onSelected(inputRef.current?.value)}>
                    {selectValue === '' 
                        ?
                        <option value="0" selected>None</option>
                        :
                        <option value="0" >None</option>
                    }
                    
                    {options.map((item) => (
                            <option key={item.id} value={item.id}>
                                {item.value}
                            </option>
                        ))}
                </select>
            </label>
    )
}

interface GenderObject{
    id: number;
    name: string;
}

interface Props{
    onSelected: (val:string | undefined) => void
    selectValue: string | undefined;
}

export default Genre
