// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:3.0.0.0
//      SpecFlow Generator Version:3.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace NowPowAutomaiton.Regression
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Patient")]
    [NUnit.Framework.CategoryAttribute("regression")]
    public partial class PatientFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Patient.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Patient", null, ProgrammingLanguage.CSharp, new string[] {
                        "regression"});
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("01.  Editing Patient Contact Information")]
        public virtual void _01_EditingPatientContactInformation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01.  Editing Patient Contact Information", null, ((string[])(null)));
#line 5
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 6
   testRunner.Given("\'CPT\' user is logged in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 7
   testRunner.And("user chooses tab \'Patient\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 8
   testRunner.And("user chooses patient card", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 9
   testRunner.When("user makes a choice to \'Edit Profile\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
   testRunner.And("user expands \'Contact Information\' section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 11
   testRunner.And("user edits \'Contact Information\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
   testRunner.Then("edited contact information is displayed in patient\'s \'Consent\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("04.Verify Patient Search by MRN")]
        public virtual void _04_VerifyPatientSearchByMRN()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04.Verify Patient Search by MRN", null, ((string[])(null)));
#line 32
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 33
testRunner.Given("\'CPT\' user is logged in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 34
   testRunner.And("user chooses tab \'Patient\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
   testRunner.When("user searches patient by \'MRN\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 36
   testRunner.Then("patient matching mrn is dispayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("05.Verify invalid name/mrn search")]
        public virtual void _05_VerifyInvalidNameMrnSearch()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("05.Verify invalid name/mrn search", null, ((string[])(null)));
#line 38
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 39
testRunner.Given("\'CPT\' user is logged in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 40
   testRunner.And("user chooses tab \'Patient\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 41
   testRunner.When("user input invalid name", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 42
   testRunner.Then("no results are dispayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("06. Adding a Patient Engagement Interaction")]
        public virtual void _06_AddingAPatientEngagementInteraction()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("06. Adding a Patient Engagement Interaction", null, ((string[])(null)));
#line 44
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 45
testRunner.Given("\'CPT\' user is logged in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 46
   testRunner.And("user chooses tab \'Patient\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
   testRunner.And("user chooses patient card", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 48
   testRunner.When("user adds a new interaction with a note", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 49
   testRunner.Then("new interaction is created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 50
   testRunner.And("user chooses \'NowPow\' logo", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
   testRunner.Then("patient card is listed under \'Recent Patients\' section", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion