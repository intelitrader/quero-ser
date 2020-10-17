#pragma once
#include <vector>
#include <iostream>
#include <cstdint>

char NumToChar(uint8_t num)
{
	return num + '0';
}

std::vector<char> _LookAndSay(uint8_t index, uint8_t counter, std::vector<char>& in, std::vector<char>& out, uint8_t iterations)
{
	if (index >= in.size())
	{
		out.emplace_back(counter);
		out.emplace_back(in[index - 1]);

		if (iterations - 1 == 0)
			return out;

		in.clear();
		return _LookAndSay(1, 1, out, in, iterations - 1);
	}

	if (in[index] != in[index - 1])
	{
		out.emplace_back(counter);
		out.emplace_back(in[index - 1]);
		counter = 0;
	}

	return _LookAndSay(index + 1, counter + 1, in, out, iterations);
}

std::vector<char> LookAndSay(uint8_t firstNum, uint8_t iterations)
{
	std::vector<char> in, empty;
	in.emplace_back(firstNum);

	return _LookAndSay(1, 1, in, empty, iterations);
}