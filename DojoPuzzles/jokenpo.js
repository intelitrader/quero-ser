/*
    Nome do desafio -----------:> Jokenpo
    Link para o desafio -------:> https://dojopuzzles.com/problems/jokenpo/
    Como rodar esse desafio ---:> `node jokenpo.js` (via terminal)
*/


// Importando o módulo do Node.js que permite a leitura de dados pelo terminal
const readline = require("readline");

// Criando a interface 
const rl = readline.createInterface({
    input: process.stdin,
    output: process.stdout
});

// Array que indica os possíveis movimentos do jogo
let moves = ['Pedra', 'Papel', 'Tesoura'] 

// Escolha aleatória de um valor que corresponde a um movimento do jogo
let computerMoveOption = Math.floor(Math.random() * (3 - 0) + 0) 


// Criação da função challengeHeader() que cria o cabeçalho do desafio
const challengeHeader = () => {
    console.log('-=--=--=--=--=--=--=--=-')
    console.log('[1] --> PEDRA')
    console.log('[2] --> PAPEL')
    console.log('[3] --> TESOURA')
    console.log('-=--=--=--=--=--=--=--=-')
}

// Criação da função gameResult() que exibe o resultado do jogo
const gameResult = (winner, userMove, computerMove) => {

    let winnerString = ''

    /* 
        Aqui é feita a verificação da situação do jogo, caso seja de empate, a variável `winnerString`
        é configurada da maneira para EMPATE, caso não seja, é realizada uma outra verificação para 
        determinar o vencedor do jogo, seja o computador ou o usuário.
    */

    if (winner === 'Empate') {
        winnerString = 'O jogo resultou em empate :/'
    } else {
        winnerString = winner === 'Usuário' ? 'Parabéns!! Você ganhou essa rodada' : 'Que Pena :( O computador ganhou essa'
    }

    // Após as validações feitas acima, o resultado é mostrado
    console.log('-=--=--=--=--=--=--=--=--=--=--=--=--=-')
    console.log(`${winnerString}`);
    console.log('-=--=--=--=--=--=--=--=--=--=--=--=--=-')
    
    console.log()

    console.log(`Você escolheu --:> ${userMove}`);
    console.log(`Computador escolheu --:> ${computerMove}`);
}

// Criação da função startGame() que executa o script necessário para o jogo rodar
const startGame = (userMoveOption) => {

    try {
             
        // Caso o usuário escolha uma opção inválida das que são mostradas
        if ( userMoveOption < 0 || userMoveOption > 2  ) {
            console.log('ESCOLHA UMA OPÇÃO VÁLIDA!!');
            return
        } else {       

            // Variáveis que demonstram o que cada player escolheu
            let userMove = moves[userMoveOption] 
            let computerMove =  moves[computerMoveOption]
            
            // Caso o jogo resulte em um empate
            if (userMoveOption === computerMoveOption) {
                gameResult('Empate', userMove, computerMove)
            }

            // Caso a escolha seja PEDRA
            else if (userMoveOption === 0 && computerMoveOption === 2) {
                gameResult('Usuário', userMove, computerMove)
            } else if (userMoveOption === 0 && computerMoveOption === 1) {
                gameResult('Computador', userMove, computerMove)
            }
            
            // Caso a escolha seja PAPEL
            else if (userMoveOption === 1 && computerMoveOption === 0) {
                gameResult('Usuário', userMove, computerMove) 
            } else if (userMoveOption === 1 && computerMoveOption === 2) {
                gameResult('Computador', userMove, computerMove)
            }
        
            // Caso a escolha seja TESOURA
            else if (userMoveOption === 2 && computerMoveOption === 1) {
                gameResult('Usuário', userMove, computerMove)            
            } else if (userMoveOption === 2 && computerMoveOption === 0) {
                gameResult('Computador', userMove, computerMove)
            }  

        }

    } catch (error) {
        console.log(error)
    }
}

// Chamada da função que traz o cabeçalho do desafio
challengeHeader()


// Criação da pergunta e leitura da resposta no terminal
rl.question('Faça sua escolha, digite um número dentre as opções listadas: ', (userMove) => {
    // Limpeza do console para melhor visibilidade
    console.clear()

    // Fechamento da instância da interface que permite a entrada dos dados no terminal
    rl.close()
    
    // Chamada da função startGame() que depende da variável `userMove`
    startGame(userMove - 1)
})