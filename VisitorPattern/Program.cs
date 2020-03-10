using System;
using System.Collections.Generic;

namespace VisitorPattern
{
    //抽象元素类
    interface IEmployee
    {
        void Accept(Department department);
    }

    //具体元素类
    class FullTimeEmployee : IEmployee
    {
        public string Name { get; set; }
        public double WeeklyWage { get; set; }
        public int WorkTime { get; set; }

        public FullTimeEmployee(string name, double weeklyWage, int workTime)
        {
            this.Name = name;
            this.WeeklyWage = weeklyWage;
            this.WorkTime = workTime;
        }

        public void Accept(Department department)
        {
            department.Visit(this);
        }
    }

    //具体元素类
    class PartTimeEmployee : IEmployee
    {
        public string Name { get; set; }
        public double HourWage { get; set; }
        public int WorkTime { get; set; }

        public PartTimeEmployee(string name, double hourWage, int workTime)
        {
            this.Name = name;
            this.HourWage = hourWage;
            this.WorkTime = workTime;
        }

        public void Accept(Department department)
        {
            department.Visit(this);
        }
    }

    //对象结构类
    class EmployeeList
    {
        private IList<IEmployee> employees = new List<IEmployee>();

        public void Add(IEmployee employee)
        {
            this.employees.Add(employee);
        }

        public void Accept(Department department)
        {
            foreach (var item in employees)
            {
                item.Accept(department);
            }
        }
    }

    //抽象访问者类
    abstract class Department
    {
        public abstract void Visit(FullTimeEmployee employee);
        public abstract void Visit(PartTimeEmployee employee);
    }

    //具体访问者类
    class FinanceDepartment : Department
    {
        public override void Visit(FullTimeEmployee employee)
        {
            int workTime = employee.WorkTime;
            double weekWage = employee.WeeklyWage;
            if (workTime > 40)
            {
                weekWage = weekWage + (workTime - 40) * 50;
            }
            else if (workTime < 40)
            {
                weekWage = weekWage - (40 - workTime) * 80;
                weekWage = Math.Max(weekWage, 0);
            }
            Console.WriteLine($"正式员工 {employee.Name} 实际工资为：{weekWage} 元");
        }

        public override void Visit(PartTimeEmployee employee)
        {
            Console.WriteLine($"临时员工 {employee.Name} 实际工资为：{employee.WorkTime * employee.HourWage} 元");
        }
    }

    //具体访问者类
    class HRDepartment : Department
    {
        public override void Visit(FullTimeEmployee employee)
        {
            int workTime = employee.WorkTime;
            Console.WriteLine($"正式员工 {employee.Name} 实际工作时间为：{workTime} 小时");
            if(workTime > 40){
                Console.WriteLine($"正式员工 {employee.Name} 加班时间为：{workTime - 40} 小时");
            }else if(workTime < 40){
                Console.WriteLine($"正式员工 {employee.Name} 请假时间为：{40 - workTime} 小时");
            }
        }

        public override void Visit(PartTimeEmployee employee)
        {
            Console.WriteLine($"临时员工 {employee.Name} 实际工作时间为：{employee.WorkTime} 小时");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EmployeeList employees = new EmployeeList();
            employees.Add(new FullTimeEmployee("梁思成", 3200.00, 45));
            employees.Add(new FullTimeEmployee("徐志摩", 2000, 40));
            employees.Add(new FullTimeEmployee("梁徽因", 2400, 38));
            employees.Add(new PartTimeEmployee("方鸿渐", 80, 20));
            employees.Add(new PartTimeEmployee("唐宛如", 60, 18));
            Console.WriteLine("HR部门访问员工信息");
            Department hr = new HRDepartment();
            employees.Accept(hr);
            Console.WriteLine("Finance部门访问员工信息");
            Department finance = new FinanceDepartment();
            employees.Accept(finance);
        }
    }
}
