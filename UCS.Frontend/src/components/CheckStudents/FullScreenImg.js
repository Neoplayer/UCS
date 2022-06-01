import React from "react";
import { GetImageByGuid } from "../../api/api";
import "./CheckStudents.scss";
import InnerImageZoom from "react-inner-image-zoom";
import "react-inner-image-zoom/lib/InnerImageZoom/styles.css";

const FullScreenImg = ({ ImageGuid, setImageGuid }) => {
  if (!ImageGuid) return null;

  return (
    <div className="FullScreenImg" onClick={() => setImageGuid(null)}>
      <div className="img-zoom-wraper"  onClick={(e) => e.stopPropagation()}>
        <InnerImageZoom
          src={GetImageByGuid(ImageGuid)}
          zoomPreload={true}
          zoomScale={1.2}
          className="img"
          hideHint={true}
        />
      </div>
      <p onClick={() => setImageGuid(null)} className="close">
        🗙
      </p>
    </div>
  );
};

export default FullScreenImg;
