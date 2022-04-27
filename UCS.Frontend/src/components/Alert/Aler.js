import iziToast from "izitoast";
import "izitoast/dist/css/iziToast.min.css";

export const onAlert = (text = "") => {
  iziToast.show({
    theme: "light",
    message: text,
    zindex: 100,
    position: "topRight",
    displayMode: "replace",
    closeOnClick: true,
  });
};
