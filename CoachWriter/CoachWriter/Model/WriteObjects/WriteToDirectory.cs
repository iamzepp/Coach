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
        public void Write(CoachFile File, string FileName)
        {
            using (StreamWriter stream = new StreamWriter(FileName + ".exp", false, Encoding.UTF8))
            {
                foreach (var instruction in File.Instructions)
                {
                    stream.WriteLine(instruction.Id);
                    stream.WriteLine(instruction.Subject);
                    stream.WriteLine(instruction.Place);
                    stream.WriteLine(instruction.Effect);
                    stream.WriteLine(instruction.Value);
                    stream.WriteLine(instruction.Unit);
                    stream.WriteLine(instruction.Instr);

                    if(instruction.Group != "NULL")
                        stream.WriteLine(instruction.Group);

                    if (instruction.Clast != "NULL")
                        stream.WriteLine(instruction.Clast);
                }
            }
        }
    }
}
