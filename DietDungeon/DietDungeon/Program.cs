using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietDungeon
{
    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Gold { get; }

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }

    public class Monster
    {
        public string Name { get; }
        public int Level { get; }
        public int Hp { get; }
        public int Atk { get; } 

        public Monster(string name, int level, int hp, int atk)
        {
            Name = name;
            Level = level;
            Hp = hp;
            Atk = atk;
        }

        public void MonsterDescription()
        {
            Console.WriteLine($" Lv.{Level} {Name} | HP {Hp}");
        }
    }

    internal class Program
    {
        static Character player;
        static Monster[] monsters;

        static void Main(string[] args)
        {
            PrintStartLogo();
            GameDataSetting();
            StartMenu();
        }

        private static void PrintStartLogo()
        {
            Console.WriteLine("");
            Console.WriteLine(" ==================================================================");
            Console.WriteLine("");
            Console.WriteLine("   ██     ██ ███████ ██      ██       ██████  ██████  ███    ███  ");
            Console.WriteLine("   ██     ██ ██      ██      ██      ██      ██    ██ ████  ████  ");
            Console.WriteLine("   ██  █  ██ █████   ██      ██      ██      ██    ██ ██ ████ ██  ");
            Console.WriteLine("   ██ ███ ██ ██      ██      ██      ██      ██    ██ ██  ██  ██  ");
            Console.WriteLine("    ███ ███  ███████ ███████ ███████  ██████  ██████  ██      ██  ");
            Console.WriteLine("                                                                  ");
            Console.WriteLine("                                                                  ");
            Console.WriteLine("                  ██████    ██   ███████  ████████                ");
            Console.WriteLine("                  ██   ██   ██   ██          ██                   ");
            Console.WriteLine("                  ██   ██   ██   █████       ██                   ");
            Console.WriteLine("                  ██   ██   ██   ██          ██                   ");
            Console.WriteLine("                  ██████    ██   ███████     ██                   ");
            Console.WriteLine("                                                                  ");
            Console.WriteLine("                                                                  ");
            Console.WriteLine("   ██████  ██    ██ ███    ██  ██████  ███████  ██████  ███    ██ ");
            Console.WriteLine("   ██   ██ ██    ██ ████   ██ ██       ██      ██    ██ ████   ██ ");
            Console.WriteLine("   ██   ██ ██    ██ ██ ██  ██ ██   ███ █████   ██    ██ ██ ██  ██ ");
            Console.WriteLine("   ██   ██ ██    ██ ██  ██ ██ ██    ██ ██      ██    ██ ██  ██ ██ ");
            Console.WriteLine("   ██████   ██████  ██   ████  ██████  ███████  ██████  ██   ████ ");
            Console.WriteLine("");
            Console.WriteLine(" ==================================================================");
            Console.WriteLine("                       PRESS ANYKEY TO START                       ");
            Console.WriteLine(" ==================================================================");
            Console.ReadKey();
        }

        private static void GameDataSetting()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(" 캐릭터의 이름을 입력해주세요.");
            Console.WriteLine("");
            Console.Write(" >> ");
            string Name = Console.ReadLine();

            player = new Character($"{Name}", "초보자", 1, 10, 5, 100, 1500);

            monsters = new Monster[3];
            monsters[0] = new Monster("탕후루", 2, 15, 5);
            monsters[1] = new Monster("떡볶이", 3, 25, 9);
            monsters[2] = new Monster("대창", 5, 20, 8);

        }

        private static void StartMenu()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽");
            Console.WriteLine("");
            Console.WriteLine("다이어트 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽◾◽");
            Console.WriteLine("");

            Console.WriteLine("< 다이어트 마을 >\n");
            Console.WriteLine("[활동 선택]\n");

            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 전투 시작");
            Console.WriteLine("3. 게임 종료");
            Console.WriteLine("");

            switch (CheckValidInput(1, 3))
            {
                case 1:
                    StatusMenu();
                    break;
                case 2:
                    BattleStart();
                    break;
                case 3:
                    return;
            }
        }

        private static void StatusMenu()
        {
            Console.Clear();

            ShowHighlightedText("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("");
            PrintTextwithHighlights("Lv. ", player.Level.ToString("00")); // 01, 07
            Console.WriteLine("{0} ( {1} )", player.Name, player.Job);
            PrintTextwithHighlights("공격력 : ", player.Atk.ToString());
            PrintTextwithHighlights("방어력 : ", player.Def.ToString());
            PrintTextwithHighlights("체력 : ", player.Hp.ToString());
            PrintTextwithHighlights("Gold : ", player.Gold.ToString(), " G");
            Console.WriteLine("");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("");
            switch (CheckValidInput(0, 0))
            {
                case 0:
                    StartMenu();
                    break;
            }
        }

        private static void BattleStart()
        {
            Console.Clear();

            Console.WriteLine("");
            ShowHighlightedText(" Battle!!");
            Console.WriteLine("");

            int count = new Random().Next(1,5);

            for(int i = 0; i < count; ++i)
            {
                int idx = new Random().Next(0, 3);
                monsters[idx].MonsterDescription();
            }

            Console.WriteLine();
            Console.WriteLine(" [내 정보]");
            Console.WriteLine($" Lv.{player.Level} {player.Name} ({player.Job})");
            Console.WriteLine(" HP {0}/100",player.Hp.ToString());//100부분 {1}로 바꿔서 써도 될거같아요

            Console.WriteLine("");
            Console.WriteLine("1. 공격");
            Console.WriteLine("");

            switch (CheckValidInput(1, 1))
            {
                case 1:
                    Battle();
                    break;
            }

        }

        private static void Battle()
        {
            
        }

        private static void PrintTextwithHighlights(string s1, string s2, string s3 = "")
        {
            Console.Write(s1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(s2);
            Console.ResetColor();
            Console.WriteLine(s3);
        }

        private static void ShowHighlightedText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static int CheckValidInput(int min, int max)
        {
            // 아래 두 가지 상황은 비정상 -> 재입력 수행
            // (1) 숫자가 아닌 입력을 받은 경우
            // (2) 숫자가 최소값 ~ 최대값의 범위를 넘는 경우

            Console.WriteLine("원하시는 행동을 입력해주세요.");

            while (true)
            {
                Console.Write(">> ");
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (min <= ret && ret <= max)
                        return ret;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("잘못된 입력입니다.");
                Console.ResetColor();
            }

        }




    }
}

