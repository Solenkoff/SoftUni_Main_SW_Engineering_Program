type OkResponse = { code: 200 | 201 | 301 , text: string };
type BadResponse = { code: 400 | 404 | 500, text: string, printChars?: number };

function printResponseText(response: OkResponse | BadResponse){
    // switch (response.code) {
    //     case 200:
    //     case 201:
    //     case 301: console.log(response.text); return;
    //     case 400:
    //     case 404:
    //     case 500: console.log(response.text.slice(0, response.printChars));
    // }

    if('printChars' in response){
        console.log(response.text.slice(0, response.printChars));
    } else {
        console.log(response.text);
    }
}


printResponseText({ code: 200, text: 'OK'});
printResponseText({ code: 201, text: 'Created'});
printResponseText({ code: 400, text: 'Bad Request', printChars: 4});
printResponseText({ code: 404, text: 'Not Found'});
printResponseText({ code: 404, text: 'Not Found', printChars: 3});
printResponseText({ code: 500, text: 'Internal Server Error', printChars: 1});

// printResponseText({ code: 200, text: 'OK', printChars: 4});    //  Does not fit any type structure
