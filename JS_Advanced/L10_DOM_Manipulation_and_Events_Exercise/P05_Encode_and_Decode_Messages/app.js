function encodeAndDecodeMessages() {
    let firstButtonElement = document.getElementsByTagName('button')[0];
    let secondButtonElement = document.getElementsByTagName('button')[1];

    firstButtonElement.addEventListener('click', encode);
    secondButtonElement.addEventListener('click', decode);

    let toEncodeElement = document.getElementsByTagName('textarea')[0];
    let toDecodeElement = document.getElementsByTagName('textarea')[1];

    function encode(event){
        let messageToEncode = toEncodeElement.value;
        let encodedMessage = '';

        for (let i = 0; i < messageToEncode.length; i++) {
            encodedMessage += String.fromCharCode(messageToEncode.charCodeAt(i) + 1);      
        }
         
        toEncodeElement.value = '';

        toDecodeElement.value = encodedMessage;    
    }

    function decode(){
        let messageToDecode = toDecodeElement.value;
        let decodedMessage = '';

        for (let i = 0; i < messageToDecode.length; i++) {
            decodedMessage += String.fromCharCode(messageToDecode.charCodeAt(i) - 1);
        }

        toDecodeElement.value = decodedMessage;
    }

}