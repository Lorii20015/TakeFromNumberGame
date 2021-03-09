using System;
using System.Collections.Generic;
using System.Text;

namespace TakeFromNumber
{
    class Code
    {
        private bool isPlayer = true;
        private int playerOrComp = 2;
        private int end = 0;
        string intro = "Hello!\nThis game is, again, based on numbers!\nTo win you have to be the one who gets the number 25 to 0 first.\nLet me explain how you can do that...\nYou will be taking turns with the computer to subtract 1, 2 or 3 from the number 25.\nWinner is the one who subtracts as last!\n~~~\nValid format of input: 1/2/3\n~~~\n";
        private int mainNum = 25;
        int inputNum;
        static Random random = new Random();
        int randomInt = random.Next(1, 4);


        public Code()
        {
            Console.WriteLine(intro);
            while(end != 1)
            {
                GetPlayerTurn();
                GetCompTurn();
                //WannaPlayAgain();
            }
        }


        void GetPlayerTurn()
        {
            isPlayer = true;
            if (end == 1)
            {
                

            }
            else
            {
                while (inputNum != 1 || inputNum != 2 || inputNum != 3)
                {
                    Console.Write("Enter the number you wish to subtract with:");
                    string input = Console.ReadLine();
                    if (Int32.TryParse(input, out inputNum) == true)
                    {
                        if (inputNum == 1)
                        {
                            mainNum = mainNum - inputNum;
                            break;
                        }
                        else if (inputNum == 2)
                        {
                            mainNum = mainNum - inputNum;
                            break;
                        }
                        else if (inputNum == 3)
                        {
                            mainNum = mainNum - inputNum;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!\nOnly numbers 1, 2, and 3 can be used!");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.\nTry again!");
                        continue;
                    }
                }
                playerOrComp = 0;
                Compare();
            }
        }


        int intByComp;
        void GetCompTurn()
        {
            isPlayer = false;
            if (end == 1)
            {

            }
            else
            {
                if (mainNum > 6)
                {
                    mainNum = mainNum - randomInt;
                    intByComp = randomInt;
                }
                else if (mainNum == 6)
                {
                    mainNum = mainNum - 2;
                    intByComp = 2;
                }
                else if (mainNum == 5)
                {
                    mainNum = mainNum - 1;
                    intByComp = 1;
                }
                else if (mainNum == 3 || mainNum == 2 || mainNum == 1)
                {
                    intByComp = mainNum;
                    mainNum = 0;
                }
                else
                {
                    mainNum = mainNum - randomInt;
                    intByComp = randomInt;
                }
                playerOrComp = 1;
                Compare();
            }
        }
        void Compare()
        {
            if (mainNum == 0)
            {
                Console.WriteLine("That's the end of the game!");
                CheckForWin();
            }
            else if (isPlayer == false)
            {
                Console.WriteLine("You subtracted " + inputNum + " and computer subtracted " + intByComp + ".");
                Console.WriteLine("There's " + mainNum + " left!\n");
            }
        }


        void CheckForWin()
        {
            if ( playerOrComp == 0)
            {
                WinByPlayer();
            }
            else if( playerOrComp == 1)
            {
                WinByComp();
            }
        }


        void WinByPlayer()
        {
            Console.WriteLine("Congratulations, you won the game!");
            end = 1;
        }


        void WinByComp()
        {
            Console.WriteLine("Computer wins!");
            end = 1;
        }

    }
}
