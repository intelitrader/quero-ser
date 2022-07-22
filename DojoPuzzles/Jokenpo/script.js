const form = document.getElementById('play-form')
const choose = document.getElementById('choose')

const jokenpo = ['Pedra','Papel','Tesoura']

form.addEventListener('submit',event=>{   
    event.preventDefault()

    const machineRandom =()=> Math.round(Math.random()*2)
    const machinePlay = machineRandom()
    
    switch (choose.value){
        case 'Pedra':
        if(machinePlay === 1){
            console.log(jokenpo[machinePlay], 'ganha de ', choose.value ,' você perdeu :(')
        }else if(machinePlay === 2){
            console.log(choose.value,' ganha de ', jokenpo[machinePlay],'voce ganhou B) !!')
        }else{
            console.log(choose.value, ' e ', jokenpo[machinePlay], ' são iguais... Empate!')
        }
        break;
        case 'Papel': 
        if(machinePlay === 2){
            console.log(jokenpo[machinePlay], 'ganha de ', choose.value ,' você perdeu :(')
        }else if(machinePlay === 0){
            console.log(choose.value,' ganha de ', jokenpo[machinePlay],'voce ganhou B) !!')
        }else{
            console.log(choose.value, ' e ', jokenpo[machinePlay], ' são iguais... Empate!')
        }
        break;
        case 'Tesoura': 
        if(machinePlay === 0){
            console.log(jokenpo[machinePlay], 'ganha de ', choose.value ,' você perdeu :(')
        }else if(machinePlay === 1){
            console.log(choose.value,' ganha de ', jokenpo[machinePlay],'voce ganhou B) !!')
        }else{
            console.log(choose.value, ' e ', jokenpo[machinePlay], ' são iguais... Empate!')
        }
        break
    }

})

