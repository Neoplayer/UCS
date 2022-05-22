import React from "react";
import "./Progress.scss";
import ValueToClass from "./ValueToClass";

const Progress = ({ ProgressValue }) => {
  let bg = ValueToClass(ProgressValue)
  return (
    <div className={`progress-wrapper ${bg}`}>
      <progress className="progress" value={ProgressValue} max="100"></progress>
    </div>
  );
};

export default Progress;
