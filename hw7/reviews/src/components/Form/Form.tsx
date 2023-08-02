import "./Form.css"
import RangeInput from "../RangeInput/RangeInput";
import React, {ChangeEvent, FC, useState} from "react";

type FormProps = {
    rangeInputNames: string[];
    onHandle: (rating: number, text: string) => void;
};

const Form:FC<FormProps> = ({ rangeInputNames, onHandle }) => {

    const emptyRangeInput: { [name: string] : number; } = {};
    rangeInputNames.forEach(name => {
        emptyRangeInput[name] = 1;
    });

    const [rangeInputRating, setRangeInputRating] = useState<{
        [name: string]: number;
    }>(emptyRangeInput);

    const handleRatingChange = (label: string, event: React.ChangeEvent<HTMLInputElement>) => {
        const newValue = parseInt(event.target.value);
        setRangeInputRating({
            ...rangeInputRating, [label]: newValue
        });
    };

    const [text, setText] = useState("");

    const handleTextChange = (event: ChangeEvent<HTMLTextAreaElement>) => {
        setText(event.target.value);
    };

    const clearForm = () => {
        setRangeInputRating(emptyRangeInput);
        setText("");
    };
    const handleForm = (event: React.MouseEvent<HTMLButtonElement>) =>
    {
        event.stopPropagation();
        onHandle(rating, text);
        clearForm();
    };

    let rating = 0;
    Object.keys(rangeInputRating).forEach(name => {
        rating += rangeInputRating[name];
    })
    rating /= 5;

    return (
        <div className="review">
            <span className="review__label">How nice was my reply?</span>
            <div className="review__rating">
                <div className="rating__criteria">
                    {Object.keys(rangeInputRating).map((name, index) => (
                        <RangeInput
                            key={index}
                            label={name}
                            value={rangeInputRating[name]}
                            onChange={handleRatingChange}
                        />
                    ))}
                </div>
                <div>
                    <span className="rating__score">{rating}/5</span>
                </div>
            </div>
            <div className="review__form">
                <textarea
                    name="reply-textarea"
                    className="textarea"
                    value={text}
                    placeholder="What could we improve?"
                    onChange={handleTextChange}
                />
                <button
                    name="reply-button"
                    className="button"
                    onClick={handleForm}
                >
                    Send
                </button>
            </div>
        </div>
    )
}

export default Form;