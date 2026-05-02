//https://dojopuzzles.com/problems/numeros-romanos/


let romanHash = {
    'I': 1,
    'V': 5,
    'X': 10,
    'L': 50,
    'C': 100,
    'D': 500,
    'M': 1000
}

function romanToInt(s) {
    let accumulator = 0;

    for(let i = 0; i < s.length; i++) {
        if(s[i] === "I" && s[i + 1] === "V") {
            accumulator += 4;
            i++;
        } else if(s[i] === "I" && s[i + 1] === "X") {
            accumulator += 9;
            i++;
        } else if(s[i] === "X" && s[i + 1] === "L") {
            accumulator += 40;
            i++;
        } else if(s[i] === "X" && s[i + 1] === "C") {
            accumulator += 90;
            i++  
        }  else if(s[i] === "C" && s[i + 1] === "D") {
            accumulator += 400;
            i++;
        } else if(s[i] === "C" && s[i + 1] === "M") {
            accumulator += 900;
            i++;
        } else {
            accumulator  += romanHash[s[i]]
        }
     }      
        return accumulator;
}
