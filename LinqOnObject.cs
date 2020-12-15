using System;
using System.Linq;
using System.Collections.Generic;

namespace LinqTutorial
{

    class StudentInfo
    {
        public StudentInfo(int id, string name, bool isPaid, double duefee)
        {
            this.Id = id;
            this.IsPaid = isPaid;
            this.Name = name;
            this.Duefee = duefee;
        }
        public int Id
        {
            get;
        }
        public bool IsPaid
        {
            get;
            set;
        }
        public string Name
        {
            get;
        }
        public double Duefee
        {
            get;
            set;
        }
        public static IEnumerable<int> GetIds(List<StudentInfo> studentlist)
        {
            var query = studentlist.Select(c => c.Id);
            return query;
        }
        public static dynamic GetNameAndDue(List<StudentInfo> studentlist)
        {
            var query = studentlist.Select(c => new
            {
                Name = c.Name,
                Due = c.Duefee
            });
            return query;
        }
        public static dynamic Joindetails(List<StudentInfo> studentlist, List<HostelInfo> hostellist)
        {
            var query = studentlist.Join(hostellist,
                                   c => c.Id, //key for outer one
                                   ct => ct.Id,//key for inner one
                                   (c, ct) => new
                                   {
                                       cid = c.Id,
                                       hid = ct.Id,
                                       RoomNo = ct.Roomno,
                                       cName = c.Name,
                                       hName = ct.Name,
                                       clgdue = c.Duefee,
                                       hstdue = ct.Duefee,
                                   });
                                   return query;
        }
         public static double GetDueAmount(List<StudentInfo> studentlist)
        {
            var query = from c in studentlist
                        where c.IsPaid == false
                        select c.Duefee; 
            var query1 = query.Sum();
            return query1;
        }
    }

        
        class HostelInfo
        {
            public HostelInfo(int id, string name, bool isPaid, int roomno, double duefee)
            {
                this.Id = id;
                this.IsPaid = isPaid;
                this.Roomno = roomno;
                this.Name = name;
                this.Duefee = duefee;
            }
            public int Roomno
            {
                get;
            }
            public int Id
            {
                get;
            }
            public bool IsPaid
            {
                get;
                set;
            }
            public string Name
            {
                get;
            }
            public double Duefee
            {
                get;
                set;
            }
        }
    

    class Program
    {
        public static void Main(String[] args)
        {
            List<StudentInfo> L1 = new List<StudentInfo>();
            L1.Add(new StudentInfo(1, "Arjun", false, 12000));
            L1.Add(new StudentInfo(2, "Ram", true, 0));
            L1.Add(new StudentInfo(3, "Kumar", false, 62000));
            L1.Add(new StudentInfo(4, "Bharath", false, 30000));
            L1.Add(new StudentInfo(5, "Vamshi", false, 42000));
            List<HostelInfo> L2 = new List<HostelInfo>();
            L2.Add(new HostelInfo(5, "Arjun",true, 102,0));
            L2.Add(new HostelInfo(4, "Ram", false, 105,4000));
            L2.Add(new HostelInfo(3, "Kumar", false, 109,2000));
            L2.Add(new HostelInfo(2, "Bharath", false, 104,3000));
            L2.Add(new HostelInfo(1, "Vamshi", false, 103,6000));
            var ids = StudentInfo.GetIds(L1);
            Console.WriteLine("Ids:");
            foreach (var i in ids)
            {
                Console.Write(i + "\t");
            }
            var nameanddue = StudentInfo.GetNameAndDue(L1);
            Console.WriteLine("\nName And Due:");
            foreach (var i in nameanddue)
            {
                Console.WriteLine(i.Name + " " + i.Due);
            }
            var joindetails= StudentInfo.Joindetails(L1,L2);
            Console.WriteLine("Join Details");
            foreach (var i in joindetails)
            {
                Console.WriteLine(i);
            }
            var getdueamount = StudentInfo.GetDueAmount(L1);
            Console.WriteLine($"Due Amount Details-{getdueamount}");
           



        }
    }
}
