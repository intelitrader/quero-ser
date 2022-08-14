const hallLights = (qty: number): string[] => {
    let lightsStates: boolean[] = [];
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
    })

    return result;
};

console.log(hallLights(3));