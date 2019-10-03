using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easy_2
{
    class Program
    {
        static IDictionary<int, string> realNumber = new Dictionary<int, string>()
            {
                {1, "One"},
                {2, "Two"},
                {3, "Three"},
                {4, "Four"},
                {5, "Five"},
                {6, "Six"},
                {7, "Seven"},
                {8, "Eight"},
                {9, "Nine"}
            };
        static IDictionary<int, string> teens = new Dictionary<int, string>()
        {
            {10, "Ten"},
            {11, "Eleven"},
            {12, "Twelve"},
            {13, "Thirteen"},
            {14, "Fourteen"},
            {15, "Fifteen"},
            {16, "Sixteen"},
            {17, "Seventeen"},
            {18, "Eighteen"},
            {19, "Nineteen"}
        };
        static IDictionary<int, string> unit = new Dictionary<int, string>()
             {
                {1, "One"},
                {2, "Two"},
                {3, "Three"},
                {4, "Four"},
                {5, "Five"},
                {6, "Six"},
                {7, "Seven"},
                {8, "Eight"},
                {9, "Nine"},
                {10, "Ten"},
                {11, "Eleven"},
                {12, "Twelve"},
                {13, "Thirteen"},
                {14, "Fourteen"},
                {15, "Fifteen"},
                {16, "Sixteen"},
                {17, "Seventeen"},
                {18, "Eighteen"},
                {19, "Nineteen"}
            };
        static IDictionary<int, string> tens = new Dictionary<int, string>()
        {
            {10, "Ten" },
            {20, "Twenty" },
            {30, "Thirty" },
            {40, "Forty" },
            {50, "Fivty"},
            {60, "Sixty"},
            {70, "Seventy"},
            {80, "Eighty"},
            {90, "Ninety"}
        };
        static IDictionary<int, string> hundred = new Dictionary<int, string>()
        {
            {100, "One Hundred" },
            {200, "Two Hundred" },
            {300, "Three Hundred" },
            {400, "Four Hundred" },
            {500, "Five Hundred"},
            {600, "Six Hundred"},
            {700, "Seven Hundred"},
            {800, "Eight Hundred"},
            {900, "Nine Hundred"}
        };

        static string SpellNumber(string UserNumber)
        {
            try
            {
                int theNumer = Convert.ToInt32(UserNumber);

                IDictionary<int, string> unit = new Dictionary<int, string>()
            {
                {1, "One"},
                {2, "Two"},
                {3, "Three"},
                {4, "Four"},
                {5, "Five"},
                {6, "Six"},
                {7, "Seven"},
                {8, "Eight"},
                {9, "Nine"},
                {10, "Ten"},
                {11, "Eleven"},
                {12, "Twelve"},
                {13, "Thirteen"},
                {14, "Fourteen"},
                {15, "Fifteen"},
                {16, "Sixteen"},
                {17, "Seventeen"},
                {18, "Eighteen"},
                {19, "Nineteen"}
            };

                string numLenght = Convert.ToString(theNumer);
                int lenght = numLenght.Length;
                string result;
                switch (lenght)
                {
                    case 1:
                        if (unit.TryGetValue(theNumer, out result))
                        {
                            Console.WriteLine(result);
                        }
                        break;
                    case 2:
                        if (unit.TryGetValue(theNumer, out result))
                        {
                            Console.WriteLine(result);
                        }
                        else
                        {
                            GetTens(UserNumber);
                        }
                        break;
                    case 3:
                        GetHunded(UserNumber);
                        break;
                    case 4:
                    case 5:
                    case 6:
                        GetThousand(UserNumber);
                        break;
                    case 7:
                    case 8:
                    case 9:
                        GetMillion(UserNumber);
                        break;
                    default:
                        Console.WriteLine("Haa Haa Haa \n this is too mush!!!");
                        Console.WriteLine("============================================================");
                        Console.WriteLine("Only number in range of lenght 1-9\n Did you hear!!!");
                        Console.WriteLine("Try next time OK!");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("Try to input corret number next time OK");
            }
            
            return UserNumber; 
        }


        static string GetUnit(string UserNumber)
        {
            int unitsNumber = Convert.ToInt32(UserNumber);
            string unitResult;
            if(realNumber.ContainsKey(unitsNumber) && realNumber.TryGetValue(unitsNumber, out unitResult))
            {
               Console.Write(unitResult);
            }

            return UserNumber;
        }
        static string GetTens(string UserNumber)
        {
            int tensNumber = Convert.ToInt32(UserNumber);
            int theTensDivision = (tensNumber / 10) * 10;

            int theUnit = tensNumber % 10;
            string getTheUnit = Convert.ToString(theUnit);
            string tensResult;
            string teensResult;
            string realNumberResult;

            if (realNumber.ContainsKey(tensNumber) && realNumber.TryGetValue(tensNumber, out realNumberResult))
            {
                Console.Write(realNumberResult);
            }

            if (tens.ContainsKey(tensNumber) && tens.TryGetValue(tensNumber, out tensResult))
            {
                Console.Write(tensResult);
            }
            else if (teens.TryGetValue(tensNumber, out teensResult))
            {
                Console.Write(teensResult);
            }
            else if(tens.TryGetValue(theTensDivision, out tensResult))
            {
                Console.Write(tensResult + " ");
                GetUnit(getTheUnit);
            }

            return UserNumber;
        }
        static string GetHunded (string UserNumber)
        {
            int hundredNumber = Convert.ToInt32(UserNumber);
            int hundredDivision = (hundredNumber / 100) * 100;
            int theTensNumber = hundredNumber - hundredDivision;

            string theTeens = Convert.ToString(hundredNumber);
            string theTens = Convert.ToString(theTensNumber);
            string hundredResult;

            if (hundred.TryGetValue(hundredNumber, out hundredResult))
            {
                Console.Write(hundredResult);
            }
            else
            {
                if (hundredDivision == 0 )
                {
                    Console.Write("and ");
                    GetTens(theTeens);
                }
                else if(hundred.TryGetValue(hundredDivision, out hundredResult))
                {
                    Console.Write(hundredResult + " and ");
                    GetTens(theTens);
                }
            }


            return UserNumber;
        }
        static string GetThousand(string UserNumber)
        {
            int thousandNumber = Convert.ToInt32(UserNumber);
            int realThousandNumber = thousandNumber % 1000;
            int thousandDivivision = thousandNumber / 1000;
            int theHundred = realThousandNumber % 1000;
            int millionDivision = thousandDivivision * 1000;

            string numberLength = Convert.ToString(thousandNumber);

            string firstDivision = Convert.ToString(thousandDivivision);
            string lastDivision = Convert.ToString(realThousandNumber);
            string result;
            string secondResult;
            if (millionDivision == 0)
            {
                Console.Write(" ");
                GetHunded(UserNumber);
            }
            if (numberLength.Length == 4)

            {
                if (unit.TryGetValue(thousandDivivision, out result) && theHundred == 0)
                {
                    Console.Write(result + " Thousand. ");
                }
                else if (unit.TryGetValue(thousandDivivision, out result))
                {
                    Console.Write(result + " Thousand, ");
                    GetHunded(lastDivision);
                }
            }
            if (numberLength.Length == 5)
            {
                if (tens.TryGetValue(thousandDivivision, out secondResult) && theHundred == 0)
                {
                    Console.Write(secondResult + "Thousand.");
                }
                else if (tens.TryGetValue(thousandDivivision, out result))
                {
                    Console.Write(result + " Thousand, ");
                    GetHunded(lastDivision);
                }
                else if (!tens.ContainsKey(thousandDivivision) && realThousandNumber == 0)
                {
                    GetTens(firstDivision);
                    Console.Write(" Thousand ");
                }
                else if (!tens.ContainsKey(thousandDivivision))
                {
                    GetTens(firstDivision);
                    Console.Write(" Thousand, ");
                    GetHunded(lastDivision);
                }
                
            }
            if (numberLength.Length == 6)
            {
                if (hundred.ContainsKey(thousandDivivision) && theHundred == 0)
                {
                    GetHunded(firstDivision);
                    Console.Write(" Thousand. ");
                }
                else if (!hundred.ContainsKey(thousandDivivision) && theHundred == 0)
                {
                    GetHunded(firstDivision);
                    Console.Write(" Thousand. ");
                }
                else
                {
                    GetHunded(firstDivision);

                    GetHunded(lastDivision);
                }
                
            }
            
            return UserNumber;
        }
        static string GetMillion(string UserNumber)
        {
            int millionNumber = Convert.ToInt32(UserNumber);
            int millionDivision = millionNumber / 1000000;
            int millionRange = millionNumber % 1000000;

            string numberLength = Convert.ToString(millionNumber);

            string firstDivision = Convert.ToString(millionDivision);
            string lastDivision = Convert.ToString(millionRange);

            if (numberLength.Length == 7)
            {
                if (realNumber.ContainsKey(millionDivision) && millionRange == 0)
                {
                    GetTens(firstDivision);
                    Console.WriteLine( " Million. ");
                }
                else
                {
                    GetTens(firstDivision);
                    Console.Write(" Million, ");
                    GetThousand(lastDivision);
                }
            }
            else if (numberLength.Length == 8)
            {
                if (tens.ContainsKey(millionDivision) && millionRange == 0)
                {
                    GetTens(firstDivision);
                    Console.WriteLine(" Million. ");
                }
                else if (tens.ContainsKey(millionDivision))
                {
                    GetTens(firstDivision);
                    Console.Write(" Million, ");
                    GetThousand(lastDivision);
                }
                else if (!tens.ContainsKey(millionDivision) && millionRange == 0)
                {
                    GetTens(firstDivision);
                    Console.WriteLine(" Million. ");
                }
                else if (!tens.ContainsKey(millionDivision))
                {
                    GetTens(firstDivision);
                    Console.Write(" Million, ");
                    GetThousand(lastDivision);
                }

            }
            else if (numberLength.Length == 9)
            {
                if (hundred.ContainsKey(millionDivision) && millionRange == 0)
                {
                    GetHunded(firstDivision);
                    Console.Write(" Million. ");
                }
                else
                {
                    GetHunded(firstDivision);
                    Console.Write(" Million, ");
                    GetThousand(lastDivision);
                }

            }

            return UserNumber;
        }


        static void Main(string[] args)
        {

            Console.Write("Enter the number you want to spell: ");
            string getUserNumber = Console.ReadLine();
            SpellNumber(getUserNumber);

            Console.ReadLine();

            Console.WriteLine("Wow, that's pretty cool ");
            Console.WriteLine("========================================================================");
            Console.WriteLine();

            Console.WriteLine("Did you want to perform another task? \n        ('YES' OR 'NO')  ");
            Console.Write("Type 'y' for (YES) and 'n' for (NO)  => ");
            Console.Write("");

            string condition = Console.ReadLine();

            if (condition=="y" || condition=="Y")
            {
                Console.WriteLine();

                Main(args);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("I hope your results are corret.");
                Console.WriteLine("=====================================================================");
                Console.WriteLine();

                Console.Write("Have a nice day, Good byeeeeeeee...");
            }

             Console.ReadLine();
        }
    }
}
