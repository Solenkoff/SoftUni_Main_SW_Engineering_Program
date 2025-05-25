"use strict";
function dayOfTheWeekByNumber(dayAsNumber) {
    let WeekDays;
    (function (WeekDays) {
        WeekDays[WeekDays["Monday"] = 1] = "Monday";
        WeekDays[WeekDays["Tuesday"] = 2] = "Tuesday";
        WeekDays[WeekDays["Wednesday"] = 3] = "Wednesday";
        WeekDays[WeekDays["Thursday"] = 4] = "Thursday";
        WeekDays[WeekDays["Friday"] = 5] = "Friday";
        WeekDays[WeekDays["Saturday"] = 6] = "Saturday";
        WeekDays[WeekDays["Sunday"] = 7] = "Sunday";
    })(WeekDays || (WeekDays = {}));
    ;
    console.log(WeekDays[dayAsNumber] || 'error');
}
dayOfTheWeekByNumber(1);
dayOfTheWeekByNumber(4);
dayOfTheWeekByNumber(8);
dayOfTheWeekByNumber(-1);
//# sourceMappingURL=day-of-the-week.js.map