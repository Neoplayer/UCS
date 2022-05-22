import React, { useRef } from "react";
import find from "./find.svg";
import "./CheckStudents.scss";
const FindByName = ({ onFilter }) => {
  const reff = useRef(null);

  const StartSearch = () => {
    if (reff?.current) {
      let value = reff.current.value;
      onFilter(value);
    }
  };

  return (
    <div className="find-wrapper">
      <div className="find">
        <input
          ref={reff}
          onKeyUp={(e) => {
            if (e.key === "Enter") StartSearch();
          }}
          placeholder="Поиск"
          type="text"
        />
        <img onClick={StartSearch} src={find} alt="Поиск" />
      </div>
    </div>
  );
};

export default FindByName;
