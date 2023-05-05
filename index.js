import  { executar } from './src/app.js';

console.log("==========================\n");
console.log("Executando o programa...\n");

try{
  executar();
} catch(err) {
  console.log("A aplicação teve algum erro de execução: " + err);
}


console.log("Programa finalizado - Arquivos gerados se encontram na pasta 'resultados' na raíz do projeto\n");
console.log("==========================");