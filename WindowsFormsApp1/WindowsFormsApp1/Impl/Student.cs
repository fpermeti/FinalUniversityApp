using System;
using System.Collections.Generic;

namespace WindowsFormsApp1.Impl {
    public class Student {
        public Guid id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string Registration_Number { get; set; }
        public int _Age { get; set; }
        public List<CoursesCategoryEnum> CAN_LEARN { get; set; }
    }

}

