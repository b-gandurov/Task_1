using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class Entry
    {
        public static Dictionary<string, int> _collaborationDays = new Dictionary<string, int>();

        private int _employeeOneID;
        private int _employeeTwoID;
        private int _projectID;
        private int _days;

        public Entry(int employeeOneID, int employeeTwoID, int projectID, int days)
        {
            _employeeOneID = employeeOneID;
            _employeeTwoID = employeeTwoID;
            _projectID = projectID;
            _days = days;

            string key = CreateKey(employeeOneID, employeeTwoID);
            if (_collaborationDays.ContainsKey(key))
            {
                _collaborationDays[key] += days;
            }
            else
            {
                _collaborationDays.Add(key, days);
            }
        }

        public int EmployeeOneID => _employeeOneID;
        public int EmployeeTwoID => _employeeTwoID;
        public int ProjectID => _projectID;
        public int Days => _days;

        public static string CreateKey(int id1, int id2)
        {
            return id1 < id2 ? $"{id1}-{id2}" : $"{id2}-{id1}";
        }

        public static string GetMaxDaysKey()
        {
            return _collaborationDays.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }

        public override string ToString()
        {
            return $"Employee ID #1: {EmployeeOneID}, Employee ID #2: {EmployeeTwoID}, Project ID: {ProjectID}, Days worked: {Days}";
        }
        public static Dictionary<string, int> CollaborationDays
        {
            get { return _collaborationDays; }
        }

        public static void PrintCollaborationDays()
        {
            Console.WriteLine("Employee Collaboration Days:");
            foreach (var pair in Entry.CollaborationDays)
            {
                Console.WriteLine($"Key: {pair.Key}, Value: {pair.Value} days");
            }
        }
    }
}
