using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book()
            {
                Title = "Das Kapital",
                Author = "Karl Marks",
                Isbn = "1234564798"
            };

            book.ShowBook();

            CareTaker histroy = new CareTaker();  
            histroy.Memento = book.CreateUndo(); // ilk girilen bilgilerin yedeklerini alıyoruz. 

            // kitapta değişiklikler yapıyoruz. 
            book.Title = "DAS_KAPİTAL";
            book.Author = "KARL_MARKS";

            book.ShowBook();

            // değişiklikleri geri alıyoruz. 
            book.RestoreFormUndo(histroy.Memento);

            book.ShowBook();

            Console.ReadLine();
        }
    }

    class Book
    {
        private string _title;
        private string _author;
        private string _isbn;
        private DateTime _lastEdited;

        public string Title 
        { 
            get { return _title; }
            set 
            { 
                _title = value;
                SetLastEdited(); // herhangi bir değer değiştiğinde last edited güncellenmiş olacak. 
            }
        }
        public string Author
        {
            get { return _author; }
            set 
            { 
                _author = value;
                SetLastEdited();

            }
        }
        public string Isbn
        {
            get { return _isbn; }
            set 
            { 
                _isbn = value;
                SetLastEdited();
            }
        }

        private void SetLastEdited()
        {
            _lastEdited = DateTime.UtcNow;
        }

        public Memento CreateUndo() // eski halini tutmaya yarar 
        {
            return new Memento(_title,_author,_isbn,_lastEdited);
        }

        public void RestoreFormUndo(Memento memento) // kullanıcının gönderdiği değerleri eski hali ile değiştireceğiz
        {
            _title=memento.Title;
            _author=memento.Author;
            _isbn=memento.Isbn;
            _lastEdited=memento.LastEdited;
        }

        public void ShowBook()
        {
            Console.WriteLine($"Başlık : {Title}, Yazar : {Author}, Isbn : {Isbn}, Son Düzenleme : {_lastEdited}");
        }
    }

    class Memento
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public DateTime LastEdited { get; set; }

        public Memento(string title, string author, string isbn, DateTime lastEdited)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            LastEdited = lastEdited;

        }

    }

    // bu desende eski hafızadaki bilgiyi tutmak için CareTaker isimli bir klas kullanılır. 
    class CareTaker 
    {
        public Memento Memento { get; set; }
    }
}
