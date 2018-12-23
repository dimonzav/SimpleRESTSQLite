using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace DataAccess
{
    public static class DataManagement
    {
        public static readonly string csvFilePath = "./outputfile.csv";

        public static readonly string dbSQLQuery = "select record.id as RecordId, record.age as Age, workClass.id as WorkClassId, workClass.name as WorkClass," +
            " educLevel.id as EducationLevelId, educLevel.name as EducationLevelName, record.education_num as EducationLevel, ms.id as MaritalStatusId," +
            " ms.name as MaritalStatus, occup.id as OccupationId, occup.name as Occupation, rs.id as RelationshipId, rs.name as RelashionShip, race.id as RaceId," +
            " race.name as Race, sex.id as SexId, sex.name as Sex, record.capital_gain as CapitalGain, record.capital_loss as CapitalLoss, record.hours_week as HoursPerWeek," +
            " country.id as CountryId, country.name as Country, record.over_50k as IsOver50k" +
            " from records record" +
            " left join workclasses workClass on record.workclass_id = workClass.id" +
            " left join education_levels educLevel on record.education_level_id = educLevel.id" +
            " left join marital_statuses ms on record.marital_status_id = ms.id" +
            " left join occupations occup on record.occupation_id = occup.id" +
            " left join relationships rs on record.relationship_id = rs.id" +
            " left join races race on record.race_id = race.id" +
            " left join sexes sex on record.sex_id = sex.id" +
            " left join countries country on record.country_id = country.id";
        
        public static DataTable GetDataFromDb(string sqlCommand)
        {
            var returnValue = new DataTable();

            try
            {
                using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=../DataAccess/exercise01.sqlite"))
                {
                    connect.Open();

                    using (SQLiteCommand command = connect.CreateCommand())
                    {
                        command.CommandText = sqlCommand;
                        command.CommandType = CommandType.Text;

                        SQLiteDataAdapter da = new SQLiteDataAdapter(command);
                        da.Fill(returnValue);
                    }
                }

                return returnValue;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void WriteToFile(DataTable dataSource, string fileOutputPath)
        {
            var sw = new StreamWriter(fileOutputPath, false);

            int fieldCount = dataSource.Columns.Count;

            for (int i = 0; i < fieldCount; i++)
            {
                sw.Write(dataSource.Columns[i]);

                if (i < fieldCount - 1)
                {
                    sw.Write(",");
                }
            }

            sw.Write(sw.NewLine);

            foreach (DataRow drow in dataSource.Rows)
            {
                for (int i = 0; i < fieldCount; i++)
                {
                    if (!Convert.IsDBNull(drow[i]))
                    {
                        sw.Write(drow[i].ToString());
                    }

                    if (i < fieldCount - 1)
                    {
                        sw.Write(",");
                    }
                }

                sw.Write(sw.NewLine);
            }

            sw.Close();
        }

        public static List<RecordData> ReadDataFromFile(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                List<RecordData> recordsData = new List<RecordData>();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] values = line.Split(',');

                    if (values[0] != "RecordId")
                    {
                        RecordData recordData = new RecordData
                        {
                            RecordId = int.Parse(values[0]),
                            Age = int.Parse(values[1]),
                            WorkClassId = int.Parse(values[2]),
                            WorkClass = values[3],
                            EducationLevelId = int.Parse(values[4]),
                            EducationLevelName = values[5],
                            EducationLevel = values[6],
                            OccupationId = int.Parse(values[7]),
                            Occupation = values[8],
                            MaritalStatusId = int.Parse(values[9]),
                            MaritalStatus = values[10],
                            RelationshipId = int.Parse(values[11]),
                            Relashionship = values[12],
                            RaceId = int.Parse(values[13]),
                            Race = values[14],
                            SexId = int.Parse(values[15]),
                            Sex = values[16],
                            CapitalGain = int.Parse(values[17]),
                            CapitalLoss = int.Parse(values[18]),
                            HoursPerWeek = int.Parse(values[19]),
                            CountryId = int.Parse(values[20]),
                            Country = values[21],
                            IsOver50k = bool.Parse(values[22])
                        };

                        recordsData.Add(recordData);
                    }
                }

                return recordsData;
            }
        }
    }
}
