using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Employee
    {
        private int _id;
        private int _projectId;
        private DateTime _startDate;
        private DateTime _endDate;
        private string _dateFormat = "dd.MM.yyyy";
        public Employee(int id, int projectId, DateTime startDate, DateTime endDate)
        {
            _id = id;
            _projectId = projectId;
            _startDate = startDate;
            _endDate = endDate;
        }

        public int Id => _id;
        public int ProjectId => _projectId;
        public DateTime StartDate => _startDate;
        public DateTime EndDate => _endDate;

        public override string ToString()
        {
            string result = $"ID: {Id}, ProjectID: {ProjectId}, StartDate: {StartDate.ToString(_dateFormat)}, EndDate: {EndDate.ToString(_dateFormat)}";
            return result;
        }

    }
}
