import React, { useRef } from 'react'
import userIcon from './img/Logo_User.png'
import CSS from 'csstype';
import User from '../models/User';

const UserInput : React.FC<Props> = ({userID, username, setUser}) => {
    const defaultUserID: string = 'none'
    const inputRef = useRef<HTMLInputElement>(null);

    const handleUser = async (username: string | undefined) => {
        if (username) {
            let url = "User/"

            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ username: username })
            };
            const res = await fetch(url, requestOptions);
            const data = await res.json();
            setUser(data);
        }
    }

    return (
        <div>
            <input style={inputStyle} ref={inputRef} type="text" placeholder="Sign in as ..." />
            <button className="btn waves-effect waves-light" onClick={() => handleUser(inputRef.current?.value)}>
                OK
            </button>
        </div>
    )
}

interface Props{
    userID: string;
    username: string;
    setUser: (user:User) => void
}

const operatorIconStyle: CSS.Properties = {
    width:'30px',
    marginRight: '15px',
    position:'relative',
    top: '10px',
}
const inputStyle: CSS.Properties = {
    width: '20%',
    marginRight: '15px'
}
export default UserInput
