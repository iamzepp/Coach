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
        public CoachFile Read(string FileName)
        {
            CoachFile file = new CoachFile();

            using (StreamReader stream = new StreamReader(FileName))
            {
                List<string> buffer = new List<string>();

                while (!stream.EndOfStream)
                {
                    Instruction instruct = new Instruction();


                    switch(buffer.Count)
                    {
                        case 0:
                            instruct.Id = stream.ReadLine();
                            instruct.Subject = stream.ReadLine();
                            instruct.Place = stream.ReadLine();
                            instruct.Effect = stream.ReadLine();
                            instruct.Value = stream.ReadLine();
                            instruct.Unit = stream.ReadLine();
                            instruct.Instr = stream.ReadLine();
                            break;

                        case 1:
                            instruct.Id = buffer[0];
                            instruct.Subject = stream.ReadLine();
                            instruct.Place = stream.ReadLine();
                            instruct.Effect = stream.ReadLine();
                            instruct.Value = stream.ReadLine();
                            instruct.Unit = stream.ReadLine();
                            instruct.Instr = stream.ReadLine();
                            break;

                        case 2:
                            instruct.Id = buffer[0];
                            instruct.Subject = buffer[1];
                            instruct.Place = stream.ReadLine();
                            instruct.Effect = stream.ReadLine();
                            instruct.Value = stream.ReadLine();
                            instruct.Unit = stream.ReadLine();
                            instruct.Instr = stream.ReadLine();
                            break;
                    }

                    buffer.Clear();

                    string g = stream.ReadLine();
                    if(g == null)
                    {
                        break;
                    }

                    if (g.Contains("group"))
                    {
                        instruct.Group = g;
                    }
                    else
                    {
                        instruct.Group = "NULL";
                        buffer.Add(g);
                    }

                    string c = stream.ReadLine();
                    if (c == null)
                    {
                        break;
                    }

                    if (c.Contains("clast"))
                    {
                        instruct.Clast = c;
                    }
                    else
                    {
                        instruct.Clast = "NULL";
                        buffer.Add(c);
                    }

                    file.Instructions.Add(instruct);
                }
            }

            return file;

        }
    }
}
