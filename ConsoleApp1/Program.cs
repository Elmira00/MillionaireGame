using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    public class Program
    {
       private static string[] RemoveAt(string[] source, in int index)
        {
            string[] destination = new string[source.Length - 1];
            if (index > 0)
            {
                Array.Copy(source, 0, destination, 0, index);
            }
            if (index < source.Length - 1)
            {
                Array.Copy(source, index + 1, destination, index, source.Length - index - 1);
            }
            return destination;
        }
       static void Main(string[] args)
        {
            string[][] questionsAndRightAnswers = new string[10][]
            {
                   new string[]{"What kind of tree is decorated at Christmas?","Fir-tree"},
                    new string[]{"When does Pinocchio's nose become longer?","When he lies" },
                    new string[]{"What is the coldest place on earth?","The Antarctic"},
                    new string[]{"What is the name of the capital of Mongolia?","Ulaanbaatar" },
                    new string[]{"What is the longest river in the world?","Nile" },
                    new string[]{"What was the name of the Queen of the United Kingdom?","Elizabeth II" },
                    new string[]{"Where did the Olympic Games originate?","Greece" },
                    new string[]{"How many bones in the human body?","206" },
                    new string[]{"When did World War II end?","1945" },
                    new string[]{"Who painted “The Last Supper”?","Leonardo da Vinci" }
            };
            string[][] answers = new string[10][]
            {
                    new string[]{"Fir-tree","Apple-tree","Banyan Tree","Black Ash Tree"},
                    new string[]{"When he lies","When he laughs","When he speaks","When he sleeps"},
                    new string[]{"The Antarctic","Africa","Norway","The Everest"},
                    new string[]{"Ulaanbaatar","Tokyo","Oslo","Ashgabat"},
                    new string[]{"Nile","Amazon","Mississippi","Araz"},
                    new string[]{"Elizabeth II","Camilla","Diana","Kate Middleton"},
                    new string[]{"Greece","Japan","Italy","Turkey"},
                    new string[]{"206","400","234","310"},
                    new string[]{"1945","1918","1992","1941"},
                   new string[]{"Leonardo da Vinci","Vincent van Gogh","Pablo Picasso","Salvador Dalí"}
            };
            string[] variants = new string[4] { "A)", "B)", "C)", "D)" };
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\n\t\t\t\t\t M I L L I O N A I R E   G A M E");
            Console.ResetColor();
           Console.WriteLine("\n\n\n");
            Random random = new Random();
            int score = 0;
            for (int i = 0; i < 10; i++)
            {
                int getRandom = random.Next(0, 10);
                while (questionsAndRightAnswers[getRandom] == null)
                {
                    getRandom = random.Next(0, 10);
                }
                string correctAnswer = "";
                Console.WriteLine("\n"+questionsAndRightAnswers[getRandom][0]);
                int randomVariant1 = random.Next(0, 3);
                Console.WriteLine(variants[0] + answers[getRandom][randomVariant1]);              
                answers[getRandom] = RemoveAt(answers[getRandom], randomVariant1);              
                int randomVariant2 = random.Next(0, 2);
                Console.WriteLine(variants[1] + answers[getRandom][randomVariant2]);
                answers[getRandom] = RemoveAt(answers[getRandom], randomVariant2);
                int randomVariant3 = random.Next(0, 1);
                Console.WriteLine(variants[2] + answers[getRandom][randomVariant3]);
                answers[getRandom] = RemoveAt(answers[getRandom], randomVariant3);
                int randomVariant4 = random.Next(0);
                Console.WriteLine(variants[3] + answers[getRandom][randomVariant4]);
                answers[getRandom] = RemoveAt(answers[getRandom], randomVariant4);
                if (randomVariant1 == 0)
                {
                    correctAnswer = "A";
                }
                else if (randomVariant2 == 0)
                {
                    correctAnswer = "B";
                }
               else  if (randomVariant3 == 0)
                {
                    correctAnswer = "C";
                }
               else  if (randomVariant4 == 0)
                {
                    correctAnswer = "D";
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\nEnter your choice : ");
                Console.ResetColor();
                string selectedVariant = Console.ReadLine();
                if (selectedVariant.ToUpper() == correctAnswer)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    score += 1000;
                    Console.WriteLine($"\n\nYour score : {score} ");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Your score : {score} ,You lost Game!");
                    Console.ResetColor();
                    break;
                }
                if (i == 9)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Y O U    W O N   G A M E ! ");
                    Console.ResetColor();
                }
                questionsAndRightAnswers[getRandom] = null;
            }
        }
    }
}
