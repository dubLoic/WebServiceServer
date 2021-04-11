import React, { useEffect, useRef, useState } from 'react'
import Media from './Interfaces/Media'
import Modal from "react-bootstrap/Modal";
import "bootstrap/dist/css/bootstrap.min.css";
import './style/media.css'
import Data from '../../models/Data';
import User from '../../models/User';
import ResponseMessage from './Interfaces/ResponseMessage';


const MediaModal: React.FC<Props> = ({ media, show, handleClose, userID, username, users }) => {
    const [message, setMessage] = useState<string>('');
    const [nbLikes, setNbLikes] = useState<number>(0);
    const [nbSugg, setNbSugg] = useState<number>(0);
    const [selectedValue, setSelectedValue] = useState<string>('');

    const fetchNbLikes = async (id: number | undefined, type: number | undefined) => {
        console.log(id + '-' + type);
        if (id && type) {
            let url = "Like/" + id + "/" + type

            const res = await fetch(url);
            const data: ResponseMessage = await res.json();

            setNbLikes(data.count);
        }
    }
    const fetchNbSuggs = async (id: number | undefined, type: number | undefined) => {

        if (id && type) {
            let url = "Suggestion/suggs?id=" + id + "&type=" + type + "&suggestedTo=" + userID

            const res = await fetch(url);
            const data: ResponseMessage = await res.json();

            setNbSugg(data.count);
        }
    }

    useEffect(() => {
        fetchNbLikes(media?.id, media?.media_type)
        fetchNbSuggs(media?.id, media?.media_type)
        setMessage('')
    }, [media, userID])


    const handleLike = async (id: number | undefined, type: number | undefined) => {
        if (id && type && userID != Data.GUEST_ID) {

            let obj = { IdMedia: { idMedia: id, mediaType: type }, LikedBy: username }
            let url = "Like/"
            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(obj)
            };
            const res = await fetch(url, requestOptions);

            const data: ResponseMessage = await res.json();

            setNbLikes(data.count);
            setMessage(data.msg);
        }
    }
    const handleSuggestion = async (id: number | undefined, type: number | undefined, suggestedTo: string | undefined) => {
        if (id && type && userID != Data.GUEST_ID) {
            let obj = { IdMedia: { idMedia: id, mediaType: type }, SuggestedTo: suggestedTo, SuggestedBy: username }
            let url = "Suggestion/"

            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(obj)
            };
            const res = await fetch(url, requestOptions);
            const data: ResponseMessage = await res.json();
            setMessage(data.msg);
            setSelectedValue('');
        }
    }

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
                            Favorite : {nbLikes} time(s)
                        </div>
                        <div className="nb_sugg">
                            Suggested for you by {nbSugg} user(s)
                        </div>
                    </div>
                </div>
            </Modal.Body>
            <Modal.Footer>
                <div className="foot">
                    <div className="like btn" onClick={() => handleLike(media?.id, media?.media_type)}>
                        Add / Remove from favorites
                    </div>

                    <select className="sugg" ref={inputRef} onChange={() => handleSuggestion(media?.id, media?.media_type, inputRef.current?.value)}>
                        {selectedValue === '' ?
                            <option value="0" selected disabled>Suggest to :</option>
                            :
                            <option value="0" disabled>Suggest to :</option>
                        }

                        {
                            users.filter(user => user.id != userID).map((item) => (
                                <option key={item.id} value={item.id}> {item.username}</option>
                            ))}
                    </select>
                    <div className="msg">
                        {message}
                    </div>
                </div>
                
            </Modal.Footer>
        </Modal>
    )
}

interface Props {
    media?: Media;
    users: User[];
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
