function previousDay(year, month, day) {

    let dateIn = new Date(year, month - 1, day);
    let dateOut = new Date(dateIn.setDate(dateIn.getDate() - 1));

    let yearOut = dateOut.getFullYear();
    let monthOut = dateOut.getMonth() + 1;
    let dayOut = dateOut.getDate();

    console.log(`${yearOut}-${monthOut}-${dayOut}`);

}

previousDay(2016, 9, 30);
previousDay(2016, 10, 1);