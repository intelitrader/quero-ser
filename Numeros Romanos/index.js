function NumerosRomanos(numeroRomano) {
  let numbers = [];
  let soma = 0;

  const result = numeroRomano.includes("IIII" || "XXXX" || "CCCC" || "MMMM");

  if (result) {
    console.log("Erro");
    return;
  }

  for (let item of numeroRomano) {
    if (item === "I") {
      numbers.push(1);
    }
    if (item === "V") {
      numbers.push(5);
    }
    if (item === "X") {
      numbers.push(10);
    }
    if (item === "L") {
      numbers.push(50);
    }
    if (item === "C") {
      numbers.push(100);
    }
    if (item === "D") {
      numbers.push(500);
    }
    if (item === "M") {
      numbers.push(1000);
    }
  }
  for (let i = 0; i < numbers.length; i++) {
    if (numbers[i] === 1 && numbers[i] < numbers[i+1]) {
      numbers[i] = -1;
    }
    if (numbers[i] === 10 && numbers[i] < numbers[i+1]) {
      numbers[i] = -10;
    }
    if (numbers[i] === 100 && numbers[i] < numbers[i+1]) {
      numbers[i] = -100;
    }
    soma += numbers[i];
  }
    console.log(soma)
}
NumerosRomanos("IX");
