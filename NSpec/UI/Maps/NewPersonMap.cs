using System;
using System.Threading;
using Ranorex;

namespace UI_Ranorex.Maps
{
    public class NewPersonMap
    {
        public String getErrorText()
        {
            WebDoc.instance.doc.WaitForDocumentLoaded();
            WebElement element = WebDoc.instance.doc.FindSingle(".//div[#'body']/?/?/form[@action~'BMI+']//ul/li");

            return element.InnerText;
        }

        public void setSocialSecurityNumber(String socialSecurityNumber)
        {
            WebDoc.instance.doc.WaitForDocumentLoaded();
            InputTag element = WebDoc.instance.doc.FindSingle(".//input[#'socialSecurityNumber']");
            element.InnerText = socialSecurityNumber;
        }

        public void setBirthDate(String birthDate)
        {
            InputTag element = WebDoc.instance.doc.FindSingle(".//input[#'birthDate']");
            element.InnerText = birthDate;
        }

        public void setGender(String gender)
        {
        }

        public void setLength(String length)
        {
            InputTag element = WebDoc.instance.doc.FindSingle(".//input[#'length']");
            element.InnerText = length;
        }

        public void setWeight(String weight)
        {
            InputTag element = WebDoc.instance.doc.FindSingle(".//input[#'weight']");
            element.InnerText = weight;
        }

        public void setMeasurementDate(String measurementDate)
        {
            InputTag element = WebDoc.instance.doc.FindSingle(".//input[#'measurementDate']");
            element.InnerText = measurementDate;
        }

        public void clickOK()
        {
            WebElement element = WebDoc.instance.doc.FindSingle(".//button[#'btnSubmit']");
            element.Click();
        }

        public void clickCancel()
        {
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
