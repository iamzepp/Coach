using CoachWriter.Model.MainObjects;
using System;
using System.Collections.Generic;
using System.IO;

namespace CoachWriter.Model.ServiceObjects
{
    public static class ServiceCollectionCreater
    {
        public static CoachFile Create()
        {
            CoachFile f = new CoachFile();

            List<string> Subjects = ReadFile("Subjects.txt");
            List<string> Places = ReadFile("Places.txt");
            List<string> Effects = ReadFile("Effects.txt");
            List<string> Values = ReadFile("Values.txt");
            List<string> Units = ReadFile("Units.txt");

            Check(Subjects);
            Check(Places);
            Check(Effects);
            Check(Values);
            Check(Units);

            if (Subjects.Count != Places.Count ||
                Subjects.Count != Effects.Count ||
                Subjects.Count != Values.Count ||
                Subjects.Count != Units.Count)
            {
                throw new Exception();
            }

            for (int i = 0; i < Subjects.Count; i++)
            {
                Instruction instruct = new Instruction()
                {
                    Id = (i + 1).ToString(),
                    Subject = Subjects[i],
                    Place = Places[i],
                    Effect = Effects[i] + " ",
                    Value = Values[i],
                    Unit = Units[i],
                    Instr = "*****instr" + i.ToString(),
                    Group = "*****group" + i.ToString(),
                    Clast = "*****clast" + i.ToString()
                };

                if (instruct.Effect == "задать уставку ")
                {
                    instruct.Unit = " " + Units[i];
                }

                if (instruct.Effect == "нажать кнопку ")
                {
                    instruct.Value = " ";
                    instruct.Unit = " ";
                }

                f.Instructions.Add(instruct);
            }

            return f;
        }

        public static List<string> ReadFile(string name)
        {
            List<string> readf = new List<string>();

            using (StreamReader stream = new StreamReader(name))
            {
                while (!stream.EndOfStream)
                {
                    readf.Add(stream.ReadLine());
                }
            }

            return readf;
        }

        public static void Check(List<string> list)
        {
            for(int i =0; i<list.Count;i++)
            {
                while (true)
                {
                    if (list[i].StartsWith(" "))
                    {
                        string s = list[i].Remove(0, 1);
                        list[i] = s;
                    }
                    else
                    {
                        break;
                    }
                }

                while (true)
                {
                    if (list[i].EndsWith(" "))
                    {
                        string s = list[i].Remove((list[i].Length - 1), 1);
                        list[i] = s;
                    }
                    else
                    {
                        break;
                    }
                }

            }
        }

    }
}
