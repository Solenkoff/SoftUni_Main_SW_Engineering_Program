function extract(content) {
    let contentElement = document.getElementById(content);

    let patern = /(?<=\()[^)]*(?=\))/gm;
    let matches = contentElement.textContent.matchAll(patern);
    let result = Array.from(matches); 

    return result.join('; ');
    
}