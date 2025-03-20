using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConseProject
{
    class Program
    {
        struct Position
        {
            public int x;
            public int y;
        }
        static void Main(string[] args)
        {
            bool gameOver = false;
            Position playerPos;
            char[,] map;

            Start(out playerPos , out map );
            while (gameOver == false)
            {
                Render(playerPos,map);
                ConsoleKey key = Input();
                Update(key, ref playerPos ,ref map, ref gameOver);
            }

            End();

        }

        static void Start(out Position playerPos, out char[,] map )
        {
            Console.CursorVisible = false;

            //플레이어 초기위치
            playerPos.x = 2;
            playerPos.y = 2;


            //맵
            map = new char[,]
            {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#' },
                {'#',' ',' ',' ',' ','#',' ','y',' ',' ','#','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','y','#' },
                {'#',' ',' ',' ','#',' ',' ','e',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ','#',' ',' ','b',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','y',' ','e','e',' ','#' },
                {'#',' ',' ',' ',' ','#',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','e',' ','#' },
                {'#',' ','#',' ',' ','#','#',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#','b',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ','b',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ','#','#','#','#',' ','#',' ','#',' ','#',' ',' ',' ','e',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#','y',' ','#',' ',' ',' ',' ',' ','#',' ','#',' ',' ',' ','e',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ','#',' ',' ',' ',' ',' ','#',' ','#',' ',' ',' ','e',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ','#',' ',' ','#',' ',' ','#',' ','#',' ',' ',' ','e',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ',' ',' ','#',' ','b','#',' ','#',' ',' ',' ','e',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ','#',' ','#','e',' ',' ',' ',' ',' ','e',' ',' ',' ',' ','#' },
                {'#',' ',' ','#',' ',' ','#',' ',' ','#',' ','#',' ','e',' ',' ',' ','e',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ',' ',' ','#',' ',' ','#',' ','#',' ',' ',' ',' ',' ',' ',' ','e',' ',' ',' ','#' },
                {'#','#','#','#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ','e','y','e',' ',' ','e',' ',' ',' ','#' },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ','b',' ',' ','#' },
                {'#',' ','#',' ','#','#','#',' ',' ',' ',' ','#',' ',' ',' ','e',' ',' ',' ',' ',' ',' ','b','#' },
                {'#','y',' ','b',' ',' ',' ',' ','y',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ','e',' ',' ','#' },
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#' },
            };

        }
        static void Reset(out Position playerPos,out char[,] map)
        {
            //bool gameOver = false;
            playerPos.x = 2;
            playerPos.y = 2;


            //맵
            map = new char[,]
            {
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#' },
                {'#',' ',' ',' ',' ','#',' ','y',' ',' ','#','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','y','#' },
                {'#',' ',' ',' ','#',' ',' ','e',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ','#',' ',' ','b',' ',' ',' ','#',' ',' ',' ',' ',' ',' ','y',' ','e','e',' ','#' },
                {'#',' ',' ',' ',' ','#',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ','e',' ','#' },
                {'#',' ','#',' ',' ','#','#',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#','b',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ','b',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ','#','#','#','#',' ','#',' ','#',' ','#',' ',' ',' ','e',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#','y',' ','#',' ',' ',' ',' ',' ','#',' ','#',' ',' ',' ','e',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ','#',' ',' ',' ',' ',' ','#',' ','#',' ',' ',' ','e',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ','#',' ',' ','#',' ',' ','#',' ','#',' ',' ',' ','e',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ',' ',' ','#',' ','b','#',' ','#',' ',' ',' ','e',' ',' ',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ','#',' ','#','e',' ',' ',' ',' ',' ','e',' ',' ',' ',' ','#' },
                {'#',' ',' ','#',' ',' ','#',' ',' ','#',' ','#',' ','e',' ',' ',' ','e',' ',' ',' ',' ',' ','#' },
                {'#',' ',' ',' ',' ',' ','#',' ',' ','#',' ','#',' ',' ',' ',' ',' ',' ',' ','e',' ',' ',' ','#' },
                {'#','#','#','#',' ',' ','#',' ',' ',' ',' ',' ',' ',' ','e','y','e',' ',' ','e',' ',' ',' ','#' },
                {'#',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ','b',' ',' ','#' },
                {'#',' ','#',' ','#','#','#',' ',' ',' ',' ','#',' ',' ',' ','e',' ',' ',' ',' ',' ',' ','b','#' },
                {'#','y',' ','b',' ',' ',' ',' ','y',' ',' ','#',' ',' ',' ',' ',' ',' ',' ',' ','e',' ',' ','#' },
                {'#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#','#' },
            };
            //while (gameOver == false)
            //{
            //    Render(playerPos, map);
            //    ConsoleKey key = Input();
            //    Update(key, ref playerPos, map, ref gameOver);
            //}
            //End();
        }
        static void Render(Position playerPos, char[,] map)
        {
            
            Console.SetCursorPosition(0, 0);
            PrintMap(map);
            //PrintB(playerPos);
            //PrintY(playerPos);
            PrintPlayer(playerPos);

        }
        static void PrintMap(char[,] map)
        {
            //맵 그리기
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y,x] == 'b')
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (map[y,x] == 'y')
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    else if (map[y,x] == 'x')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    else if (map[y,x] == 'e')
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                        

                    Console.Write(map[y, x]);
                    
                }
                Console.WriteLine();
            }
        }
        static void PrintPlayer(Position playerPos)
        {
            //플레이어 그리기
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(playerPos.x, playerPos.y);
            Console.Write('P');
            Console.ResetColor();
        }
        //static void PrintB(Position playerPos)
        //{
        //    Console.ForegroundColor = ConsoleColor.Blue;
        //    Console.SetCursorPosition(6, 3);
        //    Console.Write('b');
        //}
        //static void PrintY(Position playerPos)
        //{
        //    Console.ForegroundColor = ConsoleColor.Magenta;
        //    Console.SetCursorPosition(8, 3);
        //    Console.Write('y');
        //}
        static ConsoleKey Input()
        {
            return Console.ReadKey(true).Key;
        }
        static void Update(ConsoleKey key, ref Position playerPos,ref char[,] map, ref bool gameOver)
        {
            Move(key, ref playerPos,ref map);

            bool clear = Clear(map);
            if (clear)
            {
                gameOver = true;
            }
            switch (key)
            {
                //리셋 하기
                case ConsoleKey.R:
                    Reset(out playerPos, out map);
                    break;
            }
        }
        static void Move(ConsoleKey key,ref Position playerPos,ref char[,] map)
        {
            Position targetPos;
            Position overPos;
            Position stopPos;

            switch (key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    targetPos.x = playerPos.x - 1;
                    targetPos.y = playerPos.y;
                    stopPos.x = playerPos.x;
                    stopPos.y = playerPos.y;
                    overPos.x = playerPos.x - 2;
                    overPos.y = playerPos.y;
                    playerPos.x--;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    targetPos.x = playerPos.x + 1;
                    targetPos.y = playerPos.y;
                    stopPos.x = playerPos.x;
                    stopPos.y = playerPos.y;
                    overPos.x = playerPos.x + 2;
                    overPos.y = playerPos.y;
                    playerPos.x++;
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    targetPos.x = playerPos.x;
                    targetPos.y = playerPos.y - 1;
                    stopPos.x = playerPos.x;
                    stopPos.y = playerPos.y;
                    overPos.x = playerPos.x;
                    overPos.y = playerPos.y - 2;
                    playerPos.y--;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    targetPos.x = playerPos.x;
                    targetPos.y = playerPos.y + 1;
                    stopPos.x = playerPos.x;
                    stopPos.y = playerPos.y;
                    overPos.x = playerPos.x;
                    overPos.y = playerPos.y + 2;
                    playerPos.y++;
                    break;
                
                default:
                    return;
            }
            //움직이는 방향에 'b'가 있을 때
            if (map[targetPos.y, targetPos.x] == 'b')
            {
                //그 다음 위치에 'y'가 있을 때
                if (map[overPos.y, overPos.x] == 'y')
                {
                    //y 위치에 x로
                    map[overPos.y, overPos.x] = 'x';
                }
                //그 다음 위치에 빈칸이 있을 때
                else if (map[overPos.y, overPos.x] == ' ')
                {
                    //빈칸 위치에 b그리기
                    map[overPos.y, overPos.x] = 'b';
                }
                //그 다음 위치에 벽이 있을 때
                else if (map[overPos.y, overPos.x] == '#')
                {
                    targetPos.x = stopPos.x;
                    targetPos.y = stopPos.y;
                }
                //그 다음 위치에 'e'가 있을 때
                else if (map[overPos.y,overPos.x] == 'e')
                {
                    targetPos.x = stopPos.x;
                    targetPos.y = stopPos.y;
                }
                    //b위치를 빈칸으로
                    map[targetPos.y, targetPos.x] = ' ';
                //플레이어를 움직이려는 위치로 
                playerPos.x = targetPos.x;
                playerPos.y = targetPos.y;
            }
            //움직이는 방향에 'y'가 있을 때
            else if (map[targetPos.y, targetPos.x] == 'y')
            {
                playerPos.x = targetPos.x;
                playerPos.y = targetPos.y;
            }
            //움직이는 방향이 빈칸일 때
            else if (map[targetPos.y, targetPos.x] == ' ')
            {
                playerPos.x = targetPos.x;
                playerPos.y = targetPos.y;
            }
            //움직이는 방향이 벽일 때
            else if (map[targetPos.y, targetPos.x] == '#')
            {
                playerPos.x = stopPos.x;
                playerPos.y = stopPos.y;
            }
            //움직이는 방향이 'e' 가 있을 때
            else if (map[targetPos.y,targetPos.x] == 'e')
            {
                Reset(out playerPos,out map);
            }
        }

        static bool Clear(char[,] map)
        {
            int clearCount = 0;
            foreach (char item in map)
            {
                //클리어 조건 x가 생길때
                if (item == 'y')
                {
                    clearCount++;
                    break;
                }
            }
            if (clearCount == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
                
        }

        static void End()
        {
            Console.Clear();
            Console.WriteLine("스테이지 클리어 !!");
        }
    }
}
