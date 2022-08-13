function cashMachine(withdrawValue) {
  const availableNotes = [100, 50, 20, 10];

  let cashOut = 0;
  const chosenNotes = [];

  while (cashOut < withdrawValue) {
    chosenNotes.push(
      availableNotes.find(note => {
        return cashOut + note <= withdrawValue;
      })
    );

    cashOut = chosenNotes.reduce((total, current) => {
      return total + current;
    }, 0);
  }

  console.log(chosenNotes);
  return chosenNotes;
}

cashMachine(280);
