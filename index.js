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
    return (withdraw.textContent = `
            100: ${notes[100]} - 
            50: ${notes[50]} - 
            20: ${notes[20]} - 
            10: ${notes[10]} - 
            turn back: ${notes["turnBack"].toFixed(2)}
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
