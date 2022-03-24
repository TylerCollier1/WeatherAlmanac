using System;

namespace WeatherAlmanac.Core.DTO
{
    public class DateRecord
    {
        public DateTime Date { get; set; }
        public decimal HighTemp { get; set; }
        public decimal LowTemp { get; set; }
        public decimal Humidity { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Date:{Date}\nHigh Temp:{HighTemp}\nLow Temp:{LowTemp}\nHumidity:{Humidity}\nDescription:{Description}";
        }
        public override bool Equals(object? obj)
        {
            return obj is DateRecord record &&
                   Date == record.Date &&
                   HighTemp == record.HighTemp &&
                   LowTemp == record.LowTemp &&
                   Humidity == record.Humidity &&
                   Description == record.Description;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Description);
        }
    }
    }
