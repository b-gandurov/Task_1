
using ConsoleApp1;
using ConsoleApp1.Helpers;

class Program
{
    static void Main(string[] args)
    {
        string filePath = @"C:\Users\Bozhil\Desktop\SampleData.csv";
        List<Employee> employees = new List<Employee>();
        List<Entry> entries = new List<Entry>();

        if (File.Exists(filePath))
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                sr.ReadLine();
                string currentLine;
                while ((currentLine = sr.ReadLine()) != null)
                {
                    string[] items = currentLine.Split(',');
                    if (items.Length >= 4)
                    {

                        int empID = Validators.TryParseInt(items[0]);
                        int projectID = Validators.TryParseInt(items[1]);
                        DateTime startTime = Validators.ConvertToDatetime(items[2]);
                        DateTime endTime = Validators.ConvertToDatetime(items[3]);
                        employees.Add(new Employee(empID, projectID, startTime, endTime));
                    }
                }
            }
            for (int i = 0; i < employees.Count(); i++)
            {
                for (int j = i; j < employees.Count(); j++)
                {
                    int emplpyeeOneProjectID = employees[i].ProjectId;
                    int emplpyeeTwoProjectID = employees[j].ProjectId;
                    int emplpyeeOneID = employees[i].Id;
                    int emplpyeeTwoID = employees[j].Id;
                    if (emplpyeeOneProjectID == emplpyeeTwoProjectID && emplpyeeOneID != emplpyeeTwoID)
                    {

                        DateTime today = DateTime.Today;
                        DateTime startDate = 
                            Math.Abs((employees[i].StartDate - today).Days) < Math.Abs((employees[j].StartDate - today).Days) ? 
                            employees[i].StartDate : employees[j].StartDate;
                        DateTime endDate = 
                            (employees[i].EndDate - today).Days > (employees[j].EndDate - today).Days ? 
                            employees[i].EndDate : employees[j].EndDate;

                        Entry newentr = new Entry(emplpyeeOneID, emplpyeeTwoID, emplpyeeOneProjectID, (endDate - startDate).Days);
                        Console.WriteLine(newentr);
                        entries.Add(newentr);
                    }



                }
            }
            Console.WriteLine(Entry.GetMaxDaysKey());
            //Entry.PrintCollaborationDays();
        }
        else
        {
            Console.WriteLine($"Error: File not found at path {filePath}");
        }
    }

}
