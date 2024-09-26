#Utilizei o https://dojopuzzles.com/problems/quiz-animal/

animais = {
    "pergunta": "Seu animal é terrestre?",
    "não":  "peixe",
    "sim": {
        "pergunta": "Seu animal tem um pescoço grande?",
        "sim": "girafa",
        "não": "vaca"
    }
}

def jogar():
    print("Pense em um animal...")
  
    while simounao("Quer jogar?"):
        walkTree(animais)

def walkTree(branch):
    direction = simounao( branch["pergunta"] )
    newBranch = ramoInferior(branch, direction)

    if foundAnimal(newBranch):
        fimdejogo(newBranch, branch, direction)
    else:
        walkTree(newBranch)

def ramoInferior(branch, direction):
    if direction:
        return branch["sim"]
    else:
        return branch["não"]

assert( ramoInferior(animais, False) == "peixe" )
  
subbranch = ramoInferior(animais, True) 
assert( ramoInferior(subbranch, False) == "vaca")
assert( ramoInferior(subbranch, True) == "girafa")

def foundAnimal(branch):
    return not isinstance(branch, dict)

def fimdejogo(branch, parent, direction):
    if simounao( "Seu animal é um(a) " + branch + "?" ):
        print("\033[1;32mAcertei!\033[m")
    else:
        guardarnovoanimal(parent, quelado(direction), branch)

def quelado(yes):
    if yes:
        return "sim"
    else:
        return "não"
assert(  quelado(True) == "sim" )
assert(  quelado(False) == "não" )


def guardarnovoanimal(higherBranch, side, animalantigo):
    print("\033[1;31mPoxa. Em que animal estava pensando?\033[m")
    novoanimal = input().lower()
        
    print("Que perguntaria diferenciaria os animais"), animalantigo, "e", novoanimal, "?"
    novapergunta = input()
        
    higherBranch[side] = {
        "pergunta": transformarempergunta(novapergunta),
        "sim": novoanimal,
        "não": animalantigo
    }

def transformarempergunta(words):
    if words.endswith("?"):
        return words
    else:
        return words + "?"
assert( transformarempergunta("Isso não é uma pergunta").endswith("?") )
assert( transformarempergunta("Isso é uma pergunta?").endswith("?") )

def respSim(answer):
    if answer.lower().startswith("s"):
        return True
    else:
        return False
assert(     respSim("Sim") )
assert(     respSim("S") )
assert(     respSim("sim") )
assert(     respSim("s") )
assert( not respSim("Não") )
assert( not respSim("Nao") )
assert( not respSim("N") )
assert( not respSim("não") )
assert( not respSim("nao") )
assert( not respSim("n") )

def simounao(question):
    print(question)
    return respSim( input() )

jogar()
