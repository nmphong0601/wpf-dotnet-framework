using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ChoETL;

namespace MediaTinLanh.Control
{
    public class Control_Json_Table
    {
        public DataTable ConvertJsonToDataTable(String jsonString)
        {
            DataTable dt = new DataTable();
            try
            {                
                dt = (DataTable)JsonConvert.DeserializeObject(jsonString, (typeof(DataTable)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public string DataTableToJsonObj(DataTable dt)
        {
            DataSet ds = new DataSet();
            ds.Merge(dt);
            StringBuilder JsonString = new StringBuilder();
            using (var parser = new ChoJSONWriter(JsonString))
                parser.Write(dt);
            return JsonString.ToString();
        }
    }
}
