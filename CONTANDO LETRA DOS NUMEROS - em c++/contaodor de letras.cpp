#include <stdio.h>
#include <iostream>

//

int numLetters1_19[] = 
{
    sizeof("one") - 1,
    sizeof("two") - 1,
    sizeof("three") - 1,
    sizeof("four") - 1,
    sizeof("five") - 1,
    sizeof("six") - 1,
    sizeof("seven") - 1,
    sizeof("eight") - 1,
    sizeof("nine") - 1,
    sizeof("ten") - 1,
    sizeof("eleven") - 1,
    sizeof("twelve") - 1,
    sizeof("thirteen") - 1,
    sizeof("fourteen") - 1,
    sizeof("fifteen") - 1,
    sizeof("sixteen") - 1,
    sizeof("seventeen") - 1,
    sizeof("eighteen") - 1,
    sizeof("nineteen") - 1,
};

int numLetters2Tens[] =
{
    sizeof("twenty") - 1,
    sizeof("thirty") - 1,
    sizeof("forty") - 1,
    sizeof("fifty") - 1,
    sizeof("sixty") - 1,
    sizeof("seventy") - 1,
    sizeof("eighty") - 1,
    sizeof("ninety") - 1,
};

#define GET_NUM_LETTERS_1_19(N) numLetters1_19[N - 1]
#define GET_NUM_LETTERS_2Tens(N) numLetters2Tens[N - 2]

int numLettersHundred = sizeof("hundred") - 1;
int numLettersAnd = sizeof("and") - 1;
int numLettersThound = sizeof("thousand") - 1;

int countLettersLessThan1000(int num)
{
    int numLetters = 0;

    int nThousand = num / 1000;
    if (nThousand > 0)
    {
        numLetters += GET_NUM_LETTERS_1_19(nThousand);
        numLetters += numLettersThound;
    }

    num = num % 1000;

    int nHundred = num / 100;
    bool hasHundred = false;
    if (nHundred > 0)
    {
        numLetters += GET_NUM_LETTERS_1_19(nHundred);
        numLetters += numLettersHundred;
        hasHundred = true;
    }

    num = num % 100;

    if (num > 0)
    {
        if (hasHundred)
        {
            numLetters += numLettersAnd;
        }

        if (num <= 19)
        {
            numLetters += GET_NUM_LETTERS_1_19(num);
        }
        else
        {
            int nTens = num / 10;
            numLetters += GET_NUM_LETTERS_2Tens(nTens);

            num = num % 10;

            if (num > 0)
            {
                numLetters += GET_NUM_LETTERS_1_19(num);
            }
        }
    }

    return numLetters;
}

int main(int argc, char* argv[])
{
	int num=0;
	for (num=1; num <=1000; num++){
		
	printf ("%d\n", num);
}
    int totalNumLetters = 0;

    for (int i = 1; i <= 1000; ++i)
    {
        totalNumLetters += countLettersLessThan1000(i);
    }
	
    printf("Resultado se todos os numeros de 1 ate 1000 fossem escritos em palavras: %d\n\n", totalNumLetters);

	system("pause");
    return 0;
}







	
