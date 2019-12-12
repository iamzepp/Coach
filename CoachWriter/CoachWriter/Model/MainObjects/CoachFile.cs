using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachWriter.Model.MainObjects
{
    public class CoachFile
    {
        public int Id { get; set; }

        public List<Instruction> Instructions { get; set; }

        public CoachFile()
        {
            Instructions = new List<Instruction>();
        }

    }
}
