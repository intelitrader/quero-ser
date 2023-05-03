// Define os jogadores e suas pontuações
let player1 = {
    name: "Player 1",
    score: 0
};

let player2 = {
    name: "Player 2",
    score: 0
};

// Define as pontuações correspondentes a cada fase do jogo
const SCORES = ["0", "15", "30", "40"];

// Retorna o nome do jogador com a maior pontuação
function getLeadingPlayerName() {
    if (player1.score > player2.score) {
        return player1.name;
    } else {
        return player2.name;
    }
}

// Retorna o nome do jogador que está em vantagem
function getAdvantagePlayerName() {
    if (player1.score > player2.score) {
        return player1.name;
    } else {
        return player2.name;
    }
}

// Retorna true se o jogo estiver empatado
function isDeuce() {
    return player1.score >= 40 && player2.score === player1.score;
}

// Retorna true se um dos jogadores tiver vantagem
function hasAdvantage() {
    return Math.abs(player1.score - player2.score) === 10 && player1.score >= 40;
}

// Retorna true se o jogo tiver acabado
function isGameOver() {
    return player1.score >= 40 && Math.abs(player1.score - player2.score) >= 2;
}

// Atualiza a pontuação de um jogador
function updateScore(player) {
    switch (player.score) {
        case 0:
            player.score = 15;
            break;
        case 15:
            player.score = 30;
            break;
        case 30:
            player.score = 40;
            break;
        case 40:
            if (isDeuce()) {
                player.score = "AD";
            } else if (hasAdvantage()) {
                player.score = "AD";
            } else {
                player.score = "WIN";
            }
            break;
        case "AD":
            player.score = "WIN";
            break;
    }
}

// Simula um ponto marcado por um jogador
function scorePoint(player) {
    updateScore(player);
    if (!isGameOver()) {
        if (player.score === "WIN") {
            console.log(`${player.name} wins the game!`);
        } else if (isDeuce()) {
            console.log("Deuce!");
        } else if (hasAdvantage()) {
            console.log(`${getAdvantagePlayerName()} has the advantage`);
        } else {
            console.log(`${player.name} scores!`);
        }
    } else {
        console.log(`${player.name} wins the game!`);
    }
}

// Simula um jogo completo
function playGame() {
    while (!isGameOver()) {
        if (Math.random() < 0.5) {
            scorePoint(player1);
        } else {
            scorePoint(player2);
        }
    }
}

// Inicia o jogo
playGame();
