using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace final_project5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            ShowUserData(GetUserData());
        }

        public static (string UserName, string UserSurname,byte Age, string HasPet, string[] pets, string[] colors) GetUserData()
        {
            (string UserName, string UserSurname, byte Age, string HasPet, string[] pets, string[] colors) User;           
            Console.WriteLine("Введите имя и фамилию пользователя через пробел: ");
            string FullName = Console.ReadLine();
            User.UserSurname = FullName.Remove(0, FullName.IndexOf(' ') + 1);
            User.UserName = FullName.Remove(FullName.IndexOf(' '), User.UserSurname.Length + 1);
            Console.WriteLine("Введите возраст(полных лет): ");
            User.Age = ValueVerify();
            Console.WriteLine("У вас есть домашнее животное? (да/нет)");
            User.HasPet = Console.ReadLine();
            User.pets = null;
            if (User.HasPet == "да")
            {
                Console.WriteLine("Введите количество питомцев: ");
                byte NumOfPet = ValueVerify();
                User.pets = GetPets(NumOfPet);
            }
            else
                User.HasPet = "нет";           
            Console.WriteLine("Сколько у вас любимых цветов? ");
            byte numOfColors = ValueVerify();
            User.colors = GetColors(numOfColors);
            return User;
            

        }

        static byte ValueVerify()
        {
            bool ParseResult;
            byte byteResult;
            string strVal;
            do
            {

                strVal = Console.ReadLine();
                ParseResult = byte.TryParse(strVal, out byte result);
                if ((ParseResult == false) || (result <= 0))
                {
                    Console.WriteLine("Ошибка, введите еще раз!");
                    ParseResult = false;                  
                }
                byteResult = result;
            } while (ParseResult == false);
            return byteResult;
        }
        static string[] GetPets(int NumOfPet)
        {
            string[] pets = new string[NumOfPet];
            for (int i = 0; i < NumOfPet; i++)
            {
                Console.WriteLine("Введите имя питомца {0}", i + 1);
                pets[i] = Console.ReadLine();
            }
            return pets;
        }

        static string[] GetColors(int numOfColors)
        {
            string[] colors = new string[numOfColors];
            for (int i = 0; i < numOfColors; i++)
            {
                Console.WriteLine("Введите цвет {0}", i + 1);
                colors[i] = Console.ReadLine();
            }
            return colors ;
        }

        static void ShowUserData((string UserName, string UserSurname, byte Age, string HasPet, string[] pets, string[] colors) User)
        {
            Console.Clear();
            Console.WriteLine("Данные пользователя: ");
            Console.WriteLine("Имя: {0}", User.UserName);
            Console.WriteLine("Фамилия: {0}", User.UserSurname);
            Console.WriteLine("Возраст: {0}", User.Age);
            Console.WriteLine("Наличие животных: {0}", User.HasPet);
            if (User.HasPet != "нет")
            {
                Console.WriteLine("Клички домашних животных: ");
                foreach (var item in User.pets)
                {
                    Console.WriteLine(item);
                }
            }
            Console.WriteLine("Любимые цвета: ");
            foreach (var item in User.colors)
            {
                Console.WriteLine(item);
            }
        }

    }
}
