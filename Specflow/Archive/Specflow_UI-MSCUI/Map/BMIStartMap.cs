using Microsoft.VisualStudio.TestTools.UITesting;

namespace Specflow_UI_MSCUI.Map.BMIStartMapClasses
{
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using System;
    using Mouse = Mouse;
    using System.Drawing;


    public partial class BMIStartMap
    {

        /// <summary>
        /// RecordedMethod1
        /// </summary>
        public void clickNewPerson()
        {
            HtmlButton btnNewPerson = UIBMIInternetExplorerWindow.UIBMIDocument.UINewButton;
            Mouse.Click(btnNewPerson, new Point(44, 18));
        }

        public void clickHyperLinkPerson(String socialSecNr)
        {
            HtmlHyperlink personLink = UIBMIInternetExplorerWindow.UIBMIDocument1.UIItem10NewPane.UIItem10Hyperlink; 
   
            personLink.SearchProperties[HtmlHyperlink.PropertyNames.InnerText] = socialSecNr; 
            Mouse.Click(personLink, new Point(9, 6));
        }
    }
}
