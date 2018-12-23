namespace DataAccess.Repository
{
    using DataAccess.Models;
    using System.Collections.Generic;

    public interface IGlobalRepository
    {
        RecordData GetRecord(int recordId);

        List<RecordData> GetRecords();

        void InsertData(RecordData recordData);
    }
}
