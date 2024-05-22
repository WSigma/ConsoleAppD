using ConsoleAppDk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDk
{
    internal class Program
    {
        static Database db = new Database();
        static List<Dk> elemek = new List<Dk>();
        static List<Dk> Topfizetes = new List<Dk>();
        static List<Dk> munkakor = new List<Dk>();
        static List<Dk> reszleg = new List<Dk>();
        static void Main(string[] args)
        {
            elemek = db.getAlldk();
            Topfizetes = db.getAlldk();
            munkakor = db.getAlldk();
            reszleg = db.getAlldk();
            var dk = db.getAlldk();
            task01();
            task02();
            task03();
            task04(dk);
            Console.WriteLine("\nEnd program");
            Console.ReadLine();
        }

        private static void task04(List<Dk> dk)
        {
            
            Console.WriteLine("\n4. Task: ");
            var asztalosok = dk.Where(d => d.reszleg == "asztalosműhely").Select(d => d.nev);
            Console.WriteLine("\tAz asztalosműhelyen dolgozók:");
            foreach (var nev in asztalosok)
            {
                Console.WriteLine($"\t{nev}");
            }
        }

        private static void task03()
        {
            Console.WriteLine("\n3. task");
            var munkakorokSzama = munkakor.GroupBy(d => d.reszleg).Select(group => new { Munkakor = group.Key, Darab = group.Count() });
            foreach (var munkakor in munkakorokSzama)
            {
                Console.WriteLine($"\tMunkakör: {munkakor.Munkakor}, Dk száma: {munkakor.Darab}");
            }
        }

        private static void task02()
        {
            Console.WriteLine("\n2. task");
            if (Topfizetes.Count > 0)
            {
                var legmagasabbFizetes = Topfizetes.OrderByDescending(d => d.ber).First();
                Console.WriteLine($"\tLegmagasabb fizetéssel rendelkező dolgozó: {legmagasabbFizetes.nev}");
            }
            else
            {
                Console.WriteLine("\tNincs adat a legmagasabb fizetéssel rendelkező dolgozóról.");
            }
        }

        private static void task01()
        {
            Console.WriteLine("1. task");
            Console.WriteLine($"\tElemek száma: {elemek.Count}");
        }
    }
}