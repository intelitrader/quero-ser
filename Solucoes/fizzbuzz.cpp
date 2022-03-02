#include <iostream>
using namespace std;

//https://dojopuzzles.com/problems/fizzbuzz/

//Declaração da função fizzbuzz
void fizzbuzz(){  
  for(int i = 1; i < 101; i++){
    if((i%3 == 0) && (i%5 == 0)){
      cout << "FizzBuzz";
    } else if(i%3 == 0){
      cout << "Fizz";  
    } else if(i%5 == 0){
      cout << "Buzz";  
    } else{
      cout << i ;
    }
    cout << "\n";
  }  
}

int main() {
  //Chamada da função
  fizzbuzz();  
}

