using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using ToXML;

namespace ToXML
{
    public class XmlConfiguration
    {
        public static string assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static readonly string xmlFileName = "Student.xml";
        public string xmlFilePath = Path.Combine(assemblyPath, xmlFileName);
        public string Xml { get { return File.ReadAllText(Path.Combine(assemblyPath, xmlFileName)); } }

        public StudentList GetConfigurations()
        {
            try
            {
                if (!File.Exists(xmlFilePath))
                {
                    saveConfig(new StudentList());
                }
                return Deserialize<StudentList>(Xml);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void saveConfig(StudentList studentList)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(StudentList));
                StreamWriter write = new StreamWriter(xmlFilePath);
                xs.Serialize(write, studentList);
                write.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private T Deserialize<T>(string input) where T : class
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        private string Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, ObjectToSerialize);
                return textWriter.ToString();
            }
        }
    }
}
