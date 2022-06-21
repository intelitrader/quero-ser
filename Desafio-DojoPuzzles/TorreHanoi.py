def TorreHanoi(disc, ori, dest, aux):
    if disc == 1:
        print(f'Mova o disco {disc} da torre {ori} para a torre {dest}')
        return
    TorreHanoi(disc - 1, ori, aux, dest)
    print(f'Mova o disco {disc} da torre {ori} para a torre {dest}')
    TorreHanoi(disc - 1, aux, ori, dest)

n = int(input("Números de disco: "))
TorreHanoi(n, 'A', 'B', 'C')
print(f"Números de jogadas {2**n-1}")