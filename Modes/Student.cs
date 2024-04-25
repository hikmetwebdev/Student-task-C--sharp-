using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classtask.Modes
{
    public class Student
    {
        public string  Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }



        public Student()
        {
         Id=Guid.NewGuid().ToString();
        }
    }
}
