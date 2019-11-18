
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 hillel gonen-325004414
 ilan russell-332339134
*/
namespace part2
{
    class Program
    {
        //prints the starting date and the final date
        //of each sequence of booked days
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
            if (calender[11, 30])
                Console.Write("finish date:{0}/{1}", 31, 12);
        }
        //prints the amount of days that are booked
        //prints the percentage of days that are booked
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
        //books the holiday if the event is free (if the next function is true)
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
        //checks if the date is free
        //you are aloud to have two people stay on the first and last day of any vacation
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
                if (calender[month, day] && calender[month, day + 1])
                    return false;
                length--;
                day++;
            }
            return true;
        }
        //recieves an event from the user
        //checks if it is free (through dateIsFree)
        //if it is free it books the event (through putInEvent)
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

            if (eventStartingDate[1] > 31 || (eventStartingDate[1] - 1 + (eventStartingDate[0] - 1) * 31 + eventLength - 1 >= 12 * 31))
            {
                Console.Write("ERROR");
            }
            else if (dateIsFree(calender, eventStartingDate, eventLength))
            {
                Console.Write("the request has been done (: ");
                putInEvent(calender, eventStartingDate, eventLength);
            }
            else
                Console.Write("the request was denied ): ");
            Console.WriteLine();


        }
        //prints the menu of the users options
        static void menuPrint()
        {
            Console.WriteLine(
    @"
For an event enter: 1
To show free dates to stay enter: 2
To show number of booked days and percentage of days that are booked enter: 3
To exit enter 4
To repeat the menu enter 5
");
        }
        static void Main(string[] args)
        {
            bool[,] calender = new bool[12, 31];
            calender.Initialize();
            bool exit = true;
            menuPrint();
            while (exit)
            {

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
                    case 5:
                        menuPrint();
                        break;
                    default:
                        Console.Write("ERROR");
                        break;

                }

            }
        }
    }
}