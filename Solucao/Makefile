all: shared.c transfer.c main.c divergence.c channels.c
	@ echo -n "Compiling the source code"
	@ gcc -c shared.c -o shared.o
	@ echo -n "."
	@ gcc -c transfer.c -o transfer.o
	@ echo -n "."
	@ gcc -c divergence.c -o divergence.o
	@ echo -n "."
	@ gcc -c channels.c -o channels.o
	@ echo -n "."
	@ gcc $^ -o desafio
	@ echo "."
	@ make clean -s
	@ echo -e "Don't forget to include the product's and sell's file!!!\nTo run: ./desafio"
clean:
	rm *.o