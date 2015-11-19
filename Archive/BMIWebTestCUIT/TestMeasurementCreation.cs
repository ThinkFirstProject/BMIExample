using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace BMIWebTestCUIT
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class TestMeasurementCreation
    {
        [TestMethod]
        public void A_measurement_is_created_with_valid_weight_and_date_and_a_length_which_is_the_minimum_length()
        {
            uiMap.OpenCreateNewPersonWindow();
            uiMap.EnterValidWeightAndDate();
            uiMap.EnterMinimalLength();
            uiMap.SubmitNewPerson();
            uiMap.ValidateNewPersonSuccess();
            //Setup for next test method. Normally instance should be closed, but bypassed this way for timesavings.
            uiMap.CancelOperation();
        }

        [TestMethod]
        public void An_exception_is_thrown_when_A_measurement_is_created_with_valid_weight_and_date_and_a_to_small_length()
        {
            uiMap.OpenCreateNewPersonWindow();
            uiMap.EnterValidWeightAndDate();
            uiMap.EnterToSmallLength();
            uiMap.SubmitNewPerson();
            uiMap.ValidateNewPersonFailed();
            uiMap.CloseApplication();
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //    // For more information on generated code, see http://go.microsoft.com/fwlink/?LinkId=179463
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return _testContextInstance;
            }
            set
            {
                _testContextInstance = value;
            }
        }

        private TestContext _testContextInstance;

        public UIMap uiMap
        {
            get
            {
                if ((_map == null))
                {
                    _map = new UIMap();
                }

                return _map;
            }
        }

        private UIMap _map;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
