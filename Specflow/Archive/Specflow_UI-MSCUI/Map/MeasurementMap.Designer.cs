﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 12.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace Specflow_UI_MSCUI.Map.MeasurementMapClasses
{
    using System.CodeDom.Compiler;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;


    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public partial class MeasurementMap
    {
        
        #region Properties
        public UIBMIInternetExplorerWindow UIBMIInternetExplorerWindow
        {
            get
            {
                if ((this.mUIBMIInternetExplorerWindow == null))
                {
                    this.mUIBMIInternetExplorerWindow = new UIBMIInternetExplorerWindow();
                }
                return this.mUIBMIInternetExplorerWindow;
            }
        }
        #endregion
        
        #region Fields
        private UIBMIInternetExplorerWindow mUIBMIInternetExplorerWindow;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class UIBMIInternetExplorerWindow : BrowserWindow
    {
        
        public UIBMIInternetExplorerWindow()
        {
            #region Search Criteria
            this.SearchProperties[UITestControl.PropertyNames.Name] = "BMI";
            this.SearchProperties[UITestControl.PropertyNames.ClassName] = "IEFrame";
            this.WindowTitles.Add("BMI");
            #endregion
        }
        
        public void LaunchUrl(System.Uri url)
        {
            this.CopyFrom(BrowserWindow.Launch(url));
        }
        
        #region Properties
        public UIBMIDocument UIBMIDocument
        {
            get
            {
                if ((this.mUIBMIDocument == null))
                {
                    this.mUIBMIDocument = new UIBMIDocument(this);
                }
                return this.mUIBMIDocument;
            }
        }
        
        public UIBMIDocument1 UIBMIDocument1
        {
            get
            {
                if ((this.mUIBMIDocument1 == null))
                {
                    this.mUIBMIDocument1 = new UIBMIDocument1(this);
                }
                return this.mUIBMIDocument1;
            }
        }
        #endregion
        
        #region Fields
        private UIBMIDocument mUIBMIDocument;
        
        private UIBMIDocument1 mUIBMIDocument1;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class UIBMIDocument : HtmlDocument
    {
        
        public UIBMIDocument(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = null;
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "BMI";
            this.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = "/BMI/AddMeasurement";
            this.FilterProperties[HtmlDocument.PropertyNames.PageUrl] = "http://localhost:15444/BMI/AddMeasurement";
            this.WindowTitles.Add("BMI");
            #endregion
        }
        
        #region Properties
        public HtmlEdit UILengthEdit
        {
            get
            {
                if ((this.mUILengthEdit == null))
                {
                    this.mUILengthEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUILengthEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "length";
                    this.mUILengthEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "length";
                    this.mUILengthEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = null;
                    this.mUILengthEdit.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mUILengthEdit.FilterProperties[HtmlEdit.PropertyNames.Title] = null;
                    this.mUILengthEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = null;
                    this.mUILengthEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "name=\"length\" id=\"length\" style=\"width: ";
                    this.mUILengthEdit.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "1";
                    this.mUILengthEdit.WindowTitles.Add("BMI");
                    #endregion
                }
                return this.mUILengthEdit;
            }
        }
        
        public HtmlEdit UIWeightEdit
        {
            get
            {
                if ((this.mUIWeightEdit == null))
                {
                    this.mUIWeightEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUIWeightEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "weight";
                    this.mUIWeightEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "weight";
                    this.mUIWeightEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = null;
                    this.mUIWeightEdit.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mUIWeightEdit.FilterProperties[HtmlEdit.PropertyNames.Title] = null;
                    this.mUIWeightEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = null;
                    this.mUIWeightEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "name=\"weight\" id=\"weight\" style=\"width: ";
                    this.mUIWeightEdit.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "2";
                    this.mUIWeightEdit.WindowTitles.Add("BMI");
                    #endregion
                }
                return this.mUIWeightEdit;
            }
        }
        
        public HtmlEdit UIDateEdit
        {
            get
            {
                if ((this.mUIDateEdit == null))
                {
                    this.mUIDateEdit = new HtmlEdit(this);
                    #region Search Criteria
                    this.mUIDateEdit.SearchProperties[HtmlEdit.PropertyNames.Id] = "measurementDate";
                    this.mUIDateEdit.SearchProperties[HtmlEdit.PropertyNames.Name] = "date";
                    this.mUIDateEdit.FilterProperties[HtmlEdit.PropertyNames.LabeledBy] = null;
                    this.mUIDateEdit.FilterProperties[HtmlEdit.PropertyNames.Type] = "SINGLELINE";
                    this.mUIDateEdit.FilterProperties[HtmlEdit.PropertyNames.Title] = null;
                    this.mUIDateEdit.FilterProperties[HtmlEdit.PropertyNames.Class] = "hasDatepicker";
                    this.mUIDateEdit.FilterProperties[HtmlEdit.PropertyNames.ControlDefinition] = "name=\"date\" class=\"hasDatepicker\" id=\"me";
                    this.mUIDateEdit.FilterProperties[HtmlEdit.PropertyNames.TagInstance] = "3";
                    this.mUIDateEdit.WindowTitles.Add("BMI");
                    #endregion
                }
                return this.mUIDateEdit;
            }
        }
        
        public UIBodyPane UIBodyPane
        {
            get
            {
                if ((this.mUIBodyPane == null))
                {
                    this.mUIBodyPane = new UIBodyPane(this);
                }
                return this.mUIBodyPane;
            }
        }
        
        public HtmlButton UIAddMeasurementButton
        {
            get
            {
                if ((this.mUIAddMeasurementButton == null))
                {
                    this.mUIAddMeasurementButton = new HtmlButton(this);
                    #region Search Criteria
                    this.mUIAddMeasurementButton.SearchProperties[HtmlButton.PropertyNames.Id] = "btnAddMeasurement";
                    this.mUIAddMeasurementButton.SearchProperties[HtmlButton.PropertyNames.Name] = null;
                    this.mUIAddMeasurementButton.SearchProperties[HtmlButton.PropertyNames.DisplayText] = "AddMeasurement";
                    this.mUIAddMeasurementButton.SearchProperties[HtmlButton.PropertyNames.Type] = "submit";
                    this.mUIAddMeasurementButton.FilterProperties[HtmlButton.PropertyNames.Title] = null;
                    this.mUIAddMeasurementButton.FilterProperties[HtmlButton.PropertyNames.Class] = null;
                    this.mUIAddMeasurementButton.FilterProperties[HtmlButton.PropertyNames.ControlDefinition] = "id=\"btnAddMeasurement\" style=\"float: lef";
                    this.mUIAddMeasurementButton.FilterProperties[HtmlButton.PropertyNames.TagInstance] = "1";
                    this.mUIAddMeasurementButton.WindowTitles.Add("BMI");
                    #endregion
                }
                return this.mUIAddMeasurementButton;
            }
        }
        #endregion
        
        #region Fields
        private HtmlEdit mUILengthEdit;
        
        private HtmlEdit mUIWeightEdit;
        
        private HtmlEdit mUIDateEdit;
        
        private UIBodyPane mUIBodyPane;
        
        private HtmlButton mUIAddMeasurementButton;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class UIBodyPane : HtmlDiv
    {
        
        public UIBodyPane(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDiv.PropertyNames.Id] = "body";
            this.SearchProperties[HtmlDiv.PropertyNames.Name] = null;
            this.FilterProperties[HtmlDiv.PropertyNames.InnerText] = "Length\r\nWeight\r\nMeasured on\r\n\r\nAddMeasur";
            this.FilterProperties[HtmlDiv.PropertyNames.Title] = null;
            this.FilterProperties[HtmlDiv.PropertyNames.Class] = null;
            this.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "id=\"body\"";
            this.FilterProperties[HtmlDiv.PropertyNames.TagInstance] = "3";
            this.WindowTitles.Add("BMI");
            #endregion
        }
        
        #region Properties
        public UIItemTable UIItemTable
        {
            get
            {
                if ((this.mUIItemTable == null))
                {
                    this.mUIItemTable = new UIItemTable(this);
                }
                return this.mUIItemTable;
            }
        }
        #endregion
        
        #region Fields
        private UIItemTable mUIItemTable;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class UIItemTable : HtmlTable
    {
        
        public UIItemTable(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlTable.PropertyNames.Id] = null;
            this.SearchProperties[HtmlTable.PropertyNames.Name] = null;
            this.FilterProperties[HtmlTable.PropertyNames.InnerText] = "Length\r\nWeight\r\nMeasured on";
            this.FilterProperties[HtmlTable.PropertyNames.ControlDefinition] = "style=\"margin-left: 3em;\"";
            this.FilterProperties[HtmlTable.PropertyNames.RowCount] = "3";
            this.FilterProperties[HtmlTable.PropertyNames.ColumnCount] = "3";
            this.FilterProperties[HtmlTable.PropertyNames.Class] = null;
            this.FilterProperties[HtmlTable.PropertyNames.TagInstance] = "1";
            this.WindowTitles.Add("BMI");
            #endregion
        }
        
        #region Properties
        public HtmlCell UIItemCell
        {
            get
            {
                if ((this.mUIItemCell == null))
                {
                    this.mUIItemCell = new HtmlCell(this);
                    #region Search Criteria
                    this.mUIItemCell.SearchProperties[HtmlCell.PropertyNames.Id] = null;
                    this.mUIItemCell.SearchProperties[HtmlCell.PropertyNames.Name] = null;
                    this.mUIItemCell.SearchProperties[HtmlCell.PropertyNames.MaxDepth] = "3";
                    this.mUIItemCell.SearchProperties[HtmlCell.PropertyNames.InnerText] = null;
                    this.mUIItemCell.FilterProperties[HtmlCell.PropertyNames.ControlDefinition] = "style=\"width: 2em;\"";
                    this.mUIItemCell.FilterProperties[HtmlCell.PropertyNames.RowIndex] = "2";
                    this.mUIItemCell.FilterProperties[HtmlCell.PropertyNames.ColumnIndex] = "1";
                    this.mUIItemCell.FilterProperties[HtmlCell.PropertyNames.Class] = null;
                    this.mUIItemCell.FilterProperties[HtmlCell.PropertyNames.TagInstance] = "8";
                    this.mUIItemCell.WindowTitles.Add("BMI");
                    #endregion
                }
                return this.mUIItemCell;
            }
        }
        #endregion
        
        #region Fields
        private HtmlCell mUIItemCell;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class UIBMIDocument1 : HtmlDocument
    {
        
        public UIBMIDocument1(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDocument.PropertyNames.Id] = null;
            this.SearchProperties[HtmlDocument.PropertyNames.RedirectingPage] = "False";
            this.SearchProperties[HtmlDocument.PropertyNames.FrameDocument] = "False";
            this.FilterProperties[HtmlDocument.PropertyNames.Title] = "BMI";
            this.FilterProperties[HtmlDocument.PropertyNames.AbsolutePath] = "/BMI/AddMeasurement";
            this.FilterProperties[HtmlDocument.PropertyNames.PageUrl] = @"http://localhost:15444/BMI/AddMeasurement?socialSecurityNumber=10&birthDate=01%2F01%2F0001%2000%3A00%3A00&gender=Male&date=01%2F01%2F0001%2000%3A00%3A00&length=0&weight=0&bmi=0&state=Measurement&socialSecurityNumberVisible=False&birthDateVisible=False&genderVisible=False&bmiVisible=False";
            this.WindowTitles.Add("BMI");
            #endregion
        }
        
        #region Properties
        public UIBodyPane1 UIBodyPane
        {
            get
            {
                if ((this.mUIBodyPane == null))
                {
                    this.mUIBodyPane = new UIBodyPane1(this);
                }
                return this.mUIBodyPane;
            }
        }
        #endregion
        
        #region Fields
        private UIBodyPane1 mUIBodyPane;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "12.0.31101.0")]
    public class UIBodyPane1 : HtmlDiv
    {
        
        public UIBodyPane1(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[HtmlDiv.PropertyNames.Id] = "body";
            this.SearchProperties[HtmlDiv.PropertyNames.Name] = null;
            this.FilterProperties[HtmlDiv.PropertyNames.InnerText] = "New measurement for person with social s";
            this.FilterProperties[HtmlDiv.PropertyNames.Title] = null;
            this.FilterProperties[HtmlDiv.PropertyNames.Class] = null;
            this.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "id=\"body\"";
            this.FilterProperties[HtmlDiv.PropertyNames.TagInstance] = "3";
            this.WindowTitles.Add("BMI");
            #endregion
        }
        
        #region Properties
        public HtmlDiv UINewmeasurementforperPane
        {
            get
            {
                if ((this.mUINewmeasurementforperPane == null))
                {
                    this.mUINewmeasurementforperPane = new HtmlDiv(this);
                    #region Search Criteria
                    this.mUINewmeasurementforperPane.SearchProperties[HtmlDiv.PropertyNames.Id] = null;
                    this.mUINewmeasurementforperPane.SearchProperties[HtmlDiv.PropertyNames.Name] = null;
                    this.mUINewmeasurementforperPane.FilterProperties[HtmlDiv.PropertyNames.InnerText] = "New measurement for person with social s";
                    this.mUINewmeasurementforperPane.FilterProperties[HtmlDiv.PropertyNames.Title] = null;
                    this.mUINewmeasurementforperPane.FilterProperties[HtmlDiv.PropertyNames.Class] = "messageField";
                    this.mUINewmeasurementforperPane.FilterProperties[HtmlDiv.PropertyNames.ControlDefinition] = "class=\"messageField\"";
                    this.mUINewmeasurementforperPane.FilterProperties[HtmlDiv.PropertyNames.TagInstance] = "5";
                    this.mUINewmeasurementforperPane.WindowTitles.Add("BMI");
                    #endregion
                }
                return this.mUINewmeasurementforperPane;
            }
        }
        #endregion
        
        #region Fields
        private HtmlDiv mUINewmeasurementforperPane;
        #endregion
    }
}
