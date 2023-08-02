import {FC, useState} from "react";
import "./App.css"
import Form from "./components/Form/Form";
import {Review} from "./types/review.ts";
import ReceivedFeedback from "./components/ReceivedFeedback/ReceivedFeedback";

const App: FC = () => {
    const [reviews, setReviews] = useState<Review[]>([]);

    const defaultCriteriaNames: string[] = [
        "Cleanliness",
        "Customer Service",
        "Speed",
        "Location",
        "Facilities"
    ]

    const handleNewReview = (rating: number, text: string) => {
        setReviews([
            ...reviews,
            {
                name: "You",
                photo: "src/assets/avatar.png",
                rating,
                text,
            }
        ]);
    };

    return (
        <>
            <Form
                rangeInputNames={defaultCriteriaNames}
                onHandle={handleNewReview}
            />

            <ReceivedFeedback
                reviews={reviews}
            />
        </>
    );
}

export default App;