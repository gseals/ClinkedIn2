﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn2.Models
{
    public class Clinker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<LineItem> Services { get; set; } = new List<LineItem>();
        public List<string> Interests { get; set; } = new List<string>();
        public List<Clinker> Friends { get; set; } = new List<Clinker>();
        public List<Clinker> Enemies { get; set; } = new List<Clinker>();
    }

    public class LineItem
    {
        public string Service { get; set; }
    }
}
