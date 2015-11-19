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
namespace Specflow_Unit
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("Person", SourceFile="PersonSpecs.feature", SourceLine=0)]
    public partial class PersonFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "PersonSpecs.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Person", "", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        [TechTalk.SpecRun.ScenarioAttribute("a person can be created", SourceLine=2)]
        public virtual void APersonCanBeCreated()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("a person can be created", ((string[])(null)));
#line 3
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Social security number",
                        "Birthdate",
                        "Gender"});
            table1.AddRow(new string[] {
                        "10",
                        "1-1-2001",
                        "Male"});
#line 4
 testRunner.Given("valid personal data is provided", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Length",
                        "Weight",
                        "Date"});
            table2.AddRow(new string[] {
                        "180",
                        "68000",
                        "2-1-2001"});
#line 7
 testRunner.And("a valid measurement is provided", ((string)(null)), table2, "And ");
#line 10
 testRunner.When("i try to create a person object", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
 testRunner.Then("the object is created and contains the provided data", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void WhenCreatingAPersonTheSocialSecurityNumberShouldBeValid(string value, string reason, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When creating a person, the social security number should be valid", exampleTags);
#line 13
this.ScenarioSetup(scenarioInfo);
#line 14
 testRunner.Given(string.Format("a social security number {0} is enterd which is invalid because {1}", value, reason), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.And("all other parameters are valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.When("i try to create a person object", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 17
 testRunner.Then("the object should throw an invalid argument exception", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("When creating a person, the social security number should be valid, null", SourceLine=19)]
        public virtual void WhenCreatingAPersonTheSocialSecurityNumberShouldBeValid_Null()
        {
            this.WhenCreatingAPersonTheSocialSecurityNumberShouldBeValid("null", "null value", ((string[])(null)));
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("When creating a person, the social security number should be valid, empty", SourceLine=20)]
        public virtual void WhenCreatingAPersonTheSocialSecurityNumberShouldBeValid_Empty()
        {
            this.WhenCreatingAPersonTheSocialSecurityNumberShouldBeValid("empty", "empty value", ((string[])(null)));
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("When creating a person, the measurement can\'t be null", SourceLine=22)]
        public virtual void WhenCreatingAPersonTheMeasurementCanTBeNull()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When creating a person, the measurement can\'t be null", ((string[])(null)));
#line 23
this.ScenarioSetup(scenarioInfo);
#line 24
 testRunner.Given("a measurement which is null", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 25
 testRunner.And("all other parameters are valid", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 26
 testRunner.When("i try to create a person object", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 27
 testRunner.Then("the object should throw an invalid argument exception", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("the social security number can be changed", SourceLine=28)]
        public virtual void TheSocialSecurityNumberCanBeChanged()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("the social security number can be changed", ((string[])(null)));
#line 29
this.ScenarioSetup(scenarioInfo);
#line 30
 testRunner.Given("a valid person object is generated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 31
 testRunner.When("i try to change the social security number to the value 20", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 32
 testRunner.Then("the person object should contain the provided social security number", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void WhenChangingTheSocialSecurityNumberTheProvidedSocialSecurityNumberShouldBeValid(string value, string reason, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When changing the social security number, the provided social security number sho" +
                    "uld be valid", exampleTags);
#line 34
this.ScenarioSetup(scenarioInfo);
#line 35
 testRunner.Given("a valid person object is generated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 36
 testRunner.When(string.Format("i try to change the social security number to {0} which is invalid because {1}", value, reason), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 37
 testRunner.Then("the object should throw an invalid argument exception", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("When changing the social security number, the provided social security number sho" +
            "uld be valid, null", SourceLine=39)]
        public virtual void WhenChangingTheSocialSecurityNumberTheProvidedSocialSecurityNumberShouldBeValid_Null()
        {
            this.WhenChangingTheSocialSecurityNumberTheProvidedSocialSecurityNumberShouldBeValid("null", "null value", ((string[])(null)));
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("When changing the social security number, the provided social security number sho" +
            "uld be valid, empty", SourceLine=40)]
        public virtual void WhenChangingTheSocialSecurityNumberTheProvidedSocialSecurityNumberShouldBeValid_Empty()
        {
            this.WhenChangingTheSocialSecurityNumberTheProvidedSocialSecurityNumberShouldBeValid("empty", "empty value", ((string[])(null)));
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("the birthdate can be changed", SourceLine=43)]
        public virtual void TheBirthdateCanBeChanged()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("the birthdate can be changed", ((string[])(null)));
#line 44
this.ScenarioSetup(scenarioInfo);
#line 45
 testRunner.Given("a valid person object is generated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 46
 testRunner.When("i try to change the birthdate to 02-01-2005", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
 testRunner.Then("the object should be updated with the new birthdate", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("the gender can be modified", SourceLine=48)]
        public virtual void TheGenderCanBeModified()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("the gender can be modified", ((string[])(null)));
#line 49
this.ScenarioSetup(scenarioInfo);
#line 50
 testRunner.Given("a valid person object is generated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 51
 testRunner.When("i try to change the gender to Female", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 52
 testRunner.Then("the object should be updated with the new gender", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("a new valid measurement can be added", SourceLine=53)]
        public virtual void ANewValidMeasurementCanBeAdded()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("a new valid measurement can be added", ((string[])(null)));
#line 54
this.ScenarioSetup(scenarioInfo);
#line 55
 testRunner.Given("a valid person object is generated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 56
 testRunner.And("a new valid measurement is provided", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.When("i try to add the new measurement", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 58
 testRunner.Then("the object should contain the new measurement", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("When adding a new measurement, the provide measurement can\'t be null", SourceLine=59)]
        public virtual void WhenAddingANewMeasurementTheProvideMeasurementCanTBeNull()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("When adding a new measurement, the provide measurement can\'t be null", ((string[])(null)));
#line 60
this.ScenarioSetup(scenarioInfo);
#line 61
 testRunner.Given("a valid person object is generated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 62
 testRunner.And("a measurement which is null", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.When("i try to add the new measurement", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 64
 testRunner.Then("the object should throw an invalid argument exception", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("The last measurement can be removed", SourceLine=65)]
        public virtual void TheLastMeasurementCanBeRemoved()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The last measurement can be removed", ((string[])(null)));
#line 66
this.ScenarioSetup(scenarioInfo);
#line 67
 testRunner.Given("a valid person object is generated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 68
 testRunner.And("a new valid measurement is added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 69
 testRunner.When("i try to remove the last measurement", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 70
 testRunner.Then("the measurement should be removed from the object", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("The last measurement can be fetched", SourceLine=71)]
        public virtual void TheLastMeasurementCanBeFetched()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("The last measurement can be fetched", ((string[])(null)));
#line 72
this.ScenarioSetup(scenarioInfo);
#line 73
 testRunner.Given("a valid person object is generated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 74
 testRunner.And("a new valid measurement is added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.When("i try to fetch the last measurement", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
 testRunner.Then("the last measurement is returned", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        public virtual void APersonObjectCanBeCheckedForEqualityToAnotherPersonObject(string value, string circumstance, string result, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("A person object can be checked for equality to another person object", exampleTags);
#line 78
this.ScenarioSetup(scenarioInfo);
#line 79
 testRunner.Given("a valid person object is generated with social security number 10", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 80
 testRunner.And(string.Format("another valid person object is generated with social security number {0}, which i" +
                        "s {1}", value, circumstance), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.When("the objects are compared for equality", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 82
 testRunner.Then(string.Format("the returned result should be {0}", result), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("A person object can be checked for equality to another person object, 1", SourceLine=84)]
        public virtual void APersonObjectCanBeCheckedForEqualityToAnotherPersonObject_1()
        {
            this.APersonObjectCanBeCheckedForEqualityToAnotherPersonObject("1", "a lower value", "false", ((string[])(null)));
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("A person object can be checked for equality to another person object, 10", SourceLine=85)]
        public virtual void APersonObjectCanBeCheckedForEqualityToAnotherPersonObject_10()
        {
            this.APersonObjectCanBeCheckedForEqualityToAnotherPersonObject("10", "the same value", "true", ((string[])(null)));
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("A person object can be checked for equality to another person object, 20", SourceLine=86)]
        public virtual void APersonObjectCanBeCheckedForEqualityToAnotherPersonObject_20()
        {
            this.APersonObjectCanBeCheckedForEqualityToAnotherPersonObject("20", "a higher value", "false", ((string[])(null)));
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("the BMI is calculated of the most recent measurement", SourceLine=88)]
        public virtual void TheBMIIsCalculatedOfTheMostRecentMeasurement()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("the BMI is calculated of the most recent measurement", ((string[])(null)));
#line 89
this.ScenarioSetup(scenarioInfo);
#line 90
 testRunner.Given("a valid person object is generated", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 91
 testRunner.And("a new valid measurement is added", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 92
 testRunner.When("i try to calculate the BMI of the person", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 93
 testRunner.Then("the BMI result is returned for the last enterd measurement", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
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