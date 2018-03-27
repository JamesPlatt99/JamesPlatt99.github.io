$(document).ready(function(){  
    var daysToBDay = document.getElementById('date');
    daysToBDay.textContent = 'Days to James\' birthday: ' + getTimeToBDay();
});

function getTimeToBDay(){
    var now = moment();
    var birthday = moment(now.year() + "0209");
    var timeSpan = birthday - now;
    timeSpan = timeSpan / (((3600) * 24) * 1000);
    if(timeSpan < 0){
        timeSpan += 365;
    }
    return (parseInt(timeSpan));
}