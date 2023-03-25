using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    // arabulucu desenidir. 
    // farklı sistemleri birbirleri ile görüştürmeye çalışır. 
    internal class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();
            Teacher teacher = new Teacher(mediator);
            teacher.Name = "İsmail";

            mediator.Teacher = teacher;

            Student student = new Student(mediator);
            student.Name = "Aylin";


            Student student2 = new Student(mediator);
            student2.Name = "Aysun";
            mediator.Students = new List<Student>{ student, student2};

            teacher.SentNewImageUrl("slide1.jpg");  // öğretmen öğrencilere slide gönderebilir. 
            teacher.ReceiveQuestion("is it True?", student); // öğretmen öğrenciden soru alabilir. 

            Console.ReadLine();

        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;  // inherit ediliği yerde bu nesneye ulaşabilmek için protected yapıyoruz. 

        public CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }

    }

    // teacher ve students bilgiyi mediator nesnesine gönderiyor. o da geri yine teacher ve student nesnesine döndürüyor. 
    class Teacher : CourseMember
    {
        public string Name { get;  set; }

        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public void ReceiveQuestion(string question, Student student)  // soru al. 
        {
            // Soru alma ile ilgili gerekli kodlar burada yazılır. Örn olması açısından; 
            Console.WriteLine($"Teacher Receive a Question {student.Name} , {question}");
        }

        public void SentNewImageUrl(string url)
        {
            Console.WriteLine($"Teacher Send Slide : {url}");
            Mediator.UpdateImage(url);  // bütün öğrencilere image göndermiş olacağız. 
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine($"Teacher answerd question {student.Name} , {answer}");
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        public string Name { get; set; }

        public  void ReceiveImage(string url)
        {
            Console.WriteLine($"{Name} Received Image : {url}"); 
        }

        public void ReceiveAnswer(string answer)
        {
            Console.WriteLine($"{Name} Received Answer : {answer}");
        }
    }

    // öğretmenin paylaştığı herhangi bir şeyi kime ne şekilde gösterecekse o görevi yapacaktır. 
    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.ReceiveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.ReceiveQuestion(question,student); // öğretmene soru ve soran öğrenci gider. 
        }

        public void SendAnswer(string answer, Student student)
        {
            student.ReceiveAnswer(answer); // öğrenciye cevap ve öğrenci gider. 
        }
    }
}
