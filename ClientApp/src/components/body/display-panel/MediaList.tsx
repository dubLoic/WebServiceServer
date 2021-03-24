import React, { useState } from 'react'
import Media from './Media'
import MediaCard from './MediaCard'
import MediaModal from './MediaModal';

const MediaList: React.FC<Props> = ({ medias, message }) => {
    
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
            />
        </div>
    )
}

interface Props {
    medias: Media[];
    message: string;
}

export default MediaList
