using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SkaiciuKonvertavimasIZodzius
{
    static void Main(string[] args)
    {
        bool whetherRepeat = true;
        do
        {
            Console.WriteLine("Iveskite skaiciu nuo -2 147 483 647 iki 2 147 483 647");
            string number = Console.ReadLine();
            Console.WriteLine();

            if (IsNumber(number) == true)
            {
                int numericValue = Convert.ToInt32(number);
                whetherRepeat = false;

                Console.WriteLine(SpausdintiVienetus(numericValue));
            }


        } while (whetherRepeat);

        // Masyvas2();
    }

    static bool IsNumber(string isNumber)           // Patikrina ar "skaicius" ivestas geru formatu.
    {
        bool isGoodNumber = true;

        for (int i = 0; i < isNumber.Length; i++)
        {
            char symbol = isNumber[i];
            if (symbol != '0' || symbol != '1' || symbol != '2' || symbol != '3' || symbol != '4' || symbol != '5' || symbol != '6' || symbol != '7' || symbol != '8' || symbol != '9')
            {
                if (symbol == '-')
                {
                    if (i != 0)                     // jeigu "-" ne pirmoje pozicijoje - ivestis bloga
                    {
                        isGoodNumber = false;
                        break;                      // ciklas toliau nevykdomas
                    }
                }
                else
                {
                    isGoodNumber = true;
                }
            }
            else
            {
                isGoodNumber = true;
            }
        }
        return isGoodNumber;

    }
        
    static string SpausdintiVienetus(int inputNumber)                        // skaiciu uzraso zodine israiska
    {
        // meta bloga zodine israiska su tokiais skaiciais kaip 11000, 21000, 31000 etc

        if (inputNumber == 0)                                   
            return "nulis";

        if (inputNumber < 0)
            return "minus " + SpausdintiVienetus(Math.Abs(inputNumber));     // jei skaicius neigiamas, vel kviecia sita funkcija pagal absoliuciaja skaiciaus verte, pradzioje pridedant minuso zenkla

        string skaiciusZodziais = null;

        if ((inputNumber / 1000000000 > 1))
        {
            skaiciusZodziais += SpausdintiVienetus(inputNumber / 1000000000) + " milijardai ";
            inputNumber %= 1000000000;
        }

        if ((inputNumber / 1000000000 == 1))
        {
            skaiciusZodziais += SpausdintiVienetus(inputNumber / 1000000000) + " milijardas ";
            inputNumber %= 1000000000;
        }

        if ((inputNumber / 1000000) > 1 && (Convert.ToString((inputNumber / 1000000)).EndsWith("0") || Convert.ToString((inputNumber / 1000000)).EndsWith("11") || Convert.ToString((inputNumber / 1000000)).EndsWith("12") || Convert.ToString((inputNumber / 1000000)).EndsWith("13") || Convert.ToString((inputNumber / 1000000)).EndsWith("14") || Convert.ToString((inputNumber / 1000000)).EndsWith("15") || Convert.ToString((inputNumber / 1000000)).EndsWith("16") || Convert.ToString((inputNumber / 1000000)).EndsWith("17") || Convert.ToString((inputNumber / 1000000)).EndsWith("18") || Convert.ToString((inputNumber / 1000000)).EndsWith("19")))
        {
            skaiciusZodziais += SpausdintiVienetus(inputNumber / 1000000) + " milijonu ";
            inputNumber %= 1000000;
        }

        else if ((inputNumber / 1000000) >= 1 && Convert.ToString((inputNumber / 1000000)).EndsWith("1"))
        {
            skaiciusZodziais += SpausdintiVienetus(inputNumber / 1000000) + " milijonas ";
            inputNumber %= 1000000;
        }

        else if ((inputNumber / 1000000) > 1)
        {
            skaiciusZodziais += SpausdintiVienetus(inputNumber / 1000000) + " milijonai ";
            inputNumber %= 1000000;
        }

        if ((inputNumber / 1000) > 1 && (Convert.ToString((inputNumber / 1000)).EndsWith("0") || Convert.ToString((inputNumber / 1000)).EndsWith("11") || Convert.ToString((inputNumber / 1000)).EndsWith("12") || Convert.ToString((inputNumber / 1000)).EndsWith("13") || Convert.ToString((inputNumber / 1000)).EndsWith("14") || Convert.ToString((inputNumber / 1000)).EndsWith("15") || Convert.ToString((inputNumber / 1000)).EndsWith("16") || Convert.ToString((inputNumber / 1000)).EndsWith("17") || Convert.ToString((inputNumber / 1000)).EndsWith("18") || Convert.ToString((inputNumber / 1000)).EndsWith("19")))
        {
            skaiciusZodziais += SpausdintiVienetus(inputNumber / 1000) + " tukstanciu ";
            inputNumber %= 1000;
        }

        else if ((inputNumber / 1000) >= 1 && Convert.ToString((inputNumber / 1000)).EndsWith("1"))
        {
            skaiciusZodziais += SpausdintiVienetus(inputNumber / 1000) + " tukstantis ";
            inputNumber %= 1000;
        }

        else if ((inputNumber / 1000) > 1)
        {
            skaiciusZodziais += SpausdintiVienetus(inputNumber / 1000) + " tukstanciai ";
            inputNumber %= 1000;
        }

        if ((inputNumber / 100) > 1)
        {
            skaiciusZodziais += SpausdintiVienetus(inputNumber / 100) + " simtai ";
            inputNumber %= 100;
        }

        if ((inputNumber / 100) == 1)
        {
            skaiciusZodziais += SpausdintiVienetus(inputNumber / 100) + " simtas ";
            inputNumber %= 100;
        }

        if (inputNumber > 0)
        {
            string[] vienetai = new[] { "nulis", "vienas", "du", "trys", "keturi", "penki", "sesi", "septyni", "astuoni", "devyni", "desimt", "vienuolika", "dvylika", "trylika", "keturiolika", "penkiolika", "sesiolika", "septyniolika", "astuoniolika", "devyniolika" };
            string[] desimtys = new[] { "nulis", "desimt", "dvidesimt", "trisdesimt", "keturiasdesimt", "penkiasdesimt", "sesiasdesimt", "septyniasdesimt", "astuoniasdesimt", "devyniasdesimt" };

            if (inputNumber < 20)
                skaiciusZodziais += vienetai[inputNumber];
            else
            {
                skaiciusZodziais += desimtys[inputNumber / 10];
                if ((inputNumber % 10) > 0)
                    skaiciusZodziais += " " + vienetai[inputNumber % 10];
            }
        }

        return skaiciusZodziais;
    }

    static void Masyvas1()
    {
        Console.WriteLine("Iveskite penkis zodzius");
        string[] words = new string[5];

        for (int i = 0; i < words.Length; i++)
        {
            words[i] = Console.ReadLine();
        }

        for (int i = 0; i < words.Length; i++)
        {
            Console.Write(words[i]);
            Console.Write(" ");
        }
        Console.WriteLine();

        for (int i = words.Length - 1; i >= 0; i--)
        {
            Console.Write(words[i]);
            Console.Write(" ");
        }
        Console.WriteLine();
    }

    static void Masyvas2()
    {
        string[] sakinys = { "Mano", "batai", "buvo", "Mano", "batai", "buvo", "du", "buvo", "du", "." };

        for (int i = 0; i < sakinys.Length; i++)
        {
            for (int a = i + 1; a < sakinys.Length; a++)
            // kai i = 0, sitas ciklas viduje patikrina visas masyvo pozicijas nuo 1 iki 9
            // kai i = 1, sitas ciklas viduje patikrina visas masyvo pozicijas nuo 2 iki 9 
            // etc....
            {
                // Pakeicia duplikatus i "!" zenkla
                if (sakinys[i] == sakinys[a])
                {
                    sakinys[a] = "!";
                }
            }
            Console.Write((sakinys[i]) + " ");
        }

        Console.WriteLine();
        string[] naujasSakinys = new string[sakinys.Length];    // Naujas tuscias masyvas
        int sakinioPradzia = 0;
        int sakinioGalas = naujasSakinys.Length - 1;

        for (int i = 0; i < sakinys.Length; i++)
        {
            if (sakinys[i] == "!")                              // Sauktukai surikiuojami masyvo gale.
            {
                naujasSakinys[sakinioGalas] = sakinys[i];
                sakinioGalas--;
            }
            else                                                // Zodziai surikiuojami sakinio pradzioje.
            {
                naujasSakinys[sakinioPradzia] = sakinys[i];
                sakinioPradzia++;
            }
        }

        for (int i = 0; i < naujasSakinys.Length; i++)
        {
            Console.Write(naujasSakinys[i] + " ");
        }
    }
}


