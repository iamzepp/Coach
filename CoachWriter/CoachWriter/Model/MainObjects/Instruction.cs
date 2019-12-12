using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachWriter.Model.MainObjects
{
    public class Instruction
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Place { get; set; }
        public string Effect { get; set; }
        public string Value { get; set; }
        public string Instr { get; set; }
        public string Group { get; set; }
        public string Clast { get; set; }
    }
}
