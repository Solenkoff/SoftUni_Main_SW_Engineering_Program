function lockedProfile() {
    
    Array.from(document.querySelectorAll('.profile button'))
         .forEach(button => button.addEventListener('click', onClick));

    function onClick(event){
        let profileElement = event.target.parentElement;
        let isActive = profileElement.querySelector('input[value="unlock"]').checked;
        if(isActive){
            let info = Array.from(profileElement.querySelectorAll('div'))
                .find(div => div.id.includes('HiddenFields'));

            if(event.target.textContent === 'Show more'){
                event.target.textContent = 'Hide it';
                info.style.display = 'block';
            }else{
                event.target.textContent = 'Show more';
                info.style.display = 'none';
            }
            
        }
    
    }     

}