using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Demo
{
    class Student
    {
        public Student(int id, String name, String branch)
        {
            Id = id;
            Name = name;
            Branch = branch;
        }
        public int Id
        {
            get;
            set;
        }
        public String Name
        {
            get;
            set;
        }
        public String Branch
        {
            get;
            set;
        }
        public static void JoinOperations(List<Student> std, List<Hostel> hst)
        {
            var innerjoin = from s in std
                            join h in hst
                            on s.Id equals h.Id
                            select new
                            {
                                Name = s.Name,
                                Id = s.Id,
                                Roomno = h.Roomno,
                                Branch = s.Branch

                            };
            foreach (var i in innerjoin)
            {
                Console.WriteLine(i);
            }
        }

        public static void LeftOuterJoin(List<Student> l1, List<Hostel> l2)
        {
            var leftouterjoin = from c in l1
                                join h in l2
                                on c.Id equals h.Id into stdDetails
                                from sd in stdDetails.DefaultIfEmpty()
                                select new
                                {
                                    Name = c.Name,
                                    Hostel = sd == null ? 0 :sd.Id

                                };
            foreach(var i in leftouterjoin)
            {
                Console.WriteLine(i);
            }

        }

        public static void CrossJoin(List<Student> l1, List<Hostel> l2)
        {
            var crossjoin = from c in l1
                            from h in l2
                            select new
                            {
                                CName = c.Name,
                                HName = h.Name
                            };
            foreach (var i in crossjoin)
            {
                Console.WriteLine(i);
            }
        }

        public static void GroupJoin(List<Student> l1, List<Hostel> l2)
        {
            var groupjoin = from c in l1
                            join h in l2
                            on c.Id equals h.Id into stdDetails
                            select new
                            {
                                BranchName = c.Branch,
                                rno = from p in stdDetails
                                              orderby p.Roomno
                                              select p.Id
                                    

                                };
            foreach (var i in groupjoin)
            {
                Console.WriteLine(i.BranchName);
                foreach(var j in i.rno)
                {
                    Console.WriteLine("\t" + j);
                }
            }

        }
    }









        class Hostel
        {
            public Hostel(int id, String name, int roomno)
            {
                Id = id;
                Name = name;
                Roomno = roomno;
            }
            public int Id
            {
                get;
                set;
            }
            public String Name
            {
                get;
                set;
            }
            public int Roomno
            {
                get;
                set;
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                int[] marks = { 29, 37, 12, 54, 98, 45, 76, 87, 26, 96 };
                var top3 = marks.OrderByDescending(x => x).Take(3);
                Console.WriteLine("Take Top 3:");
                foreach (var i in top3)
                {
                    Console.WriteLine(i);
                }
                string[] names = { "Kumar", "Kiran", "Kisan", "Vamshi", "RamNagesh", "Arjun" };
                var result = names.TakeWhile(x => x.StartsWith("K"));
                Console.WriteLine("Start With K:");
                foreach (var i in result)
                {
                    Console.WriteLine(i);
                }
                var skip = marks.OrderByDescending(x => x).Skip(5);
                Console.WriteLine("Skip Top 5:");
                foreach (var i in skip)
                {
                    Console.WriteLine(i);
                }
                var skipwhile = marks.SkipWhile(x => x > 50);
                Console.WriteLine("Skip While Above 50:");
                foreach (var i in skipwhile)
                {
                    Console.WriteLine(i);
                }
                var listnames = names.ToList();
                Console.WriteLine("To List:");
                foreach (var i in listnames)
                {
                    Console.WriteLine(i);
                }
                List<Student> L1 = new List<Student>();
                L1.Add(new Student(101, "Malli", "ECE"));
                L1.Add(new Student(102, "Arjun", "CSE"));
                L1.Add(new Student(103, "Kumar", "ECE"));
                L1.Add(new Student(104, "Vamshi", "EEE"));
                L1.Add(new Student(105, "Bharat", "CSE"));
                L1.Add(new Student(106, "Kiran", "EEE"));
                L1.Add(new Student(107, "Shiva", "Mech"));

                var groupby = L1.GroupBy(x => x.Branch);
                Console.WriteLine("Group By:");
                foreach (var i in groupby)
                {
                    Console.WriteLine(i.Key);
                    foreach (var j in i)
                    {
                        Console.WriteLine("\t" + j.Id + " " + j.Name);

                    }
                }
                var group = from c in L1
                            group c by c.Branch;
                List<Hostel> L2 = new List<Hostel>();
                L2.Add(new Hostel(101, "Malli", 106));
                L2.Add(new Hostel(102, "Arjun", 505));
                L2.Add(new Hostel(103, "Kumar", 203));
                L2.Add(new Hostel(104, "Vamshi", 304));
                L2.Add(new Hostel(105, "Bharat", 402));
                L2.Add(new Hostel(106, "Kiran", 602));
                Console.WriteLine("Inner Join:");
                Student.JoinOperations(L1, L2);
                Console.WriteLine("LeftOurt Join:");
                Student.LeftOuterJoin(L1, L2);
            Console.WriteLine("Cross Join:");
            Student.CrossJoin(L1, L2);
            Console.WriteLine("Group Join:");
            Student.GroupJoin(L1, L2);



        }
        }
    
}
