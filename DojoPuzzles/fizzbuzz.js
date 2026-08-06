
// https://dojopuzzles.com/problems/fizzbuzz/


//É utilizada a estrutura de repetição For para a listagem de números de 1 a 100 (um em cada linha)
console.log('DojoPuzzle:  FizzBuzz  ')
for (let i = 1;i <= 100; i++){
	// Se o número for divisível por 3 e 5 ao mesmo tempo (logo divisível por 15, pois 3 x 5 == 15), ao invés do número será exibido 'FizzBuzz' no console
	if(i%15 == 0){
		console.log('FizzBuzz')
	}
	// Se o número for divisível por 3, ao invés do número será exibido 'Fizz' no console
	else if(i%3 == 0 ){
	console.log('Fizz')
	// Se o número for divisível por 5, ao invés do número será exibido 'Buzz' no console
	}else if(i%5 == 0){
		console.log('Buzz')
	}
	// Caso o valor não seja compatível com as condições acima, será listado o número
	else{
		console.log(i)
	}
}