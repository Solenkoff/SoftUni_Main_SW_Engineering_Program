enum WeekDays {
    Monday = 1,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
};


function reversedWeekDay(dayString: string): void {
    console.log(WeekDays[dayString as keyof typeof WeekDays] || 'error');
}


reversedWeekDay('Monday');
reversedWeekDay('Friday');
reversedWeekDay('Invalid');