for num in range(1, 100 + 1):
    if num % 3 == 0 and num % 5 == 0:
        print('\033[1;96mFizzBuzz\033[m')
    elif num % 3 == 0:
        print('\033[1;93mFizz\033[m')
    elif num % 5 == 0:
        print('\033[1;92mBuzz\033[m')
    else:
        print(f'\033[1;97m{num}\033[m')
