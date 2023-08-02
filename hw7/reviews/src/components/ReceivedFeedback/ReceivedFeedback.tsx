import Feedback from "../Feedback/Feedback";
import {Review} from "../../types/review.ts";
import {FC} from "react";
import "./ReceivedFeedback.css"

type ReceivedFeedbackProps = {
    reviews: Review[];
}

const ReceivedFeedback:FC<ReceivedFeedbackProps> = ({reviews}) => {
    return (
        <div className="feedback-block">
            <div className="feedback-wrapper">
                {reviews.map((review, index) => (
                    <Feedback
                        key={index}
                        name={review.name}
                        photo={review.photo}
                        rating={review.rating}
                        text={review.text}
                    />
                ))}
            </div>
        </div>
    );
};

export default ReceivedFeedback;