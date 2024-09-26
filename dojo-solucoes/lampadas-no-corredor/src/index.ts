import * as readline from 'node:readline';
import { stdin, stdout } from 'process';

// Função que cria e checa as lâmpadas no corredor
const hallLights = (qty: number): string[] => {
    const lightsStates: boolean[] = [];
    const lightsPositions: number[] = [];
    for (let i = 0; i < qty; i++) {
        lightsStates.push(false);
        lightsPositions.push(i+1);
    } 

    for (let i = 0; i < qty; i++) {
        for (let j = 0; j < lightsPositions.length; j++) {
            if (lightsPositions[j] % ( i + 1 ) === 0) lightsStates[j] = !lightsStates[j];
        }
    }

    const result: string[] = lightsStates.map((state) => {
        if (state === true) {
            return 'on';
        }
        else {
            return 'off';
        }   
    });

    return result;
};

const rl: readline.Interface = readline.createInterface({
    input: stdin,
    output: stdout
});

rl.question('Por gentileza insira o número de lâmpadas presentes no corredor -> ', (answer: string) => {
    console.log(hallLights(Number(answer)));
    rl.close();
});