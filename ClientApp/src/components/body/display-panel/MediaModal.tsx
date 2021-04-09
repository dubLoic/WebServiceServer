import React, { useEffect, useRef, useState } from 'react'
import Media from './Media'
import Modal from "react-bootstrap/Modal";
import "bootstrap/dist/css/bootstrap.min.css";
import './style/media.css'
import { type } from 'os';
import User from '../../models/User';


const MediaModal: React.FC<Props> = ({ media, show, handleClose, userID, username }) => {
    const [nbLikes, setNbLikes] = useState<number>(0);
    const [nbSugg, setNbSugg] = useState<number>(0);

    const handleLike = async (id: number | undefined, type: string | undefined) => {
        if (id) {
            let url = "Likes/"

            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ IdMedia: { idMedia: id, mediaType: type }, userId:userID })
            };
            const res = await fetch(url, requestOptions);
            const data = await res.json();
            setNbLikes(data);
        }
    }
    const handleSuggestion = async (id: number | undefined, type: string | undefined, target: string | undefined) => {
        if (id) {
            let url = "Suggestions/"

            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify({ IdMedia: { idMedia: id, mediaType: type }, targetUserID: target, suggestedBy: username })
            };
            const res = await fetch(url, requestOptions);
            const data = await res.json();
            setNbSugg(data);
        }
    }

    useEffect(() => {
        if (media) {
            setNbLikes(media.nb_favorite)
            setNbSugg(media.nb_suggested)
        }
    }, [])

    const inputRef = useRef<HTMLSelectElement>(null);

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

                    <div className="stats">
                        <div className="nb_like">
                            Favorite : {nbLikes} times
                        </div>
                        <div className="nb_sugg">
                            Suggested : {nbSugg} times
                        </div>
                    </div>
                </div>
            </Modal.Body>
            <Modal.Footer>
                <div className="foot">
                    <div className="like btn" onClick={() => handleLike(media?.id, media?.media_type)}>
                        {
                            media?.isFavorite ?
                                <span>Remove from Favorites</span>
                            :
                                <span>Add to Favorites</span>
                        }
                    </div>
                    <select className="sugg" ref={inputRef} onChange={() => handleSuggestion(media?.id, media?.media_type, inputRef.current?.value)}>
                        <option value="0" selected disabled>Suggest to :</option>
                    </select>
                    <select className="grade">
                        <option value="none" selected disabled>Note :</option>
                        <option value="0" >0</option>
                        <option value="1" >1</option>
                        <option value="2" >2</option>
                        <option value="3" >3</option>
                        <option value="4" >4</option>
                        <option value="5" >5</option>
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
    userID: string;
    username: string;
}

// CSS in JS
const modalStyle = {
    backgroundColor: 'none',
}

export default MediaModal
