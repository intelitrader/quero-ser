#include <iostream>

using namespace std;

int main(int argc, char const *argv[]){
	int value;
	int oneHundred;
	int fifty;
	int twenty;
	int ten;

	cout << "Type the value: ";
	cin >> value;

	oneHundred = value/100;
	value = value%100;

	fifty = value/50;
	value = value%50;

	twenty = value/20;
	value = value%20;

	ten = value/10;
	value = value%10;

	if(oneHundred > 0) {
		cout << "Bank note of $100 : " << oneHundred << endl;
	}
	if(fifty > 0) {
		cout << "Bank note of $50 : " << fifty << endl;
	}
	if(twenty > 0) {
		cout << "Bank note of $20 : " << twenty << endl;
	}
	if(ten > 0) {
		cout << "Bank note of $10 " << ten << endl;
	}

	return 0;
}