function giveChange(value) {
  let ten = 0;
  let twenty = 0;
  let fifty = 0;
  let hundred = 0;
  let missing = value;

  while (missing >= 100) {
    missing -= 100;
    hundred += 1;
  }

  while (missing >= 50 && missing < 100) {
    missing -= 50;
    fifty += 1;
  }

  while (missing >= 20 && missing < 50) {
    missing -= 20;
    twenty += 1;
  }

  while (missing >= 10 && missing < 20) {
    missing -= 10;
    ten += 1;
  }

  const notas = {
    dez: ten,
    vinte: twenty,
    cinquenta: fifty,
    cem: hundred,
  };

  return console.log(notas);
}

giveChange(110);