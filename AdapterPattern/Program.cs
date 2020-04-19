using System;

namespace AdapterPattern
{
    interface ITarget{
        void Request();
    }

    class Adaptee{
        public void SpecificRequest(){
            Console.WriteLine("适配者中的业务代码被调用！");
        }
    }

    #region 类适配器
    class ClassAdapter : Adaptee, ITarget{
        public void Request(){
            SpecificRequest();
        }
    }
    #endregion 
    
    #region 对象适配器
    class ObjectAdapter : ITarget{
        private Adaptee m_adaptee;

        public ObjectAdapter(Adaptee adaptee){
            this.m_adaptee = adaptee;
        }

        public void Request(){
            m_adaptee.SpecificRequest();
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("类适配器模式测试:");
            ITarget classAdapter = new ClassAdapter();
            classAdapter.Request();

            Console.WriteLine("对象适配器模式测试:");
            ITarget objectAdapter = new ObjectAdapter(new Adaptee());
            objectAdapter.Request();
        }
    }
}
