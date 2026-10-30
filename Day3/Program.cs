using System;

namespace Day3
{
    // ==========================================
    // 1. الكلاس المجرد (Abstract Class)
    // ==========================================
    public abstract class Creature
    {
        public int Weight { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }

        // أ) الكونستراكتور الأول (Parameterless)
        public Creature() : this(7, 1, 10) // تطبيق Constructor Chaining هنا أيضاً
        {
            Console.WriteLine("Creature Default Constructor called.");
        }

        // ب) الكونستراكتور الثاني (Parameterised)
        public Creature(int weight, int age, int height)
        {
            Weight = weight;
            Age = age;
            Height = height;
            Console.WriteLine("Creature Parameterised Constructor called.");
        }

        // ج) دالة عادية قابلة للـ Override (Virtual)
        public virtual void Eat()
        {
            Console.WriteLine("Creature is eating...");
        }

        // د) دالة مجردة (Abstract Method) - ليس لها جسم، ويجب على الوراث تطبيقها إجبارياً
        public abstract void Move();
    }

    // ==========================================
    // 2. كلاس الابن (Human) يورث من Creature
    // ==========================================
    public class Human : Creature
    {
        public string Name { get; set; }

        // أ) Constructor Chaining باستخدام base لتمرير القيم لكونستراكتور الأب
        public Human() : base()
        {
            Name = "Unknown Human";
        }

        public Human(int weight, int age, int height, string name) : base(weight, age, height)
        {
            Name = name;
        }

        // ب) تنفيذ الـ Override للدالة Virtual (Eat)
        public override void Eat()
        {
            // استخدام base لاستدعاء دالة الأب الأصلية وإضافة تعديل عليها (Extension)
            base.Eat();
            Console.WriteLine($"{Name} (Human) is eating healthy food.");
        }

        // ج) إجبار الوراثة على تطبيق الدالة الـ Abstract (Move)
        public override void Move()
        {
            Console.WriteLine($"{Name} is walking on two legs.");
        }

        // د) تجربة دالة جديدة تستخدم الـ New (Hiding) بدلاً من Override بالصدفة
        public void Think()
        {
            Console.WriteLine($"{Name} is thinking logically.");
        }
    }

    // ==========================================
    // 3. البرنامج الرئيسي (Main Program)
    // ==========================================
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("    1. تجربة الـ Constructor Chaining والوراثة ");
            Console.WriteLine("==============================================");

            // عند إنشاء Human، سيتفعل الـ Chaining وينادي كونستراكتور الأب ثم الابن تلقائياً
            Human human1 = new Human(65, 25, 175, "أحمد");
            Console.WriteLine($"الاسم: {human1.Name}, الوزن: {human1.Weight}kg, الطول: {human1.Height}cm");

            Console.WriteLine("\n==============================================");
            Console.WriteLine("       2. تجربة الـ Polymorphism و Override   ");
            Console.WriteLine("==============================================");

            // مبدأ تعدد الأشكال: رفرنس من الأب (Creature) يشير إلى كائن من الابن (Human)
            Creature cRef = new Human(70, 30, 180, "محمد");

            // أ) استدعاء الدالة الـ Abstract والمطبقة بـ Override
            cRef.Move(); // ستنفذ دالة الـ Human رغم أن الرفرنس من Creature

            // ب) استدعاء الدالة الـ Virtual والمطبقة بـ Override
            cRef.Eat();  // ستنفذ دالة الـ Human المحدثة

            Console.WriteLine("\nاضغط أي مفتاح للإنهاء...");
            Console.ReadKey();
        }
    }
}