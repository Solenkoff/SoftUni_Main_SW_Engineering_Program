class BookClub {

    books = [];
    members = [];
    library;

    constructor(library) {
        this.library = library;
    }


    addBook(title, author) {
        const book = this.books.find(b => b.title == title && b.author == author);
        if (book) {
            return `The book "${title}" by ${author} is already in ${this.library} library.`;
        }

        const newBook = {
            title,
            author
        }

        this.books.push(newBook);

        return `The book "${title}" by ${author} has been added to ${this.library} library.`
    }

    addMember(memberName) {
        const member = this.members.find(m => m == memberName);

        if(member){
            return `Member ${memberName} is already a part of the book club.`;
        }

        this.members.push(memberName);

        return `Member ${memberName} has been joined to the book club.`;
    }

    assignBookToMember(memberName, bookTitle) {
        const member = this.members.find(m => m == memberName);
        if(!member){
            throw new Error(`Member ${memberName} not found.`);
        }

        const book = this.books.find(b => b.title == bookTitle);
        if(!book){
            throw new Error(`Book "${bookTitle}" not found.`);
        }

        this.books = this.books.filter(b => b.title != bookTitle);

        // const bookIndex = this.books.findIndex(b => b.title == bookTitle);
        // if(bookIndex === -1){
        //     throw new Error(`Book "${bookTitle}" not found.`);
        // }

        // this.books.splice(bookIndex, 1);

        return `Member ${memberName} has been assigned the book "${bookTitle}" by ${book.author}.`;
    }

    generateReadingReport() {

        if (this.members.length == 0){
            return `No members in the book club.`;
        }
        if(this.books.length == 0){
            return  `No available books in the library.`;
        }

        let result = `Available Books in ${this.library} library:\n`;

        for (const book of this.books) {
            result += `"${book.title}" by ${book.author}\n`;
        }

       return result.trim();
    }
}

//  1
// const myBookClub = new BookClub('The Bookaholics');
// console.log(myBookClub.addBook("The Great Gatsby", "F. Scott Fitzgerald"));
// console.log(myBookClub.addBook("To Kill a Mockingbird", "Harper Lee"));
// console.log(myBookClub.addBook("1984", "George Orwell"));
// console.log(myBookClub.addMember("Alice"));
// console.log(myBookClub.addMember("Peter"));
// console.log(myBookClub.assignBookToMember("Mary", "The Great Gatsby"));

//  2
const myBookClub = new BookClub('The Bookaholics');
console.log(myBookClub.addBook("The Great Gatsby", "F. Scott Fitzgerald"));
console.log(myBookClub.addBook("To Kill a Mockingbird", "Harper Lee"));
console.log(myBookClub.addBook("1984", "George Orwell"));
console.log(myBookClub.addMember("Alice"));
console.log(myBookClub.addMember("Alice"));
console.log(myBookClub.assignBookToMember("Alice", "The Great Gatsby"));
console.log(myBookClub.generateReadingReport());
