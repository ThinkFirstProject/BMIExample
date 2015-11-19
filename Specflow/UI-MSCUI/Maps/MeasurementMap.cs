namespace UI_MSCUI.Maps.MeasurementMapClasses
{
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using System;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
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

        public void clickCancel()
        {
            HtmlButton btnCancel = this.UIBMIInternetExplorerWindow.UIBMIDocument3.UICancelButton;
            Mouse.Click(btnCancel, new Point(28, 14));
        }

        public String getMessageText()
        {
            HtmlDiv messagePane = this.UIBMIInternetExplorerWindow.UIBMIDocument1.UIBodyPane.UIMeasurementalreadyexPane;

            return messagePane.DisplayText;
        }
    }
}
