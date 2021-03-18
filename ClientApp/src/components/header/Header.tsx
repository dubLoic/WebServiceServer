import Logo from "./Logo"
import Tabs from './Tabs'
import User from "./User"

const Header: React.FC<Props> = ({user, location, onChangedTab}) => {
    return (
        <nav style={navStyle} className="nav-extended">
            <div className="container nav-wrapper">
                <Logo />
                
                <User user={user} />

                <Tabs onChangedTab={onChangedTab} location={location} />
            </div>
        </nav>
    )
}

interface Props{
    user: string;
    location: string;
    onChangedTab: () => void;
}

// CSS in JS
const navStyle = {
    backgroundColor:'rgba(0,63,122,1)',
    marginBottom:'50px'
}

export default Header
