
namespace OOP_HW1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Получив ссылка на самого старшего  члена семьи, выведите на экран его генеалогическое дерево.
            // до 21:40
            AdultFamilyMember Inok = new AdultFamilyMember() { Name = "Инокентий" };

            AdultFamilyMember Marg = new AdultFamilyMember() { Name = "Маргарита" };

            FamilyMember Ivan = new FamilyMember()
            {
                Name = "Иван",
                Father = Inok,
                Mother = Marg
            };

            FamilyMember Vika = new FamilyMember()
            {
                Name = "Виктория" 
            };

            FamilyMember Anna = new FamilyMember()
            {
                Name = "Анна"
            };


            Inok.Children = new FamilyMember[] { Ivan, new FamilyMember() { Name = "Вера" }, new FamilyMember() { Name = "Надежда" } };
            Marg.Children = new FamilyMember[] { Ivan };

            FamilyMember Mary = new FamilyMember()
            {
                Name = "Мария",
                Father = new FamilyMember() { Name = "Инокентий2" },
                Mother = new FamilyMember() { Name = "Маргарита" }
            };
            FamilyMember Son = new FamilyMember() { Name = "Петя", Father = Ivan, Mother = Mary };


            AdultFamilyMember Andy = new AdultFamilyMember() { Name = "Андрей" , Father = Ivan, Mother = Anna, Wife = Vika};

            FamilyMember Max = new FamilyMember()
            {
                Name = "Максим",
                Father = Andy,
                Mother = Vika
            };



            Inok.Info(2);
            Marg.Info(2);

            Andy.Info();
            Andy.ShowPair();
            Console.ReadLine();

        }
    }
}