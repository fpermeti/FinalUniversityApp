using System;

namespace WindowsFormsApp1.Impl {
    public class Schedule {

        public string ID { get; set; }
        public string Student { get; set; }
        public string Professor { get; set; }
        public string Course { get; set; }
        public DateTime Calendar { get; set; }

        ~Schedule() {
                
        }
    }

}

