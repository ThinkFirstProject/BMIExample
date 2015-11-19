using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ranorex;


namespace UI_Ranorex.Maps
{
    public class BMIStartMap
    {
        public void clickNewPerson()
        {
            WebDoc.instance.doc.WaitForDocumentLoaded();
            WebElement element = WebDoc.instance.doc.FindSingle(".//button[#'btnNewPerson']");
            element.Click();
        }

        public void clickHyperLinkPerson(String socialSecNr)
        {
            WebDoc.instance.doc.WaitForDocumentLoaded();
            ATag element = WebDoc.instance.doc.FindSingle(".//div[#'body']/div/table//a[@innertext='123456789']");
            element.Click();   
        }
    }
}
