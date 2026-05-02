/*
  O objetivo é fazer um juiz de Jokenpo que dada a jogada dos dois jogadores informa o resultado da partida.
  As regras são as seguintes:
    >Pedra empata com Pedra e ganha de Tesoura;
    >Tesoura empata com Tesoura e ganha de Papel;
    >Papel empata com Papel e ganha de Pedra.
*/

console.log("Jokenpo Puzzle:");

function playJokenpo(P1) {
  const CPUChoices = ["paper", "rock", "scissor"];
  const randomChoice = Math.floor(Math.random() * 3);
  let CPU = CPUChoices[randomChoice];

  console.log(`P1: ${P1} x CPU: ${CPU}`);

  if (P1 === CPU) {
    console.log("Result: Draw.");
  } else {
    switch (P1 + CPU) {
      case "paperrock":
        return console.log("Result: paper wins!");
      case "paperscissor":
        return console.log("Result: scissor wins!");
      case "rockpaper":
        return console.log("Result: paper wins!");
      case "rockscissor":
        return console.log("Result: rock wins!");
      case "scissorpaper":
        return console.log("Result: scissor wins!");
      case "scissorrock":
        return console.log("Result: rock wins!");
    }
  }
}

playJokenpo("paper");
playJokenpo("rock");
playJokenpo("scissor");

console.log("-----------------------------");
