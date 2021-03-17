import React from 'react'
import userIcon from './img/Logo_User.png'
import CSS from 'csstype';

const User : React.FC<Props> = ({user}) => {
    let defaultUser: string = 'Visiteur'
    return (
        <div className="right hide-on-med-and-down">
            { 
                user !== defaultUser && 
                <img style={operatorIconStyle} src={userIcon} alt="" />
            }
            {user}
        </div>
    )
}

interface Props{
    user: string;
}

const operatorIconStyle: CSS.Properties = {
    width:'30px',
    marginRight: '15px',
    position:'relative',
    top: '10px',
}
export default User
