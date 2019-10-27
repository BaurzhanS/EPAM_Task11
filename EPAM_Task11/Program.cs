using EPAM_Task11.Task1;
using EPAM_Task11.Task3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EPAM_Task11
{
    class Program
    {
        static void Main(string[] args)
        {
            //Расширить функциональную возможность типа System.Double, 
            //реализовав возможность получения строкового представления вещественного числа
            //Вызов

            Func<double, string> delDouble = DoubleExtensions.ToByteString;
            var input = -255.255;
            string resultDouble = delDouble(input);
            Console.WriteLine($"Assignment result #1.1 {resultDouble}");

            //вызов вычисления НОД по алгоритму Евклида:
            long s1 = GCDSearch.SearchByEuclid(100, 975);
            Console.WriteLine($"Assignment result #1.2 = {s1}");
            long s2 = GCDSearch.SearchByEuclid(18, -12, 24);
            Console.WriteLine($"Assignment result #1.2 = {s2}");
            long s3 = GCDSearch.SearchByEuclid(1000, 975, 250, -1250, 250, -625);
            Console.WriteLine($"Assignment result #1.2 = {s3}");
            long s4 = GCDSearch.SearchByEuclid(1000, 975, 250, -1250, 250, -625);
            Console.WriteLine($"Assignment result #1.2 = {s4}");

            //Реализовать для null-able типов, дополнительную возможность определения - является ссылка null или нет
            //Вызов
            Func<object, bool> delNull = NullExtensions.getNullReference;
            int? inputNum = null;
            bool result = delNull(inputNum);
            Console.WriteLine($"Assignment result #1.3 {result}");

            //Develop a Countdown class, which implements the capability after the appointed
            //time(waiting time is provided by the user) to transmit a message to any subscriber 
            //who subscribes to the event. You can use the Thread.Sleep method to create a wait effect
            //Вызов

            Timering timer = new Timering();
            Subscriber first = new Subscriber(timer);

            timer.StartTimer(7);

            timer.Timeout += first.OnTimerTimeout;

            System.Threading.Thread.Sleep(7500);

            timer.Timeout -= first.OnTimerTimeout;
            timer.StartTimer(7);

            System.Threading.Thread.Sleep(7500);

            Console.WriteLine("Timer reached timeout.");
            Console.ReadKey();
        }
    }
}
