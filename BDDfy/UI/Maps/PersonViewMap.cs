using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMI.Def;
using Ranorex;
using DateTime = System.DateTime;

namespace UI_Ranorex.Maps
{
    public class PersonViewMap
    {
        public void clickAddMeasurement()
        {
            WebDoc.instance.doc.WaitForDocumentLoaded();
            WebElement element = WebDoc.instance.doc.FindSingle(".//button[#'btnAddMeasurement']");
            element.Click();
        }

        public void clickCancel()
        {
            WebElement element = WebDoc.instance.doc.FindSingle(".//button[#'btnCancel']");
            element.Click();
        }
    }
}
