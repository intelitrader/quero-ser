# Desafios selecionados - DojoPuzzles.com

**3 Testes**

### 1 Desafio - FizzBuzz

Neste problema, você deverá exibir uma lista de 1 a 100, um em cada ha, com as seguintes exceções:- Números divisíveis por 3 deve aparecer como 'Fizz' ao invés do número;

- Números divisíveis por 5 devem aparecer como 'Buzz' ao invés do número;
- Números divisíveis por 3 e 5 devem aparecer como 'FizzBuzz' ao invés do número'.

### 2 Desafio - Jokempo

Jokenpo é uma brincadeira japonesa, onde dois jogadores escolhem um dentre três possíveis itens: Pedra, Papel ou Tesoura
O objetivo é fazer um juiz de Jokenpo que dada a jogada dos dois jogadores informa o resultado da partida

**As regras são as seguintes**

    - Pedra empata com Pedra e ganha de Tesoura
    - Tesoura empata com Tesoura e ganha de Papel
    - Papel empata com Papel e ganha de Pedra

- **instruções para ver a resolução**

  - Crie uma pasta com o nome jokenpo
  - Rodo o seguinte comando na pasta `npm init -y `
  - Execulte o comando ` node index.js` no terminal local
  - Pronto é só testar

### 3 Desafio - Analisando URL's

Dada uma URL, desenvolva um programa que indique se a URL é válida ou não e, caso seja válida, retorne as suas partes constituintes.

Exemplos:

- Entrada: http://www.google.com/mail/user=fulano

**Saída:**

    - protocolo: http
    - host: www
    - domínio: google.com
    - path: mail
    - parâmetros: user=fulano

- Entrada: ssh://fulano%senha@git.com/

**Saída:**

    - protocolo: ssh
    - usuário: fulano
    - senha: senha
    - dominio: git.com
