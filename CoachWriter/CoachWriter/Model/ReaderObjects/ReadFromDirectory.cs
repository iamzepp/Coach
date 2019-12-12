using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CoachWriter.Model.MainObjects;

namespace CoachWriter.Model.ReaderObjects
{
    public class ReadFromDirectory : IReader
    {
        public CoachFile Read()
        {
            CoachFile file = new CoachFile();

            using (StreamReader stream = new StreamReader("1.exp"))
            {
                while (!stream.EndOfStream)
                {
                    Instruction instruct = new Instruction()
                    {
                        Id = stream.ReadLine(),
                        Subject =stream.ReadLine(),
                        Place = stream.ReadLine(),
                        Effect = stream.ReadLine(),
                        Value = stream.ReadLine(),
                        Unit = stream.ReadLine(),
                        Instr = stream.ReadLine(),
                        Group = stream.ReadLine(),
                        Clast = stream.ReadLine()
                    };

                    file.Instructions.Add(instruct);
                }
            }

            return file;

        }
    }
}
