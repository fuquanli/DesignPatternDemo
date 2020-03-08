using System;
using System.Collections.Generic;

namespace MementoPattern
{
    //发起人角色
    class Chessman{
        public string Lable {get;set;}
        public int X {get;set;}
        public int Y {get;set;}

        public Chessman(string lable, int x, int y){
            this.Lable = lable;
            this.X = x;
            this.Y = y;
        }

        //保存状态
        public ChessmanMemento Save(){
            return new ChessmanMemento(this.Lable, this.X, this.Y);
        }

        //恢复状态
        public void Restore(ChessmanMemento memento){
            this.Lable = memento.Lable;
            this.X = memento.X;
            this.Y = memento.Y;
        }

        public void Show() {
            Console.WriteLine($"棋子<{Lable}>：当前位置为:<{X},{Y}>");
        }
            
    }

    //备忘录角色
    class ChessmanMemento{
        public string Lable { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public ChessmanMemento(string lable, int x, int y){
            Lable = lable;
            X = x;
            Y = y;
        }
    }

    //负责人角色
    class MementoCaretaker{
        private List<ChessmanMemento> mementos = new List<ChessmanMemento>();
        public ChessmanMemento GetMemento(int index) => mementos[index];

        public void AddMemento(ChessmanMemento memento){
            mementos.Add(memento);
        }
    }

    class Program
    {
        private static int index = -1;
        private static MementoCaretaker mementoCaretaker = new MementoCaretaker();

        static void Main(string[] args)
        {
            Chessman chess = new Chessman("車", 1, 1);
            Play(chess);
            chess.X = 4;
            Play(chess);
            chess.Y = 5;
            Play(chess);
            Undo(chess);
            Undo(chess);
            Redo(chess);
            Redo(chess);
        }

        //下棋，同时保存备忘录
        static void Play(Chessman chessman){
            mementoCaretaker.AddMemento(chessman.Save());
            index++;
            chessman.Show();
        }

        //悔棋，撤销到上一个备忘录
        static void Undo(Chessman chessman){
            Console.WriteLine("******悔棋******");
            index--;
            chessman.Restore(mementoCaretaker.GetMemento(index));
            chessman.Show();
        }

        //撤销悔棋，恢复到下一个备忘录
        static void Redo(Chessman chessman){
            Console.WriteLine("******撤销悔棋******");
            index++;
            chessman.Restore(mementoCaretaker.GetMemento(index));
            chessman.Show();
        }
    }
}
