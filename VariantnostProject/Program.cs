namespace VariantnostProject
{
    class Car
    {

    }

    class Bmv : Car
    {

    }

    class Lanos : Car
    {

    }

    internal class Program
    {
        static Bmv MethodBmv(Bmv bmv)
        {
            return new Bmv();
        }

        static Car CarWork(CarCreate create)
        {
            Car car = create();
            return car;
        }
        static Bmv BmvCreate()
        {
            return new Bmv();
        }

        public delegate Car CarHandler(Car car);
        public delegate Car CarCreate();

        public delegate int BmvTester(Bmv bmv);

        static void TestBmv(BmvTester tester)
        {
            var bmv = new Bmv();
            int result = tester(bmv);
            Console.WriteLine(result);
        }

        static int UniversalTester(Car car)
        {
            return 100;
        }
        
        static void Main(string[] args)
        {
            Car car = new Bmv();

            IEnumerable<Bmv> bmvs = new List<Bmv>();
            IEnumerable<Car> cars = bmvs;

            // Ковариантность


            //CarHandler handler = MethodBmv; // ошибка
            CarCreate create = BmvCreate; // правильно работает

            Car car2 = CarWork(BmvCreate);

            // контрвариантность 

            TestBmv(UniversalTester);
        }
    }
}