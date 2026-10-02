using System;
using System.Collections.Generic;
using System.Linq;

// Каждое задание лежит в своём пространстве имён (T01..T30), потому что
// имена классов (Animal, Vehicle, Employee...) повторяются в разных заданиях.

namespace Lab
{
    static class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var tasks = new (string, Action)[]
            {
                ("Животное", T01.Demo.Run), ("Транспорт", T02.Demo.Run), ("Человек и студент", T03.Demo.Run),
                ("Сотрудники", T04.Demo.Run), ("Фигуры", T05.Demo.Run), ("Транспорт с движением", T06.Demo.Run),
                ("Работник магазина", T07.Demo.Run), ("Компьютеры", T08.Demo.Run), ("Книги", T09.Demo.Run),
                ("Домашние животные", T10.Demo.Run), ("Банковские счета", T11.Demo.Run), ("Транспортная компания", T12.Demo.Run),
                ("Работники компании", T13.Demo.Run), ("Система образования", T14.Demo.Run), ("Военная техника", T15.Demo.Run),
                ("Игровые персонажи", T16.Demo.Run), ("Электронные устройства", T17.Demo.Run), ("Платежи", T18.Demo.Run),
                ("Сотрудники с бонусами", T19.Demo.Run), ("Животные зоопарка", T20.Demo.Run), ("Абстрактные фигуры", T21.Demo.Run),
                ("Интернет-магазин", T22.Demo.Run), ("Система транспорта", T23.Demo.Run), ("Больница", T24.Demo.Run),
                ("Уровни наследования", T25.Demo.Run), ("Игра: персонажи", T26.Demo.Run), ("Файлы", T27.Demo.Run),
                ("Зарплаты", T28.Demo.Run), ("Полиморфизм", T29.Demo.Run), ("Автопарк", T30.Demo.Run),
            };
            for (int i = 0; i < tasks.Length; i++)
            {
                Console.WriteLine($"\n===== {i + 1}. {tasks[i].Item1} =====");
                tasks[i].Item2();
            }
        }
    }
}

// 1
namespace T01
{
    class Animal { public virtual void Speak() => Console.WriteLine("Животное издаёт звук"); }
    class Dog : Animal { public override void Speak() => Console.WriteLine("Гав!"); }
    class Cat : Animal { public override void Speak() => Console.WriteLine("Мяу!"); }
    static class Demo { public static void Run() { new Dog().Speak(); new Cat().Speak(); } }
}

// 2
namespace T02
{
    class Vehicle
    {
        public string Brand; public int Speed;
        public Vehicle(string b, int s) { Brand = b; Speed = s; }
        public virtual void Info() => Console.WriteLine($"{Brand}, скорость {Speed} км/ч");
    }
    class Car : Vehicle
    {
        public int Doors;
        public Car(string b, int s, int d) : base(b, s) { Doors = d; }
        public override void Info() { base.Info(); Console.WriteLine($"  Дверей: {Doors}"); }
    }
    class Motorcycle : Vehicle
    {
        public bool HasSidecar;
        public Motorcycle(string b, int s, bool sc) : base(b, s) { HasSidecar = sc; }
        public override void Info() { base.Info(); Console.WriteLine($"  Коляска: {(HasSidecar ? "да" : "нет")}"); }
    }
    static class Demo { public static void Run() { new Car("Toyota", 180, 4).Info(); new Motorcycle("Yamaha", 220, false).Info(); } }
}

// 3
namespace T03
{
    class Person
    {
        public string Name; public int Age;
        public Person(string n, int a) { Name = n; Age = a; }
        public virtual void Print() => Console.WriteLine($"{Name}, {Age} лет");
    }
    class Student : Person
    {
        public string Major; public int Course;
        public Student(string n, int a, string m, int c) : base(n, a) { Major = m; Course = c; }
        public override void Print() { base.Print(); Console.WriteLine($"  Специальность: {Major}, курс {Course}"); }
    }
    static class Demo { public static void Run() => new Student("Алия", 19, "Информатика", 2).Print(); }
}

// 4
namespace T04
{
    class Employee
    {
        public string Name; public double Salary;
        public Employee(string n, double s) { Name = n; Salary = s; }
        public virtual void Print() => Console.WriteLine($"{Name}, зарплата {Salary}");
    }
    class Manager : Employee
    {
        public int TeamSize;
        public Manager(string n, double s, int t) : base(n, s) { TeamSize = t; }
        public override void Print() { base.Print(); Console.WriteLine($"  Размер команды: {TeamSize}"); }
    }
    class Developer : Employee
    {
        public string Language;
        public Developer(string n, double s, string l) : base(n, s) { Language = l; }
        public override void Print() { base.Print(); Console.WriteLine($"  Язык: {Language}"); }
    }
    static class Demo { public static void Run() { new Manager("Ербол", 900000, 8).Print(); new Developer("Дана", 800000, "C#").Print(); } }
}

// 5
namespace T05
{
    class Shape { public virtual double GetArea() => 0; }
    class Rectangle : Shape
    {
        public double W, H;
        public Rectangle(double w, double h) { W = w; H = h; }
        public override double GetArea() => W * H;
    }
    class Circle : Shape
    {
        public double R;
        public Circle(double r) { R = r; }
        public override double GetArea() => Math.PI * R * R;
    }
    static class Demo
    {
        public static void Run()
        {
            Console.WriteLine($"Прямоугольник: {new Rectangle(3, 4).GetArea():F2}");
            Console.WriteLine($"Круг: {new Circle(2).GetArea():F2}");
        }
    }
}

// 6
namespace T06
{
    class Vehicle { public virtual void Move() => Console.WriteLine("Транспорт движется"); }
    class Car : Vehicle { public override void Move() => Console.WriteLine("Машина едет по дороге"); }
    class Bus : Vehicle { public override void Move() => Console.WriteLine("Автобус едет по маршруту"); }
    class Train : Vehicle { public override void Move() => Console.WriteLine("Поезд идёт по рельсам"); }
    static class Demo { public static void Run() { foreach (Vehicle v in new Vehicle[] { new Car(), new Bus(), new Train() }) v.Move(); } }
}

// 7
namespace T07
{
    class Worker
    {
        public string Name, Position;
        public Worker(string n, string p) { Name = n; Position = p; }
        public virtual void Work() => Console.WriteLine($"{Name} ({Position}) работает");
    }
    class Cashier : Worker
    {
        public Cashier(string n) : base(n, "Кассир") { }
        public override void Work() => Console.WriteLine($"{Name} пробивает покупки");
    }
    class Seller : Worker
    {
        public Seller(string n) : base(n, "Продавец") { }
        public override void Work() => Console.WriteLine($"{Name} консультирует покупателей");
    }
    static class Demo { public static void Run() { new Cashier("Айгерим").Work(); new Seller("Нурлан").Work(); } }
}

// 8
namespace T08
{
    class Computer
    {
        public string Processor; public int RAM;
        public Computer(string p, int r) { Processor = p; RAM = r; }
        public virtual void Info() => Console.WriteLine($"CPU: {Processor}, RAM: {RAM} ГБ");
    }
    class Laptop : Computer
    {
        public double BatteryHours;
        public Laptop(string p, int r, double b) : base(p, r) { BatteryHours = b; }
        public override void Info() { base.Info(); Console.WriteLine($"  Батарея: {BatteryHours} ч"); }
    }
    class Desktop : Computer
    {
        public int PowerSupplyW;
        public Desktop(string p, int r, int w) : base(p, r) { PowerSupplyW = w; }
        public override void Info() { base.Info(); Console.WriteLine($"  Блок питания: {PowerSupplyW} Вт"); }
    }
    static class Demo { public static void Run() { new Laptop("i7", 16, 8).Info(); new Desktop("Ryzen 7", 32, 650).Info(); } }
}

// 9
namespace T09
{
    class Book
    {
        public string Title, Author;
        public Book(string t, string a) { Title = t; Author = a; }
        public virtual void Info() => Console.WriteLine($"«{Title}», {Author}");
    }
    class PaperBook : Book
    {
        public int Pages;
        public PaperBook(string t, string a, int p) : base(t, a) { Pages = p; }
        public override void Info() { base.Info(); Console.WriteLine($"  Страниц: {Pages}"); }
    }
    class EBook : Book
    {
        public double FileSizeMB;
        public EBook(string t, string a, double s) : base(t, a) { FileSizeMB = s; }
        public override void Info() { base.Info(); Console.WriteLine($"  Размер файла: {FileSizeMB} МБ"); }
    }
    static class Demo { public static void Run() { new PaperBook("Абай жолы", "М. Ауэзов", 640).Info(); new EBook("Clean Code", "R. Martin", 4.5).Info(); } }
}

// 10
namespace T10
{
    class Pet { public virtual void Eat() => Console.WriteLine("Питомец ест"); }
    class Dog : Pet { public override void Eat() => Console.WriteLine("Собака грызёт кость"); }
    class Cat : Pet { public override void Eat() => Console.WriteLine("Кошка лакает молоко"); }
    class Parrot : Pet { public override void Eat() => Console.WriteLine("Попугай клюёт зерно"); }
    static class Demo { public static void Run() { foreach (Pet p in new Pet[] { new Dog(), new Cat(), new Parrot() }) p.Eat(); } }
}

// 11
namespace T11
{
    class BankAccount
    {
        public double Balance { get; protected set; }
        public BankAccount(double b) { Balance = b; }
        public virtual void Deposit(double sum)
        {
            if (sum <= 0) { Console.WriteLine("Сумма должна быть положительной"); return; }
            Balance += sum;
        }
        public virtual bool Withdraw(double sum)
        {
            if (sum <= 0 || sum > Balance) { Console.WriteLine("Недостаточно средств"); return false; }
            Balance -= sum; return true;
        }
    }
    class SavingsAccount : BankAccount
    {
        public double Rate;
        public SavingsAccount(double b, double rate) : base(b) { Rate = rate; }
        public void AddInterest() { Balance += Balance * Rate / 100; }
    }
    class CreditAccount : BankAccount
    {
        public double CreditLimit;
        public CreditAccount(double b, double limit) : base(b) { CreditLimit = limit; }
        public override bool Withdraw(double sum)
        {
            if (sum <= 0 || sum > Balance + CreditLimit) { Console.WriteLine("Превышен кредитный лимит"); return false; }
            Balance -= sum; return true;
        }
    }
    static class Demo
    {
        public static void Run()
        {
            var s = new SavingsAccount(1000, 5); s.Deposit(500); s.AddInterest();
            Console.WriteLine($"Накопительный: {s.Balance}");
            var c = new CreditAccount(100, 500); c.Withdraw(400);
            Console.WriteLine($"Кредитный: {c.Balance}");
            c.Withdraw(1000);
        }
    }
}

// 12
namespace T12
{
    abstract class Transport { public abstract double CalculateCost(double km); }
    class Car : Transport { public override double CalculateCost(double km) => km * 50; }
    class Truck : Transport { public override double CalculateCost(double km) => km * 120 + 500; }
    class Bus : Transport { public override double CalculateCost(double km) => km * 80 + 200; }
    static class Demo
    {
        public static void Run()
        {
            foreach (Transport t in new Transport[] { new Car(), new Truck(), new Bus() })
                Console.WriteLine($"{t.GetType().Name}: 100 км = {t.CalculateCost(100)}");
        }
    }
}

// 13
namespace T13
{
    class Employee
    {
        public string Name; public double BaseSalary;
        public Employee(string n, double s) { Name = n; BaseSalary = s; }
        public virtual double GetSalary() => BaseSalary;
    }
    class Programmer : Employee
    {
        public Programmer(string n, double s) : base(n, s) { }
        public override double GetSalary() => BaseSalary * 1.5;
    }
    class Designer : Employee
    {
        public Designer(string n, double s) : base(n, s) { }
        public override double GetSalary() => BaseSalary * 1.2 + 10000;
    }
    class Manager : Employee
    {
        public Manager(string n, double s) : base(n, s) { }
        public override double GetSalary() => BaseSalary * 2;
    }
    static class Demo
    {
        public static void Run()
        {
            foreach (Employee e in new Employee[] { new Programmer("Аян", 500000), new Designer("Мира", 400000), new Manager("Тимур", 450000) })
                Console.WriteLine($"{e.Name} ({e.GetType().Name}): {e.GetSalary()}");
        }
    }
}

// 14
namespace T14
{
    class Person
    {
        public string Name; public int Age;
        public Person(string n, int a) { Name = n; Age = a; }
        public virtual void Print() => Console.WriteLine($"Имя: {Name}, возраст: {Age}");
    }
    class Student : Person
    {
        public string University; public int Course;
        public Student(string n, int a, string u, int c) : base(n, a) { University = u; Course = c; }
        public override void Print() { base.Print(); Console.WriteLine($"Университет: {University}, курс: {Course}"); }
    }
    class GraduateStudent : Student
    {
        public string ThesisTopic; public string Supervisor;
        public GraduateStudent(string n, int a, string u, int c, string t, string s) : base(n, a, u, c) { ThesisTopic = t; Supervisor = s; }
        public override void Print() { base.Print(); Console.WriteLine($"Тема диссертации: {ThesisTopic}, руководитель: {Supervisor}"); }
    }
    static class Demo { public static void Run() => new GraduateStudent("Дамир", 24, "КБТУ", 6, "Машинное обучение", "Проф. Серик").Print(); }
}

// 15
namespace T15
{
    abstract class MilitaryVehicle
    {
        public string Name;
        protected MilitaryVehicle(string n) { Name = n; }
        public abstract void Attack();
    }
    class Tank : MilitaryVehicle
    {
        public Tank() : base("Танк") { }
        public override void Attack() => Console.WriteLine($"{Name} стреляет из пушки");
    }
    class Helicopter : MilitaryVehicle
    {
        public Helicopter() : base("Вертолёт") { }
        public override void Attack() => Console.WriteLine($"{Name} запускает ракеты");
    }
    class ArmoredCar : MilitaryVehicle
    {
        public ArmoredCar() : base("Бронеавтомобиль") { }
        public override void Attack() => Console.WriteLine($"{Name} ведёт огонь из пулемёта");
    }
    static class Demo { public static void Run() { foreach (MilitaryVehicle v in new MilitaryVehicle[] { new Tank(), new Helicopter(), new ArmoredCar() }) v.Attack(); } }
}

// 16
namespace T16
{
    class Character
    {
        public string Name; public int Health, Damage;
        public Character(string n, int h, int d) { Name = n; Health = h; Damage = d; }
        public virtual void Attack() => Console.WriteLine($"{Name} атакует ({Damage})");
    }
    class Warrior : Character
    {
        public Warrior(string n) : base(n, 150, 25) { }
        public override void Attack() => Console.WriteLine($"{Name} бьёт мечом: {Damage} урона");
    }
    class Mage : Character
    {
        public Mage(string n) : base(n, 80, 40) { }
        public override void Attack() => Console.WriteLine($"{Name} кастует огненный шар: {Damage} урона");
    }
    class Archer : Character
    {
        public Archer(string n) : base(n, 100, 30) { }
        public override void Attack() => Console.WriteLine($"{Name} стреляет из лука: {Damage} урона");
    }
    static class Demo { public static void Run() { foreach (Character c in new Character[] { new Warrior("Конан"), new Mage("Мерлин"), new Archer("Леголас") }) c.Attack(); } }
}

// 17
namespace T17
{
    class Device
    {
        public bool IsOn { get; private set; }
        public virtual void TurnOn() { IsOn = true; Console.WriteLine($"{GetType().Name}: включено"); }
        public virtual void TurnOff() { IsOn = false; Console.WriteLine($"{GetType().Name}: выключено"); }
    }
    class Phone : Device { public override void TurnOn() { base.TurnOn(); Console.WriteLine("  Загрузка Android..."); } }
    class Computer : Device { public override void TurnOn() { base.TurnOn(); Console.WriteLine("  Загрузка Windows..."); } }
    class Television : Device { public override void TurnOff() { base.TurnOff(); Console.WriteLine("  Экран погас"); } }
    static class Demo
    {
        public static void Run()
        {
            foreach (Device d in new Device[] { new Phone(), new Computer(), new Television() }) { d.TurnOn(); d.TurnOff(); }
        }
    }
}

// 18
namespace T18
{
    abstract class Payment { public abstract void Pay(double amount); }
    class CashPayment : Payment { public override void Pay(double amount) => Console.WriteLine($"Оплата наличными: {amount}"); }
    class CardPayment : Payment { public override void Pay(double amount) => Console.WriteLine($"Оплата картой: {amount} (комиссия {amount * 0.01:F2})"); }
    class OnlinePayment : Payment { public override void Pay(double amount) => Console.WriteLine($"Онлайн-оплата: {amount} (через интернет-банк)"); }
    static class Demo { public static void Run() { foreach (Payment p in new Payment[] { new CashPayment(), new CardPayment(), new OnlinePayment() }) p.Pay(1000); } }
}

// 19
namespace T19
{
    class Employee
    {
        public string Name; public double Salary;
        public Employee(string n, double s) { Name = n; Salary = s; }
        public virtual double BonusPercent => 0;
        public double Bonus() => Salary * BonusPercent / 100;
    }
    class Manager : Employee { public Manager(string n, double s) : base(n, s) { } public override double BonusPercent => 20; }
    class Developer : Employee { public Developer(string n, double s) : base(n, s) { } public override double BonusPercent => 15; }
    class SalesManager : Employee { public SalesManager(string n, double s) : base(n, s) { } public override double BonusPercent => 30; }
    static class Demo
    {
        public static void Run()
        {
            foreach (Employee e in new Employee[] { new Manager("А", 1000), new Developer("Б", 1000), new SalesManager("В", 1000) })
                Console.WriteLine($"{e.Name} ({e.GetType().Name}): бонус {e.BonusPercent}% = {e.Bonus()}");
        }
    }
}

// 20
namespace T20
{
    class Animal
    {
        public virtual void Eat() => Console.WriteLine("Животное ест");
        public virtual void MakeSound() => Console.WriteLine("...");
    }
    class Lion : Animal { public override void Eat() => Console.WriteLine("Лев ест мясо"); public override void MakeSound() => Console.WriteLine("Рррр!"); }
    class Elephant : Animal { public override void Eat() => Console.WriteLine("Слон ест траву"); public override void MakeSound() => Console.WriteLine("Уууу!"); }
    class Monkey : Animal { public override void Eat() => Console.WriteLine("Обезьяна ест бананы"); public override void MakeSound() => Console.WriteLine("Уа-уа!"); }
    class Snake : Animal { public override void Eat() => Console.WriteLine("Змея глотает мышь"); public override void MakeSound() => Console.WriteLine("Ссссс!"); }
    class Penguin : Animal { public override void Eat() => Console.WriteLine("Пингвин ест рыбу"); public override void MakeSound() => Console.WriteLine("Кря-кря!"); }
    static class Demo
    {
        public static void Run()
        {
            foreach (Animal a in new Animal[] { new Lion(), new Elephant(), new Monkey(), new Snake(), new Penguin() }) { a.Eat(); a.MakeSound(); }
        }
    }
}

// 21
namespace T21
{
    abstract class Shape { public abstract double GetArea(); }
    class Circle : Shape { double r; public Circle(double r) { this.r = r; } public override double GetArea() => Math.PI * r * r; }
    class Rectangle : Shape { double w, h; public Rectangle(double w, double h) { this.w = w; this.h = h; } public override double GetArea() => w * h; }
    class Triangle : Shape { double b, h; public Triangle(double b, double h) { this.b = b; this.h = h; } public override double GetArea() => 0.5 * b * h; }
    class Square : Shape { double a; public Square(double a) { this.a = a; } public override double GetArea() => a * a; }
    static class Demo
    {
        public static void Run()
        {
            foreach (Shape s in new Shape[] { new Circle(2), new Rectangle(3, 4), new Triangle(5, 6), new Square(4) })
                Console.WriteLine($"{s.GetType().Name}: {s.GetArea():F2}");
        }
    }
}

// 22
namespace T22
{
    class Product
    {
        public string Name; public double Price;
        public Product(string n, double p) { Name = n; Price = p; }
        public virtual double GetTotalPrice() => Price;
    }
    class Electronics : Product
    {
        public int WarrantyYears;
        public Electronics(string n, double p, int w) : base(n, p) { WarrantyYears = w; }
        public override double GetTotalPrice() => Price * 1.12 + WarrantyYears * 5000; // НДС + гарантия
    }
    class Clothing : Product
    {
        public double DiscountPercent;
        public Clothing(string n, double p, double d) : base(n, p) { DiscountPercent = d; }
        public override double GetTotalPrice() => Price * (1 - DiscountPercent / 100);
    }
    class Food : Product
    {
        public int DaysToExpire;
        public Food(string n, double p, int d) : base(n, p) { DaysToExpire = d; }
        public override double GetTotalPrice() => DaysToExpire <= 3 ? Price * 0.5 : Price;
    }
    static class Demo
    {
        public static void Run()
        {
            foreach (Product p in new Product[] { new Electronics("Ноутбук", 300000, 2), new Clothing("Куртка", 40000, 25), new Food("Молоко", 500, 2) })
                Console.WriteLine($"{p.Name}: {p.Price} -> {p.GetTotalPrice()}");
        }
    }
}

// 23
namespace T23
{
    abstract class Transport
    {
        public abstract void Move();
        public abstract double GetFuelConsumption(); // л/100км
    }
    class Car : Transport { public override void Move() => Console.WriteLine("Машина едет"); public override double GetFuelConsumption() => 8; }
    class Truck : Transport { public override void Move() => Console.WriteLine("Грузовик везёт груз"); public override double GetFuelConsumption() => 30; }
    class Bus : Transport { public override void Move() => Console.WriteLine("Автобус везёт пассажиров"); public override double GetFuelConsumption() => 25; }
    class Motorcycle : Transport { public override void Move() => Console.WriteLine("Мотоцикл мчится"); public override double GetFuelConsumption() => 5; }
    static class Demo
    {
        public static void Run()
        {
            foreach (Transport t in new Transport[] { new Car(), new Truck(), new Bus(), new Motorcycle() })
            { t.Move(); Console.WriteLine($"  Расход: {t.GetFuelConsumption()} л/100км"); }
        }
    }
}

// 24
namespace T24
{
    class MedicalWorker
    {
        public string Name;
        public MedicalWorker(string n) { Name = n; }
        public virtual void Work() => Console.WriteLine($"{Name} работает в больнице");
    }
    class Doctor : MedicalWorker { public Doctor(string n) : base(n) { } public override void Work() => Console.WriteLine($"{Name} принимает пациентов и ставит диагнозы"); }
    class Nurse : MedicalWorker { public Nurse(string n) : base(n) { } public override void Work() => Console.WriteLine($"{Name} делает уколы и ухаживает за больными"); }
    class Surgeon : MedicalWorker { public Surgeon(string n) : base(n) { } public override void Work() => Console.WriteLine($"{Name} проводит операцию"); }
    static class Demo { public static void Run() { foreach (MedicalWorker m in new MedicalWorker[] { new Doctor("Иванов"), new Nurse("Петрова"), new Surgeon("Сидоров") }) m.Work(); } }
}

// 25
namespace T25
{
    class Person
    {
        public string Name; public int Age;
        public Person(string n, int a) { Name = n; Age = a; }
        public virtual void Introduce() => Console.WriteLine($"Я {Name}, мне {Age}");
    }
    class Employee : Person
    {
        public string Position; public double Salary;
        public Employee(string n, int a, string p, double s) : base(n, a) { Position = p; Salary = s; }
        public virtual void Work() => Console.WriteLine($"{Name} работает как {Position}");
        public override void Introduce() { base.Introduce(); Console.WriteLine($"  Должность: {Position}, зарплата: {Salary}"); }
    }
    class Manager : Employee
    {
        public int TeamSize; public string Department;
        public Manager(string n, int a, string p, double s, int t, string d) : base(n, a, p, s) { TeamSize = t; Department = d; }
        public void ConductMeeting() => Console.WriteLine($"{Name} проводит планёрку отдела {Department} ({TeamSize} чел.)");
        public override void Introduce() { base.Introduce(); Console.WriteLine($"  Отдел: {Department}, команда: {TeamSize}"); }
    }
    class Director : Manager
    {
        public int Subordinates; public double Budget;
        public Director(string n, int a, string p, double s, int t, string d, int sub, double b) : base(n, a, p, s, t, d) { Subordinates = sub; Budget = b; }
        public void ApproveBudget() => Console.WriteLine($"{Name} утверждает бюджет {Budget}");
        public override void Introduce() { base.Introduce(); Console.WriteLine($"  Подчинённых: {Subordinates}, бюджет: {Budget}"); }
    }
    static class Demo
    {
        public static void Run()
        {
            var d = new Director("Асхат", 45, "Директор", 2000000, 10, "IT", 120, 50000000);
            d.Introduce(); d.Work(); d.ConductMeeting(); d.ApproveBudget();
        }
    }
}

// 26
namespace T26
{
    abstract class Character
    {
        public string Name; public int Health;
        protected Character(string n, int h) { Name = n; Health = h; }
        public abstract void Attack();
        public abstract void Defend();
        public abstract void SpecialAttack();
    }
    class Warrior : Character
    {
        public Warrior(string n) : base(n, 150) { }
        public override void Attack() => Console.WriteLine($"{Name}: удар мечом");
        public override void Defend() => Console.WriteLine($"{Name}: блок щитом");
        public override void SpecialAttack() => Console.WriteLine($"{Name}: сокрушительный удар!");
    }
    class Mage : Character
    {
        public Mage(string n) : base(n, 80) { }
        public override void Attack() => Console.WriteLine($"{Name}: магический снаряд");
        public override void Defend() => Console.WriteLine($"{Name}: магический барьер");
        public override void SpecialAttack() => Console.WriteLine($"{Name}: метеоритный дождь!");
    }
    class Archer : Character
    {
        public Archer(string n) : base(n, 100) { }
        public override void Attack() => Console.WriteLine($"{Name}: выстрел из лука");
        public override void Defend() => Console.WriteLine($"{Name}: уклонение");
        public override void SpecialAttack() => Console.WriteLine($"{Name}: град стрел!");
    }
    static class Demo
    {
        public static void Run()
        {
            foreach (Character c in new Character[] { new Warrior("Воин"), new Mage("Маг"), new Archer("Лучник") })
            { c.Attack(); c.Defend(); c.SpecialAttack(); }
        }
    }
}

// 27
namespace T27
{
    class File
    {
        public string Name; public double SizeKB;
        public File(string n, double s) { Name = n; SizeKB = s; }
        public virtual void Open() => Console.WriteLine($"Открыт файл {Name} ({SizeKB} КБ)");
    }
    class TextFile : File
    {
        public TextFile(string n, double s) : base(n, s) { }
        public override void Open() => Console.WriteLine($"{Name}: открыт в текстовом редакторе");
    }
    class ImageFile : File
    {
        public ImageFile(string n, double s) : base(n, s) { }
        public override void Open() => Console.WriteLine($"{Name}: открыт в просмотрщике изображений");
    }
    class VideoFile : File
    {
        public VideoFile(string n, double s) : base(n, s) { }
        public override void Open() => Console.WriteLine($"{Name}: запущен видеоплеер");
    }
    static class Demo { public static void Run() { foreach (File f in new File[] { new TextFile("a.txt", 4), new ImageFile("b.png", 800), new VideoFile("c.mp4", 90000) }) f.Open(); } }
}

// 28
namespace T28
{
    abstract class Employee
    {
        public string Name;
        protected Employee(string n) { Name = n; }
        public abstract double CalculateSalary();
    }
    class HourlyEmployee : Employee
    {
        double rate, hours;
        public HourlyEmployee(string n, double rate, double hours) : base(n) { this.rate = rate; this.hours = hours; }
        public override double CalculateSalary() => hours <= 160 ? rate * hours : rate * 160 + (hours - 160) * rate * 1.5;
    }
    class SalariedEmployee : Employee
    {
        double salary;
        public SalariedEmployee(string n, double s) : base(n) { salary = s; }
        public override double CalculateSalary() => salary;
    }
    class CommissionEmployee : Employee
    {
        double sales, percent;
        public CommissionEmployee(string n, double sales, double percent) : base(n) { this.sales = sales; this.percent = percent; }
        public override double CalculateSalary() => sales * percent / 100;
    }
    static class Demo
    {
        public static void Run()
        {
            var list = new List<Employee>
            {
                new HourlyEmployee("Почасовик", 2000, 170),
                new SalariedEmployee("Окладник", 400000),
                new CommissionEmployee("Комиссионер", 1000000, 10),
            };
            foreach (var e in list) Console.WriteLine($"{e.Name}: {e.CalculateSalary()}");
            Console.WriteLine($"Общий фонд зарплаты: {list.Sum(e => e.CalculateSalary())}");
        }
    }
}

// 29
namespace T29
{
    class Animal { public virtual void MakeSound() => Console.WriteLine("..."); }
    class Dog : Animal { public override void MakeSound() => Console.WriteLine("Гав!"); }
    class Cat : Animal { public override void MakeSound() => Console.WriteLine("Мяу!"); }
    class Cow : Animal { public override void MakeSound() => Console.WriteLine("Му!"); }
    class Duck : Animal { public override void MakeSound() => Console.WriteLine("Кря!"); }
    class Horse : Animal { public override void MakeSound() => Console.WriteLine("Иго-го!"); }
    static class Demo
    {
        public static void Run()
        {
            var animals = new List<Animal> { new Dog(), new Cat(), new Cow(), new Duck(), new Horse() };
            foreach (Animal a in animals) a.MakeSound();
        }
    }
}

// 30
namespace T30
{
    abstract class Vehicle
    {
        public string Brand { get; }
        public string Model { get; }
        public int MaxSpeed { get; }
        public double Price { get; }
        protected Vehicle(string brand, string model, int speed, double price)
        { Brand = brand; Model = model; MaxSpeed = speed; Price = price; }

        public abstract double GetFuelConsumption();        // на 100 км
        public virtual string FuelUnit => "л";
        public virtual void Move() => Console.WriteLine($"{Brand} {Model} едет");
        public virtual void PrintInfo() =>
            Console.WriteLine($"{GetType().Name}: {Brand} {Model}, {MaxSpeed} км/ч, {Price:N0} $, расход {GetFuelConsumption()} {FuelUnit}/100км");
        public double FuelFor(double km) => GetFuelConsumption() * km / 100;
    }
    class Car : Vehicle
    {
        public int Doors { get; }
        public Car(string b, string m, int s, double p, int doors) : base(b, m, s, p) { Doors = doors; }
        public override double GetFuelConsumption() => 8;
        public override void PrintInfo() { base.PrintInfo(); Console.WriteLine($"  Дверей: {Doors}"); }
    }
    class Truck : Vehicle
    {
        public double LoadCapacityTons { get; }
        public Truck(string b, string m, int s, double p, double load) : base(b, m, s, p) { LoadCapacityTons = load; }
        public override double GetFuelConsumption() => 20 + LoadCapacityTons * 1.5;
        public override void Move() => Console.WriteLine($"{Brand} {Model} везёт груз до {LoadCapacityTons} т");
        public override void PrintInfo() { base.PrintInfo(); Console.WriteLine($"  Грузоподъёмность: {LoadCapacityTons} т"); }
    }
    class Bus : Vehicle
    {
        public int Seats { get; }
        public Bus(string b, string m, int s, double p, int seats) : base(b, m, s, p) { Seats = seats; }
        public override double GetFuelConsumption() => 25 + Seats * 0.1;
        public override void Move() => Console.WriteLine($"{Brand} {Model} везёт {Seats} пассажиров");
        public override void PrintInfo() { base.PrintInfo(); Console.WriteLine($"  Мест: {Seats}"); }
    }
    class ElectricCar : Vehicle
    {
        public double BatteryKWh { get; }
        public ElectricCar(string b, string m, int s, double p, double battery) : base(b, m, s, p) { BatteryKWh = battery; }
        public override string FuelUnit => "кВт·ч";
        public override double GetFuelConsumption() => 15;
        public override void Move() => Console.WriteLine($"{Brand} {Model} бесшумно едет на электротяге");
        public override void PrintInfo() { base.PrintInfo(); Console.WriteLine($"  Батарея: {BatteryKWh} кВт·ч"); }
    }
    class Motorcycle : Vehicle
    {
        public Motorcycle(string b, string m, int s, double p) : base(b, m, s, p) { }
        public override double GetFuelConsumption() => 5;
    }

    class Fleet
    {
        readonly List<Vehicle> vehicles = new List<Vehicle>();
        public void Add(Vehicle v) { vehicles.Add(v); Console.WriteLine($"Добавлен: {v.Brand} {v.Model}"); }
        public bool Remove(Vehicle v)
        {
            bool ok = vehicles.Remove(v);
            Console.WriteLine(ok ? $"Удалён: {v.Brand} {v.Model}" : "Транспорт не найден");
            return ok;
        }
        public void PrintAll() { foreach (var v in vehicles) { v.PrintInfo(); } }
        public void PrintFuel(double km)
        {
            foreach (var v in vehicles)
                Console.WriteLine($"{v.Brand} {v.Model}: на {km} км нужно {v.FuelFor(km):F1} {v.FuelUnit}");
        }
        public Vehicle Fastest() => vehicles.OrderByDescending(v => v.MaxSpeed).FirstOrDefault();
        public Vehicle MostExpensive() => vehicles.OrderByDescending(v => v.Price).FirstOrDefault();
    }

    static class Demo
    {
        public static void Run()
        {
            var fleet = new Fleet();
            var car = new Car("Toyota", "Camry", 210, 30000, 4);
            var truck = new Truck("MAN", "TGX", 120, 90000, 18);
            var bus = new Bus("Mercedes", "Tourismo", 100, 250000, 50);
            var tesla = new ElectricCar("Tesla", "Model S", 250, 80000, 100);
            var moto = new Motorcycle("Ducati", "Panigale", 299, 25000);
            foreach (Vehicle v in new Vehicle[] { car, truck, bus, tesla, moto }) fleet.Add(v);

            Console.WriteLine("\n-- Информация --");
            fleet.PrintAll();
            Console.WriteLine("\n-- Движение --");
            foreach (Vehicle v in new Vehicle[] { car, truck, bus, tesla, moto }) v.Move();
            Console.WriteLine("\n-- Расход на 250 км --");
            fleet.PrintFuel(250);

            var f = fleet.Fastest(); var e = fleet.MostExpensive();
            Console.WriteLine($"\nСамый быстрый: {f.Brand} {f.Model} ({f.MaxSpeed} км/ч)");
            Console.WriteLine($"Самый дорогой: {e.Brand} {e.Model} ({e.Price:N0} $)");

            Console.WriteLine();
            fleet.Remove(bus);
            fleet.Remove(bus);
        }
    }
}
