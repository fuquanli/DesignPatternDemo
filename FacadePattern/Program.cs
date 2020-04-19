using System;

namespace FacadePattern
{
    class Curtain
    {
        public void Close()
        {
            Console.WriteLine("关闭窗帘");
        }
    }

    class Lamp
    {
        public void TurnOffTheLights()
        {
            Console.WriteLine("关闭灯光");
        }
    }

    class AirConditioner
    {
        public void Start()
        {
            Console.WriteLine("开启冷气");
        }
    }

    class Computer
    {
        public void Start()
        {
            Console.WriteLine("开启电脑");
        }
    }

    class Projector
    {
        public void Start()
        {
            Console.WriteLine("开启投影仪");
        }
    }

    class ShortcutInstruction
    {
        private Curtain m_curtain = new Curtain();
        private Lamp m_lamp = new Lamp();
        private AirConditioner m_airConditioner = new AirConditioner();
        private Computer m_computer = new Computer();
        private Projector m_projector = new Projector();
        public void SwitchMovieScene()
        {
            m_curtain.Close();
            m_lamp.TurnOffTheLights();
            m_airConditioner.Start();
            m_computer.Start();
            m_projector.Start();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("准备电影环境：");
            ShortcutInstruction shortcutInstruction = new ShortcutInstruction();
            shortcutInstruction.SwitchMovieScene();
        }
    }
}
