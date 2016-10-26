using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class player
{

    public int hp = 100;
    public int rp = 20;
    public int wg = 30;
    public int mn = 1200;

    public player(int HP, int RESPECT, int WEIGHT, int MONEY)
    {
        hp += HP;
        rp += RESPECT;
        wg += WEIGHT;
        mn += MONEY;
    }

}

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Media.SoundPlayer sp = new System.Media.SoundPlayer(Properties.Resources.music);

            Random rnd = new Random();
            int HoleLength = 10;
            int Health = 100;
            int Respect = 20;
            int Weight = 30;
            int Money = 1200;

            string stats = "";

            int[] inv = new int[4];

            inv[0] = 2;
            inv[1] = 1;
            inv[2] = 3;
            inv[3] = 2;

            int time = 6;
            string mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);

            string action;
            string message = "";

            int work = 0;
            string status = "";

            bool rest = false;

            sp.PlayLooping();

            while (true) // НАЧАЛО ИГРЫ
            {

                action = "";
                    
                if (Health > 100)
                        Health = 100 + ((Health - 100) / 2);

                if (time == 24)
                {
                    time = 6;
                    mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                    HoleLength -= 2; stats += "-2 ДЛИНА ТОНЕЛЯ\n";
                    Health += 20; stats += "+20 ОЗ\n";
                    Respect = Respect - 5 + work; stats = stats + (work - 5) + " РП\n";
                    Weight -= 5; stats += "-5 ВЕС\n";
                    Money += 500 * work; stats = stats + 500 * work + " КРЕД\n";

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

                Console.WriteLine("//Здоровье: \t" + Health + " ОЗ");
                Console.WriteLine("//Уважение: \t" + Respect + " РП");
                Console.WriteLine("//Вес: \t\t" + Weight + " кг");
                Console.WriteLine("//Кредиты: \t" + Money + " $");
                Console.WriteLine();
                Console.WriteLine("-Длина норы: \t" +    HoleLength + " м");
                Console.WriteLine("-Время: \t" +       time + mins);
                Console.WriteLine();

                Console.WriteLine(">Копать");
                Console.WriteLine(">Инвентарь");
                Console.WriteLine(">Устроить драку");
                Console.WriteLine(">Магазин");
                Console.WriteLine(">Отдыхать");
                Console.WriteLine();

                if (message != "")
                {
                    Console.WriteLine("" + message);
                    Console.WriteLine();
                    message = "";
                }

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

                    case "Копать":
                        Console.WriteLine("\nКак бы вы желали копать?\n");
                        Console.WriteLine(">Усердно\n>Лениво\n");
                        Console.Write(">>>");
                        action = Console.ReadLine();
                        Console.Beep();
                        switch (action)
                        {
                            case "Усердно":
                                work += 1;
                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                message = "Вы усердно прокапали 1 час, и очень устали.";
                                
                                

                                HoleLength += 5; stats += "+5 ДЛИНА ТОНЕЛЯ\n";
                                Health -= 30; stats += "-30 ОЗ\n";
                                break;

                            case "Лениво":
                                work += 1;
                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                message = "Вы лениво прокапали 1 час, при этом сэкономив запасы ваших сил.";

                                HoleLength += 2; stats += "+2 ДЛИНА ТОНЕЛЯ\n";
                                Health -= 15; stats += "-15 ОЗ\n";
                                break;
                            default:
                                message = "Вы передумали...";
                                break;
                        }
                        break;

                    case "Инвентарь":
                        Console.WriteLine("\nЗдесь вы храните все свои вещи. Что бы вы предпочли сейчас принять?\n");
                        Console.WriteLine(">Обезболивающее \t{0} \n>Аптечка \t\t{1} \n>Еда \t\t\t{2} \n>Пиво \t\t\t{3} \n",inv[0], inv[1], inv[2], inv[3]);
                        Console.Write(">>>");
                        action = Console.ReadLine();
                        Console.Beep();
                        switch (action)
                        {
                            case "Обезболивающее":
                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                inv[0] -= 1;
                                Health += 30; stats += "+30 ОЗ\n";
                                message = "Вы приняли обезболивающее и восполнили 30 ОЗ. \nТеперь у вас " + inv[0] + " обезболивающих";
                                
                                break;

                            case "Аптечка":
                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                inv[1] -= 1;
                                Health += 50; stats += "+50 ОЗ\n";
                                message = "Вы использовали аптечку и восполнили 50 ОЗ. \nТеперь у вас " + inv[1] + " аптечек";

                                break;

                            case "Еда":
                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                inv[2] -= 1;
                                Health += 15; stats += "+15 ОЗ\n";
                                Weight += 5; stats += "+5 ВЕС\n";
                                message = "Вы поели. Насытевшись, вы восстановили 15 ОЗ. \nТеперь у вас " + inv[2] + " порции еды";

                                break;

                            case "Пиво":
                                time += 1;
                                mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);
                                inv[3] -= 1;
                                Health += 5; stats += "+5 ОЗ\n";
                                Respect -= 3; stats += "-3 РП\n";
                                Weight += 3; stats += "+3 ВЕС\n";
                                message = "Насосавшись пива, вы почувствовали себя немного лучше, но вас увидели прохожие, которым не очень понравилось то, что вы употребляете спиртное. \nТеперь у вас " + inv[3] + " бутылок пива";

                                break;

                            default:
                                message = "Вы передумали...";
                                break;

                        }
                        break;

                    case "Устроить драку":
                        message = "Извините, но вы еще пока не готовы вступить в драку";
                        break;

                    case "Магазин":
                        message = "В магазине пока ничего нет";
                        break;

                    case "Отдыхать":

                        rest = true;
                        time = 24;

                        break;

                    case "пх":
                        time += 1;
                        mins = ":" + rnd.Next(0, 6) + rnd.Next(0, 10);

                        message = "Вы пропустили 1 час";
                        break;
                   

                    default:
                        message = "Неверно введено действие";
                        break;
                }


                if (time == 24)
                {
                    Console.Beep();
                    Console.Beep();
                }
                Console.Clear();
                };
        }
    }
}
