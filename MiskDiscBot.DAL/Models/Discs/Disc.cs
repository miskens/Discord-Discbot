using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace MiskDiscBot.DAL.Models.Discs
{
    public class Disc: Entity
    {
        public string name { get; set; }
        public string description { get; set; }
        public string discType { get; set; }
        public int speed { get; set; }
        public int glide { get; set; }
        public int turn { get; set; }
        public int fade { get; set; }
        //Beginner(easy)/Medium/Advanced(hard)
        public string level { get; set; }
        public string plasticType { get; set; }
    }
}
