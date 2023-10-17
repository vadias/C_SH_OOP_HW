using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//----------------------------------------------------------------------------------------------------------------------------------
// Доработайте приложение генеалогического дерева таким образом чтобы программа выводила на экран близких родственников (жену/мужа).
// Продумайте способ более красивого вывода с использованием горизонтальных и вертикальных черточек
//----------------------------------------------------------------------------------------------------------------------------------

namespace OOP_HW1
{
    public enum Gender
    {
        Male,
        Female
    }

    public class FamilyMember
    {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public FamilyMember Father { get; set; }
        public FamilyMember Mother { get; set; }
        public FamilyMember Hasband { get; set; }
        public FamilyMember Wife { get; set; }
        public Gender Gend { get; set; }
        public virtual void Info(int indent = 0)
        {
            for (int i = 0; i < indent; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine($"Имя: {Name}, родители: {Father?.Name}, {Mother?.Name}");

        }

        public void ShowPair()
        {  
            Console.Write("--"); 
            if(Hasband == null && Wife == null)
            {
                Console.WriteLine("Холост");
            }
            
            if (Hasband != null)
            {
                Console.WriteLine("Муж:" + Hasband.Name);
            }

            if (Wife != null)
            {
                Console.WriteLine("Жена:" + Wife.Name);
            }         
        }

        public void ShowParent()
        {
            if (Father == null)
                Console.WriteLine("Отец неизвестен");
            else
                Console.WriteLine("Отец:" + Father.Name);
            Console.WriteLine("Мать:" + Mother?.Name);
        }
        public void ShowGrandParent()
        {

            Console.WriteLine("По отцовской линии:");
            Console.WriteLine("Дедушка:" + Father?.Father?.Name);
            Console.WriteLine("Бабушка:" + Father?.Mother?.Name);

            Console.WriteLine("По материнской линии:");
            Console.WriteLine("Дедушка:" + Mother?.Father?.Name);
            Console.WriteLine("Бабушка:" + Mother?.Mother?.Name);
        }
    }
    public class AdultFamilyMember : FamilyMember
    {
        public FamilyMember[] Children { get; set; }
        public override void Info(int indent = 0)
        {
            base.Info(indent);
            //foreach (var child in Children)
           // {
                //child.Info(indent * 2);
                //Console.WriteLine(child.Name);

           // }
        }
   
    }

}