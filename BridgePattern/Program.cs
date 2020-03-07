using System;

namespace BridgePattern
{
    //抽象类
    public abstract class Pen{
        protected Color m_color;
        public void SetColor(Color color){
            this.m_color = color;
        }
        public abstract void Draw(string name);
    }

    //扩充抽象类
    public class SmallPen : Pen{
        public override void Draw(string name){
            string penType = "小号毛笔绘制";
            this.m_color.Bepaint(penType, name);
        }
    }

    //扩充抽象类
    public class MiddlePen : Pen{
        public override void Draw(string name){
            string penType = "中号毛笔绘制";
            this.m_color.Bepaint(penType, name);
        }
    }

    //扩充抽象类
    public class BigPen : Pen{
        public override void Draw(string name){
            string penType = "大号毛笔绘制";
            this.m_color.Bepaint(penType, name);
        }
    }

    //实现类接口
    public interface Color{
        void Bepaint(string penType, string name);
    }

    //扩充实现类
    public class Red : Color{
        public void Bepaint(string penType, string name){
            Console.WriteLine($"{penType}红色的{name}");
        }
    }

    //扩充实现类
    public class Green : Color{
        public void Bepaint(string penType, string name){
            Console.WriteLine($"{penType}绿色的{name}");
        }
    }

    //扩充实现类
    public class Blue : Color{
        public void Bepaint(string penType, string name){
            Console.WriteLine($"{penType}蓝色的{name}");
        }
    }

    //扩充实现类
    public class White : Color{
        public void Bepaint(string penType, string name){
            Console.WriteLine($"{penType}白色的{name}");
        }
    }

    //扩充实现类
    public class Black : Color{
        public void Bepaint(string penType, string name){
            Console.WriteLine($"{penType}黑色的{name}");
        }
    }

    class Program{
        static void Main(string[] args)
        {
            Color blackColor = new Black();
            Pen bigPen = new BigPen();
            bigPen.SetColor(blackColor);
            bigPen.Draw("图形");

            Color redColor = new Red();
            Pen middlePen = new MiddlePen();
            middlePen.SetColor(redColor);
            middlePen.Draw("图形");
        }
    }
}
