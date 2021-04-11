import User from "../models/User"
import Logo from "./Logo"
import Tabs from './Tabs'
import UserInput from "./UserInput"

const Header: React.FC<Props> = ({username, setUser, location, onChangedTab}) => {
    return (
        <nav style={navStyle} className="nav-extended">
            <div className="container nav-wrapper">
                <Logo username={username} />                 

                <br/>
                <UserInput setUser={setUser} />
                <Tabs onChangedTab={onChangedTab} location={location} />
                
            </div>
        </nav>
    )
}

interface Props{
    userID: string;
    username: string;
    setUser: (user: User) => void;
    location: string;
    onChangedTab: () => void;
}

// CSS in JS
const navStyle = {
    backgroundColor:'rgba(0,63,122,1)',
    marginBottom:'50px'
}

export default Header
