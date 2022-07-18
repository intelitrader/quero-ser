

def fizzBuzz():
    for i in range(1,101):
        if i % 3 == 0 and i % 5 == 0:
            print("FizzBuzz ", i)
        elif i % 5 == 0:
            print("Buzz ", i)
        elif i % 3 == 0:
            print("Fizz ", i)

fizzBuzz()