using System;

namespace Delegate
{

    delegate void AlarmDelegate();

    class Wekker
    {
        private static Timer wekkerTimer;
        private static int sluimerInSeconden = 5;
        private static bool isAlarmActief = false;

        private static AlarmDelegate geluidActie = () => Console.WriteLine("Piep piep piep!");
        private static AlarmDelegate boodschapActie = () => Console.WriteLine("Wakker worden. Het is tijd!");
        private static AlarmDelegate lichtActie = () => Console.WriteLine("Knipperende licht!");

        private static AlarmDelegate huidigeAlarmActie;

        static void Main()
        {
            huidigeAlarmActie = geluidActie;

            wekkerTimer = new Timer(OnTimerCallback, null, Timeout.Infinite, Timeout.Infinite);

            while (true)
            {
                ToonMenu();
                string keuze = Console.ReadLine();

                switch (keuze)
                {
                    case "1":
                        StelAlarmTijdIn();
                        break;
                    case "2":
                        StelSluimerTijdIn();
                        break;
                    case "3":
                        SchakelAlarmInUit();
                        break;
                    case "4":
                        WisselAlarmActie();
                        break;
                    case "5":
                        StopAlarm();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ongeldige keuze. Probeer opnieuw!");
                        break;
                }
            }
        }

        static void ToonMenu()
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Stel de wekkertijd in");
            Console.WriteLine("2. Stel sluimertijd in");
            Console.WriteLine("3. Schakel de wekker in/uit");
            Console.WriteLine("4. Wissel alarmactie");
            Console.WriteLine("5. Stop de wekker");
            Console.WriteLine("6. Afsluiten");
            Console.Write("Voer uw keuze in: ");
        }

        static void StelAlarmTijdIn()
        {
            Console.Write("Voer de wekkertijd in seconden in: ");
            if (int.TryParse(Console.ReadLine(), out int wekkertijdInSeconds))
            {
                wekkerTimer.Change(wekkertijdInSeconds * 1000, Timeout.Infinite);
                Console.WriteLine($"Wekkertijd ingesteld op {wekkertijdInSeconds} seconden.");
            }
            else
            {
                Console.WriteLine("Ongeldige invoer. Voer een geldig nummer in.");
            }
        }

        static void StelSluimerTijdIn()
        {
            Console.Write("Voer de sluimertijd in seconden in: ");
            if (int.TryParse(Console.ReadLine(), out int sluimerTijd))
            {
                sluimerInSeconden = sluimerTijd;
                Console.WriteLine($"Sluimertijd ingesteld op {sluimerTijd} seconden.");
            }
            else
            {
                Console.WriteLine("Ongeldige invoer. Voer een geldig nummer in.");
            }
        }

        static void SchakelAlarmInUit()
        {
            isAlarmActief = !isAlarmActief;
            if (isAlarmActief)
            {
                Console.WriteLine("Alarm is nu AAN.");
            }
            else
            {
                Console.WriteLine("Alarm is nu UIT.");
                StopAlarm();
            }
        }

        static void WisselAlarmActie()
        {
            Console.WriteLine("Kies alarmactie:");
            Console.WriteLine("1. Geluid");
            Console.WriteLine("2. Boodschap");
            Console.WriteLine("3. Licht");
            Console.Write("Voer uw keuze in: ");

            string keuze = Console.ReadLine();

            switch (keuze)
            {
                case "1":
                    huidigeAlarmActie = geluidActie;
                    break;
                case "2":
                    huidigeAlarmActie = boodschapActie;
                    break;
                case "3":
                    huidigeAlarmActie = lichtActie;
                    break;
                default:
                    Console.WriteLine("Ongeldige keuze. Gebruik de standaard geluidactie.");
                    huidigeAlarmActie = geluidActie;
                    break;
            }
        }

        static void StopAlarm()
        {
            isAlarmActief = false;
            wekkerTimer.Change(Timeout.Infinite, Timeout.Infinite);
            Console.WriteLine("Alarm gestopt.");
        }

        static void OnTimerCallback(object state)
        {
            if (isAlarmActief)
            {
                huidigeAlarmActie();

                wekkerTimer.Change(sluimerInSeconden * 1000, Timeout.Infinite);
            }
        }
    }
}
