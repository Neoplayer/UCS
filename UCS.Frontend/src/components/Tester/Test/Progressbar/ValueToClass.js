

const ValueToClass = (ProgressValue) => {
  if (ProgressValue >= 50 && ProgressValue < 75) return "bg-yellow";
  if (ProgressValue >= 75 && ProgressValue < 90) return "bg-light-red";
  if (ProgressValue >= 90 && ProgressValue < 100 ) return "bg-red";
  if (ProgressValue >= 100) return "bg-end";
  return null
};

export default ValueToClass;
 
