using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part2
{
    class Program
    {
        static void printBookedDays(bool[,] calender)
        {
            bool flag = false;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (calender[i, j])
                    {
                        if (flag == false)
                        {
                            flag = true;
                            Console.Write("start date:{0}/{1}   ", j + 1, i + 1);
                        }

                    }
                    else
                    {
                        if (flag == true)
                        {
                            Console.Write("finish date:{0}/{1}", j, i + 1);
                            Console.WriteLine();
                        }
                        flag = false;
                    }
                }
            }
        }
        static void printBookedDaysData(bool[,] calender)
        {
            int count = 0;
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 31; j++)
                {
                    if (calender[i, j])
                        count++;
                }
            }
            double percentage = count * 100 / 372;
            Console.WriteLine("Number of booked days:{0}", count);
            Console.WriteLine("Percentage of booked days: {0}%", percentage);
        }
        static void putInEvent(bool[,] calender, int[] date, int length)
        {
            int day = date[1] - 1;
            int month = date[0] - 1;
            while (length != 0)
            {
                if (day == 31)
                {
                    day = 0;
                    if (month == 11)
                        month = 0;
                    else
                        month++;
                }
                calender[month, day] = true;
                length--;
                day++;
            }
        }
        static bool dateIsFree(bool[,] calender, int[] date, int length)
        {
            int day = date[1] - 1;
            int month = date[0] - 1;
            while (length != 0)
            {
                if (day == 31)
                {
                    day = 0;
                    if (month == 11)
                        month = 0;
                    else
                        month++;
                }
                if (calender[month, day] && calender[month, day+1])
                    return false;
                length--;
                day++;
            }
            return true;
        }
        static void newEvent(bool[,] calender)
        {
            int[] eventStartingDate = new int[2];
            int eventLength = new int();
            Console.Write("Enter starting date (day,month) and event length");
            Console.WriteLine();
            Console.Write("day:");
            eventStartingDate[1] = int.Parse(Console.ReadLine());
            Console.Write("month:");
            eventStartingDate[0] = int.Parse(Console.ReadLine());
            Console.Write("length:");
            eventLength = int.Parse(Console.ReadLine());
            Console.WriteLine();
            if (dateIsFree(calender, eventStartingDate, eventLength))
            {
                Console.Write("the request has been done (: ");
                putInEvent(calender, eventStartingDate, eventLength);
            }
            else
                Console.Write("the request was denied ): ");
            Console.WriteLine();


        }
        static void menuPrint()
        {
            Console.WriteLine(
    @"
For an event enter: 1
To show free dates to stay enter: 2
To show number of booked days and percentage of days that are booked enter: 3
To exit enter 4");
        }
        static void Main(string[] args)
        {
            bool[,] calender = new bool[12, 31];
            calender.Initialize();
            bool exit = true; ;

            while (exit)
            {
                menuPrint();
                //Console.Write("enter your choice");
                int userChoice;
                userChoice = int.Parse(Console.ReadLine());
                switch (userChoice)
                {
                    case 1:
                        newEvent(calender);
                        break;
                    case 2:
                        printBookedDays(calender);
                        break;
                    case 3:
                        printBookedDaysData(calender);
                        break;
                    case 4:
                        exit = false;
                        break;
                }

            }
            Console.Read();
        }
    }
}
