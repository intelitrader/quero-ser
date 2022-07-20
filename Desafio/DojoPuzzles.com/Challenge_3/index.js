import { alphabeticLowercased, alphabeticUppercased } from "./utils.js";
/**
 * PROBLEM LINK
 * https://dojopuzzles.com/problems/palavras-primas/
 */

const getTheCorrespondingLetterNumber = (
  letter,
  lowerOrUpperAlphabeticArray,
  alphabeticObjectKeys
) => {
  const letterValue = lowerOrUpperAlphabeticArray.filter((item, index) => {
    if (alphabeticObjectKeys[index][0] === letter) {
      return item[letter];
    }
  });

  return letterValue[0][letter];
};

const isUpperCase = (caractere) => /^[A-Z]*$/.test(caractere);

const sumTheLettersValues = (word) => {
  const lowerLettersOnlyKey = alphabeticLowercased.map(Object.keys);
  const upperLettersOnlyKey = alphabeticUppercased.map(Object.keys);
  let sumLetters = 0;
  if (/^[A-Za-z]+$/.test(word)) {
    word.split("").forEach((item) => {
      if (isUpperCase(item)) {
        sumLetters =
          getTheCorrespondingLetterNumber(
            item,
            alphabeticUppercased,
            upperLettersOnlyKey
          ) + sumLetters;
      } else {
        sumLetters =
          getTheCorrespondingLetterNumber(
            item,
            alphabeticLowercased,
            lowerLettersOnlyKey
          ) + sumLetters;
      }
    });
    return sumLetters;
  } else {
    return false;
  }
};
const verifyIfPrimeOrNot = (wordInNumberFormat) => {
  if (wordInNumberFormat === 1) return false;
  if (wordInNumberFormat === 2) return true;

  for (let i = 2; i < wordInNumberFormat; i++)
    if (wordInNumberFormat % i === 0) return false;
  return wordInNumberFormat > 1;
};
const isPrimeNumber = () => {
  //Put the word that you want to check if it is prime number
  const wordInNumberFormat = sumTheLettersValues("4");
  // code -> c=3 o=15 d=4 e=5 -> a+b+c+d= 27

  if (wordInNumberFormat) {
    if (verifyIfPrimeOrNot(wordInNumberFormat)) {
      console.log(`${wordInNumberFormat} Is a prime number.`);
    } else {
      console.log(`${wordInNumberFormat} Is not a prime number.`);
    }
  } else {
    console.log("Not a valid entry! Only Word allowed");
  }
};

isPrimeNumber();
