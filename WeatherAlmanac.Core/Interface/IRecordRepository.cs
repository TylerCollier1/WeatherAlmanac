using System;
using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;

namespace WeatherAlmanac.Core.Interface
{
    public interface IRecordRepository
    {
        public Result<DateRecord> Add(DateRecord record);
        public Result<List<DateRecord>> GetAll();

        public Result<DateRecord> Remove(DateTime date);

        public Result<DateRecord> Edit(DateRecord record);

        
    }

}
