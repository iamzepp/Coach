using CoachWriter.Model.MainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachWriter.Model.WriteObjects
{
    interface IWriter
    {
        void Write(CoachFile File, string FileName);
    }
}
