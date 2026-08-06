const jokenpo = (jogador1, jogador2) => {    
    const itens = [jogador1.toLowerCase(), jogador2.toLowerCase()];

    if (itens[0] === 'pedra' && itens[1] === 'pedra') {
        console.log('Empate')
    } else if (itens.indexOf('pedra') !== -1 && itens.indexOf('tesoura') !== -1) {
        console.log('Pedra vence!')
    } else if (itens[0] === 'tesoura' && itens[1] === 'tesoura') {
        console.log('Empate')
    } else if (itens.indexOf('tesoura') !== -1 && itens.indexOf('papel') !== -1) {
        console.log('Tesoura vence!')
    } else if (itens[0] === 'papel' && itens[1] === 'papel') {
        console.log('Empate')
    } else if (itens.indexOf('papel') !== -1 && itens.indexOf('pedra') !== -1) {
        console.log('Papel vence!')
    } else {
        console.error('Escolha pedra, papel ou tesoura.')
    }
}

jokenpo('papel', 'pedra')