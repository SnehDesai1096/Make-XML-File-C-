using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace ToXML
{
    public class StudentList
    {
        public List<Student> Student { get; set; }
    }

    public class Student
    {
        [XmlAttribute(AttributeName = "firstname")]
        public string FirstName { get; set; }

        [XmlAttribute(AttributeName = "lastname")]
        public string LastName { get; set; }

        [XmlAttribute(AttributeName = "age")]
        public string Age { get; set; }

        public List<College> College { get; set; }
    }

    public class College
    {
        [XmlAttribute(AttributeName = "collegename")]
        public string CollegeName { get; set; }

        [XmlAttribute(AttributeName = "stream")]
        public string Stream { get; set; }

        [XmlAttribute(AttributeName = "branch")]
        public string Branch { get; set; }

        [XmlAttribute(AttributeName = "idnumber")]
        public string IdNumber { get; set; }

    }
}
