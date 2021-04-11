import React, { useRef } from 'react'
import CSS from 'csstype';
import User from '../models/User';

const UserInput : React.FC<Props> = ({setUser}) => {
    const inputRef = useRef<HTMLInputElement>(null);

    const handleUser = async (username: string | undefined) => {
        if (username && username.length > 0) {
            let url = "User/"

            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ Username: username })
            };
            const res = await fetch(url, requestOptions);
            const data = await res.json();
            setUser(data);
            console.log(data);
        }
    }

    return (
        <div>
            <input style={inputStyle} ref={inputRef} type="text" placeholder="Sign in as ..." />
            <button style={btnStyle} className="btn waves-effect waves-light" onClick={() => handleUser(inputRef.current?.value)}>
                OK
            </button>
        </div>
    )
}

interface Props{
    setUser: (user:User) => void
}

const inputStyle: CSS.Properties = {
    width: '20%',
    marginRight: '15px'
}
const btnStyle: CSS.Properties = {
    color: 'white'
}

export default UserInput
