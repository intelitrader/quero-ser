function lampadasNoCorredor(nLampadas) {
  let arrayDeLampadas = [];
  for (let i = 1; i <= nLampadas; i++) {
    arrayDeLampadas.push(-1);
  }

  let counter = 1;

  while (counter <= nLampadas) {
    for (let i = 0; i < arrayDeLampadas.length; i++) {
      if ((i + 1) % counter === 0) {
        arrayDeLampadas[i] *= -1;
      }
    }

    counter++;
  }

  let arrayOnOff = [];

  //on = 1, off = -1;
  arrayDeLampadas.forEach(lampada => {
    if (lampada === -1) {
      arrayOnOff.push('off');
    } else {
      arrayOnOff.push('on');
    }
  });
  console.log(arrayOnOff);
  return arrayOnOff;
}

lampadasNoCorredor(5);
