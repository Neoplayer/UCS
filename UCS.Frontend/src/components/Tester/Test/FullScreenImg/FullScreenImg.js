import React from "react";
import { GetImageByGuid } from "../../../../api/api";
import "./FullScreenImg.scss";

const FullScreenImg = ({ FullImgData, setFullImgData }) => {

  if (!FullImgData) return null;

  return (
    <div className="FullScreenQuestion" onClick={() => setFullImgData(null)}>
      <p className="question-text">{FullImgData.question}</p>
      <img
        className="quest-img"
        src={GetImageByGuid(FullImgData.imgUrl)}
        alt="Картинка вопроса"
      />
      <div className="close" onClick={() => setFullImgData(null)}>
        X
      </div>
    </div>
  );
};

export default FullScreenImg;
