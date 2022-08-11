const prod = [16320, 23400, 26440, 28790, 36540];
const estoque = [344, 1435, 2899, 310, 431];
const quantMin = [200, 500, 800, 150, 100];
const quantVendas = [153, 937, 214, 233, 617];
const estAposVenda = [];
const neces = [];
const transf = [];

console.log("Necessidade de Transferência Armazém para CO");

console.log(
    "\nProduto QtCO    QtMin   QtVendas   Estq.após Vendas  Necess.  Transf. de Arm p/ CO\n"
);
for (let i = 0; i < prod.length; i++) {
    estAposVenda[i] = estoque[i] - quantVendas[i];
    if (estAposVenda[i] < quantMin[i]) {
        neces[i] = quantMin[i] - estAposVenda[i];

        if (neces[i] > 1 && neces[i] < 10) {
            transf[i] = 10;
        } else {
            transf[i] = neces[i];
        }
    } else {
        neces[i] = 0;
        transf[i] = 0;
    }
    console.log(
        `${prod[i]}   ${estoque[i]}    ${quantMin[i]}      ${quantVendas[i]}             ${estAposVenda[i]}              ${neces[i]}           ${transf[i]}`
    );
}

/* SAÍDA DO PROGRAMA 
Necessidade de Transferência Armazém para CO

Produto QtCO    QtMin   QtVendas   Estq.após Vendas  Necess.  Transf. de Arm p/ CO

16320   344    200      153             191              9           10
23400   1435    500      937             498              2           10
26440   2899    800      214             2685              0           0
28790   310    150      233             77              73           73
36540   431    100      617             -186              286           286*/
