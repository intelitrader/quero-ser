function jogar(){
    const Jogador1 = prompt('Primeiro jogador, digite o seu nome:')
    const Jogador2 = prompt("Segundo jogador, digite o seu nome:")
    
    
    const primeiraJogada = prompt("Jogador 1, digite pedra, papel ou tesoura:")
    const segundaJogada = prompt("Jogador 2, digite pedra, papel ou tesoura:")
    
    
    if(primeiraJogada === "pedra" && segundaJogada === "pedra"){
        return alert('Deu empate! Atualize a página para jogar novamente!')
    } else if(primeiraJogada === "papel" && segundaJogada === "papel") {
        return alert('Deu empate! Atualize a página para jogar novamente!')
    } else if(primeiraJogada === "tesoura" && segundaJogada === "tesoura") {
        return alert('Deu empate! Atualize a página para jogar novamente!')
    }

    if(primeiraJogada === "pedra" && segundaJogada === "tesoura") {
        return alert(`${Jogador1} venceu! Atualize a página para jogar novamente!`)
    } else if(primeiraJogada === "pedra" && segundaJogada === "papel") {
        return alert(`${Jogador2} venceu! Atualize a página para jogar novamente!`)
    }

    if(primeiraJogada === "papel" && segundaJogada === "tesoura") {
        return alert(`${Jogador2} venceu! Atualize a página para jogar novamente!`)
    } else if(primeiraJogada === "papel" && segundaJogada === "pedra") {
        return alert(`${Jogador1} venceu! Atualize a página para jogar novamente!`)
    }

    if(primeiraJogada === "tesoura" && segundaJogada === "pedra") {
        return alert(`${Jogador2} venceu! Atualize a página para jogar novamente!`)
    } else if(primeiraJogada === "tesoura" && segundaJogada === "papel") {
        return alert(`${Jogador1} venceu! Atualize a página para jogar novamente!`)
    }
}

jogar()