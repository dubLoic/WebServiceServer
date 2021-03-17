import NavTicket from "./Tab"
import {useState} from 'react'
import NavItem from "../models/NavItem";
import Data from '../models/Data'


const Tabs: React.FC<Props> = ({location}) => {
    const [navItems, setNavItems] = useState<NavItem[]>([
        { id: 1, name:Data.NAME_SEARCH_MOVIES, active: location === Data.PATH_SEARCH_MOVIES ? 'active' : ''},
        { id: 2, name:Data.NAME_SEARCH_TV, active: location === Data.PATH_SEARCH_TV ? 'active' : ''},
        { id: 3, name:Data.NAME_FAVORITES, active: location === Data.PATH_FAVORITES ? 'active' : ''},
        { id: 4, name:Data.NAME_SUGGESTIONS, active: location === Data.PATH_SUGGESTIONS ? 'active' : ''},
    ]);

    const onClick = (id: number) => {
        setNavItems(navItems.map((item) => item.id === id
      ?
        {...item, active: 'active'}
      :
        {...item, active: ''}
      )
    )
    }

    return (
        <div className="nav-content">
            <ul className="tabs tabs-transparent">
                {navItems.map((item) => (
                    <li key={item.id} className="tab">
                        <NavTicket  item={item} 
                                    
                                    onClick={onClick}
                        />
                    </li>
                ))}
            </ul>
        </div>
    )
}

interface Props {
    location: string;
}

export default Tabs
