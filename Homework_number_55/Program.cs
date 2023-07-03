using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_number_55
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Warehouse warehouse = new Warehouse();

            warehouse.ShowAllCannedFoods();

            Console.WriteLine("Для того что бы показать весь просроченный товар нажмите любую клавишу");
            Console.ReadKey();
            Console.Clear();

            warehouse.ShowExpiredCannedFood();

            Console.ReadKey();
        }
    }

    class CannedFood
    {
        public CannedFood(string name, int productionYear, int expiryDate)
        {
            Name = name;
            ProductionYear = productionYear;
            ExpiryDate = expiryDate;
        }

        public string Name { get; private set; }
        public int ProductionYear { get; private set; }
        public int ExpiryDate { get; private set; }
    }

    class Warehouse
    {
        private List<CannedFood> _cannedFoods = new List<CannedFood>();

        private int _currentYear;

        public Warehouse()
        {
            Fill();

            ShowInfo();
        }

        public void ShowExpiredCannedFood()
        {
            List<CannedFood> overdueCannedFoods = GetExpiredCannedFood();

            ShowInfo();

            ShowCannedFoods(overdueCannedFoods);
        }

        public void ShowAllCannedFoods()
        {
            ShowCannedFoods(_cannedFoods);
        }

        private List<CannedFood> GetExpiredCannedFood()
        {
            return _cannedFoods.Where(cannedFoods => cannedFoods.ExpiryDate < _currentYear).ToList();
        }

        private void ShowCannedFoods(List<CannedFood> cannedFoods)
        {
            foreach (CannedFood cannedFood in cannedFoods)
            {
                Console.WriteLine("Игрок:");
                Console.WriteLine($"Название : {cannedFood.Name}");
                Console.WriteLine($"Год выпуска : {cannedFood.ProductionYear}");
                Console.WriteLine($"Дата истечения срока годности: {cannedFood.ExpiryDate}");
                Console.WriteLine();
            }
        }

        private void ShowInfo()
        {
            Console.WriteLine($"Количество Консерв на складе : {_cannedFoods.Count}\n" +
                              $"Текущий год : {_currentYear}\n\n");
        }

        private void Fill()
        {
            Random random = new Random();

            string nameCannedFood = "Тушонка";
            int expiryDate;
            int productionYear;
            int quantityCannedFood = 10;
            int minProductionYear = 1980;
            int maxProductionYear = 2000;
            int storageTime = 10;

            _currentYear = random.Next(minProductionYear, maxProductionYear);

            for (int i = 0; i < quantityCannedFood; i++)
            {
                productionYear = random.Next(minProductionYear, maxProductionYear);
                expiryDate = productionYear + storageTime;

                _cannedFoods.Add(new CannedFood(nameCannedFood,
                                                productionYear,
                                                expiryDate));
            }
        }
    }
}
