using System;

namespace AbstractFactoryPattern
{
    interface ITV{
        void Show();
    }

    class TCLTV : ITV{
        public void Show(){
            Console.WriteLine("TCL电视");
        }
    }

    class MITV : ITV{
        public void Show(){
            Console.WriteLine("小米电视");
        }
    }

    interface IAirConditioner{
        void Show();
    }

    class TCLAirConditioner : IAirConditioner{
        public void Show(){
            Console.WriteLine("TCL空调");
        }   
    }

    class MIAirConditioner : IAirConditioner{
        public void Show(){
            Console.WriteLine("小米空调");
        }   
    }

    abstract class AbstractFactory{
        public abstract ITV CreateTV();
        public abstract IAirConditioner CreateAirConditioner();
    }

    class TCLFactory : AbstractFactory{
        public override ITV CreateTV(){
            return new TCLTV();
        }
        public override IAirConditioner CreateAirConditioner(){
            return new TCLAirConditioner();
        }
    }

    class MIFactory : AbstractFactory{
        public override ITV CreateTV(){
            return new MITV();
        }
        public override IAirConditioner CreateAirConditioner(){
            return new MIAirConditioner();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            AbstractFactory miFactory = new MIFactory();
            var miTV = miFactory.CreateTV();
            miTV.Show();
            var miAC = miFactory.CreateAirConditioner();
            miAC.Show();

            AbstractFactory tclFactory = new TCLFactory();
            var tclTV = tclFactory.CreateTV();
            tclTV.Show();
            var tclAC = tclFactory.CreateAirConditioner();
            tclAC.Show();
        }
    }
}
