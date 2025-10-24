using System;
using System.IO;

namespace JobApplications.Classes;

public class Paths
{
    private static readonly string Home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
    private static readonly string MainPath = Path.Combine(Home, ".databases/JobApplications");
    public static readonly string JobApplications = Path.Combine(MainPath, "JobApplications.db");
}