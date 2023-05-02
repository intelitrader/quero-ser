export default function somaCanal(ArrayVendas) {
  let Representante = 0;
  let Website = 0;
  let Android = 0;
  let iPhone = 0;

  ArrayVendas.forEach((venda) => {
    switch (venda.canal) {
      case 1:
        Representante += venda.quantidade;
        break;
      case 2:
        Website += venda.quantidade;
        break;
      case 3:
        Android += venda.quantidade;
        break;
      case 4:
        iPhone += venda.quantidade;
        break;
    }
  });

  console.log(iPhone);
}
