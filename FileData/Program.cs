using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using ThirdPartyTools;


namespace FileData
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.Clear();

                var versionKeyWords = ConfigurationSettings.AppSettings["VersionKeyWords"];
                var sizeKeyWords = ConfigurationSettings.AppSettings["SizeKeyWords"];

                Console.WriteLine("Please Enter Command :");
                string cmdRead = Convert.ToString(Console.ReadLine());
                var parameters = cmdRead.Split(' ');
                FileDetails fileDetails = new FileDetails();
                if (parameters.Count() == 2)
                {
                    if (versionKeyWords != null && !string.IsNullOrWhiteSpace(versionKeyWords))
                    {
                        if (versionKeyWords.Split(',').Any(a => a == args[0]))
                        {
                            Console.WriteLine("File Version is : " + fileDetails.Version(args[1]));
                        }
                    }

                    if (sizeKeyWords != null && !string.IsNullOrWhiteSpace(sizeKeyWords))
                    {
                        if (sizeKeyWords.Split(',').Any(a => a == args[0]))
                        {
                            Console.WriteLine("File Size is : " + fileDetails.Size(args[1]));
                        }
                    }
                }
                else
                {
                    Console.WriteLine("You need pass two arguments like example '-v C:/test.txt'");
                }
                Console.Read();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
