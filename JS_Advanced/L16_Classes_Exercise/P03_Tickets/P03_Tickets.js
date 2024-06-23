
function solve(ticketsInput, sortCriteria){

    class Ticket {
        destination;
        price;
        status;
    
        constructor(destination,price,status){
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }

    const tickets = [];

    for (const ticketData of ticketsInput) {
        const [destinationName, price, status] = ticketData.split('|');
        let ticket = new Ticket(destinationName, Number(price), status);
        tickets.push(ticket);
    }

    const sortingFunctions = {
        destination: (a,b) => a.destination.localeCompare(b.destination),
        price: (a,b) => a.price - b.price,
        status: (a,b) => a.status.localeCompare(b.status)
    }

    if(sortingFunctions[sortCriteria]){
        tickets.sort(sortingFunctions[sortCriteria]);
    }

    return tickets;
}

console.log(solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
));