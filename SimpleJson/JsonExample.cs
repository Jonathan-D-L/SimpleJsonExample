using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace SimpleJson
{
    internal class JsonExample
    {
        static readonly string fileName = "jsonExample.json";
        static readonly string fileDirectory = "fileDirExample.json";
        public void RunExample()
        {
            var exampleList = new List<ExampleClass>();
            CreateJsonFile(); //kollar om det finns en fil i bin\debug\fileDirExample, om det inte finns skapar den en mapp och en fil i mappen

            PopulateList(exampleList); //skapar upp en lista med test object

            SerializeObjectsToJsonFile(exampleList); //serialiserar objecten från listan till json filen

            DeserializeObjectsFromJsonFile(exampleList); //deserialiserar objecten från json filen till listan

            foreach (var e in exampleList)
            {
                Console.WriteLine($"{e.ExampleInt} {e.ExampleString} {e.ExampleChar}");
            }
            Console.ReadKey();
        }

        public List<ExampleClass> PopulateList(List<ExampleClass> exampleList)
        {
            
            var addThisAmountToList = 5; //ändra mängden du vill lägga till i listan
            var exampleInt = 1;
            for (int i = 0; i < addThisAmountToList; i++)
            {
                exampleList.Add(new ExampleClass { ExampleInt = exampleInt, ExampleString = "exampleString", ExampleChar = 'e' });
                exampleInt++;
            }
            return exampleList;
        }

        public void CreateJsonFile()
        {
            if (!File.Exists($"{fileDirectory}\\{fileName}")) 
            {
                if (!Directory.Exists(fileDirectory))
                {
                    Directory.CreateDirectory(fileDirectory); //skapar en mapp
                }
                var createFile = File.Create($"{fileDirectory}\\{fileName}"); //skapar en fil i mappen
                createFile.Close();
            }
        }

        public void SerializeObjectsToJsonFile(List<ExampleClass> exampleList)
        {
            if (File.Exists($"{fileDirectory}\\{fileName}"))
            {
                string jsonFile = $"{fileDirectory}\\{fileName}";
                string jsonSerialize = JsonConvert.SerializeObject(exampleList, Formatting.Indented);
                File.WriteAllText(jsonFile, jsonSerialize);
            }
            exampleList.Clear();
        }

        public List<ExampleClass> DeserializeObjectsFromJsonFile(List<ExampleClass> exampleList)
        {
            if (File.Exists($"{fileDirectory}\\{fileName}"))
            {
                string jsonFile = File.ReadAllText($"{fileDirectory}\\{fileName}");
                var jsonDeserialize = JsonConvert.DeserializeObject<IEnumerable<ExampleClass>>(jsonFile);
                if (jsonDeserialize != null)
                {
                    exampleList.AddRange(jsonDeserialize);
                }
            }
            return exampleList;
        }
    }
}
