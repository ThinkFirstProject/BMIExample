using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using BMI.Def;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Specflow_UI_MSCUI.Map;
using TechTalk.SpecFlow;

namespace Specflow_UI_MSCUI.Spec
{
    [Binding]
    public class Common
    {
        [BeforeScenario]
        public void setUp()
        {
            Thread.Sleep(3000);
            StartIISExpressFromPath(@"D:\Elektromap\KHLimCo-op\net\WP3 Onwtikkel-implementatie onderzoek 1\BMIExample\BMIWeb", 8057);
        }

        [AfterScenario]
        public void tearDown()
        {
            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd", "/c " + "taskkill /IM iisexpress.exe ");
            Process proc = new Process {StartInfo = procStartInfo};
            proc.Start();
            proc.WaitForExit();

            procStartInfo = new ProcessStartInfo("cmd", "/c " + "taskkill /IM iexplore.exe");
            proc = new Process { StartInfo = procStartInfo };
            proc.Start();
            proc.WaitForExit();
        }

        [Given(@"a valid user")]
        public void GivenAValidUser()
        {
            BMIUIMap.BMIStartMap.clickNewPerson();
            BMIUIMap.newPersonMap.setSocialSecurityNumber("1");
            BMIUIMap.newPersonMap.setGender(PersonDef.Gender.Male.ToString());

            DateTime date = new DateTime(1986, 5, 2);
            BMIUIMap.newPersonMap.setBirthDate(date.Day + "-" + date.Month + "-" + date.Year);
            BMIUIMap.newPersonMap.setLength("180");
            BMIUIMap.newPersonMap.setWeight("75000");
            date = DateTime.Now;
            BMIUIMap.newPersonMap.setMeasurementDate(date.Day + "-" + date.Month + "-" + date.Year);

            BMIUIMap.newPersonMap.clickOK();
            
            Assert.IsFalse(String.IsNullOrEmpty(BMIUIMap.newPersonMap.getMessageText()));

            BMIUIMap.newPersonMap.clickCancel();
            
            BMIUIMap.BMIStartMap.clickHyperLinkPerson("1");
            
        }

        [Then(@"an error is returned containing the message (.*)")]
        public void ThenAnErrorIsReturnedContainingTheMessageInvalidLength(String message)
        {
            Assert.IsTrue(ScenarioContext.Current.ContainsKey("Error"));
            String error = ScenarioContext.Current.Get<String>("Error");
            Assert.IsTrue(error.Contains(message));
        }

        public void StartIISExpressFromPath(string path, int port = 7329)
        {
            var arguments = new StringBuilder();

            arguments.Append(@"/path:""" + path + @"""");

            arguments.Append(@" /port:""" + port + @"""");

            var process = Process.Start(new ProcessStartInfo()

            {
                FileName = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\IIS Express\\iisexpress.exe",
                Arguments = arguments.ToString(),
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            });
            
            Process.Start("http://localhost:" + port);

            
        }
    }
}
