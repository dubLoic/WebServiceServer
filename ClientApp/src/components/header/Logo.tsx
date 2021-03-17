import logo from './img/poring.png'
import CSS from 'csstype';

const Logo: React.FC = () => {
    return (
        <div className="brand-logo">
            <img style={logoStyle} src={logo} alt="" />
            Rate'n Chill
        </div>
    )
}

const logoStyle: CSS.Properties = {
    width:'40px',
    marginRight: '15px',
    position:'relative',
    top: '8px',
}

export default Logo
