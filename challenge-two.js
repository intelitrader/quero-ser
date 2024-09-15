const statistics = (...numbers) => {
  if (
    numbers.length === 0 ||
    numbers.some(number => typeof number !== 'number')
  ) {
    return 'Apenas números são permitidos';
  }

  const minValue = Math.min(...numbers);
  const maxValue = Math.max(...numbers);
  const numbersLength = numbers.length;

  let sum = 0;
  for (let i = 0; i < numbers.length; i++) {
    sum += numbers[i++];
  }

  const average = sum / numbersLength;
  const formattedAverage = Math.floor(average);

  const result = {
    valor_minimo: minValue,
    valor_maximo: maxValue,
    numero_de_elementos_na_sequencia: numbersLength,
    valor_medio: formattedAverage
  };

  return result;
};

console.log(statistics(1, 2, 3, 4, '5', 6, 7, 8, 9, 10));
