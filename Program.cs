using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easy_2
{
    class Program
    {
        static IDictionary<int, string> realnum = new Dictionary<int, string>()
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
        static string spellnum(string getnum)
        {
            try
            {
                int thenum = Convert.ToInt32(getnum);

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

                string numlenght = Convert.ToString(thenum);
                int lenght = numlenght.Length;
                string result;
                switch (lenght)
                {
                    case 1:
                        if (unit.TryGetValue(thenum, out result))
                        {
                            Console.WriteLine(result);
                        }
                        break;
                    case 2:
                        if (unit.TryGetValue(thenum, out result))
                        {
                            Console.WriteLine(result);
                        }
                        else
                        {
                            Gettens(getnum);
                        }
                        break;
                    case 3:
                        Gethund(getnum);
                        break;
                    case 4:
                    case 5:
                    case 6:
                        Getthousand(getnum);
                        break;
                    case 7:
                    case 8:
                    case 9:
                        Getmillion(getnum);
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
            
            return getnum; 
        }

        static string Getunit(string cnvtstring)
        {
            int unitnum = Convert.ToInt32(cnvtstring);
            string unitresult;
            if(realnum.ContainsKey(unitnum) && realnum.TryGetValue(unitnum, out unitresult))
            {
               Console.Write(unitresult);
            }

            return cnvtstring;
        }

        static string Gettens(string getnum)
        {
            int tensnum = Convert.ToInt32(getnum);
            int thetensdiv = (tensnum / 10) * 10;

            int theunit = tensnum % 10;
            string cnvtstring = Convert.ToString(theunit);
            string unit = Convert.ToString(theunit); 
            string tensresult;
            string teensresult;
            string realnumresult;

            if (realnum.ContainsKey(tensnum) && realnum.TryGetValue(tensnum, out realnumresult))
            {
                Console.Write(realnumresult);
            }

            if (tens.ContainsKey(tensnum) && tens.TryGetValue(tensnum, out tensresult))
            {
                Console.Write(tensresult);
            }
            else if (teens.TryGetValue(tensnum, out teensresult))
            {
                Console.Write(teensresult);
            }
            else if(tens.TryGetValue(thetensdiv, out tensresult))
            {
                    Console.Write(tensresult+" ");
                    Getunit(cnvtstring);
            }

            return getnum;
        }
        static string Gethund (string getnum)
        {
            int hundrednum = Convert.ToInt32(getnum);
            int hundreddiv = (hundrednum / 100) * 100;
            int thetens = hundrednum - hundreddiv;

            string cnvertteen = Convert.ToString(hundrednum);
            string cnvtstring = Convert.ToString(thetens);
            string hundredresult;

            if (hundred.TryGetValue(hundrednum, out hundredresult))
            {
                Console.Write(hundredresult);
            }
            else
            {
                if (hundreddiv == 0 )
                {
                    Console.Write("and ");
                    Gettens(cnvertteen);
                }
                else if(hundred.TryGetValue(hundreddiv, out hundredresult))
                {
                    Console.Write(hundredresult + " and ");
                    Gettens(cnvtstring);
                }
            }


            return getnum;
        }
        static string Getthousand(string getnum)
        {
            int thousandnum = Convert.ToInt32(getnum);
            int thethousandnum = thousandnum % 1000;
            int thousanddiv = thousandnum / 1000;
            int thehundred = thethousandnum % 1000;
            int milliondiv = thousanddiv * 1000;

            string numberlength = Convert.ToString(thousandnum);

            string tostring = Convert.ToString(thousanddiv);
            string tostring2 = Convert.ToString(thehundred);
            string cnvtstring = Convert.ToString(thethousandnum);
            string result;
            string result2;
            if (milliondiv == 0)
            {
                Console.Write(" ");
                Gethund(getnum);
            }
            if (numberlength.Length == 4)
            {
                if (unit.TryGetValue(thousanddiv, out result) && thehundred == 0)
                {
                    Console.Write(result + " Thousand. ");
                }
                else if (unit.TryGetValue(thousanddiv, out result))
                {
                    Console.Write(result + " Thousand, ");
                    Gethund(cnvtstring);
                }
            }
            if (numberlength.Length == 5)
            {
                if (tens.TryGetValue(thousanddiv, out result2) && thehundred == 0)
                {
                    Console.Write(result2 + "Thousand.");
                }
                else if (tens.TryGetValue(thousanddiv, out result))
                {
                    Console.Write(result + " Thousand, ");
                    Gethund(cnvtstring);
                }
                else if (!tens.ContainsKey(thousanddiv) && thethousandnum == 0)
                {
                    Gettens(tostring);
                    Console.Write(" Thousand ");
                }
                else if (!tens.ContainsKey(thousanddiv))
                {
                    Gettens(tostring);
                    Console.Write(" Thousand, ");
                    Gethund(cnvtstring);
                }
                
            }
            if (numberlength.Length == 6)
            {
                if (hundred.ContainsKey(thousanddiv) && thethousandnum == 0)
                {
                    Gethund(tostring);
                    Console.Write(" Thousand. ");
                }
                else
                {
                    Gethund(tostring);
                    Console.Write(" Thousand, ");
                    Gethund(cnvtstring);
                }
                
            }
            
            return getnum;
        }
        static string Getmillion(string getnum)
        {
            int millionNum = Convert.ToInt32(getnum);
            int milliondiv = millionNum / 1000000;
            int millionrange = millionNum % 1000000;

            string numberlength = Convert.ToString(millionNum);

            string tostring = Convert.ToString(milliondiv);
            string tostring2 = Convert.ToString(millionrange);

            if (numberlength.Length == 7)
            {
                if (realnum.ContainsKey(milliondiv) && millionrange == 0)
                {
                    Gettens(tostring);
                    Console.WriteLine( " Million. ");
                }
                else
                {
                    Gettens(tostring);
                    Console.Write(" Million, ");
                    Getthousand(tostring2);
                }
            }
            else if (numberlength.Length == 8)
            {
                if (tens.ContainsKey(milliondiv) && millionrange == 0)
                {
                    Gettens(tostring);
                    Console.WriteLine(" Million. ");
                }
                else if (tens.ContainsKey(milliondiv))
                {
                    Gettens(tostring);
                    Console.Write(" Million, ");
                    Getthousand(tostring2);
                }
                else if (!tens.ContainsKey(milliondiv) && millionrange == 0)
                {
                    Gettens(tostring);
                    Console.WriteLine(" Million. ");
                }
                else if (!tens.ContainsKey(milliondiv))
                {
                    Gettens(tostring);
                    Console.Write(" Million, ");
                    Getthousand(tostring2);
                }

            }
            else if (numberlength.Length == 9)
            {
                if (hundred.ContainsKey(milliondiv) && millionrange == 0)
                {
                    Gethund(tostring);
                    Console.Write(" Million. ");
                }
                else
                {
                    Gethund(tostring);
                    Console.Write(" Million, ");
                    Getthousand(tostring2);
                }

            }

            return getnum;
        }


        static void Main(string[] args)
        {

            Console.Write("Enter the number you want to spell: ");
            string getnum = Console.ReadLine();
            spellnum(getnum);

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
