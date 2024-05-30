function validate() {
    const passInputElement = document.querySelector('#email');
    passInputElement.addEventListener('change', emailValidation);

    function emailValidation(e){        
        const patternToMatch = /^[a-z]+@[a-z]+\.[a-z]+$/;

        //   /([a-z]+)@([a-z]+)\.([a-z]+)/g
        
        if (patternToMatch.test(passInputElement.value)) {
            e.target.classList.remove('error');
        }else{          
            e.target.classList.add('error');
        }
    }
}