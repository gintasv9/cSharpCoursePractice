using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class SkaiciuKonvertavimasIZodzius
{
    static void Main(string[] args)
    {
        bool whetherRepeat = true;
        Console.Title = "Skaiciu konvertavimas i zodzius";

        do
        {
            Console.WriteLine("Iveskite skaiciu nuo -2 147 483 647 iki 2 147 483 647");
            string number = Console.ReadLine();
            Console.WriteLine();

            double checkBigNumbers;                                     // Didesniu skaiciu patikrinimui
            string errorMessage;

            if (IsNumber(number, out checkBigNumbers, out errorMessage) == true)
            {
                int numericValue = Convert.ToInt32(checkBigNumbers);

                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine(number + ": " + PrintNumberToWords(numericValue));
                Console.ResetColor();
                Console.WriteLine("Noredami ivesti nauja skaiciu, spauskite bet kuri mygtuka. Jei norite iseiti - spauskite ESC.");

                whetherRepeat = ExitOrContinue();
                Console.Clear();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n" + errorMessage);
                Console.ResetColor();
                Thread.Sleep(3000);
                Console.Clear();
            }
        } while (whetherRepeat);

        // Masyvas2();
    }

    private static bool ExitOrContinue()
    {
        char keyPress = Console.ReadKey().KeyChar;
        char keyPressESC = (char)ConsoleKey.Escape;

        if (keyPress == keyPressESC)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    // Patikrina ar "skaicius" ivestas geru formatu.
    static bool IsNumber(string isNumber, out double bigNumber, out string errorMsg)
    {
        bool isGoodNumber = true;
        errorMsg = "";
        bigNumber = 0;

        if (string.IsNullOrWhiteSpace(isNumber))
        {
            errorMsg = "Ivestis tuscia";
            return isGoodNumber = false;
        }

        for (int i = 0; i < isNumber.Length; i++)
        {
            char symbol = isNumber[i];

            if (symbol == '0' && i == 0)
            {
                isGoodNumber = false;
                errorMsg = "Skaicius negali prasideti nuliu.";
                break;
            }
            else if (symbol == '0' || symbol == '1' || symbol == '2' || symbol == '3' || symbol == '4' || symbol == '5' || symbol == '6' || symbol == '7' || symbol == '8' || symbol == '9' || symbol == '-')
            {
                if (symbol == '-' && i != 0)                            // jeigu "-" ne pirmoje pozicijoje - ivestis bloga
                {
                    isGoodNumber = false;
                    errorMsg = "Skaicius privalo buti sudarytas is skaitmenu 0-9 ir/arba \"-\" zenklo priekyje.";
                    break;                                              // ciklas toliau nevykdomas
                }
                //else if (symbol == '-' && i == 0)
                //{
                //    isGoodNumber = true;
                //    break;
                //}

                isGoodNumber = true;
            }
            else
            {
                isGoodNumber = false;
                errorMsg = "Skaicius privalo buti sudarytas is skaitmenu 0-9 ir/arba \"-\" zenklo priekyje.";
                break;
            }
        }

        if (isGoodNumber)
        {
            bigNumber = Convert.ToDouble(isNumber);

            if (bigNumber > int.MaxValue || bigNumber < int.MinValue)       // Patikrina int rezius.
            {
                isGoodNumber = false;
                errorMsg = "Skaicius nepatenka i reikalaujama intervala, prasome ivesti skaiciu dar karta.";
                return isGoodNumber;
            }
        }

        return isGoodNumber;
    }

    static string PrintNumberToWords(int inputNumber)                        // skaiciu uzraso zodine israiska
    {
        // laikini string, lietuvisku galuniu patikrinimui su "EndsWith()"
        string tempStringMillions = Convert.ToString(inputNumber / 1000000);
        string tempStringThousands = Convert.ToString(inputNumber / 1000);

        if (inputNumber == 0)
            return "nulis";

        if (inputNumber < 0)
            return "minus " + PrintNumberToWords(Math.Abs(inputNumber));     // jei skaicius neigiamas, vel kviecia sita funkcija pagal absoliuciaja skaiciaus verte, pradzioje pridedant minuso zenkla

        string numberInWords = string.Empty;

        if ((inputNumber / 1000000000 > 1))
        {
            numberInWords += PrintNumberToWords(inputNumber / 1000000000) + " milijardai ";
            inputNumber %= 1000000000;
        }

        if ((inputNumber / 1000000000 == 1))
        {
            numberInWords += PrintNumberToWords(inputNumber / 1000000000) + " milijardas ";
            inputNumber %= 1000000000;
        }

        if ((inputNumber / 1000000) > 1 && (tempStringMillions.EndsWith("0") || tempStringMillions.EndsWith("11") || tempStringMillions.EndsWith("12") || tempStringMillions.EndsWith("13") || tempStringMillions.EndsWith("14") || tempStringMillions.EndsWith("15") || tempStringMillions.EndsWith("16") || tempStringMillions.EndsWith("17") || tempStringMillions.EndsWith("18") || tempStringMillions.EndsWith("19")))
        {
            numberInWords += PrintNumberToWords(inputNumber / 1000000) + " milijonu ";
            inputNumber %= 1000000;
        }

        else if ((inputNumber / 1000000) >= 1 && tempStringMillions.EndsWith("1"))
        {
            numberInWords += PrintNumberToWords(inputNumber / 1000000) + " milijonas ";
            inputNumber %= 1000000;
        }

        else if ((inputNumber / 1000000) > 1)
        {
            numberInWords += PrintNumberToWords(inputNumber / 1000000) + " milijonai ";
            inputNumber %= 1000000;
        }

        if ((inputNumber / 1000) > 1 && (tempStringThousands.EndsWith("0") || tempStringThousands.EndsWith("11") || tempStringThousands.EndsWith("12") || tempStringThousands.EndsWith("13") || tempStringThousands.EndsWith("14") || tempStringThousands.EndsWith("15") || tempStringThousands.EndsWith("16") || tempStringThousands.EndsWith("17") || tempStringThousands.EndsWith("18") || tempStringThousands.EndsWith("19")))
        {
            numberInWords += PrintNumberToWords(inputNumber / 1000) + " tukstanciu ";
            inputNumber %= 1000;
        }

        else if ((inputNumber / 1000) >= 1 && tempStringThousands.EndsWith("1"))
        {
            numberInWords += PrintNumberToWords(inputNumber / 1000) + " tukstantis ";
            inputNumber %= 1000;
        }

        else if ((inputNumber / 1000) > 1)
        {
            numberInWords += PrintNumberToWords(inputNumber / 1000) + " tukstanciai ";
            inputNumber %= 1000;
        }

        if ((inputNumber / 100) > 1)
        {
            numberInWords += PrintNumberToWords(inputNumber / 100) + " simtai ";
            inputNumber %= 100;
        }

        if ((inputNumber / 100) == 1)
        {
            numberInWords += PrintNumberToWords(inputNumber / 100) + " simtas ";
            inputNumber %= 100;
        }

        if (inputNumber > 0)
        {
            string[] units = new[] { "nulis", "vienas", "du", "trys", "keturi", "penki", "sesi", "septyni", "astuoni", "devyni", "desimt", "vienuolika", "dvylika", "trylika", "keturiolika", "penkiolika", "sesiolika", "septyniolika", "astuoniolika", "devyniolika" };
            string[] tens = new[] { "nulis", "desimt", "dvidesimt", "trisdesimt", "keturiasdesimt", "penkiasdesimt", "sesiasdesimt", "septyniasdesimt", "astuoniasdesimt", "devyniasdesimt" };

            if (inputNumber < 20)
                numberInWords += units[inputNumber];
            else
            {
                numberInWords += tens[inputNumber / 10];
                if ((inputNumber % 10) > 0)
                    numberInWords += " " + units[inputNumber % 10];
            }
        }

        return numberInWords;
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
            // kai i = 0, sitas iklas viduje patikrina visas masyvo pozicijas nuo 1 iki 9
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

        foreach (string zodis in sakinys)
        {
            if (zodis == "!")                              // Sauktukai surikiuojami masyvo gale.
            {
                naujasSakinys[sakinioGalas] = zodis;
                sakinioGalas--;
            }
            else                                                // Zodziai surikiuojami sakinio pradzioje.
            {
                naujasSakinys[sakinioPradzia] = zodis;
                sakinioPradzia++;
            }
        }

        for (int i = 0; i < naujasSakinys.Length; i++)
        {
            Console.Write(naujasSakinys[i] + " ");
        }
    }
}


