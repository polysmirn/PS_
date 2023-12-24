using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Win32;
using PS.Model.CustomEntities;
using PS.Model.Data;
using PS.Model.Entities;
using PS.Model.Services;
using PS.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PS.ViewModel
{
    public class ReportsViewModel : ViewModelBase
    {
        private DateTime _startDate;
        private DateTime _endDate;
        private List<Hall> _allhalls;
        private int _hallId;
        private Report _dataTable;
      
        private int? _statusId;
        public DateTime StartDate { get => _startDate; set { _startDate = value; OnPropertyChanged(nameof(StartDate)); } }
        public DateTime EndDate { get => _endDate; set { _endDate = value; OnPropertyChanged(nameof(EndDate)); } }
        public Report DataTable { get => _dataTable; set { _dataTable = value; OnPropertyChanged(nameof(DataTable)); } }
    
        public int HallId { get => _hallId; set { _statusId = value; OnPropertyChanged(nameof(HallId)); } }
        public List<Hall> AllHalls { get => _allhalls; set { _allhalls = value; OnPropertyChanged(nameof(AllHalls)); } }


        public ICommand UpdateReportDataTableCommand { get; set; }
        public ICommand DownloadReportDataTableCommand { get; set; }

        private ReportService context;
      
        public ReportsViewModel()
        {
            context = new ReportService();
            StartDate = DateTime.Now.AddMonths(-1);
            EndDate = DateTime.Now;


            AllHalls = new List<Hall> { new Hall() { Id = 0, Name = "Все заказы" } };
            AllHalls.AddRange(context.GetHalls());
            HallId = 0;

            DataTable = new Report();
            DataTable.StartDate = StartDate; DataTable.EndDate = EndDate;
            DataTable.Orders = new ObservableCollection<OrdersByDate>(context.OrderByDate(StartDate, EndDate,HallId));

            DownloadReportDataTableCommand = new RelayCommand(DownloadReportDataTable);
            UpdateReportDataTableCommand = new RelayCommand(UpdateReportDataTable);
        }

        private void UpdateReportDataTable(object obj)
        {
            DataTable.Orders = new ObservableCollection<OrdersByDate>(context.OrderByDate(StartDate, EndDate,HallId));
        }

        private string filePath;
        private void DownloadReportDataTable(object obj)
        {
            filePath = OpenFolderDialog();

            if (!string.IsNullOrEmpty(filePath))
            {
                string _filePath = Path.Combine(filePath, "output.csv");

                GenerateCsvReport(DataTable.Orders, _filePath);
            }
        }

        public string OpenFolderDialog()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Title = "Выберите папку",
                Filter = "Все файлы (.)|.",
                OverwritePrompt = false,
                FileName = "Новый файл"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                return Path.GetDirectoryName(saveFileDialog.FileName);
            }

            return null;
        }

        public static void GenerateCsvReport(ObservableCollection<OrdersByDate> data, string filePath)
        {
            using (var writer = new StreamWriter(filePath, false, Encoding.GetEncoding("windows-1251")))
            using (var csv = new CsvWriter(writer, new CsvConfiguration(new CultureInfo("ru-RU"))))
            {
                csv.WriteRecords(data.Select(item => new { Дата = item.Date, Время = item.Time, Зал = item.Hall, Стоимость_заказа = item.Price }));
            }
        }
    }
}
