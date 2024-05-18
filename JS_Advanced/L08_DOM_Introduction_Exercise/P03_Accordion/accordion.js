function toggle() {
   
    let buttonElement = document.querySelector('.head .button')
    let extraTextElement = document.querySelector('#extra')   

    if(buttonElement.textContent === 'More'){
        buttonElement.textContent = 'Less';
        extraTextElement.style.display = 'block';
    }else if(buttonElement.textContent === 'Less'){
        buttonElement.textContent = 'More';
        extraTextElement.style.display = 'none'
    }


    // extraTextElement.style.display = buttonElement.textContent == 'More'
    // ? 'block'
    // : 'none';   
    
    // buttonElement.textContent = buttonElement.textContent == 'More'
    // ? 'Less'
    // : 'More';

}