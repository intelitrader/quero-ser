const parseUrl = require('parse-url');

const url="http://www.google.com/mail/user=fulano";
const parsedUrl = parseUrl(url);
console.log(parsedUrl);


let url2="ssh://fulano%senha@git.com/";
const parsedUrl2 = parseUrl(url2);
console.log(parsedUrl2);

