//Nomes de Autores de Obras - Dojo Puzzles -https://dojopuzzles.com/problems/nomes-de-autores-de-obras-bibliograficas/

const nomes = [
  "Kafka",
  "Felipe Memória",
  "José de Alencar",
  "Fábio Joaquim dos Santos de Jesus",
  "Alexandre Dumas Neto",
  "Vinicius Miranda Souza Tavares"
];

const finalNames = [
  "Filho",
  "Filha",
  "Neto",
  "Neta",
  "Sobrinho",
  "Sobrinha",
  "Junior"
];

const prepositions = ["da", "de", "do", "das", "dos"];

function capitalizeName(name: string): string {
  return name.charAt(0).toUpperCase() + name.slice(1);
}

function formatName(fullname: string): string {
  let nameFormatted: string;
  let nameWords = fullname.split(" ");

  //um nome
  if (nameWords.length === 1) {
    nameFormatted = nameWords[0].toUpperCase();
  }

  //dois nomes
  if (nameWords.length === 2) {
    nameFormatted =
      nameWords[1].toUpperCase() + ", " + capitalizeName(nameWords[0]);
  }

  //três ou mais nomes
  if (nameWords.length >= 3) {
    let lastName = capitalizeName(nameWords[nameWords.length - 1]);
    let firstNames = "";

    //nomes finais
    finalNames.map((finalName: string) => {
      if (lastName === capitalizeName(finalName)) {
        lastName = nameWords[nameWords.length - 2] + " " + lastName;
      }
    });

    // nomes iniciais
    nameWords.map((name: string) => {
      if (name !== lastName && !lastName.includes(name)) {
        prepositions.map((preposition) => {
          if (name !== preposition) {
            capitalizeName(name);
          }
        });

        firstNames = firstNames + " " + name;
      }
    });

    nameFormatted = lastName.toUpperCase() + ", " + firstNames.slice(1);
  }

  return nameFormatted;
}

const formattedName = formatName(nomes[0]);
console.log(formattedName);

//LOGS
// input: Kafka                                output: KAFKA
// input: Felipe Memória                       output: MEMÓRIA, Felipe
// input: José de Alencar                      output: ALENCAR, José de
// input: Fábio Joaquim dos Santos de Jesus    output: JESUS, Fábio Joaquim dos Santos de
// input: Alexandre Dumas Neto                 output: DUMAS NETO, Alexandre
// input: Vinicius Miranda Souza Tavares       output: TAVARES, Vinicius Miranda Souza
