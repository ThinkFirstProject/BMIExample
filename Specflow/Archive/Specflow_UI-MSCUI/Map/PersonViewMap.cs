using System;
using System.Drawing;
using BMI.Def;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Specflow_UI_MSCUI.Map.Personview
{
    public partial class PersonViewMap
    {
        public String getSocicalSecurityNumber()
        {
            HtmlEdit txtSocialSecNr = UIBMIInternetExplorerWindow.UIBMIDocument.UISocialSecurityNumberEdit;
            return txtSocialSecNr.Text;
        }

        public DateTime getBirthDate()
        {
            HtmlEdit txtBirthDate = UIBMIInternetExplorerWindow.UIBMIDocument.UIBirthDateEdit;
            return DateTime.Parse(txtBirthDate.Text);
        }

        public PersonDef.Gender getGender()
        {
            HtmlComboBox cmbGender = UIBMIInternetExplorerWindow.UIBMIDocument.UIGenderComboBox;
            return (PersonDef.Gender) Enum.Parse(typeof (PersonDef.Gender), cmbGender.SelectedItem);
        }

        public double getBMI()
        {
            HtmlEdit txtBMI = UIBMIInternetExplorerWindow.UIBMIDocument.UIBmiEdit;
            return Double.Parse(txtBMI.Text.Replace(".", ","));
        }

        public void clickAddMeasurement()
        {
            HtmlButton btnAddMeasurement = UIBMIInternetExplorerWindow.UIBMIDocument.UIAddMeasurementButton;    
            Mouse.Click(btnAddMeasurement, new Point(123, 16));
        }

        public void clickCancel()
        {
            HtmlButton btnCancel = UIBMIInternetExplorerWindow.UIBMIDocument1.UICancelButton;
            Mouse.Click(btnCancel, new Point(70, 14));
        }
    }
}
