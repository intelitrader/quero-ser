#pragma once
#include <iostream> // cout, endl
#include <cstring>  // string, strlen(const char *)
#include <list>     // list<T>
#include <cstdint>  // uint8_t

/* Função StrSwap troca de posição os elementos na posição a e b da string str*/
void StrSwap(std::string& str, uint8_t a, uint8_t b)
{
	char aux = str[a];
	str[a] = str[b];
	str[b] = aux;
}

/* Função recursiva _Anagrama */
void _Anagrama(std::string str, uint8_t pos, std::list<std::string>& list, const uint8_t len)
{
	if (pos < 1)
	{
		list.emplace_back(str);
		return;
	}

	_Anagrama(str, pos - 1, list, len);
	for (uint8_t i = 1, k = len - pos; i < pos; i++)
	{
		StrSwap(str, k, k + i);
		_Anagrama(str, pos - 1, list, len);
	}

}

/* Chama função recursiva _Anagrama e retorna std::list contendo permutações da string str*/
std::list<std::string> Anagrama(const char* str)
{
	std::list<std::string> a_list;
	const uint8_t len = (uint8_t)std::strlen(str);

	_Anagrama(str, len, a_list, len);

	return a_list;
}

/* Imprime anagramas da string str*/
void PrintAnagrama(const char* str)
{
	for (std::string str : Anagrama(str))
		std::cout << str << std::endl;
}


