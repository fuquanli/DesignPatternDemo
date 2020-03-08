using System;

namespace MementoPattern
{
    class PrototypeMemento
    {
        public static void main(String[] args)
        {
            OriginatorPrototype or = new OriginatorPrototype();
            PrototypeCaretaker cr = new PrototypeCaretaker();
            or.SetState("S0");
            Console.WriteLine("初始状态:" + or.GetState());
            cr.SetMemento(or.CreateMemento()); //保存状态      
            or.SetState("S1");
            Console.WriteLine("新的状态:" + or.GetState());
            or.RestoreMemento(cr.GetMemento()); //恢复状态
            Console.WriteLine("恢复状态:" + or.GetState());
        }
    }
    //发起人原型
    public class OriginatorPrototype : ICloneable
    {
        private String state;
        public void SetState(String state)
        {
            this.state = state;
        }
        public String GetState()
        {
            return state;
        }
        public OriginatorPrototype CreateMemento()
        {
            return this.Clone() as OriginatorPrototype;
        }
        public void RestoreMemento(OriginatorPrototype opt)
        {
            this.SetState(opt.GetState());
        }
        public object Clone()
        {
            var value = new OriginatorPrototype();
            value.state = state;
            return value;
        }
    }
    //原型管理者
    class PrototypeCaretaker
    {
        private OriginatorPrototype opt;
        public void SetMemento(OriginatorPrototype opt)
        {
            this.opt = opt;
        }
        public OriginatorPrototype GetMemento()
        {
            return opt;
        }
    }
}