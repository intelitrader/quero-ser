let pedraLeft = window.document.querySelector('input#pedraLeft')
let papelLeft = window.document.querySelector('input#papelLeft')
let tesouraLeft = window.document.querySelector('input#tesouraLeft')
let pedraRight = window.document.querySelector('input#pedraRight')
let papelRight = window.document.querySelector('input#papelRight')
let tesouraRight = window.document.querySelector('input#tesouraRight')
let btnJogar = window.document.querySelector('input#btnJogar')
let info = window.document.querySelector('p#info')
let vencedorAzul = window.document.querySelector('p#vencedorAzul')
let vencedorVermelho = window.document.querySelector('p#vencedorVermelho')
let empate = window.document.querySelector('p#empate')

/*
    Poderia ter criado apenas duas variáveis para lincar com os radioButton, através do 
    getElementsByName, assim:
        let radioLeft = window.document.getElementsByName('radioLeft')
        let radioRight = window.document.getElementsByName('radioRight')
    Porém, a função 'limpaResultado()' teria que ser chamada no HTML, via 
    'onchange = 'limpaResultado()' em cada radioButton para funcionar corretamente, 
    e como não quis 'sujar' meu HTML com funções ou chamadas de funções, criei uma
    variável para cada radioButton e atribuí a elas a respectiva função. 
*/

pedraLeft.onchange = limpaResultado
papelLeft.onchange = limpaResultado
tesouraLeft.onchange = limpaResultado
pedraRight.onchange = limpaResultado
papelRight.onchange = limpaResultado
tesouraRight.onchange = limpaResultado

//Limpa o conteúdo do resultado
function limpaResultado(params) {
    info.innerHTML = ''
    vencedorAzul.innerHTML = ''
    vencedorVermelho.innerHTML = ''
    empate.innerHTML = ''
}

btnJogar.onclick = function () {
    limpaResultado()
    //Se User 1 selecionou...
    if (pedraLeft.checked || papelLeft.checked || tesouraLeft.checked) {
        //E Se User 2 selecionou...
        if (pedraRight.checked || papelRight.checked || tesouraRight.checked) {
            //User 1: Pedra
            if (pedraLeft.checked) {
                info.innerHTML = `User 1: [Pedra] <br>` 
                //User 2: Pedra       
                if(pedraRight.checked){
                    info.innerHTML += `User 2: [Pedra]`
                    empate.innerHTML = 'Empate!'
                //User 2: Papel
                } else if (papelRight.checked) {
                    info.innerHTML += `User 2: [Papel]`
                    //Se vermelho ganhou, chamo o 'vencedorVermelho' que no CSS recebe a cor vermelha
                    vencedorVermelho.innerHTML = 'Vencedor: User 2#Vermelho!'
                    /*
                        Poderia ter criado apenas uma variável e chama-la aqui no JS, setando a cor desejada
                        conforme abaixo. Porém, novamente quis separar as funções de cada arquivo...
                        vencedor.style.color = 'rgb(200, 100, 100)'
                    */
                //User 2: Tesoura
                } else {                                                
                    info.innerHTML += `User 2: [Tesoura]`
                    vencedorAzul.innerHTML = 'Vencedor: User 1#Azul'
                }
            //User 1: Papel
            } else if (papelLeft.checked) {
                info.innerHTML = `User 1: [Papel] <br>` 
                if(pedraRight.checked){
                    info.innerHTML += `User 2: [Pedra]`
                    vencedorAzul.innerHTML = 'Vencedor: User 1#Azul!'
                } else if (papelRight.checked) {
                    info.innerHTML += `User 2: [Papel]`
                    empate.innerHTML = 'Empate!'
                } else {
                    info.innerHTML += `User 2: [Tesoura]`
                    vencedorVermelho.innerHTML = 'Vencedor: User 2#Vermelho!'
                }
            //User 1: Tesoura
            } else{
                info.innerHTML = `User 1: [Tesoura] <br>`        
                if(pedraRight.checked){
                    info.innerHTML += `User 2: [Pedra]`
                    vencedorVermelho.innerHTML = 'Vencedor: User 2#Vermelho!'
                } else if (papelRight.checked) {
                    info.innerHTML += `User 2: [Papel]`
                    vencedorAzul.innerHTML = 'Vencedor: User 1#Azul!'
                } else {
                    info.innerHTML += `User 2: [Tesoura]`
                    empate.innerHTML += 'Empate!'
                }
            }
        } else{
            info.innerHTML = 'User 2 não selecionou nenhuma opção!'
        }        
    } else {
        info.innerHTML = 'User 1 não selecionou nenhuma opção!'
    }
}