import React, { useState } from 'react'
import Media from './Media'
import MediaCard from './MediaCard'

const MediaList: React.FC<Props> = ({ medias }) => {

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
            <div className="display-modal">
                {medias.map((item) => (
                    <MediaCard key={item.id} media={item} />
                ))}
            </div>

        </div>
    )
}

interface Props {
    medias: Media[];
}

export default MediaList
