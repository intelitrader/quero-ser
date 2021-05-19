using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions; 

namespace Dojo_DescubraAssassino
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> Murders = new Dictionary<int, string>();
            Dictionary<int, string> Places = new Dictionary<int, string>();
            Dictionary<int, string> Weapons = new Dictionary<int, string>();
            bool end = false;
            
            #region Dictionary adds

            Murders.Add(1, "Charles B. Abbage");
            Murders.Add(2, "Donald Duck Knuth");
            Murders.Add(3, "Ada L. Ovelace");
            Murders.Add(4, "Alan T. Uring");
            Murders.Add(5, "Ivar J. Acobson");
            Murders.Add(6, "Ras Mus Ler Dorf");

            Places.Add(1,"Redmond");
            Places.Add(2,"Palo Alto");
            Places.Add(3,"San Francisco");
            Places.Add(4,"Tokio");
            Places.Add(5,"Restaurante no Fim do Universo");
            Places.Add(6,"São Paulo");
            Places.Add(7,"Cupertino");
            Places.Add(8,"Helsinki");
            Places.Add(9,"Maida Vale");
            Places.Add(10,"Toronto");

            Weapons.Add(1, "Peixeira");
            Weapons.Add(2, "DynaTAC 8000X (o primeiro aparelho celular do mundo)");
            Weapons.Add(3, "Trezoitão");
            Weapons.Add(4, "Trebuchet");
            Weapons.Add(5, "Maça");
            Weapons.Add(6, "Gládio");

            #endregion

            Random r = new Random();
            int rMurder = r.Next(1, 6);
            int rPlace = r.Next(1, 10);
            int rWeapon = r.Next(1, 6);

            string ansMurder = "";
            string ansPlace = "";
            string ansWeapon = "";

            Console.Clear();
            Console.WriteLine($"==========================");
            Console.WriteLine($"== Descubra o assassino ==");
            Console.WriteLine($"==========================");
            Console.WriteLine($"");
            Console.WriteLine($"Bem vindo(a)!");
            Console.WriteLine($"");
            FinalizarDialogo();
            
            Console.Clear();
            Console.WriteLine($"Alguem foi assassinado, em algum lugar, com alguma arma.");
            Console.WriteLine($"");
            Console.WriteLine($"Você deve dar palpites e o detetive dirá o que está errado no seu palpite.");
            Console.WriteLine($"Ele responderá com números sobre o que está INCORRETO!");
            Console.WriteLine($"");
            Console.WriteLine($"1 indica que o assassino está incorreto;");
            Console.WriteLine($"2 indica que o local está incorreto;");
            Console.WriteLine($"3 indica que a arma está incorreta.");
            FinalizarDialogo();

            do
            {
                Console.Clear();
                Console.WriteLine($"Vamos lá");
                Console.WriteLine($"");
                Console.WriteLine($"Escolha o número do seu suspeito");
                Console.WriteLine($"Assassinos:");
                

                foreach (KeyValuePair<int, string> murder in Murders)    
                {    
                    Console.WriteLine("{0}: {1}", murder.Key, murder.Value);
                    if (murder.Key == rMurder)
                    {
                        ansMurder = murder.Value;
                    }
                }
                
                Int32 suspeito = 0;
                bool check1 = false;
                IEnumerable<int> numbersList = Enumerable.Range(1, 6) ;

                do
                {
                    Console.WriteLine($"");
                    Console.Write($"Escolha: ");
                    try
                    {
                        suspeito = int.Parse(Console.ReadLine());
                        if (suspeito.GetType() == typeof(System.Int32))
                        {
                            if (!numbersList.Any(x => suspeito.Equals(x)))
                            {
                                Console.WriteLine($"Você deve escolher um dos número!");
                            }else
                            {
                                check1 = true;
                            }
                        }

                    }
                    catch (System.Exception)
                    {
                        // TODO
                        Console.WriteLine($"Você deve escolher um dos número!");
                    }
                    
                } while (!check1);

                Console.Clear();
                Console.WriteLine($"Seus números: {suspeito}");
                Console.WriteLine($"");
                Console.WriteLine($"Escolha o número do local suspeito");
                Console.WriteLine($"Locais:");
                
                foreach (KeyValuePair<int, string> place in Places)    
                {    
                    Console.WriteLine("{0}: {1}", place.Key, place.Value);
                    if (place.Key == rPlace)
                    {
                        ansPlace = place.Value;
                    }   
                }
                
                Int32 local = 0;
                bool check2 = false;
                IEnumerable<int> numbersList2 = Enumerable.Range(1, 10) ;

                do
                {
                    Console.WriteLine($"");
                    Console.Write($"Escolha: ");
                    try
                    {
                        local = int.Parse(Console.ReadLine());
                        if (local.GetType() == typeof(System.Int32))
                        {
                            if (!numbersList2.Any(x => local.Equals(x)))
                            {
                                Console.WriteLine($"Você deve escolher um dos número!");
                            }else
                            {
                                check2 = true;
                            }
                        }

                    }
                    catch (System.Exception)
                    {
                        // TODO
                        Console.WriteLine($"Você deve escolher um dos número!");
                    }
                    
                } while (!check2);

                Console.Clear();
                Console.WriteLine($"Seus números: {suspeito}, {local}");
                Console.WriteLine($"");
                Console.WriteLine($"Escolha o número da arma suspeita");
                Console.WriteLine($"Armas:");
                
                foreach (KeyValuePair<int, string> weapon in Weapons)    
                {    
                    Console.WriteLine("{0}: {1}", weapon.Key, weapon.Value);
                    if (weapon.Key == rWeapon)
                    {
                        ansWeapon = weapon.Value;
                    }   
                }

                Int32 arma = 0;
                bool check3 = false;
                IEnumerable<int> numbersList3 = Enumerable.Range(1, 6) ;

                do
                {
                    Console.WriteLine($"");
                    Console.Write($"Escolha: ");
                    try
                    {
                        arma = int.Parse(Console.ReadLine());
                        if (arma.GetType() == typeof(System.Int32))
                        {
                            if (!numbersList3.Any(x => arma.Equals(x)))
                            {
                                Console.WriteLine($"Você deve escolher um dos número!");
                            }else
                            {
                                check3 = true;
                            }
                        }

                    }
                    catch (System.Exception)
                    {
                        // TODO
                        Console.WriteLine($"Você deve escolher um dos número!");
                    }
                    
                } while (!check3);

                Console.Clear();
                Console.WriteLine($"Seus números: {suspeito}, {local}, {arma}");
                FinalizarDialogo();

                Console.Clear();
                Console.WriteLine($"Seus números: {suspeito}, {local}, {arma}");
                Console.Write($"Detetive: ");
                
                if (suspeito == rMurder && local == rPlace && arma == rWeapon)
                {
                    Console.Write($"Parabéns você resolveu o mistério!!!");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("O assassino era {0}, matou em {1} usando {2}.", ansMurder, ansPlace, ansWeapon);
                    
                    end = true;
                }

                if (suspeito != rMurder)
                {
                    Console.Write($"1(suspeito) ");
                }
                if (local != rPlace)
                {
                    Console.Write($"2(local) ");
                }
                if (arma != rWeapon)
                {
                    Console.Write($"3(arma)");
                }

                FinalizarDialogo();
            } while (!end);
        }

        public static void FinalizarDialogo () 
        {
            System.Console.WriteLine ();
            System.Console.WriteLine ();
            System.Console.WriteLine ("Aperte alguma tecla para prosseguir");
            Console.ReadLine ();
        }
    }
}
