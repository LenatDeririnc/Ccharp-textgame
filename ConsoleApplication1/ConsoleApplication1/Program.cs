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

            int enemy;

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

                    if (rest == false)  message += "\nПрошел день. ";
                    else                message += "Вы решили отдохнуть. ";

                    message = message + status + "\nВы отзанимались " + work + " часов работы и вам выплатили соответствующую сумму кредитов.";

                    work = 0;

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
                Console.WriteLine(">bm.com\t\t -Чёрный рынок");
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
                        message += ("\nВыберите программу для взлома\n");
                        message += (">hack/max\t-Максимальная затрата энергии\n>hack/mid\t-Средняя затрата энергии\n");
                        message += ("Для возвращения назад, введите любую другую команду.\n");
                        break;

                                case "hack/max":
                                work += 1;
                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                message = "Программа max.exe проработала 1 час. \nОна использовала всю вашу энергию по максимому\n";

                                Memory += 5;
                                Energy -= 30;
                                break;

                                case "hack/mid":
                                work += 1;
                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                message = "Программа min.exe проработала 1 час. \nЭтим вы немного сэкономили энергию.\n";

                                Memory += 2;
                                Energy -= 15;
                                break;

                    case "inv":
                        message += ("Выберите программу\n");
                        message += (">inv/en+ \t\t" + inv[0] + "\t - +30 Энергии \n>inv/en++ \t\t" + inv[1] + "\t - +50 Энергии \n>inv/drive \t\t" + inv[2] + "\t - +15 Энергии +5 Опыта \n>inv/cleaner \t" + inv[3] + "\t - +5 Энергии +3 Опыта \n");
                        break;

                    case "inv/en+":
                                    time += 1;
                                    mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                    inv[0] -= 1;
                                    Energy += 30;
                                    message = "Вы увеличили энергию на 30%. \nТеперь у вас " + inv[0] + " програм en+";

                                    break;

                    case "inv/en++":
                                    time += 1;
                                    mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                    inv[1] -= 1;
                                    Energy += 50;
                                    message = "Вы увеличили энергию на 50%.. \nТеперь у вас " + inv[1] + " програм en++";

                                    break;

                    case "inv/drive":
                                    time += 1;
                                    mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                    inv[2] -= 1;
                                    Energy += 15;
                                    Exp += 5;
                                    message = "Ускоритель drive.exe разогнал ваш компьютер до максимально возможной производительности.";

                                    break;

                    case "inv/cleaner":
                                    time += 1;
                                    mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                    inv[3] -= 1;
                                    Energy += 5;
                                    Exp += 3;
                                    message = "С помощью cleaner.exe вы успешно очистили компьютер от вирусов";

                                    break;

                    case "attack":
                        message += ("\nЕсли вы хотите атаковать чужую сеть, выберите какую сеть вы хотите атаковать.\n");
                        message += (">attack/samizdat - Известная газета с низким уровнем защиты. (Рек. ур. >10 ex)\n");
                        message += (">attack/company72 - Крупная корпарация по производству устройств. На ней стоит защита средней сложности. (Рек. ур. >50 ex)\n");
                        message += (">attack/whitehouse - официальная резиденция президента. Крайне не рекомендуется направлять атаку именно туда. (Рек. ур. >100 ex)\n");
                        break;

                        

                            case "attack/samizdat":

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

                            case "attack/company72":                                

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

                            case "attack/whitehouse":

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

                    case "bm.com":
                        message += ("\nДоступные программы на BM.com:\n");
                        message += (">bm.com/en+ \t\t" + 100 + " \n>bm.com/en++ \t\t" + 500 + " \n>bm.com/drive \t\t" + 300 + " \n>bm.com/cleaner \t" + 150);
                        break;

                            case "bm.com/en+":
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

                            case "bm.com/en++":
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

                            case "bm.com/drive":
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

                            case "bm.com/cleaner":
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

                    case "playgames":

                        rest = true;
                        time = 24;

                        break;

                    case "skip":
                        time += 1;
                        mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);

                        message = "Вы пропустили 1 час";
                        break;

                    case "easteregg":
                        message += "Тут нет никаких посхалок. Иди от сюда.";
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
