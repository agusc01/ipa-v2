using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Text;

namespace CoreLibrary
{
    public class Mock
    {
        private static string pathDebug;
        private static string file;
        private static string pathTextDataBase;
        private static string pathFolder;
        private const string folder = "ipa";
        private API api;
        static Mock()
        {
            Mock.pathDebug = AppDomain.CurrentDomain.BaseDirectory;
        }

        public Mock(string fileNameTextDataBase)
        {
            this.api = new API();

            Mock.file = fileNameTextDataBase;
            Mock.pathTextDataBase = Path.Combine(Mock.pathDebug, Mock.file);
            Mock.pathFolder = Path.Combine(Mock.pathDebug, Mock.folder);
            if (!Directory.Exists(Mock.pathFolder))
            {
                Directory.CreateDirectory(Mock.pathFolder);
            }
        }
        
        public void Mocking()
        {
            this.Reading();
            int i = 0;
            foreach(IPA ipa in this.api.DataBase)
            {
                try
                {
                    if (this.Serilizer(ipa))
                    {
                        Console.WriteLine($"{i} - Serializacion de {ipa.Word}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ipa.Word} - {ex.Message}");
                }
                i++;
            }
        }
        
        private void Reading()
        {
            using (StreamReader sr = new StreamReader(Mock.pathTextDataBase))
            {
                string line = String.Empty;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    i++;
                    string word = String.Empty;
                    string phonetic = String.Empty;
                    if (line.Split(')').Length > 1)
                    {
                        word = line.Split("(")[0];
                        phonetic = line.Substring(line.IndexOf(')') + 2);
                        //Console.WriteLine($"{i}-{word}-{phonetic}");
                    }
                    else
                    {
                        word = line.Split(' ')[0];
                        phonetic = line.Substring(line.IndexOf(' ') + 1);
                        //Console.WriteLine($"**{i}-{word}-{phonetic}");
                    }

                    Console.WriteLine($"*{i}-{word}-{phonetic}");
                    IPA ipa = new IPA(word, new List<string>() { phonetic });
                    bool add = this.api + ipa;
                }

                //Console.WriteLine(api.ToString());
            }
        }
     
        private bool Serilizer(IPA ipa)
        {
            if(ipa is not null)
            {
                JsonSerializerOptions opciones = new JsonSerializerOptions();
                opciones.WriteIndented = true;

                // Existe una sobrecarga del método Serialize que recibe el objeto de configuración. 
                string jsonString = JsonSerializer.Serialize(ipa, opciones);
                string file = $"_{ipa.Word}.json";
                string path = Path.Combine(Mock.pathFolder,file);
                File.WriteAllText(path, jsonString, Encoding.ASCII);
                return true;
            }
            return false;
        }
    }
}
