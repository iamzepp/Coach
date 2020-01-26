using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoachWriter.Model.MainObjects;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;
using System.Diagnostics;

namespace CoachWriter.Model.ReaderObjects
{
    public class ExcelReader : IReader
    {


        public CoachFile Read(string FileName)
        {
            CoachFile file = new CoachFile();

            //Книга Excel
            XSSFWorkbook xssfwb;

            //Открываем файл
            using (FileStream f = new FileStream(FileName, FileMode.Open, FileAccess.Read))
            {
                xssfwb = new XSSFWorkbook(f);
            }

            //Получаем первый лист книги
            ISheet sheet = xssfwb.GetSheetAt(0);

            //запускаем цикл по строкам
            for (int row = 0; row < 3000; row++)
            {
                //получаем строку
                var currentRow = sheet.GetRow(row);
                Instruction instruction = new Instruction();

                if (currentRow != null) //null когда строка содержит только пустые ячейки
                {
                    //Получаем значение ячейки
                    instruction.Id = (row + 1).ToString();

                    if(currentRow.GetCell(0).CellType ==CellType.String)
                        instruction.Subject = currentRow.GetCell(0).StringCellValue.ToString();
                    else
                        instruction.Subject = currentRow.GetCell(0).NumericCellValue.ToString();

                    if (currentRow.GetCell(1).CellType == CellType.String)
                        instruction.Place = currentRow.GetCell(1).StringCellValue.ToString();
                    else
                        instruction.Place = currentRow.GetCell(1).NumericCellValue.ToString();

                    if (currentRow.GetCell(2).CellType == CellType.String)
                        instruction.Effect = currentRow.GetCell(2).StringCellValue.ToString() + " ";
                    else
                        instruction.Effect = currentRow.GetCell(2).NumericCellValue.ToString() + " ";

                    if (currentRow.GetCell(3).CellType == CellType.String)
                    {
                        string str = currentRow.GetCell(3).StringCellValue.ToString();

                        if (str.Contains("-"))
                            instruction.Value = " ";
                        else
                            instruction.Value = str;
                    }
                    else
                    {
                        string str = currentRow.GetCell(3).NumericCellValue.ToString();

                        if (str.Contains("-"))
                            instruction.Value = " ";
                        else
                            instruction.Value = str;
                    }

                    if (currentRow.GetCell(4).CellType == CellType.String)
                    {
                        string str = currentRow.GetCell(4).StringCellValue.ToString();

                        if (str.Contains("-"))
                            instruction.Unit = " ";
                        else
                            instruction.Unit = str;
                    }
                    else
                    {
                        string str = currentRow.GetCell(4).NumericCellValue.ToString();

                        if (str.Contains("-"))
                            instruction.Unit = " ";
                        else
                            instruction.Unit = str;
                    }

                    instruction.Instr = "*****instr" + row.ToString();
                    instruction.Group = "*****group" + row.ToString();
                    instruction.Clast = "*****clast" + row.ToString();

                    file.Instructions.Add(instruction);
                }
                else
                {
                    break;
                }
            }


            xssfwb.Close();

            return file;
        }
    }
}
