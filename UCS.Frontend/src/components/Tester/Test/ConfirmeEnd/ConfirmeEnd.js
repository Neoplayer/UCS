import React from "react";

const ConfirmeEnd = ({ IsReadyToCloseSession, ReadyFinishTest, AbortFinishTest }) => {
  return (
    <div className={`fullpage-sure-wrapper ${IsReadyToCloseSession ? "active" : ""}`}>
      <div className="sure-wrapper">
        <h1 className="sure-text">Завершить выполнение ?</h1>
        <div className="btn-sure-wrapper">
          <button onClick={ReadyFinishTest} className="yes">
            ДА
          </button>
          <button onClick={AbortFinishTest} className="no">
            НЕТ
          </button>
        </div>
      </div>
    </div>
  );
};

export default ConfirmeEnd;
