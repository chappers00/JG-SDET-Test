﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.1.0.0
//      SpecFlow Generator Version:2.0.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace JustGivingDitTest.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("Make some donations", Description="As a really good interview candidate\r\nI want to make lots of donations to the tes" +
        "t charity\r\nSo that you guys give me the job", SourceFile="Features\\GiveLoadsOfMoney.feature", SourceLine=0)]
    public partial class MakeSomeDonationsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GiveLoadsOfMoney.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Make some donations", "As a really good interview candidate\r\nI want to make lots of donations to the tes" +
                    "t charity\r\nSo that you guys give me the job", ProgrammingLanguage.CSharp, ((string[])(null)));
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
        
        public virtual void FeatureBackground()
        {
#line 6
#line 7
 testRunner.Given("I have the home page open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.Then("the \'Donate\' section is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 9
 testRunner.And("the header should be \'Donate to The Demo Charity (JustGiving Demo)\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Make a 30 pound donation", SourceLine=10)]
        public virtual void MakeA30PoundDonation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Make a 30 pound donation", ((string[])(null)));
#line 11
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 12
 testRunner.When("I press the continue button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.Then("the \'Identity\' section is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
 testRunner.And("a donation by \'Anonymous\' is created with a message of \'(no message)\' and amount " +
                    "of \'£30\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Change currency to euros", SourceLine=15)]
        public virtual void ChangeCurrencyToEuros()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change currency to euros", ((string[])(null)));
#line 16
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 17
 testRunner.Given("I have changed currency to \'EUR\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
 testRunner.When("I press the continue button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.Then("the \'Identity\' section is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
 testRunner.And("a donation by \'Anonymous\' is created with a message of \'(no message)\' and amount " +
                    "of \'€30\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("Make a twenty euro donation", SourceLine=21)]
        public virtual void MakeATwentyEuroDonation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Make a twenty euro donation", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 23
 testRunner.Given("I have entered an amount of \'20\' \'EUR\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
 testRunner.Then("a donation by \'Anonymous\' is created with a message of \'(no message)\' and amount " +
                    "of \'€20\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
 testRunner.When("I enter an email address of \'hire@me.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
 testRunner.And("I enter a password of \'hireme\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("I pay with a \'Visa Credit Card\' with number \'4111-1111-1111-1111\' expiry \'01\' \'20" +
                    "20\' and name \'My Name\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.TestRunCleanup()]
        public virtual void TestRunCleanup()
        {
            TechTalk.SpecFlow.TestRunnerManager.GetTestRunner().OnTestRunEnd();
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.1.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Make some donations")]
    public partial class MakeSomeDonationsFeature_NUnit
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GiveLoadsOfMoney.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Make some donations", "As a really good interview candidate\r\nI want to make lots of donations to the tes" +
                    "t charity\r\nSo that you guys give me the job", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
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
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 6
#line 7
 testRunner.Given("I have the home page open", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 8
 testRunner.Then("the \'Donate\' section is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 9
 testRunner.And("the header should be \'Donate to The Demo Charity (JustGiving Demo)\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Make a 30 pound donation")]
        public virtual void MakeA30PoundDonation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Make a 30 pound donation", ((string[])(null)));
#line 11
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 12
 testRunner.When("I press the continue button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
 testRunner.Then("the \'Identity\' section is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
 testRunner.And("a donation by \'Anonymous\' is created with a message of \'(no message)\' and amount " +
                    "of \'£30\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Change currency to euros")]
        public virtual void ChangeCurrencyToEuros()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Change currency to euros", ((string[])(null)));
#line 16
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 17
 testRunner.Given("I have changed currency to \'EUR\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
 testRunner.When("I press the continue button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 19
 testRunner.Then("the \'Identity\' section is displayed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 20
 testRunner.And("a donation by \'Anonymous\' is created with a message of \'(no message)\' and amount " +
                    "of \'€30\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Make a twenty euro donation")]
        public virtual void MakeATwentyEuroDonation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Make a twenty euro donation", ((string[])(null)));
#line 22
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 23
 testRunner.Given("I have entered an amount of \'20\' \'EUR\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 24
 testRunner.Then("a donation by \'Anonymous\' is created with a message of \'(no message)\' and amount " +
                    "of \'€20\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 25
 testRunner.When("I enter an email address of \'hire@me.com\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 26
 testRunner.And("I enter a password of \'hireme\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
 testRunner.And("I pay with a \'Visa Credit Card\' with number \'4111-1111-1111-1111\' expiry \'01\' \'20" +
                    "20\' and name \'My Name\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion