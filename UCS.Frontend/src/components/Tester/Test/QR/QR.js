import React from "react";
import "./QR.scss";
import { QRCodeSVG } from "qrcode.react";

const QR = ({ isQRVisible, setIsQRVisible }) => {
  const token = localStorage.getItem("token");
  return (
    <div
      onClick={() => setIsQRVisible(false)}
      className={`QR ${isQRVisible ? "QR-active" : ""}`}
    >
      <QRCodeSVG
        value={`http://194.58.107.109/mobile?token=${token}`}
        size={512}
        bgColor={"#ffffff"}
        fgColor={"#000000"}
        level={"L"}
        includeMargin={false}
        imageSettings={{
          src: `${process.env.PUBLIC_URL}/qr_logo.jpg`,
          x: null,
          y: null,
          height: 64,
          width: 64,
          excavate: true,
        }}
      />

      <p className="close" onClick={() => setIsQRVisible(false)}>
        X
      </p>
    </div>
  );
};

export default QR;
