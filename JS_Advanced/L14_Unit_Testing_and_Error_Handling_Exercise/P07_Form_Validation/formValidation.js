function validate() {
    document.querySelector("#submit").type = "button";

    const usernameEl = document.getElementById('username');
    const emailEl = document.getElementById('email');
    const passwordEl = document.getElementById('password');
    const confirmPassEl = document.getElementById('confirm-password');
    const companyNumberEl = document.getElementById('companyNumber');
    const companyInfoEl = document.getElementById('companyInfo');
    const validDivEl = document.getElementById('valid');

    const isCompanyEl = document.getElementById('company');
    isCompanyEl.addEventListener('change', onChange);

    const submitBtn = document.getElementById('submit');
    submitBtn.addEventListener('click', submitInfo);

    function submitInfo(event) {
        event.preventDefault();

        const username = usernameEl.value;
        const email = emailEl.value;
        const password = passwordEl.value;
        const confirmPass = confirmPassEl.value;
        const isCompany = isCompanyEl.checked;
        const companyNumber = Number(companyNumberEl.value);

        let isValid = true;
        if (!isValidUsername(username)) {
            usernameEl.style.borderColor = "red";
            isValid = false;
        }
        if (!isValidEmail(email)) {
            emailEl.style.borderColor = "red";
            isValid = false;
        }
        if (!isValidPassword(password)) {
            passwordEl.style.borderColor = "red";
            isValid = false;
        }
        if (!isValidPassword(confirmPass)) {
            confirmPassEl.style.borderColor = "red";
            isValid = false;
        }
        if (password !== confirmPass) {
            passwordEl.style.borderColor = "red";
            confirmPassEl.style.borderColor = "red";
            isValid = false;
        }
        if(isCompany){
            if( companyNumber < 1000 || companyNumber > 9999){
                companyNumberEl.style.borderColor = "red";
                isValid = false;
            }
        }

        if(isValid){
            validDivEl.style.display = 'block' ;
        }

    }

    function onChange(event) {
        if (event.target.checked) {
            companyInfoEl.style.display = 'block';
        } else {
            companyInfoEl.style.display = 'none';
        }
    }

    function isValidUsername(username) {
        const pattern = /^[A-Za-z0-9]{3,20}$/;         //--   /^(?!_)\w{3,20}$/gm;   Mine - Not correct
        return pattern.test(username);
    }

    function isValidEmail(email) {
        const pattern = /^[^@.]+@[^@]*\.[^@]*$/;       //--   /^\S+@\S+\.\S+$/gm;  Mine - Not correct
        return pattern.test(email);
    }

    function isValidPassword(password) {
        const pattern = /^[\w]{5,15}$/;                //--   /^\w{5,15}$/gm;  Mine - Not correct
        return pattern.test(password);
    }

}
