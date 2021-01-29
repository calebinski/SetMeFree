using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetMeFree.Models
{
    public class GuessWhoAnswer
    {
        public int ID { get; set; }

        public int PictureID { get; set; }
        public int Rating { get; set; }
        public string DateTimeAnswered { get; set; }
    }
}
