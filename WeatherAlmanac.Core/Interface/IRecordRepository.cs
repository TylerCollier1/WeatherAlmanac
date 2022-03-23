using System;
using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;

namespace WeatherAlmanac.Core.Interface
{
    public interface IRecordRepository
    {
        public Result<DateRecord> Add(DateRecord record);
    }
}
