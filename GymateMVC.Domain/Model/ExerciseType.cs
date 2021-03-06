﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GymateMVC.Domain.Model
{
    public class ExerciseType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}
