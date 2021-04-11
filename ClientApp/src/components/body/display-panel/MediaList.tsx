import React, { useState } from 'react'
import User from '../../models/User';
import Media from './Interfaces/Media'
import MediaCard from './MediaCard'
import MediaModal from './MediaModal';

const MediaList: React.FC<Props> = ({ medias, message, userID, username, users }) => {
    
    const [mediaToDisplay, setMediaToDisplay] = useState<Media | undefined>(undefined);

    const [show, setShow] = useState(false);
    const handleClose = () => setShow(false);
    const handleShow = (mediaToDisplay: Media) =>{
        setShow(true);
        setMediaToDisplay(mediaToDisplay);
    } 

    return (
        <div className="container">
            <br />
            {message}
            <br />
            <div className="display-grid">
                {medias.map((item) => (
                    <MediaCard key={item.id} media={item} handleShow={handleShow} />
                ))}
            </div>

            <MediaModal show={show}
                handleClose={handleClose}
                media={mediaToDisplay}
                userID={userID}
                username={username}
                users={users}
            />
        </div>
    )
}

interface Props {
    medias: Media[];
    users: User[];
    message: string;
    userID: string;
    username: string;
}

export default MediaList
