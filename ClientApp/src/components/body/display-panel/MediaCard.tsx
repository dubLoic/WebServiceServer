import React, { useEffect } from 'react'
import { useState } from 'react';
import Media from './Media'
import './style/media.css'

const MediaCard: React.FC<Props> = ({ media }) => {
    return (
        <div className="card-container">

            <div className="card" title={media.title}>
                <img src={media.poster_path} width="170" height="250" />
                <div>{media.title}</div>
            </div>
        </div>
    )
}

interface Props{
    media: Media;
}

export default MediaCard
