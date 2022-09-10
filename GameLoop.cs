using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Find_BombGame
{
    //2차원 배열 초기화하는데 -> 주변의 폭탄 갯수로 +100 / if Map_Pos >100 = ■ 출력 / 스페이스바가 눌리면 -100이나 % 100초기에 저장한 이 타일의 정보가 나온다
    //ex) 3개 -> 103(스페이스바 눌리기 전)
    //나머지 값을 계산해서 3을 출력
    //100~ 109 
    //폭탄이면 199
    //
    // 폭탄 배치 -> 갯수 받은 만큼
    // 폭탄이 아닌 타일은 주변 폭탄 갯수를 세요
    // 폭탄이 아닌 타일은 0 ~ 8 까지 초기화가 완료
    // 2차원 배열 모든 값에 +100 -> 100 ~ 108, 폭탄은 199
    // Map_pos[index,index] >= 100 -> ■ 출력 (스페이스 바 눌리기 전 초기화면)
    // 스페이스바가 눌리면 -100 또는 % 100을 해주어서 저희 초기에 저장값을 만들어준다
    // ex) 초기 정보가 3 -> 103 -> 스페이스바가 눌리면 -> 3 -> 3이라는 정보를 출력이 가능
    internal class GameLoop
    {
        public int MapSize;
        public int BombSize;

        Player player;
        Random random = new Random();
        public int[,] Map_Pos; // 얘 값 초기화
        public bool NeedRefresh = true;
        public int x;
        public int y;
        int Bomb_count;
        int Num_count;
        bool isGameOver = false;
        public void Awake()
        {
            //처음 맵 설정 입력 받기
            Console.WriteLine("맵의 크기?");
            MapSize = int.Parse(Console.ReadLine());

            //커서 지우기
            Console.CursorVisible = false;

            //폭탄의 갯수 입력 받기
            Console.WriteLine("폭탄 몇개?");
            BombSize = int.Parse(Console.ReadLine());
            Console.Clear();
        }
        public void Start()
        {
            player = new Player();
            player.Awake();
            player.Start();
            player.SetMapSize(MapSize);
            Map_Pos = new int[MapSize, MapSize];

            MakeBomb();
        }
        public void Factorial(int P_xpos, int P_ypos)
        {
            if (Map_Pos[P_ypos, P_xpos] == 100) //좌표값이 100일때 무조건 들어옴
            {
                Map_Pos[P_ypos, P_xpos] = 0; //
                for (int x = -1; x < 2; x++)
                {
                    if (P_xpos + x < 0 || P_xpos + x >= MapSize) // 맵 범위를 넘어갔을때 그냥 지나감
                    {
                        continue;
                    }
                    for (int y = -1; y < 2; y++)
                    {
                        if (P_ypos + y < 0 || P_ypos + y >= MapSize || (x == 0 && y == 0)) //본인값일때
                        {
                            continue;
                        }
                        Factorial(P_xpos + x, P_ypos + y);
                    }
                }

                /*if (Map_Pos[P_ypos - 1, P_xpos] == 0) { Map_Pos[P_ypos - 1, P_xpos] -= 100; } // 상
                if (Map_Pos[P_ypos + 1, P_xpos] == 0) { Map_Pos[P_ypos + 1, P_xpos] -= 100; } // 하
                if (Map_Pos[P_ypos, P_xpos - 1] == 0) { Map_Pos[P_ypos, P_xpos - 1] -= 100; } //좌
                if (Map_Pos[P_ypos, P_xpos + 1] == 0) { Map_Pos[P_ypos, P_xpos + 1] -= 100; } //우
                if (Map_Pos[P_ypos - 1, P_xpos - 1] == 0) { Map_Pos[P_ypos - 1, P_xpos - 1] -= 100; } // 좌상
                if (Map_Pos[P_ypos + 1, P_xpos - 1] == 0) { Map_Pos[P_ypos + 1, P_xpos - 1] -= 100; } // 좌하
                if (Map_Pos[P_ypos - 1, P_xpos + 1] == 0) { Map_Pos[P_ypos - 1, P_xpos + 1] -= 100; } //우상
                if (Map_Pos[P_ypos + 1, P_xpos + 1] == 0) { Map_Pos[P_ypos + 1, P_xpos + 1] -= 100; } //우하*/
                //맵범위체크하는것도 추가해야함

            }
            /*if (Map_Pos[P_ypos, P_xpos] != 0) 
            {
                for (int i = 8; i > 0; i--)
                {
                    if (Map_Pos[P_ypos, P_xpos] == i) { return Map_Pos[P_ypos, P_xpos] == i; }
                }
            }*/


        }
        public void MakeBomb() //폭탄 배치
        {
            //주변 폭탄 갯수 체크하는 것부터 하고
            //그 다음에 2차원 배열 모든 값에 +100

            //for (int i = 0; i < BombSize; i++)
            //{
            /* Bomb_xPos[i] = random.Next(); //값이 아님 index 임
             Bomb_yPos[i] = random.Next();
             Map_Pos[Bomb_yPos[i], Bomb_xPos[i]] = 99;

             if (Map_Pos[Bomb_yPos[i], Bomb_xPos[i]] == 99)
             {
                 //Console.Write("■");
                 continue;
             }*/

            Bomb_count = 0;

            while (Bomb_count != BombSize) //중복 제거 & 폭탄 위치
            {
                x = random.Next(0, MapSize - 1); //각 좌표에 랜덤한 값을 넣어줘
                y = random.Next(0, MapSize - 1);

                if (Map_Pos[y, x] != 99) //폭탄이 아닐때
                {
                    Map_Pos[y, x] = 99; //폭탄값을 넣어줘
                    Bomb_count++; //폭탄 갯수를 세어줘

                    /*for (int i = 0; i < MapSize; i++)
                    {
                        for (int j = 0; j < MapSize; j++)
                        {
                            if (Map_Pos[i, j] == 99) { Map_Pos[i, j]++; }

                        }
                    }*/

                    //폭탄 범위 체크 / 폭탄 카운트
                    if (y - 1 > 0) { Map_Pos[y - 1, x]++; } // 상
                    if (y + 1 < MapSize) { Map_Pos[y + 1, x]++; } // 하
                    if (x - 1 > 0) { Map_Pos[y, x - 1]++; } //좌
                    if (x + 1 < MapSize) { Map_Pos[y, x + 1]++; } //우
                    if (x - 1 > 0 && y - 1 > 0) { Map_Pos[y - 1, x - 1]++; } // 좌상
                    if (x - 1 > 0 && y + 1 < MapSize) { Map_Pos[y + 1, x - 1]++; } // 좌하
                    if (x + 1 < MapSize && y - 1 > 0) { Map_Pos[y - 1, x + 1]++; } //우상
                    if (x + 1 < MapSize && y + 1 < MapSize) { Map_Pos[y + 1, x + 1]++; } //우하

                }

            }

            for (int i = 0; i < MapSize; i++)
            {
                for (int j = 0; j < MapSize; j++)
                {
                    Map_Pos[i, j] += 100; //맵 전체 좌표에 100을 더해줌
                }
            }

        }
        public void Update()
        {
            if (Console.KeyAvailable) //캐릭터 이동
            {
                Console.Clear(); //Tick을 넣을 필요가 없는 이유 : 키가 사용되었을때만 지우고 다시 그려주면 되기 때문에

                ConsoleKeyInfo Key = Console.ReadKey();

                switch (Key.Key)
                {
                    case ConsoleKey.RightArrow:
                        player.KeyRight();
                        break;

                    case ConsoleKey.LeftArrow:
                        player.KeyLeft();
                        break;

                    case ConsoleKey.UpArrow:
                        player.KeyUp();
                        break;

                    case ConsoleKey.DownArrow:
                        player.KeyDown();
                        break;

                    case ConsoleKey.Spacebar:
                        Factorial(player.P_xpos, player.P_ypos);
                        if (Map_Pos[player.P_ypos, player.P_xpos] > 100)
                        {
                            Map_Pos[player.P_ypos, player.P_xpos] -= 100; //더해줬던 100의 값만큼 빼주고 남은 값을 계산                        
                        }

                        break;

                    default:
                        Console.WriteLine("■");
                        break;
                }

                player.Update();
            }
        }
        public void Render()
        {
            if (NeedRefresh == false) { return; }
            if (isGameOver == false)
            {
                Console.SetCursorPosition(0, 0); //맵 그리기
                for (int i = 0; i < MapSize; i++)
                {
                    for (int j = 0; j < MapSize; j++)
                    {
                        switch (Map_Pos[i, j])
                        {
                            case 0:
                                Console.Write("  "); //공백 퍼지기 해줘야 함
                                break;
                            case 1:
                                Console.Write("①");
                                break;
                            case 2:
                                Console.Write("②");
                                break;
                            case 3:
                                Console.Write("③");
                                break;
                            case 4:
                                Console.Write("④");
                                break;
                            case 5:
                                Console.Write("⑤");
                                break;
                            case 6:
                                Console.Write("⑥");
                                break;
                            case 7:
                                Console.Write("⑦");
                                break;
                            case 8:
                                Console.Write("⑧");
                                break;
                            case 99:
                                Console.Write("♠");
                                NeedRefresh = false;
                                isGameOver = true;

                                break;
                            default:
                                Console.Write("□");
                                break;
                        }
                        if (!NeedRefresh)
                            break;
                    }
                    Console.WriteLine(); // 스페이스바를 누를 경우 클리어 하고 숫자 또는 폭탄 출력
                                         // Console.Write(player.P_xpos +"  "+player.P_ypos);
                }

            }

            player.Render();
            if (isGameOver == true)
            {
                //게임종료
                Console.Clear();
                Console.SetCursorPosition(10, 10);
                Console.WriteLine("Game Over");
            }

            //스페이스바를 누를 때 동작할 함수
            //count++;
            //현재 위치 주변 8곳 확인하는 함수
            //맵범위를 벗어나는 경우 제외 (continue;)

            //폭탄 주변 위치파악
        }
    }
}

/*public void SpaceBar()
        {
            for (int i = 0; i < BombSize; i++) //폭탄 갯수만큼
            {
                Map_Pos[Bomb_xPos[i], Bomb_yPos[i]] = 99;

                if (Map_Pos[Bomb_xPos[i], Bomb_yPos[i]] == i) { map.dir = i; map.Spacebar(); }
                for (int y = Bomb_yPos[i] - 1; y <= Bomb_yPos[i] + 1; y++) // 폭탄 위 칸이 폭탄 아래 칸보다 작
                {
                    for (int x = Bomb_xPos[i] - 1; x <= Bomb_xPos[i] + 1; x++)
                    {
                        //Console.SetCursorPosition(x * 2, y);
                        if (Map_Pos[Bomb_xPos[i], Bomb_yPos[i]] == i) { map.dir = i; map.Spacebar(); }

                        if (Map_Pos[Bomb_xPos[i], Bomb_yPos[i]] == 0) { Console.Write(" "); }
                        if (Map_Pos[Bomb_xPos[i], Bomb_yPos[i]] == 1) { Console.Write("①"); }
                        if (Map_Pos[Bomb_xPos[i], Bomb_yPos[i]] == 2) { Console.Write("②"); }
                        if (Map_Pos[Bomb_xPos[i], Bomb_yPos[i]] == 3) { Console.Write("③"); }
                        if (Map_Pos[Bomb_xPos[i], Bomb_yPos[i]] == 4) { Console.Write("④"); }
                        if (Map_Pos[Bomb_xPos[i], Bomb_yPos[i]] == 5) { Console.Write("⑤"); }
                        if (Map_Pos[Bomb_xPos[i], Bomb_yPos[i]] == 6) { Console.Write("⑥"); }
                        if (Map_Pos[Bomb_xPos[i], Bomb_yPos[i]] == 7) { Console.Write("⑦"); }
                        if (Map_Pos[Bomb_xPos[i], Bomb_yPos[i]] == 8) { Console.Write("⑧"); }

                        Map_Pos[Bomb_xPos[i], Bomb_yPos[i]]++;
                    }
                }
            }
        }*/