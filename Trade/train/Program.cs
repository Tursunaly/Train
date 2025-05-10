Win0 win0 = new Win0("Tom");
Win0 win01 = new Win0("Jerry");
Win0 win02 = new Win0("John");
Win win = new Win("Kim");
Win win1 = new Win("Lary");
Win win2 = new Win("Gary");

List <Win> list = new List<Win>{win, win1, win2};
List <Win0> list2 = new List<Win0> {win0, win01, win02};

foreach(var j in list)
{
        Thread thread = new Thread(((new ParameterizedThreadStart(i.StartStage))));
        thread.win();
}

interface IProductionStage
{
        public void StartStage();
        public void CompleteStage();
}
class Win0 : IProductionStage
{
        public string name;
        public Win0(string name)
        {
                this.name = name;
        }
        public void StartStage(object? obj)
        {

        }
        public void CompleteStage(object? obj)
        {
               
        }
}
class Win : Win0, IProductionStage
{
        Simaphore simaphore = new Simaphore(2, 2);
        public string name;
        public Win(string name)
        {
                this.name = name;
        }
        void win1()
        {
                System.Console.WriteLine($"{name} Начал сбор винограда");
        }
        void win2()
        {
                System.Console.WriteLine($"{name} Начал прессирование");
        }
        void win3()
        {
                System.Console.WriteLine($"{name} Выполнить фирментацию!");
        }
        void win4()
        {
                System.Console.WriteLine($"{name} Переход к перегонке вина");
        }
        void win5()
        {
                System.Console.WriteLine($"{name} Закончили выдержку!");
        }
        public void StartStage(object? obj)
        {
                var i = obj as Win;
                simaphore.WaitOne();
                win1();
                Thread.Sleep(5000);
                win2();
                Thread.Sleep(5000);
                win3();
                Thread.Sleep(5000);
                win4();
                Thread.Sleep(5000);
                win5();
                Thread.Sleep(5000);
                simaphore.Release();
        }
        public void CompleteStage(object? obj)
        {
                var i = obj as Win0;
                simaphore.WaitOne();
                win1();
                Thread.Sleep(5000);
                win2();
                Thread.Sleep(5000);
                win3();
                Thread.Sleep(5000);
                win4();
                Thread.Sleep(5000);
                win5();
                Thread.Sleep(5000);
                simaphore.Release();
        }
}
