using System;
using System.Collections.Generic;

namespace Projekt_1
{
    public class BadanieLiczb
    {
        public static List<string> PodzielnośćLiczb(List<int> liczby)
        {
            List<string> wyniki = new List<string>();
            for (int i = 0; i < liczby.Count; i++)
            {
                if (liczby[i] % 3 == 0 && liczby[i] % 5 == 0)
                {
                    wyniki.Add("FizzBuzz");
                }
                else if (liczby[i] % 3 == 0 && liczby[i] % 5 != 0)
                {
                    wyniki.Add("Fizz");
                }
                else if (liczby[i] % 3 != 0 && liczby[i] % 5 == 0)
                {
                    wyniki.Add("Buzz");
                }
                else
                {
                    wyniki.Add(Convert.ToString(liczby[i]));
                }
            }
            return wyniki;
        }
    }
}