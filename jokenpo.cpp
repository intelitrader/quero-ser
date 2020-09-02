#include <iostream>

using namespace std;

int main(int argc, char const *argv[]){
	int firstPlayer;
	int secondPlayer;
	cout << "------INSTRUCTIONS------" << endl;
	cout << "\tType 1 for Rock" << endl;
	cout << "\tType 2 for Paper" << endl;
	cout << "\tType 3 for Scissors\n" << endl;

	cout << "First Player : ";
	cin >> firstPlayer;

	cout << "Second Player : ";
	cin >> secondPlayer;

	if (firstPlayer == 1) {
		if (secondPlayer == 1) {
			cout << "You tied the game!" << endl;
		} else if(secondPlayer == 2) {
			cout << "Second player win the game!" << endl;
		} else if(secondPlayer == 3) {
			cout << "First player win the game!" << endl;
		} else {
			cout << "Invalid Operation" << endl;
		}
	} else if(firstPlayer == 2) {
		if (secondPlayer == 1) {
			cout << "First player win the game!" << endl;
		} else if(secondPlayer == 2) {
			cout << "You tied the game!" << endl;
		} else if(secondPlayer == 3) {
			cout << "Second player win the game!" << endl;
		} else {
			cout << "Invalid Operation" << endl;
		}
	} else if(firstPlayer == 3) {
		if (secondPlayer == 1) {
			cout << "Second player win the game!" << endl;
		} else if(secondPlayer == 2) {
			cout << "First player win the game!" << endl;
		} else if(secondPlayer == 3) {
			cout << "You tied the game!" << endl;
		} else {
			cout << "Invalid Operation" << endl;
		}
	} else {
		cout << "Invalid Operation" << endl;
	}

	return 0;
}