function colorize() {
    // Ist Solution with CSS selector
    // let elementsToCororize = document.querySelectorAll('tr:nth-of-type(2n) td');

    // elementsToCororize.forEach(x => {
    //     x.style.backgroundColor = 'teal';
    // });

    let elementsToCororize = document.getElementsByTagName('tr');

    let rows = Array.from(elementsToCororize);

    rows.forEach((x, i) => {
        if(i % 2 != 0){
            x.style.backgroundColor = 'teal';
        }
    });

}