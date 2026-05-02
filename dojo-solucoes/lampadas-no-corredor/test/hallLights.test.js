const hallLights = (qty) => {
    const lightsStates = [];
    const lightsPositions = [];
    for (let i = 0; i < qty; i++) {
        lightsStates.push(false);
        lightsPositions.push(i+1);
    } 

    for (let i = 0; i < qty; i++) {
        for (let j = 0; j < lightsPositions.length; j++) {
            if (lightsPositions[j] % ( i + 1 ) === 0) lightsStates[j] = !lightsStates[j];
        }
    }

    const result = lightsStates.map((state) => {
        if (state === true) {
            return 'on';
        }
        else {
            return 'off';
        }   
    });

    return result;
};

test('Teste para o número de lâmpadas igual à 3', () => {
    const result = hallLights(3);
    console.log(result);
    expect(result).toEqual(['on', 'off', 'off']); 
});