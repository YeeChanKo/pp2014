using System;

namespace Next
{
    public class NumPuzzle
    {
        public int shuffletime; // 셔플할 횟수
        public int size; // 숫자퍼즐의 사이즈
        private bool gameplay = true; // 게임을 계속 진행할지 여부
        private int[,] board; // 숫자퍼즐의 값을 담는 2차원 배열 선언
        private int[] movable = new int[5]; // 움직일 수 있는 숫자들의 집합 //5로 한 것은 예외처리 위해
        private int count = 0; // 몇번만에 맞췄는지 카운트
        private int zerox; // 0의 배열 X위치
        private int zeroy; // 0의 배열 Y위치

        public void Init(int size) // board[,] 초기화 
        {
            board = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = i * size + j + 1;
                }
            }
            board[size - 1, size - 1] = 0;
        }

        private void Print() // board[,] 전체출력
        {
            Console.WriteLine("{0}번째 턴: ", count);
            for (int i = 0; i < size; i++)
            {
                Console.Write("\t");
                for (int j = 0; j < size; j++)
                    Console.Write("{0,3:D} ", board[i, j]);
                Console.WriteLine();
            }
        }

        private int PrintWhatToSwap() // 바꿀 숫자 입력 받기
        {
            Console.Write("0과 바꿀 숫자: ");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            count++; // 여기서 카운터 증가

            if (num == 0)
                gameplay = false;
            else if (num < 0)
                Shuffle();
            return num;
        }

        private void FindZero() // 0의 위치 찾아서 zerox와 zeroy에 넣기
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[i, j] == 0)
                    {
                        zerox = i;
                        zeroy = j;
                        break;
                    }
                }
            }
        }

        private void FindMovableForShuffle() // 이동가능한 숫자 찾기
        {
            FindZero();
            int i = 0;
            if (zerox + 1 < size && zerox + 1 >= 0)
            {
                movable[i] = board[zerox + 1, zeroy];
                i++;
            }
            if (zerox - 1 < size && zerox - 1 >= 0)
            {
                movable[i] = board[zerox - 1, zeroy];
                i++;
            }
            if (zeroy + 1 < size && zeroy + 1 >= 0)
            {
                movable[i] = board[zerox, zeroy + 1];
                i++;
            }
            if (zerox - 1 < size && zeroy - 1 >= 0)
            {
                movable[i] = board[zerox, zeroy - 1];
                i++;
            }
            movable[i] = -1; // movable의 마지막 위치 책갈피, 음수 나오면 종료시키기
        }

        private void FindMovableForPlay() // 이동가능한 숫자 찾고 출력
        {
            FindMovableForShuffle();
            Console.Write("움직일 수 있는 숫자는 ");
            for (int i = 0; i < movable.Length && movable[i] > 0; i++)
            {
                Console.Write("{0}", movable[i]);
                if (movable[i + 1] > 0)
                    Console.Write(", ");
            }
            Console.WriteLine("입니다.");
        }

        private void Swap(int a) // 숫자 위치 바꾸기
        {
            int temp = 0;
            int ax = 0, ay = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[i, j] == a)
                    {
                        ax = i;
                        ay = j;
                    }
                }
            }

            temp = board[ax, ay];
            board[ax, ay] = board[zerox, zeroy];
            board[zerox, zeroy] = temp;
        }

        private bool Check() // 퍼즐이 맞춰졌는지 여부 검사(false면 게임계속, true면 게임오버)
        {
            bool status = true;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if ((i == (size - 1)) && (j == (size - 1)))
                    {
                         if (board[size-1,size-1] != 0)
                         {
                             status = false;
                         }
                    }
                    else
                    {
                        if(board[i,j] != (i * size + j + 1))
                        {
                            status = false;
                        }
                    }
                }
            }
            return status;
        }

        private void PrintMessage() // 결과 메시지 출력
        {
            if (gameplay == true && Check() == true)
                Console.WriteLine("축하합니다!!! {0}번만에 해내셨군요!", count);
            else
                Console.WriteLine("{0}번만에 포기하는 건가요...ㅠㅠ", count - 1);
        }

        private void Shuffle() // 숫자퍼즐 섞기
        {
            do
            {
                for (int time = shuffletime; time > 0; time--)
                {
                    FindZero();
                    FindMovableForShuffle();
                    Random r = new Random();
                    int a = r.Next(0, 3);
                    while (movable[a] < 0)
                    {
                        a = r.Next(0, 3);
                    }
                    Swap(movable[a]);
                }
            } while (Check() == true);
            count = 0; // Shuffle시 카운트 초기화됨
        }

        public void Play() // 게임플레이
        {
            Console.WriteLine();
            Console.WriteLine("=============== 신나는 숫자퍼즐 게임에 오신 걸 환영합니다!!! ===============");
            Console.WriteLine();
            Console.Write("숫자퍼즐의 사이즈: ");
            size = Convert.ToInt32(Console.ReadLine());
            Console.Write("랜덤셔플할 횟수: ");
            shuffletime = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("****** 기권하려면 0을 입력 ******");
            Console.WriteLine("*** 다시 셔플하려면 -1을 입력 ***");
            Console.WriteLine();

            Init(size);
            Shuffle();

            while (gameplay == true && Check() == false)
            {
                Print();
                FindMovableForPlay();
                Swap(PrintWhatToSwap());
            }

           PrintMessage();
        }
    }

    class Game
    {
        static void Main() // 메인 메소드 시작
        {
            string retry = "1";
            string quit = "2";
            string answer;

            NumPuzzle np1 = new NumPuzzle();
            do
            {
                np1 = new NumPuzzle();
                np1.Play();

                do
                {
                    Console.WriteLine();
                    Console.Write("재도전하려면 1번, 종료하려면 2번을 눌러주세요: ");
                    answer = Console.ReadLine();
                    if (quit == answer)
                        Console.WriteLine("빠이 짜이찌엔!");
                    else
                        Console.WriteLine("다시 입력해주세요!");
                }while (answer != retry && answer != quit);
            }while(answer==retry);
            Console.ReadLine();
        }
    }
}