using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace Specflow_Unit
{
    [Binding]
    public class Common
    {
        [Then(@"the object should throw an invalid argument exception")]
        public void ThenTheObjectShouldThrowAnArgumentException()
        {
            Assert.IsTrue(ScenarioContext.Current.ContainsKey("Error"));

            Exception ex = ScenarioContext.Current.Get<Exception>("Error");
            
            Assert.IsNotNull(ex);
            Assert.IsInstanceOfType(ex, typeof(ArgumentException));
        }
    }
}
