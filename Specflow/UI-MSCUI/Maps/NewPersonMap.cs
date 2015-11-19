using System.Globalization;
using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;

namespace Specflow_UI_MSCUI.Map.NewPersonMapClasses
{
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using System;
    using Mouse = Mouse;
    using System.Drawing;

    public partial class NewPersonMap
    {
        public String getErrorText()
        {
            HtmlCustom errorText = UIBMIInternetExplorerWindow.UIBMIDocument1.UIBodyPane1.UIThevalue5isnotvalidfCustom;
            return errorText.InnerText;
        }

        public void setSocialSecurityNumber(String socialSecurityNumber)
        {
            HtmlEdit txtSocialSecurityNumber = UIBMIInternetExplorerWindow.UIBMIDocument.UISocialSecurityNumberEdit;
            txtSocialSecurityNumber.Text = socialSecurityNumber;
        }

        public void setBirthDate(String birthDate)
        {
            HtmlEdit dsBirthDate = UIBMIInternetExplorerWindow.UIBMIDocument.UIBirthDateEdit;
            dsBirthDate.Text = birthDate;
        }

        public void setGender(String gender)
        {
            HtmlComboBox cmbGender = UIBMIInternetExplorerWindow.UIBMIDocument.UIGenderComboBox;
            cmbGender.SelectedItem = gender;
        }

        public void setLength(String length)
        {
            HtmlEdit txtLength = UIBMIInternetExplorerWindow.UIBMIDocument.UILengthEdit;
            txtLength.Text = length.ToString(CultureInfo.CurrentCulture);
        }

        public void setWeight(String weight)
        {
            HtmlEdit txtWeight = UIBMIInternetExplorerWindow.UIBMIDocument.UIWeightEdit;
            txtWeight.Text = weight.ToString(CultureInfo.CurrentCulture);
        }

        public void setMeasurementDate(String measurementDate)
        {
            HtmlEdit dsMeasurementDate = UIBMIInternetExplorerWindow.UIBMIDocument.UIDateEdit;
            dsMeasurementDate.Text = measurementDate;
        }

        public void clickOK()
        {
            HtmlButton btnOK = UIBMIInternetExplorerWindow.UIBMIDocument.UIOKButton;
            Mouse.Click(btnOK, new Point(30, 13));
        }

        public void clickCancel()
        {
            HtmlButton btnCancel = UIBMIInternetExplorerWindow.UIBMIDocument1.UICancelButton;
            Mouse.Click(btnCancel, new Point(50, 15));
        }

        public String getMessageText()
        {
            HtmlDiv messagePane = UIBMIInternetExplorerWindow.UIBMIDocument1.UIBodyPane.UINewpersonwithsocialsPane;

            return messagePane.DisplayText;
        }        
    }
}
