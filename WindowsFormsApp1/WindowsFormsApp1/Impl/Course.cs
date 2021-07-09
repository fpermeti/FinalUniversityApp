using System;

namespace WindowsFormsApp1.Impl {
    public class Course : Entity {

        public string Code { get; set; }

        public string Subject { get; set; }

        public int Hours { get; set; }

        public CourseCategory Category { get; set; }

    }

}

