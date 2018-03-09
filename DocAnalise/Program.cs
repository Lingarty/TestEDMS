using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml;

namespace DocAnalise
{
    class Program
    {
        //работает
        static void CreateFolder(string pathName)
        {
            string path = "@" + pathName;
            try
            {
                // Determine whether the directory exists.
                if (Directory.Exists(path))
                {
                    Console.WriteLine("That path exists already.");
                    return;
                }

                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);
                Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
            finally { }
        }

        static void SaveFinalDocument(string docText)
        {
            using (var file = File.Create("d1.docx"))
            using (var sw = new StreamWriter(file, Encoding.UTF8))
            {
                sw.Write(docText);
            }
        }
        //работает
        static string ReadAllText(WordprocessingDocument doc)
        {
            using (var sr = new StreamReader(doc.MainDocumentPart.GetStream()))
            {
                return sr.ReadToEnd();
            }
        }
        //------не работает!
        static void ReplaceMarkers(ref string docText, string[] markers, string[] data)
        {
            for (int i = 0; i < markers.Length; i++)
            {
                Regex marker = new Regex(markers[i]);
                docText = marker.Replace(docText, data[i]);
            }
        }

        static string[] markers = {
                "typeOfPractice", "institute", "specialty", "department", "StudentFIO",
                "step", "group", "frstDate", "lastDate", "TeacherFIO", "Position", "AcademicTitle",
                "frstTask, secondTask, thirdTask, fourthTask, fifthTask",
                "FD1", "FD2", "FD3", "FD4", "FD5", "LD1", "LD2", "LD3", "LD4", "LD5", "GenFIO"
            };

        static void IndTask()
        {
            // opening and closing template
            using (var doc = WordprocessingDocument.Open("templates/individual-task.docx", true))
            {
                var docText = ReadAllText(doc);
                ReplaceMarkers(ref docText, markers, data);
                CreateFolder("OutputIndTask");
                SaveFinalDocument(docText);
            }
        }
        static string[] data = {
                "учебная", "ИВМиИТ", "специальность", "кафедра технологий программирования", "{StudentFIO}",
                "{step}", "{group}", "{frstDate}", "{lastDate}", "{TeacherFIO}", "{Position}", "{AcademicTitle}",
                "{frstTask}, {secondTask}, {thirdTask}, {fourthTask}, {fifthTask}",
                "{FD1}", "{FD2}", "{FD3}", "{FD4}", "{FD5}", "{LD1}", "{LD2}", "{LD3}", "{LD4}", "{LD5}", "{GenFIO}"
            };
        static void Main(string[] args)
        {
            IndTask();
            Console.ReadKey();
        }
    }
}
