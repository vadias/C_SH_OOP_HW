/*
Напишите приложение конвертирующее произвольный JSON в XML.
Используете JsonDocument
 */

using System.Collections.Generic;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;

namespace OOP_HW9
{
    class Program
    {
        static void Main()
        {
            string filePath = @"c:\xmlDir\";
            string jsonString = @"{
                          ""Class Name"": ""С# Learn"",
                          ""Students"": [
                                            {
                                              ""Name"": ""Misha"",
                                              ""Last Name"": ""Ivanov""
                                            },
                                            {
                                              ""Name"": ""Ola"",
                                              ""Last Name"": ""Kruglova""
                                            },
                                            {
                                              ""Name"": ""Vika"",
                                              ""Last Name"": ""Petrova""
                                            },
                                            {
                                              ""Name"": ""Alex"",
                                              ""Last Name"": ""Berkman""
                                            },
                                            {
                                              ""Name"": ""Max"",
                                              ""Last Name"": ""Putin""
                                            }
                                        ]
 
                                    }";

            using (JsonDocument document = JsonDocument.Parse(jsonString))
            {
                JsonElement root = document.RootElement;
                JsonElement studentsElementJ = root.GetProperty("Students");

               
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement rootElement = xmlDoc.CreateElement("root");
               
                XmlElement studentsElement = xmlDoc.CreateElement("Students");

                foreach (JsonElement student in studentsElementJ.EnumerateArray())

                {

                    
                    var LastNameJ = student.GetProperty("Last Name").GetString();
                    var nameJ = student.GetProperty("Name").GetString();

                    XmlElement studentElement = xmlDoc.CreateElement("Student");

                    XmlElement name = xmlDoc.CreateElement("Name");
                    name.InnerText = nameJ;
                    studentElement.AppendChild(name);

                    XmlElement LastName = xmlDoc.CreateElement("LastName");
                    LastName.InnerText = LastNameJ;
                    studentElement.AppendChild(LastName);

                    studentsElement.AppendChild(studentElement);
                }

                rootElement.AppendChild(studentsElement);
                xmlDoc.AppendChild(rootElement);
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                xmlDoc.Save(filePath + "test.xml");
            }
        }
    }
}