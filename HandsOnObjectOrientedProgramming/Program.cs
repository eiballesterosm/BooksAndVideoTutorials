using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HandsOnObjectOrientedProgramming
{
    #region ClassesAndObjects
    public class ClassesAndObjects
    {
        public static void Main(string[] args)
        {
            //Call default constructor
            Customer customer1 = new Customer();
            customer1.firstName = "Eduardo";
            customer1.lastName = "Ballesteros";
            customer1.phoneNumber = "3057523730";
            customer1.emailAddress = "eduballesteros@gmail.com";

            Console.WriteLine("Customer 1 first name is " + customer1.firstName);


            //Call constructor, two parameters
            Customer customer2 = new Customer("Isaac", "Ballesteros");
            Console.WriteLine("Customer 2 name is " + customer2.GetFullName());
        }
    }

    /// <summary>
    /// Class Customer
    /// </summary>
    public class Customer
    {
        //Variables
        public string firstName;
        public string lastName;
        public string phoneNumber;
        public string emailAddress;

        /// <summary>
        /// Default constructor
        /// </summary>
        public Customer()
        {

        }

        /// <summary>
        /// Constructor with two parameters
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        public Customer(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        /// <summary>
        /// Method
        /// </summary>
        /// <returns></returns>
        public string GetFullName()
        {
            return firstName + " " + lastName;
        }
    }

    #endregion

    #region CharacteristicsOfOOP
    public class CharacteristicsOfOOP
    {
        public static void Main(string[] args)
        {
            //Polymorphism example
            MyCalc myCalc = new MyCalc(1, 1);
            MyCalc myCalc2 = new MyCalc(1, 1);
            MyCalc myCalcSum = myCalc + myCalc2;
            Console.WriteLine("myCalcSum.a: " + myCalcSum.a);
            Console.WriteLine("myCalcSum.b: " + myCalcSum.b);
            Console.ReadKey();
        }
    }

    #region Inheritance

    /// <summary>
    /// Parent class Fruit
    /// </summary>
    public class Fruit
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }

    public class Apple : Fruit
    {
        public int NumberOfSeeds { get; set; }
    }

    #endregion

    #region Encapsulation

    /// <summary>
    /// Class BankAccount
    ///The GetBalanceAfterTax method is a method that will not be needed by other classes.
    /// We only want to provide the AccountBalance after tax, so we can make this method private.
    /// </summary>	
    public class BankAccount
    {
        //Variables
        private double AccountBalance { get; set; }
        private double TaxRate { get; set; }

        public double GetAccountBalance()
        {
            double balanceAfterTax = GetBalanceAfterTax();
            return balanceAfterTax;
        }

        private double GetBalanceAfterTax()
        {
            return AccountBalance * TaxRate;
        }
    }


    #endregion

    #region Abstraction

    /// <summary>
    /// Abstract class with an abstrac method, this method has to be overridden by the classes that implement the abstract class
    /// </summary>
    public abstract class Vehicle
    {
        public abstract int GetNumberOfTyres();
    }

    public class Bicycle : Vehicle
    {
        public string Company { get; set; }
        public string Model { get; set; }
        public int NumberOfTyres { get; set; }

        public override int GetNumberOfTyres()
        {
            return NumberOfTyres;
        }
    }

    public class Car : Vehicle
    {
        public string Company { get; set; }
        public string Model { get; set; }
        public int FrontTyres { get; set; }
        public int BackTires { get; set; }

        public override int GetNumberOfTyres()
        {
            return FrontTyres + BackTires;
        }
    }

    #endregion

    #region Polymorphism

    /// <summary>
    /// Class with two methods with the same name, but different parameters
    /// </summary>
    public class Calculator
    {
        public int AddNumbers(int firstNum, int secondNum)
        {
            return firstNum + secondNum;
        }

        public double AddNumbers(double firstNum, double secondNum)
        {
            return firstNum + secondNum;
        }
    }

    public class MyCalc
    {
        public int a;
        public int b;

        public MyCalc(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        /// <summary>
        /// Overloaded the plus (+) dign with another type of calculation
        /// If you sum two MyCalc objects, you will get an overloaded result instead of the normal sum.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static MyCalc operator +(MyCalc a, MyCalc b)
        {
            return new MyCalc(a.a * 3, b.b * 3);
        }
    }

    #endregion

    #endregion

    #region ImplementationOOP

    #region Interfaces
    public class ImplementationOOPInterfaces
    {
        public static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.Credit(1000);
            bankAccount.Debit(500);

            Console.Read();
        }

        interface IBankAccount
        {
            void Debit(double amount);

            void Credit(double amount);
        }

        class BankAccount : IBankAccount
        {
            public void Credit(double amount)
            {
                Console.WriteLine($" ${amount} has been credited to your account");
            }

            public void Debit(double amount)
            {
                Console.WriteLine($" ${amount} has been debited from your account!");
            }
        }
    }

    #endregion

    #region AbstractClass
    public class AbstractClass
    {
        public static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Move();
            dog.Eat();

            Console.Read();
        }

        abstract class Animal
        {
            public string Name { get; set; }
            public int ageInMonths { get; set; }

            public abstract void Move();

            public void Eat()
            {
                Console.WriteLine("Eating....");
            }
        }

        class Dog : Animal
        {
            public override void Move()
            {
                Console.WriteLine("Moving...");
            }
        }
    }
    #endregion

    #region SealedClass

    public class SealedClass
    {
        public static void Main(string[] args)
        {
            Animal dog = new Animal();
            dog.name = "Doggy";
            dog.ageInMonths = 1;
            dog.Move();
            dog.Eat();
        }
    }

    sealed class Animal
    {
        public string name;
        public int ageInMonths;
        public void Move()
        {
            Console.WriteLine("Moving...");
        }

        public void Eat()
        {
            Console.WriteLine("Eating....");
        }
    }

    #endregion

    #region Tuples

    public class Tuples
    {
        public static void Main()
        {
            //var developer = GetPerson();
            Tuple<string, int, string> developer = GetPerson();
            Console.WriteLine(developer.Item1);
            Console.WriteLine(developer.Item2);
            Console.WriteLine(developer.Item3);

            Console.Read();
        }

        public static Tuple<string, int, string> GetPerson()
        {
            //var person = new Tuple<string, int, string>("Eduardo Isaac Ballesteros", 30, "Software Developer");
            Tuple<string, int, string> person = new Tuple<string, int, string>("Eduardo Isaac Ballesteros", 30, "Software Developer");
            return person;
        }
    }

    #endregion

    #region Properties

    public class Properties
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Example of Properties in C#");
            Console.WriteLine("Eduardo Isaac Ballesteros Muñoz");
        }
    }

    public class House
    {
        //prop
        public string Name { get; set; }

        //prop
        public string Address { get; set; }

        private int area;

        public int Area
        {
            get { return area; }
            set { area = value; }
        }
    }
    #endregion

    #endregion

    #region Events and Delegates

    #region How to create and use delegates 

    delegate int MathFunc(int a, int b);

    public class DelegateExample
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Delegate Example. Eduardo Isaac Ballesteros Muñoz");
            MathFunc mf = new MathFunc(Add);

            Console.WriteLine("Add");
            Console.WriteLine(mf(4, 5));

            mf = new MathFunc(Sub);
            Console.WriteLine("Sub");
            Console.WriteLine(mf(6, 1));

            Console.ReadKey();
        }

        public static int Add(int a, int b)
        {
            return a + b;
        }

        public static int Sub(int a, int b)
        {
            return a - b;
        }
    }

    #endregion

    #region Method Group Conversion

    delegate double MathFuncionDelegate(double paramA, double paramB);

    public class DelegatesMethodGroupConversion
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Delegate Example. Method group conversion.  Eduardo Isaac Ballesteros Muñoz");
            MathFuncionDelegate mfd = Add;
            Console.WriteLine("Add");
            Console.WriteLine(mfd(4, 67));

            mfd = Product;
            Console.WriteLine("Product");
            Console.WriteLine(mfd(12, 8));

            Console.ReadKey();
        }

        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Product(double a, double b)
        {
            return a * b;
        }
    }


    #endregion

    #region Using the Static and Instance Methos as Delegates

    delegate int MathFunctionDelegate(int a, int b);

    public class DelegateStaticAndInstanceMethod
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Delegate Example\nUsing the static and instance methods as delegates\nEduardo Isaac Ballesteros Muñoz\n");
            MyMath mm = new MyMath();

            MathFunctionDelegate mfd = mm.Add;
            Console.WriteLine("Add");
            Console.WriteLine(mfd(2, 34));

            mfd = mm.Sub;
            Console.WriteLine("Sub");
            Console.WriteLine(mfd(2, 34));

            Console.ReadKey();
        }
    }

    public class MyMath
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Sub(int a, int b)
        {
            return (a > b) ? (a - b) : (b - a);
        }
    }

    #endregion

    #region Multicasting

    delegate void MathFunctionRefDelegate(ref int a);
    public class DelegateMulticasting
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Delegate Example\nMulticasting\nEduardo Isaac Ballesteros Muñoz\n");

            MathFunctionRefDelegate mfd;

            MathFunctionRefDelegate myAddDelegate = MathFunction.Add;
            MathFunctionRefDelegate mySubDelegate = MathFunction.Sub;

            mfd = myAddDelegate;
            mfd += mySubDelegate;

            int number = 10;
            mfd(ref number);
            Console.WriteLine("Final number: " + number);
            mfd -= mySubDelegate;
            mfd(ref number);
            Console.WriteLine("Final number: " + number);

            Console.ReadKey();
        }
    }

    public class MathFunction
    {
        public static void Add(ref int a)
        {
            a = a + 5;
            Console.WriteLine("After adding 5 the answer is " + a);
        }

        public static void Sub(ref int a)
        {
            a = a - 3;
            Console.WriteLine("After substracting 3 the answer is " + a);
        }
    }

    #endregion

    #region Covariance

    public delegate A DoSomething();

    public class A
    {
        public int value { get; set; }
    }

    public class B : A
    {

    }

    public class DelegateCovariance
    {
        public static A WorkA()
        {
            A a = new A();
            a.value = 1;
            return a;
        }

        public static B WorkB()
        {
            B b = new B();
            b.value = 2;
            return b;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Delegate Example\nCovariance\nEduardo Isaac Ballesteros Muñoz\n");

            A someA = new A();
            DoSomething something = WorkB;

            someA = something();
            Console.WriteLine("The value is " + someA.value);

            Console.ReadLine();
        }

    }

    #endregion

    #region Contravariance

    public delegate int DoSomethingDelegate(D d);

    public class C
    {
        public int value = 5;
    }

    public class D : C
    {

    }

    public class DelegateContravariance
    {
        public static int WorkC(C c)
        {
            Console.WriteLine("Method WorkC called: ");
            return c.value * 5;
        }

        public static int WorkD(D d)
        {
            Console.WriteLine("Method WorkB called: ");
            return d.value * 10;
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Delegate Example\nContravariance\nEduardo Isaac Ballesteros Muñoz\n");

            D someD = new D();
            DoSomethingDelegate somethingDelegate = WorkC;

            int result = somethingDelegate(someD);
            Console.WriteLine("The values is " + result);
            Console.Read();
        }
    }

    #endregion

    #region Events

    public delegate void GetResult();

    public class ResultPublishEvent
    {
        public event GetResult PublishResult;

        public void PublishResultNow()
        {
            if (PublishResult != null)
            {
                Console.WriteLine("We are publishing the results now!");
                Console.WriteLine("");
                PublishResult();
            }
        }
    }

    public class EmailEventHandler
    {
        public void SendEmail()
        {
            Console.WriteLine("Results have been emailed successfully");
        }
    }

    public class Events
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Events Example\nEduardo Isaac Ballesteros Muñoz\n");

            ResultPublishEvent e = new ResultPublishEvent();
            EmailEventHandler email = new EmailEventHandler();

            e.PublishResult += email.SendEmail;
            e.PublishResultNow();

            Console.ReadLine();
        }
    }

    #endregion

    #region Multicasting Events

    public delegate void GetResultsDelegate();

    public class ResultPublishEvents
    {
        public event GetResultsDelegate PublishResults;

        public void PublishResultsNow()
        {
            if (PublishResults != null)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine("Publishing the results now!!!");
                Console.WriteLine(string.Empty);
                PublishResults();
            }
        }
    }

    public class SMSEventHandler
    {
        public void SendSMS()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + ":" + DateTime.Now.Millisecond + " Results have been messaged SMS succesfully!!");
        }
    }

    public class NewsLetterHandler
    {
        public void SendNotification()
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + ":" + DateTime.Now.Millisecond + " Results have been messaged succesfully!!");
        }
    }

    public class MulticastingEvents
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Multicasting Events Example\nEduardo Isaac Ballesteros Muñoz\n");

            ResultPublishEvents e = new ResultPublishEvents();

            SMSEventHandler smsEventHandler = new SMSEventHandler();
            NewsLetterHandler newsLetterEventHandler = new NewsLetterHandler();

            e.PublishResults += smsEventHandler.SendSMS;
            e.PublishResults += newsLetterEventHandler.SendNotification;
            e.PublishResultsNow();

            Thread.Sleep(1000);

            e.PublishResults -= smsEventHandler.SendSMS;
            e.PublishResultsNow();
        }
    }

    #endregion

    #region EventGuidelines

    public delegate void MyEventHandler(object sender, MyEventArgs e);

    public class MyEventArgs : EventArgs
    {
        public int number;
    }

    public class MyEvent
    {
        public static int counter = 0;

        public event MyEventHandler MyEventHandlerObj;

        public void GetSomeEvent()
        {
            MyEventArgs args = new MyEventArgs();

            if (MyEventHandlerObj != null)
            {
                args.number = counter++;
                MyEventHandlerObj(this, args);
            }
        }
    }

    public class Test
    {
        public void Handler(object sender, MyEventArgs e)
        {
            Console.WriteLine("Event number: " + e.number);
            Console.WriteLine("Source object: " + sender);
            Console.WriteLine();
        }
    }

    public class EventGuidelines
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Multicasting Events Example\nEduardo Isaac Ballesteros Muñoz\n");

            Test test = new Test();
            MyEvent myEvent = new MyEvent();
            myEvent.MyEventHandlerObj += test.Handler;

            for (int i = 0; i < 16; i++)
            {
                myEvent.GetSomeEvent();
            }

            Console.Read();
        }

    }

    #endregion

    #endregion

    #region Generics

    #region Basic Example

    public class Price<T>
    {
        T ob;

        public Price(T o)
        {
            ob = o;
        }

        public void PrintType()
        {
            Console.WriteLine("The type is " + typeof(T));
        }

        public T GetPrice()
        {
            return ob;
        }
    }

    public class GenericExample
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Generics\nBasic Example\nEduardo Isaac Ballesteros Muñoz\n");

            Price<int> price = new Price<int>(1250);
            price.PrintType();
            Console.WriteLine("The price is " + price.GetPrice());
            Console.WriteLine("---------------------");

            Price<Double> priceDouble = new Price<Double>(2560.30);
            priceDouble.PrintType();
            Console.WriteLine("The price is " + priceDouble.GetPrice());
            Console.WriteLine("---------------------");

            Price<string> priceString = new Price<string>("$4589,69");
            priceString.PrintType();
            Console.WriteLine("The price is " + priceString.GetPrice());
        }
    }

    #endregion

    #region Basic class constraints

    public class Person
    {
        public void PrintName()
        {
            Console.WriteLine("My name is Eduardo Isaac Ballesteros Muñoz");
        }
    }

    public class Boy : Person
    {

    }

    public class Toy
    {

    }

    public class Human<T> where T : Person
    {
        T obj;

        public Human(T o)
        {
            obj = o;
        }

        public void MustPrint()
        {
            obj.PrintName();
        }
    }

    public class GenericBasicClassConstraints
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Generics\nBasic class constraints\nEduardo Isaac Ballesteros Muñoz\n");

            Person person = new Person();
            Boy boy = new Boy();
            Toy toy = new Toy();

            Human<Person> personTypeHuman = new Human<Person>(person);
            personTypeHuman.MustPrint();

            Human<Boy> boyTypeHuman = new Human<Boy>(boy);
            boyTypeHuman.MustPrint();

            /*NOT ALLOWED
            Human<Toy> toyTypeHuman = new Human<Toy>(toy);
            toyTypeHuman.MustPrint();
            */
        }
    }

    #endregion

    #region Reference Type and Value Type Constraints

    public class GenericReferenceTypeAndValueTypes
    {
        //In .NET Fiddle Compilation error (line 7, col 78): Constraint cannot be special class 'System.Enum'
        //Only C# 7.3
        //https://stackoverflow.com/questions/79126/create-generic-method-constraining-t-to-an-enum
        //public static Dictionary<int, string> EnumNamedValues<T>() where T : Enum

        public static Dictionary<int, string> EnumNamedValues<T>() where T : struct, IComparable, IFormattable, IConvertible
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            Array values = Enum.GetValues(typeof(T));

            foreach (int item in values)
            {
                result.Add(item, Enum.GetName(typeof(T), item));
            }

            return result;
        }

        enum ColorsEnum
        {
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            Indigo,
            Violet
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Generics\nReference type and value type constraints\nEduardo Isaac Ballesteros Muñoz\n");

            Dictionary<int, string> enumNamedValues = EnumNamedValues<ColorsEnum>();
            foreach (var item in enumNamedValues)
            {
                Console.WriteLine(item.Key + "\t" + item.Value);
            }
        }
    }


    #endregion

    #region Interface Constraint

    public interface ISampleInterface
    {
        void SampleMethod();
    }

    public class ConstraintSimpleClass<G> where G : ISampleInterface
    {
        G obj;

        public ConstraintSimpleClass(G o)
        {
            obj = o;
        }

        public void Call()
        {
            obj.SampleMethod();
        }
    }

    public class SimpleClass : ISampleInterface
    {
        public void SampleMethod()
        {
            Console.WriteLine("SampleMethod");
        }
    }

    public class SimpleClass2
    {
        public void SampleMethod2()
        {
            Console.WriteLine("SampleMethod2");
        }
    }

    public class GenericInterface
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Generics\nInterface constraints\nEduardo Isaac Ballesteros Muñoz\n");

            SimpleClass simpleClass = new SimpleClass();
            ConstraintSimpleClass<SimpleClass> testConstraintClass = new ConstraintSimpleClass<SimpleClass>(simpleClass);
            testConstraintClass.Call();

            //Compilation Error CS0311
            //The type 'HandsOnObjectOrientedProgramming.SimpleClass2' cannot be used as type parameter 'G' in the generic type or method 'ConstraintSimpleClass<G>'.
            //There is no implicit reference conversion from 'HandsOnObjectOrientedProgramming.SimpleClass2' to 'HandsOnObjectOrientedProgramming.ISampleInterface'.
            //SimpleClass2 simpleClass2 = new SimpleClass2();
            //ConstraintSimpleClass<SimpleClass2> test2 = new ConstraintSimpleClass<SimpleClass2>(simpleClass2);
        }
    }

    #endregion

    #region Generic Methods

    public class Hello
    {
        public static T Larger<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }

    public class GenericMethods
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Generics\nGeneric Methods\nEduardo Isaac Ballesteros Muñoz\n");

            //int intResult = Hello.Larger<int>(3, 4);
            //Type-inferencing
            int intResult = Hello.Larger(3, 4);
            Console.WriteLine("The large int value is: " + intResult);

            //double doubleResult = Hello.Larger<double>(4.3, 5.6);
            //Type-inferencing
            double doubleResult = Hello.Larger<double>(4.3, 5.6);
            Console.WriteLine("The large double value is: " + doubleResult);
        }
    }

    #endregion

    #region Covariance and contravariance in generics

    public interface IFood<in T>
    {
        void PrintName(T obj);
    }

    public class HealthyFood<T> : IFood<T>
    {
        public void PrintName(T obj)
        {
            Console.WriteLine("This is " + obj);
        }
    }

    public class Vegetable
    {
        public override string ToString()
        {
            return "Vegetable";
        }
    }

    public class Carrot : Vegetable
    {
        public override string ToString()
        {
            return "Carrot";
        }
    }

    public class GenericCovarianceAndContravariance
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Generics\nCovariance and contravariance\nEduardo Isaac Ballesteros Muñoz\n");

            IFood<Carrot> mySelf = new HealthyFood<Carrot>();
            IFood<Carrot> mySelf2 = new HealthyFood<Vegetable>();
            
            mySelf2.PrintName(new Carrot());
        }
    }

    #endregion


    #endregion
}