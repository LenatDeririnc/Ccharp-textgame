using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class player
{

    public int en;
    public int rp;
    public int exp;
    public int mn;
    public int memor;

    public player(int EN, int RESPECT, int EXPERIENCE, int MONEY, int MEMORY)
    {
        en += EN;
        rp += RESPECT;
        exp += EXPERIENCE;
        mn += MONEY;
        memor += MEMORY;
    }

}

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "HACKnet";

            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.music);

            Random rnd = new Random();
            int Memory = 10;    int ME = Memory;
            int Energy = 100;   int EN = Energy;
            int Respect = 20;   int RE = Respect;
            int Exp = 30;       int EX = Exp;
            int Money = 1200;   int MO = Money;

            string stats = "";

            int[] inv = new int[10]; string[] invdisc = new string[10];

            inv[0] = 2; invdisc[0] = "Увеличивает энергию на 30 EN";                                    // en+.exe
            inv[1] = 1; invdisc[1] = "Увеличивает энергию на 50 EN";                                    // en++.exe
            inv[2] = 3; invdisc[2] = "Разгоняет компьютер, давая 15 EN и 5 EXP, но отнимая 5 RP";       // drive.exe
            inv[3] = 2; invdisc[3] = "Чистит компьютер от вирусов, давая 5 EN и 3 EXP";                 // cleaner.exe

            int time = 6;
            string mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);

            string action;
            string message = "";

            int work = 0;
            string status = "";

            bool rest = false;

            //string last = "";

            int attackrand;

            sp.PlayLooping();

            while (true) // НАЧАЛО ИГРЫ
            {

                action = "";
                    
                if (Energy > 100)
                        Energy = 100 + ((Energy - 100) / 2);

                if (Memory <= 0 || Energy <= 0 || Respect <= 0 || Exp <= 0)
                {
                    goto gameover;
                }

                if (time == 24)
                {
                    time = 6;
                    mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                    Memory -= 2;
                    Energy += 20;
                    Respect = Respect - 5 + work; 
                    Exp -= 5;
                    Money += 500 * work;

                    if (work >= 10)
                        status = "Да вы себя вообще не жалели!";
                    else if (work >= 5)
                        status = "Вы потрудились на славу!";
                    else if (work >= 1)
                        status = "Вы сегодня маловато поработали.";
                    else
                        status = "Весь день вы только и делали, что валяли дурака.";

                    if (rest == false)  message += "Прошел день. ";
                    else                message += "Вы решили отдохнуть. ";

                    message = message + status + "\nВы отзанимались " + work + " часов работы и вам выплатили соответствующую сумму кредитов.";

                    rest = false;
                }

                Console.WriteLine("//Энергия: \t\t" + Energy);                    
                Console.WriteLine("//Карма: \t\t" + Respect);                     
                Console.WriteLine("//Опыт: \t\t" + Exp);                        
                Console.WriteLine("//Биткоины: \t\t" + Money);                    
                Console.WriteLine();
                Console.WriteLine("-Скачанно файлов: \t" +    Memory + " Гб");          
                Console.WriteLine("-Время: \t\t" +       time + mins);
                Console.WriteLine();

                Console.WriteLine(">hack\t\t -Взломать сеть.");
                Console.WriteLine(">inv\t\t -Инвентарь.");
                Console.WriteLine(">attack\t\t -Провести хакерскую атаку.");
                Console.WriteLine(">BM.com\t\t -Чёрный рынок");
                Console.WriteLine(">playgames\t -Отдохнуть весь день");
                Console.WriteLine(">skip\t\t -Пропустить ход");
                //Console.WriteLine(">last\t\t -Последнее действие");
                Console.WriteLine();

                if (message != "")
                {
                    Console.WriteLine("" + message);
                    Console.WriteLine();
                    message = "";
                }


                
                if (Memory - ME != 0)
                {
                    if (Memory - ME > 0)
                    stats = stats + "+" + (Memory - ME) + " Гб скачанных данных\n";
                    else
                    stats = stats + (Memory - ME) + " Гб скачанных данных\n";
                }

                if (Energy - EN != 0)
                {
                    if (Energy - EN > 0)
                        stats = stats + "+" + (Energy - EN) + " Энергии\n";
                    else
                        stats = stats + (Energy - EN) + " Энергии\n";
                }

                if (Money - MO != 0)
                {
                    if (Money - MO > 0)
                        stats = stats + "+" + (Money - MO) + " Биткойнов\n";
                    else
                        stats = stats + (Money - MO) + " Биткойнов\n";
                }

                if (Exp - EX != 0)
                {
                    if (Exp - EX > 0)
                        stats = stats + "+" + (Exp - EX) + " Опыта\n";
                    else
                        stats = stats + (Exp - EX) + " Опыта\n";
                }

                if (Respect - RE != 0)
                {
                    if (Respect - RE > 0)
                        stats = stats + "+" + (Respect - RE) + " Кармы\n";
                    else
                        stats = stats + (Respect - RE) + " Кармы\n";
                }

                EN = Energy;
                RE = Respect;
                EX = Exp;
                MO = Money;
                ME = Memory;

                if (stats != "")
                {
                    Console.WriteLine("" + stats);
                    stats = "";
                }

                Console.Write(">>>");
                action = Console.ReadLine();
                Console.Beep();

                switch (action)
                {

                    case "hack":
                        Console.WriteLine("\nВыберите программу для взлома\n");
                        Console.WriteLine(">max\t-Максимальная затрата энергии\n>mid\t-Средняя затрата энергии\n");
                        Console.WriteLine("Для возвращения назад, введите любую другую команду.\n");
                        Console.Write(">>>hack/");
                        action = Console.ReadLine();
                        Console.Beep();
                        switch (action)
                        {
                            case "max":
                                work += 1;
                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                message = "Программа max.exe проработала 1 час. \nОна использовала всю вашу энергию по максимому";
                                
                                

                                Memory += 5;
                                Energy -= 30;
                                break;

                            case "mid":
                                work += 1;
                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                message = "Программа min.exe проработала 1 час. \nЭтим вы немного сэкономили энергию.";

                                Memory += 2;
                                Energy -= 15;
                                break;
                            default:
                                message = "Отмена операции.";
                                break;
                        }
                        break;

                    case "inv":
                        Console.WriteLine("\nЗдесь хранятся все ваши одноразовые программы, купленные с BM.com.\nВыберите программу, которую вы хотите использовать.\n");
                        Console.WriteLine(">en+ \t\t{0} \n>en++ \t\t{1} \n>drive \t\t{2} \n>cleaner \t{3} \n", inv[0], inv[1], inv[2], inv[3]);
                        Console.WriteLine("Для возвращения назад, введите любую другую команду.\n");
                        Console.Write(">>>");
                        action = Console.ReadLine();
                        Console.Beep();
                        switch (action)
                        {
                            case "en+":
                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                inv[0] -= 1;
                                Energy += 30;
                                message = "Вы приняли обезболивающее и восполнили 30 ОЗ. \nТеперь у вас " + inv[0] + " обезболивающих";
                                
                                break;

                            case "en++":
                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                inv[1] -= 1;
                                Energy += 50;
                                message = "Вы использовали аптечку и восполнили 50 ОЗ. \nТеперь у вас " + inv[1] + " аптечек";

                                break;

                            case "drive":
                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                inv[2] -= 1;
                                Energy += 15;
                                Exp += 5;
                                message = "Ускоритель drive.exe разогнал ваш компьютер до максимально возможной производительности.";

                                break;

                            case "cleaner":
                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                inv[3] -= 1;
                                Energy += 5;
                                Exp += 3;
                                message = "С помощью cleaner.exe вы успешно очистили компьютер от вирусов";

                                break;

                            default:
                                message = "Вы передумали...";
                                break;

                        }
                        break;

                    case "attack":
                        Console.WriteLine("\nВы хотите атаковать чужую сеть.\nКакую сеть вы хотите атаковать?\n");
                        Console.WriteLine(">samizdat\t- Известная газета с низким уровнем защиты. (Рек. ур. >10 ex)");
                        Console.WriteLine(">company72\t-Крупная корпарация по производству устройств. На ней стоит защита средней сложности. (Рек. ур. >50 ex)");
                        Console.WriteLine(">whitehouse\t- официальная резиденция президента. Крайне не рекомендуется направлять атаку именно туда. (Рек. ур. >100 ex)");
                        Console.WriteLine();
                        Console.WriteLine("Для возвращения назад, введите любую другую команду.\n");
                        Console.Write(">>>attack/");
                        action = Console.ReadLine();
                        Console.Beep();

                        int enemy;

                        switch (action)
                        {
                            case "samizdat":

                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);

                                enemy = 10;

                                attackrand = rnd.Next(0, (Exp + enemy) + 1);

                                if (attackrand <= Exp)
                                {
                                    Energy -= ((enemy + Exp) / Exp);
                                    Respect += ((enemy + Exp) / Exp)*5;
                                    Money += ((enemy + Exp) / Exp) * 100;
                                    message = "Вы успешно атаковали сервер samizdat'а.";
                                    message += "\nШансы на победу: " + Exp + "/" + (enemy + Exp) + " ( " + (Exp * 100 / (enemy + Exp)) + "% )";
                                    //message += "\nattackrand = " + attackrand;
                                }
                                else
                                {
                                    Energy -= ((enemy + Exp) / Exp) * 10;
                                    Respect -= ((enemy + Exp) / Exp) * 10;
                                    message = "Атака сервера samizdat'а прошла неудачно.";
                                    message += "\nШансы на победу: " + Exp + "/" + (enemy + Exp) + " ( " + (Exp * 100 / (enemy + Exp)) + "% )";
                                    //message += "\nattackrand = " + attackrand;
                                }

                                break;

                            case "company72":

                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);

                                enemy = 50;

                                attackrand = rnd.Next(0, (Exp + enemy) + 1);

                                if (attackrand <= Exp)
                                {
                                    Energy -= ((enemy + Exp) / Exp);
                                    Respect += ((enemy + Exp) / Exp) * 5;
                                    Money += ((enemy + Exp) / Exp) * 100;
                                    message = "Вы успешно атаковали сервер samizdat'а.";
                                    message += "\nШансы на победу: " + Exp + "/" + (enemy + Exp) + " ( " + (Exp * 100 / (enemy + Exp)) + "% )";
                                    //message += "\nattackrand = " + attackrand;
                                }
                                else
                                {
                                    Energy -= ((enemy + Exp) / Exp) * 10;
                                    Respect -= ((enemy + Exp) / Exp) * 10;
                                    message = "Атака сервера samizdat'а прошла неудачно.";
                                    message += "\nШансы на победу: " + Exp + "/" + (enemy + Exp) + " ( " + (Exp * 100 / (enemy + Exp)) + "% )";
                                    //message += "\nattackrand = " + attackrand;
                                }

                                break;

                            case "whitehouse":

                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);

                                enemy = 100;

                                attackrand = rnd.Next(0, (Exp + enemy) + 1);

                                if (attackrand <= Exp)
                                {
                                    Energy -= ((enemy + Exp) / Exp);
                                    Respect += ((enemy + Exp) / Exp) * 5;
                                    Money += ((enemy + Exp) / Exp) * 100;
                                    message = "Вы успешно атаковали сервер samizdat'а.";
                                    message += "\nШансы на победу: " + Exp + "/" + (enemy + Exp) + " ( " + (Exp * 100 / (enemy + Exp)) + "% )";
                                    //message += "\nattackrand = " + attackrand;
                                }
                                else
                                {
                                    Energy -= ((enemy + Exp) / Exp) * 10;
                                    Respect -= ((enemy + Exp) / Exp) * 10;
                                    message = "Атака сервера samizdat'а прошла неудачно.";
                                    message += "\nШансы на победу: " + Exp + "/" + (enemy + Exp) + " ( " + (Exp * 100 / (enemy + Exp)) + "% )";
                                    //message += "\nattackrand = " + attackrand;
                                }

                                break;

                            default:
                                message = "Отмена операции.";
                                break;
                        }
                        break;

                    case "BM.com":
                        Console.WriteLine("\nДобро пожаловать в BM.com!\nВыберите программу, которую вы желаете приобрести.\n");
                        Console.WriteLine(">en+ \t\t{0} \n>en++ \t\t{1} \n>drive \t\t{2} \n>cleaner \t{3} \n", 100, 500, 300, 150);
                        Console.WriteLine("Для возвращения назад, введите любую другую команду.\n");
                        Console.Write(">>>");
                        action = Console.ReadLine();
                        Console.Beep();
                        switch (action)
                        {
                            case "en+":
                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                if (Money >= 100)
                                {
                                    Money -= 100;
                                    inv[0] += 1;
                                    message = "Вы приобрели en+";
                                }
                                else
                                {
                                    message = "На вашем счёте недостаточно средств";
                                }

                                break;

                            case "en++":
                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                if (Money >= 500)
                                {
                                    Money -= 500;
                                    inv[1] += 1;
                                    message = "Вы приобрели en++";
                                }
                                else
                                {
                                    message = "На вашем счёте недостаточно средств";
                                }

                                break;

                            case "drive":
                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                if (Money >= 300)
                                {
                                    Money -= 300;
                                    inv[2] += 1;
                                    message = "Вы приобрели drive";
                                }
                                else
                                {
                                    message = "На вашем счёте недостаточно средств";
                                }

                                break;

                            case "cleaner":
                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                if (Money >= 150)
                                {
                                    Money -= 150;
                                    inv[3] += 1;
                                    message = "Вы приобрели cleaner";
                                }
                                else
                                {
                                    message = "На вашем счёте недостаточно средств";
                                }
                                break;

                            default:
                                message = "Отмена операции.";
                                break;

                        }
                        break;

                    case "playgames":

                        rest = true;
                        time = 24;

                        break;

                    case "skip":
                        time += 1;
                        mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);

                        message = "Вы пропустили 1 час";
                        break;
                   

                    default:
                        message = "ОШИБКА: Неверно введена команда.";
                        if (Energy > 100)
                            Energy += (Energy - 100);
                        break;
                }


                if (time == 24)
                {
                    Console.Beep();
                    Console.Beep();
                }
                Console.Clear();
                };
            gameover:
            Console.WriteLine("Игра окончена.\n");
            if (Memory <= 0)
            {
                Console.WriteLine("- Вы потеряли все скаченные файлы.");
            }
            if (Energy <= 0)
            {
                Console.WriteLine("- Ваша инергия упала до нуля.");
            }
            if (Respect <= 0)
            {
                Console.WriteLine("- Ваша карма упала до нуля.");
            }
            if (Exp <= 0)
            {
                Console.WriteLine("- Ваш опыт упал до нуля.");
            }
            Console.WriteLine("\n>Нажмите любую клавишу, чтобы закрыть игру.");
            Console.ReadKey();

        }
    }
}
