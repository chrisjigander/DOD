using Utils;
using DungeonsOfDoomLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Game
    {
        Player player;
        Room[,] world;
        Random random = new Random();
        string message;
        //public const int maxHealth = 100;

        public void Play()
        {
            CreatePlayer();
            CreateWorld();
            Console.Clear();
            TextUtils.Animate("Welcome to Dungeons of Doom!");
            Console.ReadKey(true);

            do
            {
                Console.Clear();
                DisplayStats();
                Console.WriteLine("[I]nventory");
                DisplayWorld();
                if (message != string.Empty)
                {
                    Console.WriteLine(message);
                    //Console.ReadKey();
                }
                message = string.Empty;
                AskForMovement();
            } while (player.Health > 0);

            GameOver();
        }

        void DisplayStats()
        {
            Console.WriteLine($"Health: {player.Health}");
            Console.WriteLine($"Damage: {player.Damage}");
        }

        private void AskForMovement()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            int newX = player.X;
            int newY = player.Y;
            bool isValidMove = true;


            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow: newX++; break;
                case ConsoleKey.LeftArrow: newX--; break;
                case ConsoleKey.UpArrow: newY--; break;
                case ConsoleKey.DownArrow: newY++; break;
                case ConsoleKey.I: DisplayInventory(player.BackPack); break;
                default: isValidMove = false; break;
            }

            if (isValidMove &&
                newX >= 0 && newX < world.GetLength(0) &&
                newY >= 0 && newY < world.GetLength(1))
            {
                player.X = newX;
                player.Y = newY;

                if (world[player.X, player.Y].Item != null)
                {
                    world[player.X, player.Y].Item.Obtain(player);

                    #region BackPack typ
                    //if (player.BackPack.Count < 10)
                    //{
                    //    player.BackPack.Add(world[player.X, player.Y].Item);

                    //    message += $"\nYou picked up a {world[player.X, player.Y].Item.Name}";

                    //    world[player.X, player.Y].Item = null;
                    //}
                    //else
                    //{
                    //    message += $"\nYour BackPack is full!";
                    //}

                    #endregion

                }
                else if (world[player.X, player.Y].Monster != null)
                {
                    Character opponent = world[player.X, player.Y].Monster;

                    if (opponent.Name == "Dragon")
                    {
                        TextUtils.Animate($"You've come up against a {opponent.Name}! This is a fight till death!");
                        do
                        {
                            message += player.Fight(opponent);
                            //Console.ReadKey(true);
                            if (opponent.Health > 0)
                            {
                                message += opponent.Fight(player);
                                Console.WriteLine(message);
                                Console.ReadKey(true);
                            }
                            message = string.Empty;
                        } while (player.Health > 0 && opponent.Health > 0);

                        if (world[player.X, player.Y].Monster.Health <= 0)
                        {
                            player.BackPack.Add(world[player.X, player.Y].Monster);
                            world[player.X, player.Y].Monster = null;
                        }
                    }
                    else
                    {
                        message += player.Fight(opponent);

                        if (opponent.Health > 0 && player.Health > 0)
                        {
                            message += opponent.Fight(player);
                        }

                        if (world[player.X, player.Y].Monster.Health <= 0)
                        {
                            player.BackPack.Add(world[player.X, player.Y].Monster);
                            world[player.X, player.Y].Monster = null;
                        }

                    }
                }
            }
        }

        private void DisplayWorld()
        {
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    Room room = world[x, y];
                    if (player.X == x && player.Y == y)
                        Console.Write(player.GameChar);
                    else if (room.Monster != null)
                        Console.Write(room.Monster.GameChar);
                    else if (room.Item != null)
                        Console.Write(room.Item.GameChar);
                    else if (room.TreasureChest != null)
                        Console.WriteLine(room.TreasureChest.GameChar);
                    else
                        Console.Write(room.GameChar);
                }
                Console.WriteLine();
            }
        }

        private void GameOver()
        {
            message = string.Empty;
            Console.Clear();
            Console.WriteLine("Game over...");
            Console.ReadKey();
            Play();

        }

        private void CreateWorld()
        {
            world = new Room[20, 5];
            for (int y = 0; y < world.GetLength(1); y++)
            {                   //0an i parentensen = 1a dimension, 1an i parentesen = 2a dimensionen, unt so weiter
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    world[x, y] = new Room();

                    if (player.X != x || player.Y != y)
                    {
                        if (RandomUtils.ChanceForTrueInPercentage(10))
                        {
                            if (RandomUtils.ChanceForTrueInPercentage(50))
                                world[x, y].Monster = new Ogre();
                            else if (RandomUtils.ChanceForTrueInPercentage(40))
                                world[x, y].Monster = new Orc();
                            else
                                world[x, y].Monster = new Dragon();
                        }

                        if (RandomUtils.ChanceForTrueInPercentage(5))
                            world[x, y].Item = new Sword("Dagger (Damage +5)");

                        if (RandomUtils.ChanceForTrueInPercentage(5))
                        {
                            if (RandomUtils.ChanceForTrueInPercentage(90))
                            {
                                world[x, y].Item = new HealingPotion();
                            }
                            else
                                world[x, y].Item = new MagicPotion(world);

                        }

                        if (RandomUtils.ChanceForTrueInPercentage(1))
                        {
                            world[x, y].TreasureChest = new TreasureChest(20);
                        }
                    }
                }
            }
        }

        private void CreatePlayer()
        {
            player = new Player(100, 5, 0, 0);
        }

        private void DisplayInventory(List<IObtainable> BackPack)
        {
            Console.Clear();
            int i = 1;

            Console.WriteLine("|---INVENTORY---|\n");

            foreach (var item in BackPack)
            {
                Console.WriteLine($"{i}. {item.Name}");
                i++;
            }
            Console.ReadKey();
        }
    }
}
