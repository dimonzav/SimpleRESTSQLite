namespace DataAccess.Repository
{
    using DataAccess.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SQLite;
    using System.Linq;

    public class GlobalRepository : IGlobalRepository
    {
        public RecordData GetRecord(int recordId)
        {
            try
            {
                return AppInitializer.RecordsData.Where(i => i.RecordId == recordId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RecordData> GetRecords()
        {
            try
            {
                return AppInitializer.RecordsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InsertData(RecordData recordData)
        {
            try
            {
                using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=../DataAccess/exercise01.sqlite"))
                {
                    connect.Open();

                    using (SQLiteCommand command = connect.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO records (age, workclass_id, education_level_id, education_num, marital_status_id, occupation_id," +
                            " relationship_id, race_id, sex_id, capital_gain, capital_loss, hours_week, country_id, over_50k)" +
                            " VALUES(@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14)";

                        command.CommandType = CommandType.Text;

                        command.Parameters.Add(new SQLiteParameter("@p1", recordData.Age));
                        command.Parameters.Add(new SQLiteParameter("@p2", recordData.WorkClassId));
                        command.Parameters.Add(new SQLiteParameter("@p3", recordData.EducationLevelId));
                        command.Parameters.Add(new SQLiteParameter("@p4", recordData.EducationLevel));
                        command.Parameters.Add(new SQLiteParameter("@p5", recordData.MaritalStatusId));
                        command.Parameters.Add(new SQLiteParameter("@p6", recordData.OccupationId));
                        command.Parameters.Add(new SQLiteParameter("@p7", recordData.RelationshipId));
                        command.Parameters.Add(new SQLiteParameter("@p8", recordData.RaceId));
                        command.Parameters.Add(new SQLiteParameter("@p9", recordData.SexId));
                        command.Parameters.Add(new SQLiteParameter("@p10", recordData.CapitalGain));
                        command.Parameters.Add(new SQLiteParameter("@p11", recordData.CapitalLoss));
                        command.Parameters.Add(new SQLiteParameter("@p12", recordData.HoursPerWeek));
                        command.Parameters.Add(new SQLiteParameter("@p13", recordData.CountryId));
                        command.Parameters.Add(new SQLiteParameter("@p14", recordData.IsOver50k));

                        command.ExecuteNonQuery();
                    }
                }

                DataTable dataTable = DataManagement.GetDataFromDb(DataManagement.dbSQLQuery);

                DataManagement.WriteToFile(dataTable, DataManagement.csvFilePath);

                List<RecordData> recordsData = DataManagement.ReadDataFromFile(DataManagement.csvFilePath);

                AppInitializer.RecordsData = recordsData;
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }
    }
}
