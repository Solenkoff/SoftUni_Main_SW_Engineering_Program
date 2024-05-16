function solve() {
    let inputTextElement = document.getElementById('text');
    let text = inputTextElement.value;
    let namingConventionElement = document.getElementById('naming-convention');
    let namingConvention = namingConventionElement.value;
    let resultElement = document.getElementById('result');

    let result = '';

    for (let i = 0; i < text.length; i++) {
        if(text[i] === ' '){
            result += text[i + 1].toUpperCase();
            i++;
        }else{
            result += text[i].toLowerCase();
        }  
    }
  
    if(namingConvention === 'Camel Case'){
        result = result;
    }else if(namingConvention === 'Pascal Case'){
        result = result[0].toUpperCase() + result.slice(1, result.length);
    }else{
        result = 'Error!';
    }

    resultElement.textContent = result;
}