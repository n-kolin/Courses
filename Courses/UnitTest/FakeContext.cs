using Courses;
using Courses.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    internal class FakeContext : IDataContext
    {
        public List<Student> LoadData()
        {
            List<Student> fakeData = new List<Student>();
            fakeData.Add(new Student() { Id=1, Phone="0554567895"});
            fakeData.Add(new Student() { Id=2, Phone="0554567895"});
            fakeData.Add(new Student() { Id=3, Phone="0554567895"});
            fakeData.Add(new Student() { Id=4, Phone="0554567895"});
                       
            return fakeData;
        }

        public bool SaveData(List<Student> students)
        {
            return true;
        }
    }
}
