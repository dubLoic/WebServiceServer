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
                        <img src={media?.poster_path} width="255" height="375" />
                    </div>

                    <div className="title">
                        <h4>{media?.title}</h4>
                    </div>

                    <div className="desc">
                        {media?.overview}
                    </div>

                    <div className="grade">
                        Note :
                    </div>
                </div>
            </Modal.Body>
            <Modal.Footer>
                <div className="foot">
                    <div className="like btn" onClick={() => handleLike(media?.id)}>
                        Add to Favorites ({nbLikes})
                        </div>
                    <select className="sugg">
                        <option value="none" selected>Suggest to :</option>
                    </select>
                    <select className="grade">
                        <option value="none" selected disabled>Note :</option>
                        <option value="0" >0</option>
                        <option value="1" >1</option>
                        <option value="2" >2</option>
                        <option value="3" >3</option>
                        <option value="4" >4</option>
                        <option value="5">5</option>
                    </select>
                </div>
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
