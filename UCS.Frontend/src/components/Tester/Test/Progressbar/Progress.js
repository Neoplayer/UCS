import React, { useMemo } from "react";
import { SecForSolve, StringToSec, toHHMMSS } from "../TimeUtils";
import "./Progress.scss";
import ValueToClass from "./ValueToClass";

const Progress = ({ ProgressValue, Time }) => {
  const Max = useMemo(() => SecForSolve(Time.startDateTime, Time.timeLimit), [Time]);
  const MaxStr = useMemo(() => toHHMMSS(Max), [Time]);

  const TimeNow = useMemo(() => toHHMMSS(ProgressValue), [ProgressValue]);

  let bg = ValueToClass(ProgressValue, Max);

  return (
    <div className={`progress-wrapper ${bg}`}>
      <progress className="progress" value={ProgressValue} max={Max}></progress>
      <div className="time-wrapper">
        <span>{MaxStr}</span>
        {"/"}
        <span>{TimeNow}</span>
      </div>
    </div>
  );
};

export default Progress;
