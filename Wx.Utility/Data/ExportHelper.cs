using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace Wx.Utility.Data
{
    /// <summary>
    /// 导出辅助操作类
    /// gl
    /// 20151019
    /// </summary>
    public static class ExportHelper
    {
        /// <summary>
        /// 将DateTable转换为文件
        /// </summary>
        /// <param name="dt">导出的DateTable</param>
        /// <param name="path">服务器临时存放路径</param>
        public static void WriteExcel(DataTable dt, string path)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    sb.Append(dt.Columns[k].ColumnName + "\t");
                }
                sb.Append(Environment.NewLine);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        sb.Append(dt.Rows[i][j] + "\t");
                    }
                    sb.Append(Environment.NewLine);//每写一行数据后换行
                }
                WriteFile(sb, path);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// 将字符串转换为文件
        /// </summary>
        /// <param name="sb">字符串</param>
        /// <param name="path">服务器临时存放路径</param>
        public static void WriteFile(StringBuilder sb, string path)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("gb2312"));
                sw.Write(sb.ToString());
                sw.Flush();
                sw.Close();//释放资源
            }
            catch (Exception ex)
            {
            }
        }
        /// <summary>
        /// 将DataTable输出到模板Excel中
        /// 这种方式不能动态列,适合复杂表头
        /// </summary>
        /// <param name="dt">输出的结果集</param>
        /// <param name="modelName">模板文件路径</param>
        /// <param name="fileName">服务器临时存放路径</param>
        /// <param name="RowNum">从第几行开始写</param>
        public static void WriteToModelExcel(DataTable dt, string modelName, string fileName, int RowNum)
        {
            FileStream fs = new FileStream(modelName, FileMode.Open, FileAccess.Read);
            HSSFWorkbook workbook = new HSSFWorkbook(fs);
            HSSFSheet sheet = (HSSFSheet)workbook.GetSheetAt(0);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (sheet.GetRow(RowNum + i) == null)
                {
                    sheet.CreateRow(RowNum + i);
                }
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (sheet.GetRow(RowNum + i).GetCell(j) == null)
                    {
                        sheet.GetRow(RowNum + i).CreateCell(j);
                    }
                    sheet.GetRow(RowNum + i).GetCell(j).SetCellValue(dt.Rows[i][j].ToString());
                }
            }
            //增加“结束”行
            MemoryStream ms = new MemoryStream();
            using (ms)
            {
                workbook.Write(ms);
                //ms.Write(data, 0, data.Length);

                FileStream fsNew = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                byte[] data = ms.ToArray();
                fsNew.Write(data, 0, data.Length);
                fsNew.Flush();
                fsNew.Close();
            }
        }
        /// <summary>
        /// 将DataTable输出到模板Excel中
        /// 动态绑定列,转DataTable有风险
        /// </summary>
        /// <param name="dt">输出的结果集</param>
        /// <param name="modelName">模板文件路径</param>
        /// <param name="fileName">服务器临时存放路径</param>
        /// <param name="columns">从第几行开始写</param>
        public static void WriteToModelExcel(DataTable dt, string modelName, string fileName, List<DatagridColumn> columns)
        {
            FileStream fs = new FileStream(modelName, FileMode.Open, FileAccess.Read);
            HSSFWorkbook workbook = new HSSFWorkbook(fs);
            HSSFSheet sheet = (HSSFSheet)workbook.GetSheetAt(0);
            for (int i = 0; i < columns.Count; i++)
            {
                if (sheet.GetRow(0) == null)
                {
                    sheet.CreateRow(0);
                }
                if (sheet.GetRow(0).GetCell(i) == null)
                {
                    sheet.GetRow(0).CreateCell(i);
                }
                sheet.GetRow(0).GetCell(i).SetCellValue(columns[i].Title);
            }
            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (sheet.GetRow(1 + i) == null)
                    {
                        sheet.CreateRow(1 + i);
                    }
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (sheet.GetRow(1 + i).GetCell(j) == null)
                        {
                            sheet.GetRow(1 + i).CreateCell(j);
                        }
                        sheet.GetRow(1 + i).GetCell(j).SetCellValue(dt.Rows[i][j].ToString());
                    }
                }
            }


            //增加“结束”行

            MemoryStream ms = new MemoryStream();
            using (ms)
            {
                workbook.Write(ms);
                //ms.Write(data, 0, data.Length);

                FileStream fsNew = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                byte[] data = ms.ToArray();
                fsNew.Write(data, 0, data.Length);
                fsNew.Flush();
                fsNew.Close();
            }
        }
        /// <summary>
        /// 将数组输出到模板Excel中
        /// </summary>
        /// <param name="list">输出的结果集</param>
        /// <param name="modelName">模板文件路径</param>
        /// <param name="fileName">服务器临时存放路径</param>
        /// <param name="columns">从第几行开始写</param>
        public static void WriteToModelExcel(IEnumerable<object> list, string modelName, string fileName, List<DatagridColumn> columns)
        {
            FileStream fs = new FileStream(modelName, FileMode.Open, FileAccess.Read);
            HSSFWorkbook workbook = new HSSFWorkbook(fs);
            HSSFSheet sheet = (HSSFSheet)workbook.GetSheetAt(0);
            columns.RemoveAll(p => p.Hidden == true);
            for (int i = 0; i < columns.Count; i++)
            {
                if (sheet.GetRow(0) == null)
                {
                    sheet.CreateRow(0);
                }
                if (sheet.GetRow(0).GetCell(i) == null)
                {
                    sheet.GetRow(0).CreateCell(i);
                }
                sheet.GetRow(0).GetCell(i).SetCellValue(columns[i].Title);
            }
            if (list != null)
            {
                int i = 0;
                foreach (Dictionary<string,object> row in list)
                {
                    sheet.CreateRow(i + 1);
                    for (int j = 0; j < columns.Count; j++)
                    {
                        if (sheet.GetRow(1 + i).GetCell(j) == null)
                        {
                            sheet.GetRow(1 + i).CreateCell(j);
                        }
                        if (row.ContainsKey(columns[j].Field.Trim()))
                        {
                            string value = row[columns[j].Field.Trim()].ToString();
   
                            sheet.GetRow(1 + i).GetCell(j).SetCellValue(value);
                        }
                    }
                    i++;
                }
            }


            //增加“结束”行

            MemoryStream ms = new MemoryStream();
            using (ms)
            {
                workbook.Write(ms);
                //ms.Write(data, 0, data.Length);

                FileStream fsNew = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                byte[] data = ms.ToArray();
                fsNew.Write(data, 0, data.Length);
                fsNew.Flush();
                fsNew.Close();
            }
        }

    }

  
}
