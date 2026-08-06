const spiralMatrix = (columns, rows) => {
    const matrix = [];
    matrix.length = rows;
    
    for (let i = 0; i < matrix.length; i++) {
        const arr = [];
        arr.length = columns;
        matrix[i] = arr;
    }

    let row = 0;
    let column = 0;
    let rowEnd = rows - 1;
    let columnEnd = columns - 1;
    let counter = 1;
    
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

describe('Testes da função spiralMatrix', () => {
    test('Testando para matriz de 3 x 4', () => {
        const result = spiralMatrix(3, 4);
        console.log(result);
        expect(result).toEqual([[1, 2, 3], [10, 11, 4], [9, 12, 5], [8, 7, 6]]);
    });
    
    test('Testando para matriz de 5 x 6', () => {
        const result = spiralMatrix(5, 6);
        console.log(result);
        expect(result).toEqual([[1, 2, 3, 4, 5], [18, 19, 20, 21, 6], [17, 28, 29, 22, 7], [16, 27, 30, 23, 8], [15, 26, 25, 24, 9],[14, 13, 12, 11, 10]]);
    });
});