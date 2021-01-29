using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SetMeFree.Models
{
    public class MythFactAnswer
    {
        public int ID { get; set; }
        public string DateTimeAnswered { get; set; }
        public int QuestionID { get; set; }
        public string Answer { get; set; }
    }
}
