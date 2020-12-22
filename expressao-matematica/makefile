all: desafio3

desafio3: ed.o main.o parser.o solver.o
	gcc $^ -o $@

ed.o: ed.c ed.h
	gcc -c $< -o $@

parser.o: parser.c parser.h
	gcc -c $< -o $@

solver.o: solver.c solver.h
	gcc -c $< -o $@

main.o: main.c ed.h
	gcc -c $< -o $@

clean:
	@rm *.o desafio3