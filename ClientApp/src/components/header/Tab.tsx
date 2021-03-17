import React from 'react'
import {Link} from 'react-router-dom'
import NavItem from '../models/NavItem';
import './style/nav.css'

const Tab: React.FC<Props> = ({item, onClick}) => {
    const route = `/${item.name}`
    return (
        <Link   to={route}
                style={navTicketStyle} 
                className={item.active} 
                onClick={() => onClick(item.id)}
                >
                    {item.name}
        </Link>
    )
}

interface Props{
    item: NavItem;
    onClick: (id: number) => void
}

const navTicketStyle = {
    fontSize: '18px',
}

export default Tab
