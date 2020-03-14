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
                if (liczby[i] % 7 == 0)
                {
                    wyniki.Add("Buzzinga");
                }
                else if ((liczby[i] % 3 == 0 && liczby[i] % 5 == 0) || liczby[i].ToString().Contains("35") || liczby[i].ToString().Contains("53"))
                {
                    wyniki.Add("FizzBuzz");
                }
                else if (liczby[i] % 5 == 0 || liczby[i].ToString().Contains("5"))
                {
                    wyniki.Add("Buzz");
                }
                else if (liczby[i] % 3 == 0)
                {
                    wyniki.Add("Fizz");
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