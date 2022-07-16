export const lerArquivoProdutos = (e) => {
    let lista = [];
    
    e.preventDefault();
    const reader = new FileReader();
    reader.onload = (e) => {
        const text = e.target.result.split("\n");
      
        for(var i = 0; i < text.length; i++){
            let listaTemp = text[i].split(";");

            lista.push({
                codigoProduto: parseInt(listaTemp[0], 10), 
                qtdEstoque: parseInt(listaTemp[1], 10), 
                qtdMinima: parseInt(listaTemp[2].split("\r")[0], 10)
            });
        }
    };
    reader.readAsText(e.target.files[0]);

    return lista;
};

export const lerArquivoVendas = (e) => {
    let lista = [];
    
    e.preventDefault();
    const reader = new FileReader();
    reader.onload = (e) => {
        const text = e.target.result.split("\n");

        for(var i = 0; i < text.length - 1; i++){
            let listaTemp = text[i].split(";");

            lista.push({
                codigoProduto: parseInt(listaTemp[0], 10), 
                qtdVendas: parseInt(listaTemp[1], 10), 
                situacaoVenda: parseInt(listaTemp[2], 10), 
                canalVenda: parseInt(listaTemp[3].split("\r")[0], 10)
            });
        }
    };
    reader.readAsText(e.target.files[0]);

    return lista;
};