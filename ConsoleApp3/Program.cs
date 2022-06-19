using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {








            Santa santa = Santa.Instance;
            santa.SantaComand();
        }
    }
    internal interface Interface1
    {
    }
}
public class Santa
{
    private static Santa instance = new Santa();
    private Santa() { }

    public static Santa Instance
    {
        get { return instance; }
    }

    public void SantaComand()
    {
        MagicBoard BoardView = new MagicBoard();

        BoardDisplay agency1 = new BoardDisplay("Magic Board: Island Toys");
        BoardView.Attach(agency1);

        BoardView.ToyName = "69";

        Console.ReadLine();

    }

    interface ISubject
    {
        void Attach(IObserver observer);
        void Notify();
    }

    class MagicBoard : ISubject
    {
        private List<IObserver> _observers;

        public String ToyName
        {
            get { return _toy; }
            set
            {
                _toy = value;
                Notify();
            }



        }
        private String _toy;

        public MagicBoard()
        {
            _observers = new List<IObserver>();
        }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Notify()
        {
            _observers.ForEach(o =>
            {
                o.Update(this);
            });
        }
    }

    interface IObserver
    {
        void Update(ISubject subject);
    }

    class BoardDisplay : IObserver
    {
        public String DisplayValue { get; set; }
        public BoardDisplay(String name)
        {
            DisplayValue = name;
        }

        public void Update(ISubject subject)
        {
            if (subject is MagicBoard BoardDisplay)
            {
                Console.WriteLine(String.Format("{0} = Produced toys today {1}  ", DisplayValue, BoardDisplay.ToyName));
                Console.WriteLine();

            }
        }
    }

}