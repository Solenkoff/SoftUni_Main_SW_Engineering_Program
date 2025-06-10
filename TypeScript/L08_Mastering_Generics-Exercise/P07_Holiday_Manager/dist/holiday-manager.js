"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var TravelVacation;
(function (TravelVacation) {
    TravelVacation["Abroad"] = "Abroad";
    TravelVacation["InCountry"] = "InCountry";
})(TravelVacation || (TravelVacation = {}));
var MountainVacation;
(function (MountainVacation) {
    MountainVacation["Ski"] = "Ski";
    MountainVacation["Hiking"] = "Hiking";
})(MountainVacation || (MountainVacation = {}));
var BeachVacation;
(function (BeachVacation) {
    BeachVacation["Pool"] = "Pool";
    BeachVacation["Sea"] = "Sea";
    BeachVacation["ScubaDiving"] = "ScubaDiving";
})(BeachVacation || (BeachVacation = {}));
class PlannedHoliday {
    _start;
    _end;
    constructor(startDate, endDate) {
        this.start = startDate;
        this.end = endDate;
    }
    set start(val) {
        if (this._end < val) {
            throw new Error('End date cannot be before start date');
        }
        this._start = val;
    }
    set end(val) {
        if (this._start > val) {
            throw new Error('End date cannot be before start date');
        }
        this._end = val;
    }
    getInfo() {
        return `Holiday: ${this._start.getDate()}/${this._start.getMonth() + 1}/${this._start.getFullYear()} - ${this._end.getDate()}/${this._end.getMonth() + 1}/${this._end.getFullYear()}`;
    }
}
class HolidayManager {
    reservations = new Map();
    reserveVacation(holiday, vacationType) {
        this.reservations.set(holiday, vacationType);
    }
    listReservations() {
        let reservationsInfo = [];
        Array.from(this.reservations.entries())
            .forEach(r => reservationsInfo.push(`${r[0].getInfo()} => ${r[1]}`));
        return reservationsInfo.join('\n');
    }
}
// let holiday = new PlannedHoliday(new Date(2024, 1, 1), new Date(2024, 1, 4));
// let holiday2 = new PlannedHoliday(new Date(2025, 3, 14), new Date(2025, 3, 17));
// let holidayManager = new HolidayManager<Holiday, TravelVacation>();
// holidayManager.reserveVacation(holiday, TravelVacation.Abroad);
// holidayManager.reserveVacation(holiday2, TravelVacation.InCountry);
// console.log(holidayManager.listReservations());
// let holiday = new PlannedHoliday(new Date(2022, 10, 11), new Date(2022, 10, 18));
// let holiday2 = new PlannedHoliday(new Date(2024, 5, 18), new Date(2024, 5, 22));
// let holidayManager = new HolidayManager<Holiday, BeachVacation>();
// holidayManager.reserveVacation(holiday, BeachVacation.ScubaDiving);
// holidayManager.reserveVacation(holiday2, BeachVacation.Sea);
// console.log(holidayManager.listReservations())
//let holiday3 = new PlannedHoliday(new Date(2021, 3, 14), new Date(2020, 3, 17));         //Runtime error: End date cannot be before start date
//let holiday4 = new PlannedHoliday(new Date(2024, 2, 1), new Date(2024, 1, 4));           //Runtime error: End date cannot be before start date
let holiday = new PlannedHoliday(new Date(2024, 1, 1), new Date(2024, 1, 4));
let holiday2 = new PlannedHoliday(new Date(2025, 3, 14), new Date(2024, 3, 17));
let holidayManager = new HolidayManager();
holidayManager.reserveVacation(holiday, BeachVacation.ScubaDiving);
holidayManager.reserveVacation(holiday2, TravelVacation.InCountry);
console.log(holidayManager.listReservations());
//# sourceMappingURL=holiday-manager.js.map