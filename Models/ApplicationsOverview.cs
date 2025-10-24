using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using JobApplications.Classes;
using JobApplications.Controller;

namespace JobApplications.Models;

public class ApplicationsOverview
{
    public static List<string> StatusOptions { get; } = new() { "Active", "Cancelled"};
    public static ObservableCollection<Company> ApplicationOverview { get; set; } = new();
    public static async Task GetApplicationsOverview()
    {
        ObservableCollection<Company> companies = await DatabaseController.GetJobApplications();
        ApplicationOverview.Clear();
        foreach(var company in companies)
        {
            ApplicationOverview.Add(company);
        }
    }
}