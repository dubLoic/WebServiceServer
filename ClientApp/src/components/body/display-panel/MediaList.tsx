import React, { useState } from 'react'
import Media from './Media'
import MediaCard from './MediaCard'
import MediaModal from './MediaModal';

const MediaList: React.FC<Props> = ({ medias }) => {
    
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
            {medias?.length > 0
                ?
                <h4>Results</h4>

                :
                <h5>No results</h5>
            }
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
}

export default MediaList
