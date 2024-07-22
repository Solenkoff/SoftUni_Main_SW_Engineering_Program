function solve() {
    getStudents();
    document.getElementById('submit').addEventListener('click', createStudent);
}

solve();

async function getStudents() {

    const url = 'http://localhost:3030/jsonstore/collections/students';
    const tbodyEl = document.querySelector('tbody');
    tbodyEl.replaceChildren();

    try {
        const response = await fetch(url);
        const data = await response.json();

        Object.values(data).map(s => renderStudent(s)).forEach(s => tbodyEl.appendChild(s));
    } catch (error) {
        alert(error.message);
    }
}

function renderStudent({ facultyNumber, firstName, grade, lastName }) {
    const trEl = createEl('tr');
    const firstNameEl = createEl('td', firstName, trEl);
    const lastNameEl = createEl('td', lastName, trEl);
    const facultyNumberEl = createEl('td', facultyNumber, trEl);
    const gradeEl = createEl('td', grade, trEl);

    return trEl;
}

async function createStudent(e) {
    e.preventDefault();
    const formEl = document.getElementById('form');

    const formData = new FormData(formEl);
    const {firstName, lastName, facultyNumber, grade} = Object.fromEntries(formData);

    if (!firstName || !lastName || !facultyNumber || !grade) {
        alert('All fields are required!');
    }

    if (typeof (firstName) != 'string' || typeof (lastName) != 'string') {
        alert('Wrong name format!');
    }

    if (isNaN(facultyNumber) || isNaN(grade)) {
        alert('FacultyNumber and Grade must be numbers!');
    }

    const student = {
        firstName,
        lastName,
        facultyNumber,
        grade
    }

    const url = 'http://localhost:3030/jsonstore/collections/students';

    const request = await fetch(url, {
        method: 'post',
        headers: { 'Content-type': 'applications/json' },
        body: JSON.stringify(student)
    });

    getStudents();

}

function createEl(type, content, appender) {
    const el = document.createElement(type);

    if (content) {
        el.textContent = content;
    }
    if(appender){
        appender.appendChild(el);
    }
   
    return el;
}