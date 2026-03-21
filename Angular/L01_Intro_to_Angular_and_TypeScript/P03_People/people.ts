abstract class Employee {
    public name: string;
    public age: number;
    public salary: number;
    protected tasks: string[];
    private currentTaskIndex: number;

    constructor(name: string, age: number) {
        this.name = name;
        this.age = age;
        this.salary = 0;
        this.tasks = [];
        this.currentTaskIndex = 0;
    }

    public work(): void {
        console.log(`${this.name}${this.tasks[this.currentTaskIndex]}`);
        this.currentTaskIndex++;

        if (this.currentTaskIndex >= this.tasks.length) {
            this.currentTaskIndex = 0;
        }
    }

    public collectSalary(): void {
        console.log(`${this.name} received ${this.getSalary()} this month.`);
    }

    protected getSalary(): number {
        return this.salary;
    }
}

class Junior extends Employee {
    constructor(name: string, age: number) {
        super(name, age);

        this.tasks.push(' is working on a simple task.');
    }
}

class Senior extends Employee {
    constructor(name: string, age: number) {
        super(name, age);

        this.tasks.push(' is working on a complicated task.');
        this.tasks.push(' is taking time off work.');
        this.tasks.push(' is supervising junior workers.');
    }
}

class Manager extends Employee {
    public dividend: number;

    constructor(name: string, age: number) {
        super(name, age);

        this.dividend = 0;

        this.tasks.push(' scheduled a meeting.');
        this.tasks.push(' is preparing a quarterly report.');
    }

    protected getSalary(): number {
        return this.salary + this.dividend;
    }
}

let empOne = new Manager(
    'Pesho',
    34,
);


empOne.work();
empOne.work();
empOne.work();

empOne.collectSalary();

empOne.salary = 1234;
empOne.collectSalary();

empOne.dividend = 300;
empOne.collectSalary();
