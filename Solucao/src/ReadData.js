module.exports = function () {
    const fs = require('fs');

    function produtos() {
        var produtos = fs.readFileSync('./entry_files/produtos.txt', 'utf-8');
        produtos = produtos.split('\r\n');
        var result = [];
        for (i in produtos) {
            var self_data = produtos[i].split(';');
            result.push(self_data);
        }
        return result;
    }

    function vendas() {
        var vendas = fs.readFileSync('./entry_files/vendas.txt', 'utf-8');
        vendas = vendas.split('\r\n');
        var result = [];
        for (i in vendas) {
            if (vendas[i] != "" && vendas[i] != null && vendas[i] != undefined) {
                var self_data = vendas[i].split(';');
                result.push(self_data);
            }
        }
        return result;
    }

    return {
        produtos: produtos(),
        vendas: vendas()
    }
}