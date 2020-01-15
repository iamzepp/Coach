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

namespace CoachWriter.Model.WriteObjects
{
    public class ExcelWriter : IWriter
    {

        public void Write(CoachFile File, string FileName)
        {
            //Рабочая книга Excel
            XSSFWorkbook wb;
            //Лист в книге Excel
            XSSFSheet sh;

            //Создаем рабочую книгу
            wb = new XSSFWorkbook();
            //Создаём лист в книге
            sh = (XSSFSheet)wb.CreateSheet("Лист 1");

            //Количество заполняемых строк
            int countRow = File.Instructions.Count;

            //Запускаем цыкл по строка
            for (int i = 0; i < countRow; i++)
            {
                //Создаем строку
                var currentRow = sh.CreateRow(i);

                //в строке создаём ячеёку с указанием столбца
                currentRow.CreateCell(0).SetCellValue(File.Instructions[i].Subject.ToString());
                //в строке создаём ячеёку с указанием столбца
                currentRow.CreateCell(1).SetCellValue(File.Instructions[i].Place.ToString());
                //в строке создаём ячеёку с указанием столбца
                currentRow.CreateCell(2).SetCellValue(File.Instructions[i].Effect.ToString());
                //в строке создаём ячеёку с указанием столбца
                currentRow.CreateCell(3).SetCellValue(File.Instructions[i].Value.ToString());
                //в строке создаём ячеёку с указанием столбца
                currentRow.CreateCell(4).SetCellValue(File.Instructions[i].Unit.ToString());

                //Выравним размер столбца по содержимому
                sh.AutoSizeColumn(0);
                //Выравним размер столбца по содержимому
                sh.AutoSizeColumn(1);
                //Выравним размер столбца по содержимому
                sh.AutoSizeColumn(2);
                //Выравним размер столбца по содержимому
                sh.AutoSizeColumn(3);
                //Выравним размер столбца по содержимому
                sh.AutoSizeColumn(4);
               

            }

            //запишем всё в файл
            using (var fs = new FileStream(FileName, FileMode.Create, FileAccess.Write))
            {
                wb.Write(fs);
            }

            wb.Close();

            //Откроем файл
            Process.Start(FileName);
        }
    }
}
