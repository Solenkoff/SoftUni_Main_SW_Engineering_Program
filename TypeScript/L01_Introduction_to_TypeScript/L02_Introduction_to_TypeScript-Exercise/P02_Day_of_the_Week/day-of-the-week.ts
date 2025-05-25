function dayOfTheWeekByNumber(dayAsNumber: number): void {

    enum WeekDays {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    };

    console.log(WeekDays[dayAsNumber] || 'error');


}

dayOfTheWeekByNumber(1);
dayOfTheWeekByNumber(4);
dayOfTheWeekByNumber(8);
dayOfTheWeekByNumber(-1);
