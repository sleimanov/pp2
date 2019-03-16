using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class GameState
    {
        bool gameOver = false;
        Worm worm = new Worm('O');
        Food food = new Food('@');
        Wall wall = new Wall('#');
        Player player = new Player();
        ConsoleKey consoleKeyInfo = new ConsoleKey(); 
        public GameState()
        {
            Console.SetWindowSize(40, 40);
            Console.SetBufferSize(40, 40);
            Console.CursorVisible = false;
            wall.Draw();
        }

        public void SetName()
        {
            Console.SetCursorPosition(20, 20);
            Console.Write("Please enter your name: ");
        }

        public void Draw()
        {
            if (!gameOver)
            {
                worm.Draw();
                food.Draw();
                //wall.Draw();
                player.score.Draw();
            }
        }
        public void ProcessKeyEvent()
        {
            if (Console.KeyAvailable) consoleKeyInfo = Console.ReadKey(true).Key;
            switch (consoleKeyInfo)
            {
                case ConsoleKey.UpArrow:
                    if (worm.dir != Worm.Direction.Down)
                    {
                        worm.Move(0, -1);
                        worm.dir = Worm.Direction.Up;
                    }
                    else
                    {
                        worm.Move(0, 1);
                        worm.dir = Worm.Direction.Down;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if(worm.dir != Worm.Direction.Up)
                    {
                        worm.Move(0, 1);
                        worm.dir = Worm.Direction.Down;
                    }
                    else
                    {
                        worm.Move(0, -1);
                        worm.dir = Worm.Direction.Up;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if(worm.dir != Worm.Direction.Left)
                    {
                        worm.Move(1, 0);
                        worm.dir = Worm.Direction.Right;
                    }
                    else
                    {
                        worm.Move(-1, 0);
                        worm.dir = Worm.Direction.Left;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if(worm.dir != Worm.Direction.Right)
                    {
                        worm.Move(-1, 0);
                        worm.dir = Worm.Direction.Left;
                    }
                    else
                    {
                        worm.Move(1, 0);
                        worm.dir = Worm.Direction.Right;
                    }
                    break;
            }

            CheckCollision();
        }

        private void CheckCollision()
        {
            if (worm.IsIntersected(wall.body) || worm.IsIntersected(worm.body))
            {
                gameOver = true;
                Console.Clear();
                Console.SetCursorPosition(10, 20);
                Console.Write("Game over!");
            }
            else if (worm.IsIntersected(food.body))
            {
                player.score.Score += 100;
                worm.Eat(food.body);
                food.GenerateLocation(wall.body, worm.body);
            }
        }
    }
}