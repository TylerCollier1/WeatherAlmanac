using System;
using System.Collections.Generic;
using WeatherAlmanac.Core.DTO;
using WeatherAlmanac.Core.Interface;
using WeatherAlmanac.BLL;
using WeatherAlmanac.DAL;

namespace WeatherAlmanac.UI
{
    class MenuController
    {
        private ConsoleIO _ui;
        public IRecordService Service { get; set; }
        public MenuController(ConsoleIO ui)
        {
            _ui = ui;
            Service = new RecordService(new MockRecordRepository());
        }

        public ApplicationMode Setup()
        {
            _ui.Display("Enter Application Mode: ");
            _ui.Display("1. Test");
            _ui.Display("2. Live");

            int mode = _ui.GetInt("");
            if (mode == 1)
            {
                return ApplicationMode.TEST;
            } else if (mode == 2)
            {
                return ApplicationMode.LIVE;
            }
            else
            {
                _ui.Error("Invalid mode. Exiting.");
                Environment.Exit(0);
                return ApplicationMode.TEST; // program has exited here
            }
        }

        public void Run()
        {
            bool running = true;

            while(running)
            {
                switch(GetMenuChoice())
                {
                    case 1:
                        LoadRecord();
                        break;
                    case 2:
                        ViewRecordsByDateRange();
                        break;
                    case 3:
                        AddRecord();
                        break;
                    case 4:
                        EditRecord();
                        break;
                    case 5:
                        DeleteRecord();
                        break;
                    case 6:
                        running = false;
                        break;
                    default:
                        // some error message
                        _ui.Error("Invalid menu option");
                        break;
                }
            }
        }
        public int GetMenuChoice()
        {
            DisplayMenu();
            return _ui.GetInt("Enter Choice: ");
        }
        public void DisplayMenu()
        {
            _ui.Display("Main Menu");
            _ui.Display("=====================");
            _ui.Display("1. Load a record");
            _ui.Display("2. View Records by Date Range");
            _ui.Display("3. Add Record");
            _ui.Display("4. Edit Record");
            _ui.Display("5. Delete Record");
            _ui.Display("6. Quit");
        }
        public void LoadRecord()
        {
            DateTime userInput = _ui.GetDateTime("Enter a valid date: ");


            Result<DateRecord> result = Service.Get(userInput);
            if (!result.Success)
            {
                Console.WriteLine(result.Message);
                return;
            }
            Console.WriteLine(result.Data);
        }
        public void ViewRecordsByDateRange()
        {
            DateTime startDate = _ui.GetDateTime("Enter Start Date:");
            DateTime endDate = _ui.GetDateTime("Enter end date:");
           Result <List<DateRecord>> result = Service.LoadRange (startDate, endDate);
            if (!result.Success)
            {
                Console.WriteLine(result.Message);
                return;
            }
            foreach(DateRecord dr in result.Data)
            {
                Console.WriteLine (dr);
            }
        }
        public void AddRecord()
        {         
            DateRecord _dateRecord = new DateRecord();
            _dateRecord.Date = _ui.GetDateTime("Enter a valid date: ");
            _dateRecord.HighTemp = _ui.GetDecimal("Enter a HighTemp: ");
            _dateRecord.LowTemp = _ui.GetDecimal("Enter a LowTemp: ");
            _dateRecord.Humidity = _ui.GetDecimal("Enter a Humidity: ");
            Console.WriteLine("Enter a Description: ");
            _dateRecord.Description = Console.ReadLine();

            Service.Add(_dateRecord);
        }
        public void EditRecord()
        {
            DateRecord _dateRecord = new DateRecord();
            _dateRecord.Date = _ui.GetDateTime("Enter a valid date: ");
            _dateRecord.HighTemp = _ui.GetDecimal("Enter a HighTemp: ");
            _dateRecord.LowTemp = _ui.GetDecimal("Enter a LowTemp: ");
            _dateRecord.Humidity = _ui.GetDecimal("Enter a Humidity: ");
            Console.WriteLine("Enter a Description: ");
            _dateRecord.Description = Console.ReadLine();

            Result<DateRecord> result= Service.Edit(_dateRecord);
          
            Console.WriteLine(result.Message);
            
        }
        public void DeleteRecord()
        {
            
            DateTime userInput = _ui.GetDateTime("Enter a valid date: ");
            

            Result<DateRecord> result = Service.Remove(userInput);

            Console.WriteLine(result.Message);
        }
    }
}
