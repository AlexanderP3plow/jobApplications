using Avalonia.Controls;
using Avalonia.Interactivity;
using JobApplications.ViewModels;

namespace JobApplications.Views;

public partial class NewJobApplicationView : Window
{
    public NewJobApplicationView()
    {
        InitializeComponent();
    }
    private void CloseWindow(object? sender, RoutedEventArgs e)
    {
        Close();
    }
    private void SaveNewApplication(object? sender, RoutedEventArgs e)
    {
        if (sender is Button button && DataContext  is CompanyViewModel companyViewModel)
        {
            (DataContext as CompanyViewModel)?.SendNewJobApplication();
        }
        Close();
    }
}