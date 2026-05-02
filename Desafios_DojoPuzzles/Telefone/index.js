const telefone = {
    '0': '0',
    '1': '1',
    'ABC': '2',
    'DEF': '3',
    'GHI': '4',
    'JKL': '5',
    'MNO': '6',
    'PQRS': '7',
    'TUV': '8',
    'WXYZ': '9',
    '-': '-'
}


function validationPhone() {
    let phone = prompt("Informe a expressão a ser convertida:").toUpperCase()

    // Verifica se  expressão informada atende o limite de caracteres. Se atender chama a função de converter
    if(phone.length <= 30) {
        convertPhone(phone)
    }else {
        alert("Limite de caracteres excedido!! \nInforme uma expressão com no máximo 30 caracteres.")
        validationPhone()
    }

}


function convertPhone(numTel){    
    let novoTel = ''
    
    // Utilizado o laço for para percorrer cada caracter da expressão e aplica um switch case para converter o valor de acordo com o caracter. Se houver algum caracter inválido é apresentado um erro e chama novamente a função de validação da expressão.
    for(i = 0; i <= numTel.length - 1; i++){          

        switch(numTel[i]) {
            case "A": case "B": case "C":
                novoTel += telefone.ABC
                break
            
            case "D": case "E": case "F":
                novoTel += telefone.DEF
                break
            
            case "G": case "H": case "I":
                novoTel += telefone.GHI
                break
            
            case "J": case "K": case "L":
                novoTel += telefone.JKL
                break

            case "M": case "N": case "O":
                novoTel += telefone.MNO
                break

            case "P": case "Q": case "R": case "S":
                novoTel += telefone.PQRS
                break

            case "T": case "U": case "V":
                novoTel += telefone.TUV
                break

            case "W": case "X": case "Y": case "Z":
                novoTel += telefone.WXYZ
                break
            
            case "0":
                novoTel += telefone[0]
                break

            case "1":
                novoTel += telefone[1]
                break

            case "-":
                novoTel += telefone["-"]
                break

            default:
                alert('Identificado caracter inválido!\nO sistema aceita apenas letras de A-Z, os números 1 e 0 e o separador hifen( - )')
                validationPhone()
        }
    }

    alert(`O resultado da conversão da expressão é o número de telefone: ${novoTel}`)
    validationPhone()    

}

validationPhone()
