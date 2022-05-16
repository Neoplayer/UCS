import iziToast from "izitoast";
import "izitoast/dist/css/iziToast.min.css";

const Error = (text) => {
  iziToast.error({
    message: text,
    messageSize: '16',
    backgroundColor: 'rgb(255, 103, 103)',
    position: "topRight",
    displayMode: "replace",
    closeOnClick: true,
    timeout: 7000,
  });
};

const Show = (text) => {
  iziToast.show({
    theme: "dark",
    message: text,
    position: "topRight",
    displayMode: "replace",
    closeOnClick: true,
    timeout: 5000,
  });
};


export const onAlert = (text = "", status = "show") => {
  if (status === "show") Show(text);
  else if (status === "error") Error(text);
};
