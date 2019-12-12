using CoachWriter.Model.MainObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachWriter.Model.WriteObjects
{
    public class WriteToDirectory : IWriter
    {
        public void Write(CoachFile File)
        {
            using (StreamWriter stream = new StreamWriter("Новый.exp",false, Encoding.UTF8))
            {
                foreach(var instruction in File.Instructions)
                {
                    stream.WriteLine(instruction.Id);
                    stream.WriteLine(instruction.Subject);
                    stream.WriteLine(instruction.Place);
                    stream.WriteLine(instruction.Effect);
                    stream.WriteLine(instruction.Value);
                    stream.WriteLine(instruction.Unit);
                    stream.WriteLine(instruction.Instr);
                    stream.WriteLine(instruction.Group);
                    stream.WriteLine(instruction.Clast);
                }
            }
        }
    }
}
