﻿using System;

namespace WindowsFormsApp1.Impl {

    public class Schedule :Entity{


        public Student Student { get; set; }

        public Professor Professor { get; set; }

        public Course Course { get; set; }

        public DateTime Calendar { get; set; }


    }

}

