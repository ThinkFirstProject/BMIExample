﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34014
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Service
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("Register Amnesis Data", Description="\tAs a user\r\n\tI can register anamnesis data of a person\r\n\tIn order to calculate th" +
        "e person’s bmi", SourceFile="RegisterAnamnesisDataSpecs.feature", SourceLine=0)]
    public partial class RegisterAmnesisDataFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "RegisterAnamnesisDataSpecs.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Register Amnesis Data", "\tAs a user\r\n\tI can register anamnesis data of a person\r\n\tIn order to calculate th" +
                    "e person’s bmi", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("A measurement with new anamnesis data can be added", SourceLine=6)]
        public virtual void AMeasurementWithNewAnamnesisDataCanBeAdded()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A measurement with new anamnesis data can be added", ((string[])(null)));
#line 7
    this.ScenarioSetup(scenarioInfo);
#line 8
        testRunner.Given("an existing person", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
        testRunner.When("I provide as length 180", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
        testRunner.And("I provide as weight 75000", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
        testRunner.And("I provide as date 12-12-2012", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
        testRunner.And("I try to add the measurement to this person", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
        testRunner.Then("a new measurement is added to the anamnesis history of this person with the data " +
                    "provided", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void AnErrorMessageIsGivenWhenAnyFieldOfTheAnamnesisDataIsInvalid(string field, string invalidValue, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("An error message is given when any field of the anamnesis data is invalid", exampleTags);
#line 16
    this.ScenarioSetup(scenarioInfo);
#line 17
        testRunner.Given("an existing person", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
        testRunner.When(string.Format("I provide {0} as {1}", invalidValue, field), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
  testRunner.And("all other data is valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
        testRunner.And("I try to add the measurement to this person", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
        testRunner.Then("an error message is given", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("An error message is given when any field of the anamnesis data is invalid, length" +
            "", SourceLine=23)]
        public virtual void AnErrorMessageIsGivenWhenAnyFieldOfTheAnamnesisDataIsInvalid_Length()
        {
            this.AnErrorMessageIsGivenWhenAnyFieldOfTheAnamnesisDataIsInvalid("length", "49", ((string[])(null)));
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("An error message is given when any field of the anamnesis data is invalid, weight" +
            "", SourceLine=24)]
        public virtual void AnErrorMessageIsGivenWhenAnyFieldOfTheAnamnesisDataIsInvalid_Weight()
        {
            this.AnErrorMessageIsGivenWhenAnyFieldOfTheAnamnesisDataIsInvalid("weight", "299", ((string[])(null)));
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("An error message is given when any field of the anamnesis data is invalid, date", SourceLine=25)]
        public virtual void AnErrorMessageIsGivenWhenAnyFieldOfTheAnamnesisDataIsInvalid_Date()
        {
            this.AnErrorMessageIsGivenWhenAnyFieldOfTheAnamnesisDataIsInvalid("date", "10-10-3016", ((string[])(null)));
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("An error message is given if a measurement is already registered for the current " +
            "date and time", SourceLine=28)]
        public virtual void AnErrorMessageIsGivenIfAMeasurementIsAlreadyRegisteredForTheCurrentDateAndTime()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("An error message is given if a measurement is already registered for the current " +
                    "date and time", ((string[])(null)));
#line 29
    this.ScenarioSetup(scenarioInfo);
#line 30
     testRunner.Given("an existing person", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
        testRunner.And("the person has a measurement on 9-9-2009", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
        testRunner.When("I provide as date 9-9-2009", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 33
        testRunner.And("all other data is valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
        testRunner.And("I try to add the measurement to this person", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
        testRunner.Then("an error message is given", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.TestRunCleanup()]
        public virtual void TestRunCleanup()
        {
TechTalk.SpecFlow.TestRunnerManager.GetTestRunner().OnTestRunEnd();
        }
    }
}
#pragma warning restore
#endregion
