const ValueToClass = (ProgressValue, Max) => {
  let half2 = Max / 2;
  let half4 = Max - Max / 4;
  let half10 = Max - Max / 10;

  if (ProgressValue >= half2 && ProgressValue < half4) return "bg-yellow";
  if (ProgressValue >= half4 && ProgressValue < half10) return "bg-light-red";
  if (ProgressValue >= half10 && ProgressValue < Max) return "bg-red";
  if (ProgressValue >= Max) return "bg-end";

  return null;
};

export default ValueToClass;
