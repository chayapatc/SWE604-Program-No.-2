using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new TicTacToe();

            game.Init();

            while (true)
            {
                game.Render();


                if (game.FoundWinner())
                {
                    Console.WriteLine("We have got a winner.");
                    break;
                }
                    
                if (game.IsFull())
                    break;

                Console.Write("Where do you want to place `{0}` [1-9]: ", game.sign);
                string pos = Console.ReadLine();

                if (game.PlaceMark(pos))
                {
                    game.ChangePlayer();
                }
                else
                {
                    Console.WriteLine("!!You must do something wrong.");
                }

            }
            Console.WriteLine("Game Finished");
            Console.ReadLine();
        }
    }
}
