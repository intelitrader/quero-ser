import unittest
from anagramas import anagramas

class TesteAnagrama(unittest.TestCase):
       
    def testedj(self):
        self.assertEqual(anagramas('biro'),
            set('''biro bior brio broi boir bori
                    ibro ibor irbo irob iobr iorb
                    rbio rboi ribo riob roib robi
                    obir obri oibr oirb orbi orib'''.split()))
        
unittest.main()
