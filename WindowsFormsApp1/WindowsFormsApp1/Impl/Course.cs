using System;

namespace WindowsFormsApp1.Impl {
    public class Course :Entity {

        //public Guid Id { get; set; }

        public string Code { get; set; }

        public string Subject { get; set; }

        public int Hours { get; set; }

        //public int Category { get; set; }
        public CourseCategory Category { get; set; }


        //public Course() {
                
        //}

    }

}

