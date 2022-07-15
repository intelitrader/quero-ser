export const lerArquivoProdutos = (e) => {
    let lista = [];
    
    e.preventDefault();
    const reader = new FileReader();
    reader.onload = (e) => {
        const text = e.target.result.split("\n");
      
        for(var i = 0; i < text.length; i++){
            let listaTemp = text[i].split(";");

            lista.push({codigoProduto: listaTemp[0], qtdeEstoque: listaTemp[1], qtdeMinima: listaTemp[2].split("\r")[0]});
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
      
        for(var i = 0; i < text.length; i++){
            let listaTemp = text[i].split(";");

            lista.push({codigoProduto: listaTemp[0], qtdeVenda: listaTemp[1], situacaoVenda: listaTemp[2], canalVenda: listaTemp[3].split("\r")[0]});
        }
    };
    reader.readAsText(e.target.files[0]);

    return lista;
};