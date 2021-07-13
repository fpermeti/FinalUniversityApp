using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Impl {

    public class Person : Entity {

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public List<Course> Courses { get; set; }
    }
}
