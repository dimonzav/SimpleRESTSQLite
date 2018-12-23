namespace DataAccess
{
    using DataAccess.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.IO;

    public class AppInitializer
    {
        public static List<RecordData> RecordsData { get; set; }        

        public static void Initialize()
        {
            try
            {
                if (!File.Exists(DataManagement.csvFilePath))
                {
                    DataTable dataTable = DataManagement.GetDataFromDb(DataManagement.dbSQLQuery);

                    DataManagement.WriteToFile(dataTable, DataManagement.csvFilePath);

                    List<RecordData> recordsData = DataManagement.ReadDataFromFile(DataManagement.csvFilePath);

                    RecordsData = recordsData;
                }
                else if (File.Exists(DataManagement.csvFilePath))
                {
                    List<RecordData> recordsData = DataManagement.ReadDataFromFile(DataManagement.csvFilePath);

                    RecordsData = recordsData;
                }
                else
                {
                    throw new Exception("File not found.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
