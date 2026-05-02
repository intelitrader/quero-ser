import * as readline from 'node:readline';
import { stdin, stdout } from 'process';

// Tipágem da saída
export type Matrix = number[][];

// função que cria a Matriz dado o número de linhas e colunas
export const spiralMatrix = (columns: number, rows: number): Matrix => {
    const matrix: Matrix = [];
    matrix.length = rows;
    
    for (let i = 0; i < matrix.length; i++) {
        const arr: number[] = [];
        arr.length = columns;
        matrix[i] = arr;
    }

    let row: number = 0;
    let column: number = 0;
    let rowEnd: number = rows - 1;
    let columnEnd: number = columns - 1;
    let counter: number = 1;
    
    while (column <= columnEnd && row <= rowEnd) {
        
        for (let i = column; i <= columnEnd; i++) {
            matrix[row][i] = counter;
            counter++;
        }
        row++;     
        
        for (let i = row; i <= rowEnd; i++) {
            matrix[i][columnEnd] = counter;
            counter++;
        }
        columnEnd--;

        for (let i = columnEnd; i >= column; i--) {
            matrix[rowEnd][i] = counter;
            counter++;
        }
        rowEnd--;

        for (let i = rowEnd; i >= row; i--) {
            matrix[i][column] = counter;
            counter++;
        }
        column++;
        
    }
            
    return matrix;
};

const rl: readline.Interface = readline.createInterface({
    input: stdin,
    output: stdout
});

rl.question('Por gentileza insira o número de colunas -> ', (answer: string) => {
    rl.question('E agora o número de linhas -> ', (answer2: string) => {
        const columns: number = Number(answer);
        const rows: number = Number(answer2);
        console.log('Sua Matriz espiral em sentido horário é:', spiralMatrix(columns, rows));
        rl.close();
    })
});