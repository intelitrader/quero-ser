// https://dojopuzzles.com/problems/intervalos/

const numerosInteiros = [100, 101, 102, 103, 104, 105, 110, 111, 113, 114, 115, 150];

const agruparIntervalos = (numerosInteiros) => {
  const intervalos = [];
  let inicio = numerosInteiros[0];
  let fim = numerosInteiros[0];
  for (let i = 1; i < numerosInteiros.length; i++) {
    if (numerosInteiros[i] - numerosInteiros[i - 1] === 1) {
      fim = numerosInteiros[i];
    } else {
      intervalos.push([inicio, fim]);
      inicio = numerosInteiros[i];
      fim = numerosInteiros[i];
    }
  }
  inicio === fim ? intervalos.push([inicio]) : intervalos.push([inicio, fim]);
  return intervalos;
}

console.log(agruparIntervalos(numerosInteiros));
