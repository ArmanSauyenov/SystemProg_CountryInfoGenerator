using Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateEngine.Docx;

namespace P3.DocumentGeneratorWorker
{
    class ReportGenerator
    {
        public void Generate(
            CountryResearchRequest request, 
            CountryDto dto)
        {
            DirectoryInfo currentFolder = new DirectoryInfo(Directory.GetCurrentDirectory());
            DirectoryInfo projectFolder = currentFolder.Parent.Parent;
            DirectoryInfo generatedReportFolder = new DirectoryInfo(projectFolder.FullName + @"\" + "GeneratedReports");
            DirectoryInfo documentTemplates = 
                new DirectoryInfo(projectFolder.FullName + @"\" + "DocumentTemplates");
            FileInfo file = new FileInfo(documentTemplates.FullName + @"\" + "CountryReportTemplate.docx");
            string pathToOutput = generatedReportFolder.FullName + @"\" + $"ReportForUser_{request.RequestedUserId}.docx";
            File.Copy(file.FullName, pathToOutput);
            var valuesToFill = new Content(
                new FieldContent("CountryName", dto.Name),
                new FieldContent("CountryCode", dto.Alpha3Code),
                new FieldContent("Population", dto.Population.ToString()),
                new FieldContent("Gini", dto.Gini.ToString()));

            using (var outputDocument = new TemplateProcessor(pathToOutput)
                .SetRemoveContentControls(true))
            {
                outputDocument.FillContent(valuesToFill);
                outputDocument.SaveChanges();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ReportGenerator r = new ReportGenerator();
            r.Generate(new CountryResearchRequest()
            { RequestedUserId = 123 }, new CountryDto()
            { Population = 10000, Gini =  21, Name = "WAKANDA", Alpha3Code = "WAK", Capital = "WAKANDA" });
        }
    }
}
