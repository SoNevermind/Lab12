using System;
using System.Collections.Generic;

namespace Lab12_class
{
    public class Person
    {
        private string name { get; set; }
        private string surname { get; set; }
        private DateTime birthday { get; set; }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }

        public int birthdayYear
        {
            get => this.birthday.Year;
            set => this.birthday = new DateTime(value, this.birthday.Month, this.birthday.Day);
        }

        public Person(string name, string surname, DateTime birthday)
        {
            this.name = name;
            this.surname = surname;
            this.birthday = birthday;
        }

        public Person()
        {
            this.name = "Random";
            this.name = "Faggot";
            this.birthday = new DateTime(1996, 6, 6);
        }

        public override string ToString()
        {
            return string.Format(name + " " + surname + " date of birth: " + birthday);
        }

        public virtual string ToShortString()
        {
            return "\n" + "Name: " + name + "\n" + "Surname: " + surname;
        }
    }

    public enum Education
    {
        Specialist,
        Bacheilor,
        SecondEducation
    }

    public class Exam
    {
        public string subject { get; set; }
        public int mark { get; set; }
        public DateTime examDate { get; set; }

        public int Rating { get; internal set; }

        public Exam(string subject, int mark, DateTime examDate)
        {
            this.subject = subject;
            this.mark = mark;
            this.examDate = examDate;
        }

        public Exam()
        {
            this.examDate = new DateTime(2007, 1, 7);
        }

        public override string ToString()
        {
            return string.Format(subject + " date of exam: " + examDate + " " + mark);
        }
    }

    public class Student
    {
        private Person person;
        private Education education;
        private int groupNumber;
        private List<Exam> exams = new List<Exam>();

        public Student(Person person, Education education, int group)
        {
            this.person = person;
            this.education = education;
            this.groupNumber = group;
        }

        public Student()
        {
            this.person = new Person();
            this.education = Education.Bacheilor;
            this.groupNumber = 1337;
        }

        public Person Person
        {
            get { return person; }
            set { person = value; }
        }

        public Education Education
        {
            get { return education; }
            set { education = value; }
        }

        public int GroupNumber
        {
            get { return groupNumber; }
            set { groupNumber = value; }
        }

        public Exam[] Exams
        {
            get { return exams.ToArray(); }
        }

        public double averageRaiting
        {
            get
            {
                int sum = 0;
                for(int i = 0; i < exams.Count; i++)
                {
                    sum += exams[i].Rating;
                }

                if(exams.Count != 0)
                {
                    return sum / exams.Count;
                } else
                {
                    return 0;
                }
            }
        }

        public bool this[Education index]
        {
            get
            {
                if(this.Education == index)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public void AddExams(params Exam[] exams)
        {
            this.exams.AddRange(exams);
        }

        public override string ToString()
        {
            return string.Format(person + " " + education + " " + groupNumber + " " + string.Join(", ", exams));
        }

        public string ToShortString()
        {
            return string.Format(person + " " + education + " " + groupNumber + " Average raiting: " + averageRaiting);
        }
    }
}