function previousDay(year, month, day) {
    
    let dateAsString = year + '-' + month + '-' + day;
    let dateIn = new Date(dateAsString);
    let dateOut = new Date(dateIn.setDate(day - 1));

    let yearOut = dateOut.getFullYear();
    let monthOut = Number(dateOut.getMonth()) + 1;
    let dayOut = dateOut.getDate();

    console.log(`${yearOut}-${monthOut}-${dayOut}`);

    //console.log(dateOut.getFullYear() + '-' + (Number(dateOut.getMonth()) + 1) + '-' + dateOut.getDate());
}

previousDay(2016, 1, 1);