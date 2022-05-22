import React from "react";
import { GetImageByGuid } from "../../api/api";
import "./CheckStudents.scss";
const FullScreenImg = ({ ImageGuid, setImageGuid }) => {
  if (!ImageGuid) return null;

  return (
    <div className="FullScreenImg" onClick={() => setImageGuid(null)}>
      <img
        onClick={(e) => e.stopPropagation()}
        className="img"
        src={GetImageByGuid(ImageGuid)}
        alt="Изображение"
      />
      <p onClick={() => setImageGuid(null)} className="close">
        🗙
      </p>
    </div>
  );
};

export default FullScreenImg;
