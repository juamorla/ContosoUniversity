using System;

namespace ContosoUniversity.Models
{
    public class Instructor
    {

        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime Hiredate { get; set; }
        public OfficeAssignment OfficeAssignment { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", LastName, FirstMidName);

            }
        }
    }
}