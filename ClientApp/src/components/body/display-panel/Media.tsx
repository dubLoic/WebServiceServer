export default Media

interface Media {
    genre_ids: number[];
    id: number;
    media_type: string;
    title: string;
    overview: string;
    original_title: string;
    poster_path: string;
    nb_suggested: number;
    nb_favorite: number;
    isFavorite: boolean;
}

