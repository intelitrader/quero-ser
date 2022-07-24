const readline = require("readline");
const rl = readline.createInterface({
  input: process.stdin,
  output: process.stdout,
  terminal: false,
});

function isPalindrome(word) {
  if (!word) throw new Error("Pass a valid string");

  word = word.toLowerCase();

  for (let i = 0; i < word.length; i++) {
    if (word[i] !== word[word.length - 1 - i])
      return "INFELIZMENTE, NÃO SOU UM PALÍNDROMO";
  }

  return "SIM, SOU UM PALÍNDROMO";
}

rl.on("line", (entrada) => {
  console.log(isPalindrome(entrada));
  // fechar readline
  rl.close();
});
