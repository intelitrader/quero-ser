import { alphabetic } from "./utils.js";
/**
 * PROBLEM LINK
 *   https://dojopuzzles.com/problems/entre-letras/
 */

const quantityOfLettersBetweenTwoLetters = (fLetter, sLetter) => {
  const firstLetter = fLetter.toLowerCase();
  const secondLetter = sLetter.toLowerCase();
  const sortedLetters = [firstLetter, secondLetter].sort();

  const firstLetterIndex = alphabetic.indexOf(firstLetter) + 1;
  const secondLetterIndex = alphabetic.indexOf(secondLetter) + 1;

  if (sortedLetters[0] !== firstLetter) {
    console.log(
      `${firstLetter} and ${secondLetter} = Are Not In Alphabetical Order`
    );
    return;
  }

  console.log(
    ` ${firstLetter}, ${secondLetter} = ${
      secondLetterIndex - firstLetterIndex - 1
    }`
  );
};

quantityOfLettersBetweenTwoLetters("B", "D"); // 1 - only b
