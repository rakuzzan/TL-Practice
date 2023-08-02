import "./RangeInput.css"
import {ChangeEvent, CSSProperties, FC} from "react";

const sliderProgressStyle = (lineWidth: number): CSSProperties => ({
    position: `absolute`,
    width: lineWidth.toString() + `px`,
    height: `6px`,
    backgroundColor: `#1E64B7`,
    borderRadius: `5px`,
    transition: `width 0.25s ease-in-out`
});

type RangeInputProps = {
    label: string;
    value: number;
    onChange: (label: string, event: ChangeEvent<HTMLInputElement>) => void;
};

const RangeInput:FC<RangeInputProps> = ({ label, value, onChange }) => {
    const maxValue = 50;

    return (
        <div className="range-input">
        <div style={ sliderProgressStyle(maxValue * (value-1)) } />
    <div className="range-input-points">
        {Array.from(Array(5), (_, i) => {
                return <div key={i} className={value-1 >= i ? "range-input-point active" : "range-input-point"} />
            })}
        </div>
        <input
    type="range"
    min="1"
    value={value}
    max="5"
    step="1"
    name={label}
    className="range-input-slider"
    onChange={(e) => onChange(label, e)}
    />
    <span className="range-input-name">{label}</span>
    </div>
)
}

export default RangeInput;