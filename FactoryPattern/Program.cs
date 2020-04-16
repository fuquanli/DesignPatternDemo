using System;

namespace FactoryPattern
{
    interface IFactory{
        IProduct Create();
    }

    interface IProduct{
        void Show();
    }

    class TCLTV : IProduct{
        public void Show(){
            Console.WriteLine("TCL电视");
        }
    }

    class MITV : IProduct{
        public void Show(){
            Console.WriteLine("小米电视");
        }
    }

    class TCLFactory : IFactory{
        public IProduct Create(){
            return new TCLTV();
        }
    }

    class MIFactory : IFactory{
        public IProduct Create(){
            return new MITV();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IFactory miFactory = new MIFactory();
            var miTV = miFactory.Create();
            miTV.Show();

            IFactory tclFactory = new TCLFactory();
            var tclTV = tclFactory.Create();
            tclTV.Show();
        }
    }
}
