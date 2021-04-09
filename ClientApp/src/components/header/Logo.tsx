import logo from './img/poring.png'
import CSS from 'csstype';

const Logo: React.FC<Props> = ({ username }) => {
    return (
        <div className="brand-logo">
            <img style={logoStyle} src={logo} alt="" />
            Rate'n Chill - {username}
        </div>
    )
}

const logoStyle: CSS.Properties = {
    width:'40px',
    marginRight: '15px',
    position:'relative',
    top: '8px',
}

interface Props {
    username: string;
}

export default Logo
