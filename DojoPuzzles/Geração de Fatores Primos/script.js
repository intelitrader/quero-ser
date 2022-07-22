const form = document.getElementById("form")
const input = document.getElementById("input")
const fator = []

const looping = () => {
    let num = input.value

    while (num != 1) {
        if (num % 2 == 0) {
            num /= 2
            fator.push(2)
        } else if (num % 3 == 0) {
            num /= 3
            fator.push(3)
        } else if (num % 5 == 0) {
            num /= 5
            fator.push(5)
        } else if (num % 7 == 0) {
            num /= 7
            fator.push(7)
        } else if (num % 11 == 0) {
            num /= 11
            fator.push(11)
        } else if (num % 13 == 0) {
            num /= 13
            fator.push(13)
        } else if (num % 17 == 0) {
            num /= 17
            fator.push(17)
        } else if (num % 19 == 0) {
            num /= 19
            fator.push(19)
        } else if (num % 23 == 0) {
            num /= 23
            fator.push(23)
        } else {
            fator.push(num)
        }
    }
}

form.addEventListener('submit', event => {
    event.preventDefault()
    looping()

    const fatores = fator.join(" X ");
    console.log(input.value,' = ',fatores)
    input.value = ''
    
})
