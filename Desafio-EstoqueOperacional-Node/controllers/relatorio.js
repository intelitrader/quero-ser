const fs = require('fs');

class Relatorio {

    /**
     * Gera o arquivo transfere.txt:
     * @param {vendasConfirmadas} <object> -> objeto dos produtos vendidos. cada chave representa um produto
     */
    writeTransfere(vendasConfirmadas){
        let title = "Necessidade de Transferência Armazém para CO"
        let data = title+"\n\n";
        const colunas = ['Produto','QtCO','QtMin','QtVendas','Estq.após','Necess.','Transf. de']
        for(let i = 0; i < colunas.length; i++){
            const titleLen = colunas[i].length;
            data += (colunas[i] + ' '.repeat(12-titleLen));
        }
        data += "\n";
        data += (' '.repeat(12*4) + "Vendas" + ' '.repeat(12-"Vendas".length) );
        data += (' '.repeat(12) + "Arm p/ CO" + ' '.repeat(12-"Arm p/ CO".length) );
        data += "\n";
        for(const codigo in vendasConfirmadas){
            const qtCo = String(vendasConfirmadas[codigo].qtCO);
            const qtMin = String(vendasConfirmadas[codigo].qtMin);
            const qtVendas = String(vendasConfirmadas[codigo].qtVendas);
            const estoqueApos = String(vendasConfirmadas[codigo].estoqueApos);
            const necessario = String(vendasConfirmadas[codigo].necessario);
            const armazemParaCO = String(vendasConfirmadas[codigo].armazemParaCO);
            data += (codigo + ' '.repeat(12-codigo.length));
            data += (qtCo + ' '.repeat(12-qtCo.length));
            data += (qtMin + ' '.repeat(12-qtMin.length));
            data += (qtVendas + ' '.repeat(12-qtVendas.length));
            data += (estoqueApos + ' '.repeat(12-estoqueApos.length));
            data += (necessario + ' '.repeat(12-necessario.length));
            data += (armazemParaCO + ' '.repeat(12-armazemParaCO.length));
            data += "\n";
        }
        fs.writeFile(process.cwd() + '/transfere.txt', data, (err) => {
            if (err) console.log(err);
        });
    }

    /**
     * Gera o arquivo divergencias.txt:
     * @param {divergencias} <array> -> Array com divergências encontradas
     */
    writeDivergencias(divergencias){
        let data = '';
        divergencias.forEach(elem => {
            data += `${elem}\n`;
        });
        fs.writeFile(process.cwd() + '/divergencias.txt', data, (err) => {
            if (err) console.log(err);
        });
    }

    /**
     * Gera o arquivo totcanal.txt:
     * @param {vendasPorCanal} <object> -> Objeto onde a chave é o código de um canal de venda,
     *                                     e o valor desta chave é quantidade de produtos vendidos
     */
    //1 - Representantes | 2 - Website
    //3 - App móvel Android | 4 - App móvel iPhone
    writeTotCanais(vendasPorCanal){
        let data = "Quantidades de Vendas por canal\n\n";
        data += ("Canal" + ' '.repeat(25-"Canal".length));
        data += ("QtVendas");
        data += "\n";
        
        data += ('1 - Representantes' + ' '.repeat(25 - '1 - Representantes'.length))
        data += (vendasPorCanal['1'] + '\n')

        data += ('2 - Website' + ' '.repeat(25 - '2 - Website'.length))
        data += (vendasPorCanal['2'] + '\n')

        data += ('3 - App móvel Android' + ' '.repeat(25 - '3 - App móvel Android'.length))
        data += (vendasPorCanal['3'] + '\n')

        data += ('4 - App móvel iPhone' + ' '.repeat(25 - '4 - App móvel iPhone'.length))
        data += (vendasPorCanal['4'] + '\n')

        fs.writeFile(process.cwd() + '/totcanal.txt', data, (err) => {
            if (err) console.log(err);
        });
    }

}

module.exports = Relatorio;