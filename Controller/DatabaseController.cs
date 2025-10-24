using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Threading.Tasks;
using JobApplications.Classes;
using LiteDB;
using LiteDB.Async;

namespace JobApplications.Controller;

public static class DatabaseController
{
    public static void SaveNewJobApplication(Company company)
    {
        try
        { 
            var db = new LiteDatabase(Paths.JobApplications);
            var col = db.GetCollection<Company>("JobApplications");
            var maxId = col.FindAll()
                .OrderByDescending(x => x.Id)
                .FirstOrDefault()?.Id ?? 0;
            company.Id = maxId + 1;
            col.Insert(company);
            db.Dispose();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static async Task<ObservableCollection<Company>> GetJobApplications()
    {
        ObservableCollection<Company> companies = new ObservableCollection<Company>();
        try
        { 
            var db = new LiteDatabaseAsync(Paths.JobApplications);
            var col = db.GetCollection<Company>("JobApplications");
            var results = await col.FindAllAsync();
            foreach (var company in results)
            {
                companies.Add(company);
            }
            db.Dispose();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return companies;
    }

    public static async Task UpdateApplication(Company company)
    {
        try
        { 
            var db = new LiteDatabaseAsync(Paths.JobApplications);
            var col = db.GetCollection<Company>("JobApplications");
            
            if (await col.ExistsAsync(x => x.Id == company.Id))
            {
                await col.UpdateAsync(company);
                db.Dispose();
            }
            else
            {
                db.Dispose();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    public static async Task DeleteApplication(Company company)
    {
        try
        { 
            var db = new LiteDatabaseAsync(Paths.JobApplications);
            var col = db.GetCollection<Company>("JobApplications");
            if (await col.ExistsAsync(x => x.Id == company.Id))
            {
                await col.DeleteAsync(company.Id);
                db.Dispose();
            }
            else
            {
                db.Dispose();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}