using System;

namespace LibraryLib
{
    public class LibraryFunctions
    {
        private const string LibraryName = "Городская библиотека г. Чита";   // Название библиотеки
        private string _chiefLibrarian = "Иванова Мария Петровна";          // Главный библиотекарь
        private string[] _staff = new string[]                             // Список сотрудников
        {
            "Петров П.С.",
            "Сидорова А.В.",
            "Козлов И.Д.",
            "Иванова М.П."
        };
        private readonly Random _random = new Random();             // RNG для метода GenerateBookCod                                                            
        public string GetChiefLibrarian()                          //Метод, который возращает ФИО глав. библеотекоря
        {
            return _chiefLibrarian;
        }
        public string GetLibraryName()                           //Метод, который возращает название библеотеки
        {
            return LibraryName;
        }
        public bool SetChiefLibrarian(string fullname)                              //Метод для изменения ФИО глав. библеотекоря
        {
            if (string.IsNullOrWhiteSpace(fullname))                            // Проверка на то чтоб ввод не был пустым
            {
                Console.WriteLine("   Введено пустое поле.");
                return false;
            }
            foreach (string s in _staff)                                 // Проверка на соответсвие введёного ФИО в списке
            {
                if (fullname == s)
                {
                    _chiefLibrarian = fullname;
                    return true;
                }
            }
            Console.WriteLine("   Данного ФИО нет в списке сотрудников.");
            return false;
        }
        public string GenerateBookCode(string category, int number)                  // Метод формирует код книги вида CAT_number
        {
            if (string.IsNullOrWhiteSpace(category))             // Проверка на то чтоб ввод не был пустым
            {
                throw new ArgumentException("Категория книги не может быть пустой.", nameof(category));
            }

            if (number <= 0)                             // Проверка на то чтобы число не было <= 0
            {
                throw new ArgumentOutOfRangeException(nameof(number), "Число должно быть больше нуля.");
            }

            int randomNumber = _random.Next(1, number + 1);            // Генерирует случайное число от 1 до number
            return $"{category}_{randomNumber}";                      // Возращает код вида CAT_number
        }
        public string[] GetStaff()
        {
            return (string[])_staff.Clone();                                    // Метод который, возращает копию списка сотрудников
        }
        public bool AddStaff(string fullname)                                  // Метод добавления нового сотрудника в список
        {
            if (string.IsNullOrWhiteSpace(fullname))                          // Проверка на то чтоб ввод не был пустым
            {
                Console.WriteLine("   Введено пустое поле.");
                return false;
            }
            if (Array.IndexOf(_staff, fullname) == -1)                        // Проверка на дубликацию ФИО в списке сотрудников
            {
                Array.Resize(ref _staff, _staff.Length + 1);
                _staff[_staff.Length - 1] = fullname;
                Console.WriteLine("   Новый сотрудник успешно добавлен в список.");
                return true;
            }
            Console.WriteLine("   ФИО данного сотрудника уже есть в списке");
            return false;
        }
    }   internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
