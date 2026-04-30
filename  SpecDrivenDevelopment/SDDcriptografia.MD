# SDD - Desafio de Descriptografia de Rede (Intelitrader)

## 1. Visão Geral
Este documento descreve a especificação técnica para a tradução de mensagens capturadas em uma rede naval. A solução foca em manipulação de bits (bitwise operations) para reverter um processo de cifragem simétrica de baixa complexidade, priorizando performance $O(n)$ e consumo de memória constante.

## 2. Análise do Problema
A criptografia aplicada a cada byte (8 bits) segue duas regras:
1. **Bit Flip:** Inversão dos dois últimos bits.
2. **Nibble Swap:** Troca dos 4 bits mais significativos (High Nibble) pelos 4 menos significativos (Low Nibble).

### 2.1 Engenharia Reversa
Para restaurar a mensagem original, aplicamos o caminho inverso:
1. **Passo 1 (Swap):** Reverter a posição dos nibbles.
2. **Passo 2 (XOR):** Reverter a inversão dos dois últimos bits.

## 3. Arquitetura da Solução

### 3.1 Operadores Bitwise Utilizados
Para atingir performance máxima e evitar o uso de estruturas condicionais (`if/else`), utilizamos:
* **AND (`&`) com Máscaras:** Para isolar os nibbles (`0xF0` e `0x0F`).
* **Shifting (`<<` e `>>`):** Para deslocar os bits para as novas posições.
* **XOR (`^`) com Máscara `0x03`:** Para inverter os bits de posição 0 e 1 simultaneamente em um único ciclo de instrução.

### 3.2 Complexidade Algorítmica
* **Tempo:** $O(n)$, onde $n$ é o comprimento da mensagem.
* **Espaço:** $O(1)$ de memória auxiliar (excluindo o buffer de saída).

## 4. Implementação (C# / .NET 9)

```csharp
using System;
using System.Text;
using System.Linq;

public class Decryptor
{
    public static void Main()
    {
        string input = "10010110 11110111 01010110 00000001 00010111 00100110 01010111 00000001 00010111 01110110 01010111 00110110 11110111 11010111 01010111 00000011";
        
        string result = Decrypt(input);
        
        Console.WriteLine("--- Mensagem Descriptografada ---");
        Console.WriteLine(result);
    }

    public static string Decrypt(string encryptedData)
    {
        var binaries = encryptedData.Split(' ');
        byte[] decryptedBytes = new byte[binaries.Length];

        for (int i = 0; i < binaries.Length; i++)
        {
            byte b = Convert.ToByte(binaries[i], 2);

            // 1. Reverter Nibble Swap (4 bits)
            // Isola os nibbles e desloca 4 posições
            int swapped = ((b & 0x0F) << 4) | ((b & 0xF0) >> 4);

            // 2. Reverter Bit Flip (Últimos 2 bits)
            // XOR com 00000011 (0x03) inverte apenas os bits 0 e 1
            int original = swapped ^ 0x03;

            decryptedBytes[i] = (byte)original;
        }

        return Encoding.ASCII.GetString(decryptedBytes);
    }
}

5. Justificativa Técnica (Decisões de Design)
Uso de XOR: Escolhido por ser uma operação involutiva ($ (x \oplus y) \oplus y = x $). Isso garante que a mesma operação que "criptografa" os bits também os "descriptografa", simplificando o código.

Eficiência de Cache: O processamento é feito de forma sequencial, aproveitando o prefetch de memória do processador.

Single File: O código foi estruturado para ser executado em ambientes como DotNetFiddle ou Playcode sem dependências externas.
