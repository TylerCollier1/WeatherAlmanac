using System;
using WeatherAlmanac.BLL;
using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;
using WeatherAlmanac.UI;
using WeatherAlmanac.DAL;

namespace WeatherAlmanac{

    class Program
    {
        static void Main(string[] args)
        {
            ConsoleIO ui = new ConsoleIO();
            MenuController menu = new MenuController(ui);

            ApplicationMode mode = menu.Setup();
            IRecordService service = RecordServiceFactory.GetRecordService(mode);
            menu.Service = service;
            menu.Run();

        }
    }
}