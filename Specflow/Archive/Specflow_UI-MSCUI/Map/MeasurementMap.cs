using System.Globalization;
using System.Windows.Forms;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;

namespace Specflow_UI_MSCUI.Map.MeasurementMapClasses
{
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using System;
    using Mouse = Mouse;
    using System.Drawing;


    public partial class MeasurementMap
    {
        public void setLength(String length)
        {
            HtmlEdit txtLength = UIBMIInternetExplorerWindow.UIBMIDocument.UILengthEdit;
            txtLength.Text = length;
        }

        public void setWeight(String weight)
        {
            HtmlEdit txtWeight = UIBMIInternetExplorerWindow.UIBMIDocument.UIWeightEdit;
            txtWeight.Text = weight;
        }

        public void setMeasurementDate(String measurementDate)
        {
            HtmlEdit dsMeasurementDate = UIBMIInternetExplorerWindow.UIBMIDocument.UIDateEdit;
            dsMeasurementDate.Text = measurementDate;
        }

        public void clickAddMeasurement()
        {
            HtmlButton btnAddMeasurement = UIBMIInternetExplorerWindow.UIBMIDocument.UIAddMeasurementButton;   
            Mouse.Click(btnAddMeasurement, new Point(143, 16));
        }

        public String getMessageText()
        {
            HtmlDiv messagePane = UIBMIInternetExplorerWindow.UIBMIDocument1.UIBodyPane.UINewmeasurementforperPane;

            return messagePane.DisplayText;
        }
    }
}
