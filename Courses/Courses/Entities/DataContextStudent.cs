using System.Drawing;
using System.Text.Json;

namespace Courses.Entities
{
    public class DataContextStudent : IDataContext
    {

        public List<Student> LoadData()
        {
            string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.json");



            string jsonString = File.ReadAllText(path);
            var AllStudent = JsonSerializer.Deserialize<List<Student>>(jsonString);

            return AllStudent;
        }

        public bool SaveData(List<Student> newData)
        {
            try
            {

                string path = Path.Combine(AppContext.BaseDirectory, "Data", "data.json");


                string jsonString = JsonSerializer.Serialize(newData);
                
                File.WriteAllText(path, jsonString);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
