import React from "react";
import "./QR.scss";
import { QRCodeSVG } from "qrcode.react";

const QR = ({ isQRVisible, setIsQRVisible }) => {
  return (
    <div
      onClick={() => setIsQRVisible(false)}
      className={`QR ${isQRVisible ? "QR-active" : ""}`}
    >
      <QRCodeSVG
        value={
          "http://192.168.0.100:3000/mobile?token=eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJuYmYiOjE2NTM4NDU0NDcsImV4cCI6MTY1NDQ1MDI0NywiaWF0IjoxNjUzODQ1NDQ3fQ.Jdr4zUcT6Wf0WMlmaMg7ixdZ29ozy-zWxEJWDgNcbjg"
        }
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
