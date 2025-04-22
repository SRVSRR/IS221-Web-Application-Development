using System.Collections.Generic;
using System.Xml.Linq;
using Lab7_StudentRegistration.Models;
using System.IO;

namespace Lab7_StudentRegistration.Services
{
    public class XmlDataService
    {
        public List<Major> GetMajors()
        {
            var majors = new List<Major>();
            var xmlPath = Path.Combine(Directory.GetCurrentDirectory(), "App_Data", "Majors.xml");            
            if (File.Exists(xmlPath))
            {
                var doc = XDocument.Load(xmlPath);
                foreach (var majorElement in doc.Descendants("major"))
                {
                    majors.Add(new Major { 
                        Name = majorElement.Attribute("name")?.Value ?? string.Empty 
                    });
                }
            }
            
            return majors;
        }
    }
}