using CoachWriter.Model.MainObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachWriter.Model.ServiceObjects
{
    public static class ServiceCollectionCreater
    {
        public static CoachFile Create()
        {
            CoachFile f = new CoachFile();

            List<string> Ids = ReadFile("Ids.txt");
            List<string> Subjects = ReadFile("Subjects.txt");
            List<string> Places = ReadFile("Places.txt");
            List<string> Effects = ReadFile("Effects.txt");
            List<string> Values = ReadFile("Values.txt");
            List<string> Units = ReadFile("Units.txt");



            for (int i = 0; i < Ids.Count; i++)
            {
                Instruction instruct = new Instruction()
                {
                    Id = Ids[i],
                    Subject = Subjects[i],
                    Place = Places[i],
                    Effect = Effects[i] + " ",
                    Value = Values[i],
                    Unit = Units[i],
                    Instr = "*****instr" + (Convert.ToInt32(Ids[i]) - 1).ToString(),
                    Group = "*****group" + (Convert.ToInt32(Ids[i]) - 1).ToString(),
                    Clast = "*****clast" + (Convert.ToInt32(Ids[i]) - 1).ToString()
                };

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
    }
}
