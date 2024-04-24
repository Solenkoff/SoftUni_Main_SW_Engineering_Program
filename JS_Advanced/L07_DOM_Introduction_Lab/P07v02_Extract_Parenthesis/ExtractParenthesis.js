function extract(content) {
    
    let para = document.getElementById(content).textContent;

    let pattern = /\(([^\)]+)\)/g, result = [], match;
  
    while(match = pattern.exec(para)) {
      result.push(match[1]);
    }
  
    return result.join('; ');
  
}

let text = extract("content");