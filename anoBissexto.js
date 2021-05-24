var anoBissexto = prompt("Digite o Ano");

if(anoBissexto%4 == 0)
{
    console.log("O Ano de: " + anoBissexto + " é um ano bissexto")
    
} else if(anoBissexto%100 == 0 && anoBissexto%400 == 0 ){
    
            console.log("O Ano de: " + anoBissexto + " é um ano bissexto")
        }