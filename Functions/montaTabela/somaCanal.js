import criaCanal from "../criaArquivo/criaCanal.js";

export default function somaCanal(ArrayVendas, cn) {
  const canais = [
    {
      nome: "Representante",
      total: 0,
    },
    {
      nome: "Website",
      total: 0,
    },
    {
      nome: "Android",
      total: 0,
    },
    {
      nome: "iPhone",
      total: 0,
    },
  ];

  ArrayVendas.forEach((venda) => {
    if (venda.situacao == 100 || venda.situacao == 102)
      switch (venda.canal) {
        case 1:
          canais[0].total += venda.quantidade;
          break;
        case 2:
          canais[1].total += venda.quantidade;
          break;
        case 3:
          canais[2].total += venda.quantidade;
          break;
        case 4:
          canais[3].total += venda.quantidade;
          break;
      }
  });

  criaCanal(canais, cn);
}
