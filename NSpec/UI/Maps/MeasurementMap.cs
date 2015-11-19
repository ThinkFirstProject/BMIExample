using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ranorex;

namespace UI_Ranorex.Maps
{
    public class MeasurementMap
    {
        public void setLength(String length)
        {
            WebDoc.instance.doc.WaitForDocumentLoaded();
            InputTag element = WebDoc.instance.doc.FindSingle(".//input[#'length']");
            element.InnerText = length;
        }

        public void setWeight(String weight)
        {
            WebDoc.instance.doc.WaitForDocumentLoaded();
            InputTag element = WebDoc.instance.doc.FindSingle(".//input[#'weight']");
            element.InnerText = weight;
        }

        public void setMeasurementDate(String measurementDate)
        {
            WebDoc.instance.doc.WaitForDocumentLoaded();
            InputTag element = WebDoc.instance.doc.FindSingle(".//input[#'measurementDate']");
            element.InnerText = measurementDate;
        }

        public void clickAddMeasurement()
        {
            WebDoc.instance.doc.WaitForDocumentLoaded();
            WebElement element = WebDoc.instance.doc.FindSingle(".//button[#'btnAddMeasurement']");
            element.Click();
        }

        public void clickCancel()
        {
            WebDoc.instance.doc.WaitForDocumentLoaded();
            WebElement element = WebDoc.instance.doc.FindSingle(".//button[#'btnCancel']");
            element.Click();
        }

        public String getMessageText()
        {
            WebDoc.instance.doc.WaitForDocumentLoaded();
            WebElement element = WebDoc.instance.doc.FindSingle(".//div[#'body']/?/?/div[@class='messageField']");

            return element.InnerText.Trim();
        }
    }
}
