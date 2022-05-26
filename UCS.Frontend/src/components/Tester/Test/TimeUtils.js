export const StringToSec = (strTime) => {
  let time = strTime.split(":");

  let hour = time[0];
  let min = time[1];
  let sec = Math.floor(time[2]);

  let hourSec = time[0] * 60 * 60;
  let minSec = time[1] * 60;
  let totalSec = hourSec + minSec + sec;

  return { hour: hour, min: min, sec: sec, totalSec: totalSec };
};
export const toHHMMSS = (str) => {
    var sec_num = parseInt(str, 10); // don't forget the second param
    var hours   = Math.floor(sec_num / 3600);
    var minutes = Math.floor((sec_num - (hours * 3600)) / 60);
    var seconds = sec_num - (hours * 3600) - (minutes * 60);

    if (hours   < 10) {hours   = "0"+hours;}
    if (minutes < 10) {minutes = "0"+minutes;}
    if (seconds < 10) {seconds = "0"+seconds;}
    return hours+':'+minutes+':'+seconds;
}

export const SecForSolve = (startDateTime, timeLimit) => {
    let startTime = new Date(startDateTime);
    let timeLimits = new Date(timeLimit);
    let subTimeSec = (timeLimits - startTime) / 1000;
  
    return subTimeSec
};