function focused() {
    const sections = document.querySelectorAll('input');

    for (const section of sections) {
        section.addEventListener('focus',onFocus);
        section.addEventListener('blur', onBlur);
    }

    function onFocus(e) {
        e.target.parentNode.className = 'focused';
    }

    function onBlur(e) {
        e.target.parentNode.className = '';
    }
}