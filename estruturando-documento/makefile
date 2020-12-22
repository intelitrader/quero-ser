CC = gcc
CC_FLAGS = -c -Wall
BIN = desafio2

OBJ = $(addprefix obj/, main.o util.o list.o structing_document.o)
LIST = src/list/list
UTIL = src/util/util
STRCT_DOC = src/structing_document

all: objdir desafio2

$(BIN): $(OBJ)
	$(CC) -g $^ -o $(BIN)

obj/main.o: main.c $(LIST).h $(UTIL.h)
	$(CC) -g $(CC_FLAGS) $< -o $@

obj/list.o: $(LIST).c $(LIST).h
	$(CC) -g $(CC_FLAGS) $< -o $@

obj/util.o: $(UTIL).c $(UTIL).h
	$(CC) -g $(CC_FLAGS) $< -o $@

obj/structing_document.o: $(STRCT_DOC).c $(STRCT_DOC).h
	$(CC) -g $(CC_FLAGS) $< -o $@

objdir:
	@mkdir -p obj

clean:
	@rm desafio2
	@rm -rf obj/