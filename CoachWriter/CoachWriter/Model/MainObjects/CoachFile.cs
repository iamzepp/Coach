using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachWriter.Model.MainObjects
{
    public class CoachFile
    {
        public int Id { get; set; }

        public ObservableCollection<Instruction> Instructions { get; set; }

        public CoachFile()
        {
            Instructions = new ObservableCollection<Instruction>();
        }

    }
}
