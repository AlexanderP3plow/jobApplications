using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using JobApplications.Classes;
using JobApplications.Controller;
using JobApplications.Models;
using JobApplications.ViewModels;

namespace JobApplications.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Loaded += GetApplicationsOverview;
    }

    private void OpenNewJobApplicationView(object? sender, RoutedEventArgs e)
    {
        NewJobApplicationView newJobApplicationView = new NewJobApplicationView();
        newJobApplicationView.Show(this);
        newJobApplicationView.Closed += GetApplicationsOverview;
    }

    private async void GetApplicationsOverview(object? sender, EventArgs eventArgs)
    {
        await ApplicationsOverview.GetApplicationsOverview();
    }

    private async void UpdateEntry(object? sender, DataGridCellEditEndedEventArgs e)
    {
        if (e.Row.DataContext is not Company company) return;
        await DatabaseController.UpdateApplication(company);
        Loaded += GetApplicationsOverview;
    }

    private async void UpdateStatus(object? sender, EventArgs eventArgs)
    {
        if (sender is not ComboBox { Parent.DataContext: Company company }) return;
        await DatabaseController.UpdateApplication(company);
        Loaded += GetApplicationsOverview;
    }
}