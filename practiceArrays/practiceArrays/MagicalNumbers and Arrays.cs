using System;
using System.Threading;

class Program
{
    static void Main()
    {
        FindMagicNumber();
        //printMineSweeperNumbers();
    }

    static void MagicNumber(ref int magicNumber)
    {
        // Perduodamas magiskas skaicius ir isspausdinamos sandaugos
        Console.WriteLine("Magiskas skaicius * 2: " + magicNumber * 2);
        Console.WriteLine("Magiskas skaicius * 3: " + magicNumber * 3);
        Console.WriteLine("Magiskas skaicius * 4: " + magicNumber * 4);
        Console.WriteLine("Magiskas skaicius * 5: " + magicNumber * 5);
        Console.WriteLine("Magiskas skaicius * 6: " + magicNumber * 6);
        Console.ResetColor();
        Console.WriteLine("Noredami iseiti, spauskite bet kuri mygtuka.");
        Console.ReadKey();
    }

    private static void FindMagicNumber()
    {

        for (int i = 100000; i <= 999999; i++)
        {
            // i paverciamas i skaitmenu masyva
            int[] scanningNumber = IntToArray(i);

            bool isMagicalNumberFound = false;

            // jei skaiciuje yra 6 nevienodi skaitmenys, vykdome masyvu palyginimus
            if (SixNonRepeatingDigits(scanningNumber))
            {
                bool isArrayAfterMultiplicationMagical = true;
                while (isArrayAfterMultiplicationMagical)
                {
                    int[] scanningNumber2 = IntToArray(i * 2);
                    int[] scanningNumber3 = IntToArray(i * 3);
                    int[] scanningNumber4 = IntToArray(i * 4);
                    int[] scanningNumber5 = IntToArray(i * 5);
                    int[] scanningNumber6 = IntToArray(i * 6);

                    if (TwoArrayComparison(scanningNumber, scanningNumber2) && TwoArrayComparison(scanningNumber, scanningNumber3) && TwoArrayComparison(scanningNumber, scanningNumber4) && TwoArrayComparison(scanningNumber, scanningNumber5) && TwoArrayComparison(scanningNumber, scanningNumber6))
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Magiskas skaicius yra: " + i);
                        isMagicalNumberFound = true;
                        MagicNumber(ref i);
                        break;
                    }
                    else
                    {
                        isArrayAfterMultiplicationMagical = false;
                    }
                }
            }
            if (isMagicalNumberFound)
            {
                break;
            }
        }
    }

    // Metodas is sesiazenklio skaiciaus padaro int[]
    static int[] IntToArray(int sixDigitNumber)
    {
        // skaicius konvertuojamas i string
        string holder = sixDigitNumber.ToString();

        int[] digitArray = new int[holder.Length];

        for (int i = 0; i < holder.Length; i++)
        {
            //pavieniai string chars konvertuojamipaverciami atgal i string, kuriu kiekvienas konvertuojamas i Int32
            digitArray[i] = Convert.ToInt32(holder[i].ToString());
        }
        return digitArray;
    }

    // Metodas patikrina ar sesianariuose masyvuose nera pasikartojanciu skaiciu
    static bool SixNonRepeatingDigits(int[] digitArray)
    {
        bool isNumberGood = false;
        int[] safeDigitArray = new int[digitArray.Length];

        // Funkcija masyvo nukopijavimui
        Array.Copy(digitArray, safeDigitArray, digitArray.Length);

        for (int i = 0; i < safeDigitArray.Length; i++)
        {
            for (int j = i + 1; j < safeDigitArray.Length; j++)
            {
                if (safeDigitArray[i] == safeDigitArray[j])
                {
                    isNumberGood = false;
                    break;
                }
                else
                {
                    isNumberGood = true;
                }
            }
            // Jei aptikta klaida - baigiamas tikrinimas ir ciklas grazina false.
            if (isNumberGood == false)
            {
                break;
            }
        }
        return isNumberGood;
    }

    // Metodas dvieju masyvu palyginimui tarpusavy (nieko protingesnio nesugalvojau)
    static bool TwoArrayComparison(int[] array1, int[] array2)
    {
        bool numberPretenderToBeMagical = false;
        bool digit1 = false;
        bool digit2 = false;
        bool digit3 = false;
        bool digit4 = false;
        bool digit5 = false;
        bool digit6 = false;

        // Patikrina ar visi skaiciai abiejuose masyvuose yra tokie patys, tačiau su SKIRTINGU indeksu
        for (int j = 0; ;)
        {
            if (((array1[1] == array2[j]) || (array1[2] == array2[j]) || (array1[3] == array2[j]) || (array1[4] == array2[j]) || (array1[5] == array2[j])) && (array1[0] != array2[j]))
            {
                digit1 = true;
                break;
            }
            else
            {
                digit1 = false;
                break;
            }
        }
        for (int j = 1; ;)
        {
            if (((array1[0] == array2[j]) || (array1[2] == array2[j]) || (array1[3] == array2[j]) || (array1[4] == array2[j]) || (array1[5] == array2[j])) && (array1[1] != array2[j]))
            {
                digit2 = true;
                break;
            }
            else
            {
                digit2 = false;
                break;
            }
        }
        for (int j = 2; ;)
        {
            if (((array1[0] == array2[j]) || (array1[1] == array2[j]) || (array1[3] == array2[j]) || (array1[4] == array2[j]) || (array1[5] == array2[j])) && (array1[2] != array2[j]))
            {
                digit3 = true;
                break;
            }
            else
            {
                digit3 = false;
                break;
            }
        }
        for (int j = 3; ;)
        {
            if (((array1[0] == array2[j]) || (array1[1] == array2[j]) || (array1[2] == array2[j]) || (array1[4] == array2[j]) || (array1[5] == array2[j])) && (array1[3] != array2[j]))
            {
                digit4 = true;
                break;
            }
            else
            {
                digit4 = false;
                break;
            }
        }
        for (int j = 4; ;)
        {
            if (((array1[0] == array2[j]) || (array1[1] == array2[j]) || (array1[2] == array2[j]) || (array1[3] == array2[j]) || (array1[5] == array2[j])) && (array1[4] != array2[j]))
            {
                digit5 = true;
                break;
            }
            else
            {
                digit5 = false;
                break;
            }
        }
        for (int j = 5; ;)
        {
            if (((array1[0] == array2[j]) || (array1[1] == array2[j]) || (array1[2] == array2[j]) || (array1[3] == array2[j]) || (array1[4] == array2[j])) && (array1[5] != array2[j]))
            {
                digit6 = true;
                break;
            }
            else
            {
                digit6 = false;
                break;
            }
        }

        // Jei tarp dvieju masyvu jokie 2 skaiciai su tuo paciu indeksu nera vienodi - skaicius pretenduoja buti MAGISKU
        if (digit1 && digit2 && digit3 && digit4 && digit5 && digit6)
        {
            return numberPretenderToBeMagical = true;
        }
        else
        {
            return numberPretenderToBeMagical = false;
        }
    }

    private static void printMineSweeperNumbers()
    {
        throw new NotImplementedException("TODO: Sukurkite programą kuri liepia vartotojui įvesti MineSweeper žaidimo lauko duomenis. " +
            "Tada paskaičiuoja ir išspausdina lentelę su skaičiais kiek aplinkui(8 kryptyse įskaitant įstrižai) yra minų.");
    }
}

