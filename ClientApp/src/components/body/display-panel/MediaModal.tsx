import React, { useState } from 'react'
import Media from './Media'
import Modal from "react-bootstrap/Modal";
import "bootstrap/dist/css/bootstrap.min.css";
import './style/media.css'


const MediaModal: React.FC<Props> = ({ media, show, handleClose }) => {
    const [nbLikes, setNbLikes] = useState<string>("0");

    const handleLike = async (id: number | undefined) => {
        if (id) {
            let url = "Likes/"

            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ idFilm: id })
            };
            const res = await fetch(url, requestOptions);
            const data = await res.json();
            setNbLikes(data);
        }
    }

    return (
        <Modal style={modalStyle} show={show} onHide={handleClose}>
            <Modal.Body>
                <div className="modal-grid">
                    <div className="photo">
                        <img src={media?.poster_path} width="170" height="250" />
                    </div>

                    <div className="title">
                        <h4>{media?.title}</h4>
                    </div>

                    <div className="desc">
                        {media?.overview}
                    </div>

                    <div className="like btn" onClick={() => handleLike(media?.id)}>
                        Like ({nbLikes})
                    </div>
                </div>
            </Modal.Body>

            <Modal.Footer>

            </Modal.Footer>
        </Modal>
    )
}

interface Props {
    media?: Media;
    show: boolean;
    handleClose: () => void;
    //favorite: (mediaID:number) => void;
}

// CSS in JS
const modalStyle = {
    backgroundColor: 'none',
}

export default MediaModal
