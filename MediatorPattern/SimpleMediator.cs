using System;
using System.Collections.Generic;
using System.Linq;

namespace MediatorPattern.SimpleMediator
{
    class EstateMedium
    {
        private static EstateMedium s_estateMedium;
        private EstateMedium()
        {
        }
        public static EstateMedium GetEstateMedium()
        {
            if (s_estateMedium == null)
            {
                s_estateMedium = new EstateMedium();
            }
            return s_estateMedium;
        }
        private List<Customer> m_members = new List<Customer>();
        public void Register(Customer member)
        {
            if (!m_members.Contains(member))
            {
                m_members.Add(member);
            }
        }
        public void Relay(string from, string message)
        {
            var member = m_members.FirstOrDefault(item => item.Name == from);
            if (member != null)
            {
                member.Receive(message);
            }
        }
    }

    abstract class Customer
    {
        protected EstateMedium m_medium;
        public string Name { get; set; }
        public Customer(string name)
        {
            this.Name = name;
            m_medium = EstateMedium.GetEstateMedium();
        }

        public abstract void Send(string to, string message);
        public abstract void Receive(string message);
    }

    class Seller : Customer
    {
        public Seller(string name) : base(name)
        {
        }
        public override void Send(string to, string message)
        {
            Console.WriteLine($"Seller-{Name}向{to}发送消息");
            m_medium.Relay(to, message);
        }
        public override void Receive(string message)
        {
            Console.WriteLine($"Seller-{Name}接收到消息：{message}");
        }
    }
    class Buyer : Customer
    {
        public Buyer(string name) : base(name)
        {
        }
        public override void Send(string to, string message)
        {
            Console.WriteLine($"Buyer-{Name}向{to}发送消息");
            m_medium.Relay(to, message);
        }
        public override void Receive(string message)
        {
            Console.WriteLine($"Buyer-{Name}接收到消息：{message}");
        }
    }

    class Manager : Customer
    {
        public Manager(string name) : base(name)
        {
        }
        public override void Send(string to, string message)
        {
            Console.WriteLine($"Manager-{Name}向{to}发送消息");
            m_medium.Relay(to, message);
        }
        public override void Receive(string message)
        {
            Console.WriteLine($"Manager-{Name}接收到消息：{message}");
        }
    }
}