#pragma once
#include <cstdint>  // uint8_t, uint16_t, uint64_t
#include <cstdlib>  // rand(), srand(unsigned int)
#include <iostream> // cout
#include <ctime>    // time()

/* Classe GameOfLife contém toda lógica por trás do Jogo da Vida*/
template <uint8_t wid, uint8_t hei, uint8_t starv = 2, uint8_t overpop = 3, uint8_t revive = 3>
class GameOfLife
{
public:
    GameOfLife(uint64_t loops) : nLoops(loops)
    {
        InitWorld();
        std::cout << "Jogo da Vida criado.\nO jogo tera " << nLoops << " turnos.";
        Loop();
    }

    ~GameOfLife()
    {
        std::cout << "\n\n\nJogo da Vida finalizado!\n";
    }

private:
    bool m_world[2][hei][wid];   // Dois tabuleiros de dimensão widxhei
    uint64_t nLoops;             // Número de iterações no loop

    /* Executa nLoops interações no jogo */
    void Loop()
    {
        for (uint64_t time = 0; time < nLoops; time++)
        {
            std::cout << "\n\n\nFrame " << time + 1 << ":\n\n";

            for (uint8_t y = 0; y < hei; y++)
            {
                for (uint8_t x = 0; x < wid; x++)
                {
                    /* Verifica estado atual das células a partir da iteração anterior*/
                    bool b = UpdateCell(x, y, (time + 1)&0x1);

                    /* Passa seu estado pro mundo atual e imprime */
                    m_world[time&0x1][y][x] = b;
                    std::cout << (b ? 'O' : '-');
                }

                std::cout << std::endl;
            }
        }
    }

    /* Retorna estado da celula (x,y) (viva ou morta)*/
    bool UpdateCell(int16_t x, int16_t y, uint8_t buf)
    {
        /* Contador de vizinhos vivos */
        uint8_t aliveNbs = 0;

        /* Verifica células vizinhas */
        for (int16_t i = -1; i <= 1; i++)
        {
            uint16_t row = y + i;

            /* Ignora bordas do tabuleiro */
            if (row < 0) continue;
            else if (row >= wid) break;
            
            for (int16_t j = -1; j <= 1; j++)
            {
                uint16_t col = x + j;

                /* Ignora bordas do tabuleiro */
                if (col < 0) continue;
                else if (col >= hei) break;


                if (m_world[buf][row][col])
                    aliveNbs++;
            }

        }

        /* Como uma célula não pode ser vizinha dela mesma, decrementa-se 1 de aliveNbs caso esteja viva */
        if (m_world[buf][y][x])
            aliveNbs--;

        /* Se tem menos vizinhos que o número de inanição ou mais que o número de sobrepopulação, célula morre */
        if (aliveNbs < starv || aliveNbs > overpop)
            return false;

        /* Se tem o número de vizinhos para reviver, célula se torna viva */
        if (aliveNbs == revive)
            return true;

        /* Caso contrário, célula mantém-se no mesmo estado anterior */
        return m_world[buf][y][x];
    }

    /* Inicializa mundo aleatório */
    void InitWorld()
    {
        /* Inicializa gerador de números aleatórios */
        std::srand((unsigned int) std::time(NULL));

        for (uint8_t row = 0; row < hei; row++)
            for (uint8_t col = 0; col < wid; col++)
                m_world[1][row][col] = rand() % 2; // Probabilidade das células estarem vivas é de 50%
                
    }
};

