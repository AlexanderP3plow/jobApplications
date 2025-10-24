using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using JobApplications.Classes;
using JobApplications.Controller;
using JobApplications.Models;
using JobApplications.ViewModels;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

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

    private async void UpdateEntry(object? sender, DataGridCellEditEndedEventArgs e)
    {
        if (e.Row.DataContext is not Company company) return;
        await DatabaseController.UpdateApplication(company);
        await ApplicationsOverview.GetApplicationsOverview();
    }

    private async void UpdateStatus(object? sender, EventArgs eventArgs)
    {
        if (sender is not ComboBox { Parent.DataContext: Company company }) return;
        await DatabaseController.UpdateApplication(company);
        await ApplicationsOverview.GetApplicationsOverview();
    }
    private async void DeleteEntry(object? sender, RoutedEventArgs routedEventArgs)
    {
        if (sender is MenuItem)
        {
            foreach (Company company in CompaniesDataGrid.SelectedItems)
            {
                await DatabaseController.DeleteApplication(company);
            }
            await ApplicationsOverview.GetApplicationsOverview();
        }
    }
    private async void DeleteGesture(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Delete)
        {
            var box = MessageBoxManager
                .GetMessageBoxStandard("Warning", "Are you sure you would like to delete?", ButtonEnum.YesNo);

            var result = await box.ShowAsync();
            if (result == ButtonResult.Yes)
            {
                foreach (Company company in CompaniesDataGrid.SelectedItems)
                {
                    await DatabaseController.DeleteApplication(company);
                }
            }
            e.Handled = true;
            await ApplicationsOverview.GetApplicationsOverview();
        }
    }
    private async void GetApplicationsOverview(object? sender, EventArgs eventArgs)
    {
        await ApplicationsOverview.GetApplicationsOverview();
    }
}