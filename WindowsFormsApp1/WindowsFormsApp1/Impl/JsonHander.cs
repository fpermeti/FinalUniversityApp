using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace WindowsFormsApp1.Impl {
    public class JsonHander {

        private const string _JsonFile = "UniversityData.json";

        private University _CodingSchool;

        private DataPopulation _DataPopulation;

        public University DeserializeFromJson() {

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string path = Path.Combine(Environment.CurrentDirectory, _JsonFile);

            string data = string.Empty;

            if (File.Exists(path)) {

                data = File.ReadAllText(path);

                _CodingSchool = serializer.Deserialize<University>(data);
            }
            else {

                File.Create(path).Dispose();

                _CodingSchool = new University();

                _DataPopulation = new DataPopulation();

                _DataPopulation.CreateDummyData(_CodingSchool);

                SerializeToJson(_CodingSchool);
            }
            return _CodingSchool;
        }

        public void SerializeToJson(object objectToBeSerialized) {

            JavaScriptSerializer serializer = new JavaScriptSerializer();

            string data = serializer.Serialize(objectToBeSerialized);

            string path = Path.Combine(Environment.CurrentDirectory, _JsonFile);

            File.WriteAllText(path, data);
        }
    }
}
