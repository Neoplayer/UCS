import React, { useState } from "react";
import { motion } from "framer-motion";
import { Link } from "react-router-dom";
const SubjectsMap = ({ Subjects }) => {
  const [ActiveSubjectsID, setActiveSubjectsID] = useState([]);

  const onActiveSubjectsID = (idx) => {
    if (ActiveSubjectsID.length === 0) setActiveSubjectsID([idx]);
    else {
      const id = ActiveSubjectsID.findIndex((value) => value === idx);
      if (id === -1) setActiveSubjectsID((oldArray) => [...oldArray, idx]);
      else {
        let copy = ActiveSubjectsID.slice();
        copy.splice(id, 1);
        setActiveSubjectsID(copy);
      }
    }
  };

  return Subjects.map((subject, i) => {
    const ChaptersMap = subject.Chapters.map((chapt, i) => {
      const TopicsMap = chapt.Topics.map((top, i) => {
        return (
          <Link to={"/testerConfirm/" + top.Id} key={i} className="topic">
            <h4>{top.Name}</h4>
            <span className="timer">{top.TimeLimit}</span>
          </Link>
        );
      });

      return (
        <div key={i} className="chapter">
          <h3 className="chapter-name">{chapt.Name}</h3>
          <div className="topics">{TopicsMap}</div>
        </div>
      );
    });

    return (
      <div key={i} className="subject-wrapper">
        <div
          className="subject"
          onClick={() => {
            onActiveSubjectsID(i);
          }}
        >
          <h2 className="subject-name">{subject.Name}</h2>
          <p className="subject-description">{subject.Description}</p>
        </div>
        {ActiveSubjectsID.includes(i) && ChaptersMap}
      </div>
    );
  });
};

export default SubjectsMap;
