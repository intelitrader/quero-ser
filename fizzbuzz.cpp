#include <iostream>

using namespace std;

int main(int argc, char const *argv[]){

	for(int number = 1; number <= 100; number++) {
		if(number %5 == 0 && number % 3 == 0) {
			cout << "FizzBuzz" << endl;
		} else if(number % 3 == 0) {
			cout << "Fizz" << endl;
		} else if(number % 5 == 0) {
			cout << "Buzz" << endl;
		} else {
			cout << number << endl;
		}
	}

	return 0;
}