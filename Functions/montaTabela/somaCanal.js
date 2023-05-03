import criaCanal from "../criaArquivo/criaCanal.js";

export default function somaCanal(ArrayVendas, cn) {
  const canais = [
    {
      nome: "1 - Representantes",
      total: 0,
    },
    {
      nome: "2 -Website",
      total: 0,
    },
    {
      nome: "3 - App móvel Android",
      total: 0,
    },
    {
      nome: "4 - App móvel iPhone",
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
