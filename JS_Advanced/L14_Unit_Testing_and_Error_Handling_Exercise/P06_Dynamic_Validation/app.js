function validate() {
    let emailElement = document.getElementById('email');
    emailElement.addEventListener('change', onChange);

    function onChange(event) {
        let enteredEmail = event.target.value;
        let pattern = /^[a-z]+@[a-z]+\.[a-z]+$/;
        if (pattern.test(enteredEmail)) {
            event.target.className = '';
        } else {
            event.target.className = 'error';
        }
    }
}