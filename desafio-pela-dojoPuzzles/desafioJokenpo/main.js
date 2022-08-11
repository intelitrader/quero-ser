/*
Jokenpo
Endereço: https://dojopuzzles.com/problems/jokenpo/
Jokenpo é uma brincadeira japonesa, onde dois jogadores escolhem um dentre três possíveis itens: Pedra, Papel ou Tesoura.
O objetivo é fazer um juiz de Jokenpo que dada a jogada dos dois jogadores informa o resultado da partida.
As regras são as seguintes:
Pedra empata com Pedra e ganha de Tesoura
Tesoura empata com Tesoura e ganha de Papel
Papel empata com Papel e ganha de Pedra
 */

const btns = document.querySelectorAll('[data-id]')
const primeiroPasso = document.querySelector('[data-js="primeiroPasso"]')
const segundoPasso = document.querySelector('[data-js="segundoPasso"]')
const containerBtnComputer  = document.querySelector('[data-js="containerBtnComputer"]')
const containerBtnUser  = document.querySelector('[data-js="containerBtnUser"]')
const containerToBackHome = document.querySelector('[data-js="toBackHome"]')
const message = document.querySelector('[data-js="menssage"]')


const options = [ 'papel', 'tesoura', 'pedra' ]

function draw() {
    message.innerHTML = 'EMPATE'
    toggleShowOptionsToBack()
    containerBtnUser.classList.remove('active')
    containerBtnComputer.classList.remove('active')
}

function vencedor() {
    message.innerHTML = 'GANHOU'
    containerBtnUser.classList.add('active')
    containerBtnComputer.classList.remove('active')
    toggleShowOptionsToBack()
}

function perdedor() {
    message.innerHTML = 'PERDEU'
    containerBtnUser.classList.remove('active')
    containerBtnComputer.classList.add('active')
    toggleShowOptionsToBack()
}

function toggleShowOptionsToBack() {
    containerToBackHome.classList.toggle('show')
}

function createNewButton( tagName, className, option ) {
    const element = document.createElement(tagName)
    element.classList.add( className )
    const img = document.createElement('img')
    img.src = `assets/img-${options[option]}.png`
    element.appendChild(img)
    return element
}

function appendButtonUser(option) {
    const buttonUser = createNewButton('button', `btn${options[option]}`, option)
    containerBtnUser.replaceChildren(buttonUser)
}

function appendButtonComputer(option) {
    const buttonComputer = createNewButton('button', `btn${options[option]}`, option)

    containerBtnComputer.replaceChildren(buttonComputer)
}

function showWhoWin( userOptions, computerOptions, userWon ) {
    primeiroPasso.classList.remove('show')
    segundoPasso.classList.add('show')

    appendButtonUser(userOptions)
    setTimeout(() => {
        appendButtonComputer(computerOptions)

        if ( userWon === 'empate' ) return draw()
        userWon ? vencedor() : perdedor()
    }, 400);


}

function verificaVecedor( userOptions, computerOptions ) {
    if ( userOptions === 0 ) {
        if ( computerOptions === 0 ) {
            return 'empate'
        } else if ( computerOptions === 1 ) {
            return false
        } else {
            return true
        }
    }
    if ( userOptions === 1 ) {
        if ( computerOptions === 0 ) {
            return true
        } else if ( computerOptions === 1 ) {
            return 'empate'
        } else {
            return false
        }
    } else {
        if ( computerOptions === 0 ) {
            return false
        } else if ( computerOptions === 1 ) {
            return true
        } else {
            return 'empate'
        }
    }
}

const getUserOptions = ( button ) => Number(button.getAttribute('data-id'))

function handleClick () {
    const userOptions = getUserOptions( this )
    const computerOptions = Math.floor( Math.random() * 3 )

    const userWon = verificaVecedor( userOptions, computerOptions )
    showWhoWin( userOptions, computerOptions, userWon )
}

btns.forEach( btn => {
    btn.addEventListener('click', handleClick)
})
