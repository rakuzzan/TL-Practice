import "./Feedback.css"
import {FC} from "react";

export type FeedbackProps = {
    name: string;
    photo: string;
    rating: number;
    text: string;
};

const Feedback:FC<FeedbackProps> = ({ name, photo, rating, text }) => {
    return (
        <div className="feedback">
            <img src={photo} alt="Avatar" className="feedback__avatar" />
            <div className="feedback__text-block">
                <span className="text-block__author">{name}</span>
                <p className="text-block__feedback">{text}</p>
            </div>
            <span className="feedback__rating">{rating}/5</span>
        </div>
    )
}

export default Feedback;