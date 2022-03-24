using System;
using System.Collections.Generic;
using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;

namespace WeatherAlmanac.BLL
{
    public class RecordService : IRecordService
    {
        private IRecordRepository _repo;

        public RecordService(IRecordRepository repo)
        {
            _repo = repo;
        }

        public Result<List<DateRecord>> LoadRange(DateTime start, DateTime end)
        {
            Result<List<DateRecord>> result = new Result<List<DateRecord>>();

            if (DateTime.Compare(start, end) > 0)
            {
                result.Success = false;
                result.Message = "Start date is later than end date.";
                return result;
            }   
            result.Data = new List<DateRecord>();
            List<DateRecord> data = _repo.GetAll().Data;
            foreach (DateRecord record in data) 
            {
                if (record.Date > start && record.Date < end)
                {
                    result.Data.Add(record);
                }

            }
            if(result.Data.Count == 0)
            {
                result.Success = false;
                result.Message = "out of range";

            }
            else
            {
                result.Success = true;
            }
            return result;
        }

        public Result<DateRecord> Get(DateTime date)
        {
            Result<DateRecord> result = new Result<DateRecord>();

            
            result.Data = new DateRecord();
            List<DateRecord> data = _repo.GetAll().Data;
           bool exists = false;
            foreach (DateRecord record in data)
            {
                if (record.Date == date)
                {
                    result.Data = record;
                    exists = true;
                    break;
                }

            }
            if (exists) { result.Success = true; }
            else { result.Success = false; }
            return result;
        }

        public Result<DateRecord> Add(DateRecord record)
        {
            Result<DateRecord> result = new Result<DateRecord>();
            result.Success = true;
            result.Message = "Add a record";
            result.Data = record;
            _repo.Add(record);
            return result;
        }

        public Result<DateRecord> Remove(DateTime date)
        {
            Result<DateRecord> result = _repo.Remove(date);
          
            return result;
        }

        public Result<DateRecord> Edit(DateRecord record)
        {
            Result<DateRecord> result = _repo.Edit(record);

            return result;
        }
    }
}
