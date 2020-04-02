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
namespace NowPowAutomaiton.Regression.CustomerAdminUI
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.0.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("CommRxUsers")]
    public partial class CommRxUsersFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "CommRxUsers.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CommRxUsers", null, ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void FeatureBackground()
        {
#line 5
#line 6
testRunner.Given("\'CPT5\' user is logged in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("03.Take Action (Deactivate)")]
        [NUnit.Framework.CategoryAttribute("regression")]
        [NUnit.Framework.TestCaseAttribute("deactivate", "deactivate user", null)]
        public virtual void _03_TakeActionDeactivate(string action, string modal, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "regression"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("03.Take Action (Deactivate)", null, @__tags);
#line 9
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line 10
 testRunner.When(string.Format("user selects {0}", action), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 11
 testRunner.Then(string.Format("{0} is displayed", modal), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("04.Take Action (Activate)")]
        [NUnit.Framework.TestCaseAttribute("activate", "activate user", null)]
        public virtual void _04_TakeActionActivate(string action, string modal, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("04.Take Action (Activate)", null, exampleTags);
#line 18
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line 19
 testRunner.When(string.Format("user chooses {0}", action), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
 testRunner.Then(string.Format("{0} is displayed", modal), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("02.Take Action (Resend Password)")]
        [NUnit.Framework.TestCaseAttribute("resend password", "resend password", null)]
        public virtual void _02_TakeActionResendPassword(string action, string modal, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("02.Take Action (Resend Password)", null, exampleTags);
#line 28
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line 29
 testRunner.When(string.Format("user clicks {0}", action), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
 testRunner.Then(string.Format("{0} is displayed", modal), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("01.Take Action (View/Edit)")]
        [NUnit.Framework.TestCaseAttribute("view/edit", "view/edit user", null)]
        public virtual void _01_TakeActionViewEdit(string action, string modal, string[] exampleTags)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("01.Take Action (View/Edit)", null, exampleTags);
#line 37
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 5
this.FeatureBackground();
#line 38
 testRunner.When(string.Format("I select {0}", action), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
 testRunner.Then(string.Format("{0} is displayed", modal), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
