const printTable = (data) => {
  // Encontra a largura máxima de cada coluna
  const columnWidths = data.reduce((acc, row) => {
    row.forEach((cell, i) => {
      const width = cell.toString().length;
      acc[i] = Math.max(acc[i] || 0, width);
    });
    return acc;
  }, []);

  // Formata cada linha da tabela
  const lines = data.map(row => {
    return row.map((cell, i) => {
      const width = columnWidths[i];
      const padding = ' '.repeat(width - cell.toString().length);
      return `${cell}${padding}`;
    }).join('  ');
  });

  // Gera a tabela
  const table = lines.join('\n');

  return table
}

export default printTable