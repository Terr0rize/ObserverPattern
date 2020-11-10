using System;
using System.Collections.Generic;
using System.Threading;

namespace RefactoringGuru.DesignPatterns.Observer.Conceptual
{
    public interface IObserver
    {        
        void Update(ISubject subject);
    }

    public interface ISubject
    {
        void Add(IObserver observer);

        void Delete (IObserver observer);

        void Message();
    }

    public class Subject : ISubject
    {      
        public int Randomize { get; set; } = -0;
      
        private List<IObserver> gau = new List<IObserver>();       
        public void Add(IObserver observer)
        {
            Console.WriteLine("Вы добавили нового наблюдателя.(подписка)");
            this.gau.Add(observer);
        }

        public void Delete(IObserver observer)
        {
            this.gau.Remove(observer);
            Console.WriteLine("Вы удалили наблюдателя.(отписка)");
        }
  
        public void Message()
        {
            Console.WriteLine("\nВведите сообщение для оповещения: ");
            string kek = Console.ReadLine();
            Console.WriteLine("\nУведомление наблюдателей о: " + kek);

            foreach (var observer in gau)
            {
                observer.Update(this);
            }
        }
         
        public void SomeBusinessLogic()
        {
            Console.WriteLine("Введите приоритет показа: " + this.Randomize);
            this.Randomize = Convert.ToInt32(Console.ReadLine());

            Thread.Sleep(15);

            Console.WriteLine("Приоритет показа сообщения изменился на: " + this.Randomize);
            this.Message();
        }
    }

  
    class ConcreteObserverA : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Subject).Randomize < 5)
            {
                Console.WriteLine("ГИБДД 1: отреагировал на сообщение.");
            }
        }
    }

    class ConcreteObserverB : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Subject).Randomize < 10)
            {
                Console.WriteLine("ГИБДД 2: отреагировал на сообщение.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {         
            var subject = new Subject();
            var observerA = new ConcreteObserverA();         
            var observerB = new ConcreteObserverB();            

            do
            {
                Console.WriteLine("[1]. Добавить наблюдателя.\n[2]. Удалить наблюдателя.\n[3]. Отправить сообщение.\n[4]. Выход.");
                int i = int.Parse(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        Console.WriteLine("[1]. Добавить нового ГАИШНИКА в ГИБДД под номером 1.\n[2]. Добавить нового ГАИШНИКА в ГИБДД под номером 2.");
                        int key = Convert.ToInt32(Console.ReadLine());
                        if(key == 1)
                        {
                            subject.Add(observerA);
                        }
                        if(key ==2)
                        {
                            subject.Add(observerB);
                        }
                        break;
                    case 2:
                        Console.WriteLine("[1]. Отсоединить ГАИШНИКА в ГИБДД под номером 1.\n[2]. Отсоединить ГАИШНИКА в ГИБДД под номером 2.");
                        int keyy = Convert.ToInt32(Console.ReadLine());
                        if (keyy == 1)
                        {
                            subject.Delete(observerA);
                        }
                        if (keyy == 2)
                        {
                            subject.Delete(observerB);
                        }
                        break;
                    case 3:
                        subject.SomeBusinessLogic();
                        break;                 
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ошибка.");
                        break;
                }
            } while (true);
        }

    
    }
}
