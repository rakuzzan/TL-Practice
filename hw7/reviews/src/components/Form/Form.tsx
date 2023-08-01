import {useCallback, useState} from 'react';
import Feedback from "../Feedback/Feedback";
import StarRating from "../StarRating/StarRating";



const Form = () => {


    const [text, setText] = useState<string>('');
    const [lastFeedback, setLastFeedback] = useState<string>('');



    const handleText = useCallback((e) => {
        setText(e.target.value);
    }, []);

    const handleSubmit = () => {
        setLastFeedback(`${text} - ${rating} stars`);
        setText('');
    }

    return (
        <div className="star-form">
            <h1>How nice was my reply?</h1>
            <StarRating rating={rating} onRatingChange={handleRating} />
            <textarea
                className="feedback-text"
                placeholder="Enter your feedback here..."
                value={text}
                onChange={handleText}
            />
            <button className="submit-button" onClick={handleSubmit}>Send</button>
            <Feedback feedback={lastFeedback} />
        </div>
    );
};

export default Form;