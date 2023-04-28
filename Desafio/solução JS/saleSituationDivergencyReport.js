import writeDivergency from "./writeDivergencyReport.js";

const saleSituationReport = (venda, line) => {
  let text = ''

  switch (venda.Situacao) {
    case '100':
    case '102': {
      return false
    }
    case '135': {
      text = `Linha ${line} - Venda Cancelada`;
      break
    }
    case '190': {
      text = `Linha ${line} - Venda não finalizada`;
      break
    }
    case '999': {
      text = `Linha ${line} - Erro desconhecido. Acionar equipe de TI.`;
      break
    }
  }
  writeDivergency(text)
}

export default saleSituationReport