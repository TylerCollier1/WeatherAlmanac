using System;
using System.Collections.Generic;
using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;

namespace WeatherAlmanac.DAL
{
    public class MockRecordRepository : IRecordRepository
    {
        private List<DateRecord> _records; // private field to store data records
        public MockRecordRepository()
        {
            _records = new List<DateRecord>();
            DateRecord bogus = new DateRecord();
            bogus.Date = new DateTime();
            bogus.HighTemp = 82;
            bogus.LowTemp = 40;
            bogus.Humidity = .30m;
            bogus.Description = "Really inconsistent weather today.";
            _records.Add(bogus);
        }

        public Result<List<DateRecord>> GetAll()
        { 
            Result<List<DateRecord>> result = new Result<List<DateRecord>>();
            result.Success = true;
            result.Message = "";
            result.Data = new List<DateRecord>(_records);
            return result;

        }

        public Result<DateRecord> Add(DateRecord record)
        {
            Result<DateRecord> result = new Result<DateRecord>();
            result.Success = true;
            result.Message = "Add a record";
            result.Data = record;
            _records.Add(record);
            return result;
        }

        public Result<DateRecord> Remove(DateTime date)
        {
            Result<DateRecord> result = new Result<DateRecord>();
            result.Success = true;
            result.Message = "Removed by date";
            result.Data = new DateRecord();
            result.Data.Date = date;
            int i;

            for (i = 0; i < _records.Count; i++)
            {
                if (_records[i].Date == date)
                {
                    _records.RemoveAt(i);
                    break;
                }
            }
            if (i == _records.Count)
            {
                result.Success = false;
                result.Message = "Date not found.";
            }
            return result;

        }

        public Result<DateRecord> Edit(DateRecord record)
        {
            Result<DateRecord> result = new Result<DateRecord>();
            result.Success = true;
            result.Message = "Edit a date record: ";
            result.Data = new DateRecord();
            result.Data.Date = record.Date;
            int i;

            for (i = 0; i < _records.Count; i++)
            {
                if (_records[i].Date == record.Date)
                {
                    _records[i] = record;
                    break;
                }
            }
            if (i == _records.Count)
            {
                result.Success = false;
                result.Message = "Date not found.";
            }
            return result;
        }
    }
}
