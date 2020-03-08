using System;

namespace NullObjectPattern
{
    interface Book{
        bool IsNull();
        void Show();
    }

    class NullBook : Book{
        public bool IsNull() => true;
        public void Show(){
            Console.WriteLine($"未找到符合的书籍");
        }
    }

    class RealBook : Book{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public RealBook(int id, string name, string author){
            this.Id = id;
            this.Name = name;
            this.Author = author;
        }
        public void Show(){
            Console.WriteLine($"Id:{Id}, Name:{Name}, Author:{Author}");
        }
        public bool IsNull() => false;
    }

    class BookFactory{
        public static Book GetBook(int id){
            switch(id){
                case 1:
                    return new RealBook(id, "人类简史", "尤瓦尔赫拉利");
                case 2:
                    return new RealBook(id, "Head First设计模式", "Freeman");
                default:
                    return new NullBook();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Book book1 = BookFactory.GetBook(1);
            book1.Show();
            Book book2 = BookFactory.GetBook(2);
            book2.Show();
            Book book3 = BookFactory.GetBook(3);
            book3.Show();
        }
    }
}
