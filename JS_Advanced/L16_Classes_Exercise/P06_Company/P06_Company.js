class Company {

    constructor() {
        this.departments = {};
    }

    addEmployee( name , salary, position, department ) {

        if (!name || !salary || !position || !department || salary < 0) {
            throw new Error('Invalid input!');
        }

        const currEmployee = {
            name,
            salary: Number(salary),
            position,
        }

        if(!this.departments[department]){
            this.departments[department] = {
                employees: []
            };
        }

        this.departments[department].employees.push(currEmployee);

        return `New employee is hired. Name: ${name}. Position: ${position}`;
    }

    bestDepartment(){

        for (const key in this.departments) {
           this.departments[key].avgSalary = this.departments[key].employees.reduce((acc, e) => acc + e.salary, 0) / this.departments[key].employees.length;
        }

        const bestDepartment = Array.from(Object.entries(this.departments).sort(([aKey, aValue],[bKey, bValue]) => bValue.avgSalary - aValue.avgSalary)[0]);
        const bestDepName = bestDepartment[0];
        const bestDepAvgSalary = bestDepartment[1].avgSalary.toFixed(2);
        const bestDepEmployees = bestDepartment[1].employees.sort((a,b) => b.salary - a.salary || a.name.localeCompare(b.name));

        let output = `Best Department is: ${bestDepName}\n`;
        output += `Average salary: ${bestDepAvgSalary}\n`;

        for (const employee of bestDepEmployees) {
            output += `${employee.name} ${employee.salary} ${employee.position}\n`;
        }

        return output.trimEnd();
    }

}


let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Construction");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());



