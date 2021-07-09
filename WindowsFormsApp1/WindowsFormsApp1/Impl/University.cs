using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Impl {

    public class University : Entity {

        public List<Student> Students { get; set; }

        public List<Professor> Professors { get; set; }

        public List<Course> Courses { get; set; }

        public List<Schedule> Schedules { get; set; }



        public University() {
            Students = new List<Student>();
            Professors = new List<Professor>();
            Courses = new List<Course>();
            Schedules = new List<Schedule>();
        }


    }

}

