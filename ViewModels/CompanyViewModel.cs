using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.InteropServices.JavaScript;
using JobApplications.Classes;
using JobApplications.Controller;

namespace JobApplications.ViewModels;

public class CompanyViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    
    private string? _companyName;
    private string? _email;
    private string? _contact;
    private string? _address;
    private string? _job;
    private string? _date;
    private string? _status;

    public string? CompanyName 
    {
        get  => _companyName;
        set
        {
            _companyName = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CompanyName)));
        }
    }
    public string? Email 
    {
        get   => _email;
        set
        {
            _email = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email))); 
        }
    }
    public string? Contact 
    {
        get   => _contact;
        set
        {
            _contact = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Contact))); 
        }
    }
    public string? Address 
    {
        get   => _address;
        set
        {
            _address = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Address))); 
        }
    }
    public string? Job 
    {
        get   => _job;
        set
        {
            _job = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Job))); 
        }
    }

    public void SendNewJobApplication()
    {
        var date = DateTime.Today;
        Company company = new Company
        {
            CompanyName = CompanyName,
            Email = Email,
            Contact = Contact,
            Address = Address,
            Job = Job,
            Date = date.ToShortDateString(),
            Status = "Active"
        };
        DatabaseController.SaveNewJobApplication(company);
    }
    
}