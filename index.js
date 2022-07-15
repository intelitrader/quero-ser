function withdrawMoney(withdrawAmount) {
  let notesAvailable = [100, 50, 20, 10];

  let withdrawNotes = {
    100: 0,
    50: 0,
    20: 0,
    10: 0,
    turnBack: 0,
  };

  for (let i = 0; i < notesAvailable.length; i++) {
    if (Math.floor(withdrawAmount / notesAvailable[i] > 0)) {
      withdrawNotes[notesAvailable[i]] = Math.floor(
        withdrawAmount / notesAvailable[i]
      );
      withdrawAmount -= withdrawNotes[notesAvailable[i]] * notesAvailable[i];
    }
    withdrawNotes["turnBack"] = withdrawAmount;
  }

  return withdrawNotes;
}

const checkValue = () => {
  const amount = document.querySelector("#amount").value;

  const withdraw = document.querySelector(".withdraw");

  const isValid = /^[0-9]/.test(amount);

  if (isValid) {
    const notes = withdrawMoney(amount);

    console.log(notes);

    if (notes["turnBack"] > 0) {
      const input = document.querySelector("#amount");
      return alert(
        "You can only withdraw values that match the following notes: 100 - 50 - 20 - 10"
      );
    }

    return (withdraw.textContent = `
            100 notes: ${notes[100]} ||
            50 notes: ${notes[50]} ||
            20 notes: ${notes[20]} || 
            10 notes: ${notes[10]} ||
            `);
  }

  return (withdraw.textContent = "Invalid input format");
};

const fizzBuzz = () => {
  const textArea = document.querySelector("#fizzBuzz");

  for (var i = 1; i < 101; i++) {
    if (i % 15 == 0) textArea.value += "FizzBuzz \n";
    else if (i % 3 == 0) textArea.value += "Fizz \n";
    else if (i % 5 == 0) textArea.value += "Buzz \n";
    else textArea.value += i + " \n";
  }
};

fizzBuzz();

function getRandomArbitrary(min, max) {
  return Math.floor(Math.random() * (max - min) + min);
}
const challegenThree = () => {
  const ele = document.querySelector("#elements");
  const seq = document.querySelector("#sequence");
  const min = document.querySelector("#minimum");
  const max = document.querySelector("#maximum");
  const med = document.querySelector("#media");

  const numberOfElements = Math.floor(Math.random() * 10);
  const maxNumber = Math.floor(Math.random() * 100);
  const minNumber = Math.floor(Math.random() * 100) * -1;
  const sequence = [];

  for (let i = numberOfElements; i > 0; i--) {
    sequence.push(getRandomArbitrary(minNumber, maxNumber));
  }

  const media = sequence.reduce((acc, number) => acc + number, 0) / sequence.length;

  med.textContent = `Media: ${media.toFixed(2)}`;
  max.textContent = `Maximum possible: ${maxNumber}`;
  ele.textContent = `Nº elements: ${numberOfElements}`;
  min.textContent = `Minimum possible: ${minNumber}`;
  seq.textContent = `Sequence sorted: ${sequence.join(" , ")}`;
};

challegenThree();
