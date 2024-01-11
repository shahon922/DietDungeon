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

    internal class Program
    {
        static Character _player;

        static void Main(string[] args)
        {
            GameDataSetting();
            StartMenu();
        }

        private static void StartMenu()
        {
            Console.Clear();
            Console.WriteLine("다이어트 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 전투 시작");
            Console.WriteLine("");

            switch (CheckValidInput(1, 2))
            {
                case 1:
                    StatusMenu();
                    break;
            }
        }

        private static void StatusMenu()
        {
            Console.Clear();

            ShowHighlightedText("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            Console.WriteLine("");
            PrintTextwithHighlights("Lv. ", _player.Level.ToString("00")); // 01, 07
            Console.WriteLine("{0} ( {1} )", _player.Name, _player.Job);
            PrintTextwithHighlights("공격력 : ", _player.Atk.ToString());
            PrintTextwithHighlights("방어력 : ", _player.Def.ToString());
            PrintTextwithHighlights("체력 : ", _player.Hp.ToString());
            PrintTextwithHighlights("Gold : ", _player.Gold.ToString(), " G");
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
            Console.Write(">>");
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("잘못된 입력입니다.");
                Console.ResetColor();
            }

        }

        private static void GameDataSetting()
        {
            Console.WriteLine("이름을 입력해주세요.");
            Console.WriteLine("");
            string Name = Console.ReadLine();

            _player = new Character($"{Name}", "전사", 1, 10, 5, 100, 1500);
        }
    }
}