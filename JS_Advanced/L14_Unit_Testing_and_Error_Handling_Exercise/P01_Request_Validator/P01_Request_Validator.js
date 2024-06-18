function validator(requestObject) {

    let validMethods = ['GET', 'POST', 'DELETE', 'CONNECT'];

    let uriPattern = /^((\*)|[a-zA-Z0-9\.]+)$/gim;     //    /[^A-Za-z0-9\.\*]+/

    let validVersions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];

    let validMessagePattern = /(^$)|^((\d)+|[^<>\\\&'"]+)$/gim;     //    /[<>\\\&\'\"]+/

    if (!requestObject.hasOwnProperty('method') || !validMethods.includes(requestObject.method)) {
        throw new Error('Invalid request header: Invalid Method')
    }

    if (!requestObject.hasOwnProperty('uri') || !requestObject.uri.match(uriPattern)) {
        throw new Error('Invalid request header: Invalid URI')
    }

    if (!requestObject.hasOwnProperty('version') || !validVersions.includes(requestObject.version)) {
        throw new Error('Invalid request header: Invalid Version')
    }

    if (!requestObject.hasOwnProperty('message') || !requestObject.message.match(validMessagePattern)) {
        throw new Error('Invalid request header: Invalid Message')
    }

    return requestObject;
}

console.log(validator({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: ''
}));

console.log(validator({
    method: 'OPTIONS',
    uri: 'git.master',
    version: 'HTTP/1.1',
    message: '-recursive'
}));



