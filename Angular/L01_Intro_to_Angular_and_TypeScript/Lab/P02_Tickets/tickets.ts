
class Ticket {

    constructor(
        public destination: string,
        public price: number,
        public status: string) { }

}

function ticketManager(ticketsInput: string[], sortingCriteria: string): Ticket[] {

    const tickets = ticketsInput.map(line => {
        // const [destination, price, status] = line.split('|').forEach(arg => arg.substring(1, arg.length - 2));
        let [destination, price, status] = line.split('|');

        return new Ticket(destination, Number(price), status);
    })

    return tickets.sort((a, b) => {
        const aValue = a[sortingCriteria];
        const bValue = b[sortingCriteria];

        if (typeof aValue === 'number' && typeof bValue === 'number') {
            return aValue - bValue;
        }

        return aValue.toString().localeCompare(bValue.toString());
    })
}


const input = [
    'Philadelphia|94.20|available',
 'New York City|95.99|available',
 'New York City|95.99|sold',
 'Boston|126.20|departed'

];

const sortingCriteria = 'status';

const result = ticketManager(input, sortingCriteria);
console.log(result);
