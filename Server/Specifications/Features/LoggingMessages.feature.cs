﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.34209
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SystemDot.MessageRouteInspector.Server.Specifications.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class LoggingMessagesFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "LoggingMessages.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "LoggingMessages", "As a message logger\r\nI want to log the fact that a message has been sent\r\nSo that" +
                    " I can see it in the inspector", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "LoggingMessages")))
            {
                SystemDot.MessageRouteInspector.Server.Specifications.Features.LoggingMessagesFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
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
 testRunner.Given("I have setup the server with a limit of the last 2 routes saved", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("One route from same machine and same thread one command")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LoggingMessages")]
        public virtual void OneRouteFromSameMachineAndSameThreadOneCommand()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("One route from same machine and same thread one command", ((string[])(null)));
#line 9
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 10
    testRunner.Given("I have logged command processing for the message \'root\' from machine \'TestMachine" +
                    "\' on thread 1 dated \'09/21/1975 00:00:01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 11
    testRunner.And("I have logged message processed from machine \'TestMachine\' on thread 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 12
    testRunner.When("I get all routes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 13
    testRunner.Then("there should only be one route", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 14
 testRunner.And("that route should have a valid id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 15
 testRunner.And("only one message in the route", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.And("the root message in the route should be the same as that message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.And("that route should be dated \'1975-09-21 00:00:01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 18
    testRunner.And("that route should be from machine \'TestMachine\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 19
 testRunner.And("that message should have a valid id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 20
 testRunner.And("that message should have the name \'root\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 21
 testRunner.And("that message should have the type \'Command\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 22
 testRunner.And("that message should have a close branch count of 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("One route from same machine and same thread one event")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LoggingMessages")]
        public virtual void OneRouteFromSameMachineAndSameThreadOneEvent()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("One route from same machine and same thread one event", ((string[])(null)));
#line 24
 this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 25
    testRunner.Given("I have logged event processing for the message \'root\' from machine \'TestMachine\' " +
                    "on thread 1 dated \'09/21/1975 00:00:01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 26
    testRunner.And("I have logged message processed from machine \'TestMachine\' on thread 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 27
    testRunner.When("I get all routes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 28
    testRunner.Then("there should only be one route", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 29
 testRunner.And("only one message in the route", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 30
 testRunner.And("that route should have a valid id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("the root message in the route should be the same as that message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.And("that route should be dated \'1975-09-21 00:00:01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 33
 testRunner.And("that route should be from machine \'TestMachine\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 34
 testRunner.And("only one message in the route", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 35
 testRunner.And("the root message in the route should be the same as that message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 36
 testRunner.And("that message should have a valid id", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.And("that message should have the name \'root\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.And("that message should have the type \'Event\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 39
 testRunner.And("that message should have a close branch count of 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("One route from same machine and same thread message in message")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LoggingMessages")]
        public virtual void OneRouteFromSameMachineAndSameThreadMessageInMessage()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("One route from same machine and same thread message in message", ((string[])(null)));
#line 41
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 42
 testRunner.Given("I have logged command processing for the message \'first\' from machine \'TestMachin" +
                    "e\' on thread 1 dated \'09/21/1975 00:00:01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 43
    testRunner.And("I have logged command processing for the message \'second\' from machine \'TestMachi" +
                    "ne\' on thread 1 dated \'09/21/1975 00:00:02\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 44
    testRunner.And("I have logged message processed from machine \'TestMachine\' on thread 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
    testRunner.And("I have logged message processed from machine \'TestMachine\' on thread 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
    testRunner.When("I get all routes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
 testRunner.Then("there should only be one route", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
 testRunner.And("there should a message at index 0 of the route\'s messages", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 49
 testRunner.And("that message should have the name \'first\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 50
 testRunner.And("that message should have a close branch count of 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 51
 testRunner.And("there should a message at index 1 of the route\'s messages", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 52
 testRunner.And("that message should have the name \'second\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 53
 testRunner.And("that message should have a close branch count of 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Two routes from same machine and same thread")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LoggingMessages")]
        public virtual void TwoRoutesFromSameMachineAndSameThread()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Two routes from same machine and same thread", ((string[])(null)));
#line 55
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 56
 testRunner.Given("I have logged command processing for the message \'firstRouteFirstMessage\' from ma" +
                    "chine \'TestMachine\' on thread 1 dated \'09/21/1975 00:00:01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 57
    testRunner.And("I have logged message processed from machine \'TestMachine\' on thread 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
    testRunner.And("I have logged command processing for the message \'secondRouteFirstMessage\' from m" +
                    "achine \'TestMachine\' on thread 1 dated \'09/21/1975 00:00:02\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
    testRunner.And("I have logged message processed from machine \'TestMachine\' on thread 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
    testRunner.When("I get all routes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 61
 testRunner.Then("there should be a route at index 0 of all the routes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 62
 testRunner.And("only one message in the route", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 63
 testRunner.And("that message should have the name \'secondRouteFirstMessage\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.And("that message should have a close branch count of 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 65
 testRunner.And("there should be a route at index 1 of all the routes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 66
 testRunner.And("only one message in the route", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 67
 testRunner.And("that message should have the name \'firstRouteFirstMessage\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 68
 testRunner.And("that message should have a close branch count of 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Two routes from same machine but different threads")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LoggingMessages")]
        public virtual void TwoRoutesFromSameMachineButDifferentThreads()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Two routes from same machine but different threads", ((string[])(null)));
#line 70
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 71
 testRunner.Given("I have logged command processing for the message \'firstRouteFirstMessage\' from ma" +
                    "chine \'TestMachine\' on thread 1 dated \'09/21/1975 00:00:01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 72
    testRunner.And("I have logged command processing for the message \'secondRouteFirstMessage\' from m" +
                    "achine \'TestMachine\' on thread 2 dated \'09/21/1975 00:00:02\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
    testRunner.And("I have logged message processed from machine \'TestMachine\' on thread 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
    testRunner.And("I have logged message processed from machine \'TestMachine\' on thread 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
    testRunner.When("I get all routes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 76
 testRunner.Then("there should be a route at index 0 of all the routes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 77
 testRunner.And("only one message in the route", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.And("that message should have the name \'secondRouteFirstMessage\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.And("that message should have a close branch count of 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.And("there should be a route at index 1 of all the routes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 81
 testRunner.And("only one message in the route", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 82
 testRunner.And("that message should have the name \'firstRouteFirstMessage\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 83
 testRunner.And("that message should have a close branch count of 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Two routes from different machines but same thread")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LoggingMessages")]
        public virtual void TwoRoutesFromDifferentMachinesButSameThread()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Two routes from different machines but same thread", ((string[])(null)));
#line 85
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 86
 testRunner.Given("I have logged command processing for the message \'firstRouteFirstMessage\' from ma" +
                    "chine \'TestMachine\' on thread 1 dated \'09/21/1975 00:00:01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 87
    testRunner.And("I have logged command processing for the message \'secondRouteFirstMessage\' from m" +
                    "achine \'TestMachine\' on thread 2 dated \'09/21/1975 00:00:02\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 88
    testRunner.And("I have logged message processed from machine \'TestMachine\' on thread 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 89
    testRunner.And("I have logged message processed from machine \'TestMachine\' on thread 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 90
    testRunner.When("I get all routes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 91
 testRunner.Then("there should be a route at index 0 of all the routes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 92
 testRunner.And("only one message in the route", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 93
 testRunner.And("that message should have the name \'secondRouteFirstMessage\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 94
 testRunner.And("that message should have a close branch count of 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 95
 testRunner.And("there should be a route at index 1 of all the routes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 96
 testRunner.And("only one message in the route", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.And("that message should have the name \'firstRouteFirstMessage\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 98
 testRunner.And("that message should have a close branch count of 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Three routes logged limited to two")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LoggingMessages")]
        public virtual void ThreeRoutesLoggedLimitedToTwo()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Three routes logged limited to two", ((string[])(null)));
#line 100
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 101
 testRunner.Given("I have logged command processing for the message \'firstRouteFirstMessage\' from ma" +
                    "chine \'TestMachine\' on thread 1 dated \'09/21/1975 00:00:01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 102
    testRunner.And("I have logged message processed from machine \'TestMachine\' on thread 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 103
    testRunner.And("I have logged command processing for the message \'secondRouteFirstMessage\' from m" +
                    "achine \'TestMachine\' on thread 1 dated \'09/21/1975 00:00:02\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 104
    testRunner.And("I have logged message processed from machine \'TestMachine\' on thread 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 105
    testRunner.And("I have logged command processing for the message \'thirdRouteFirstMessage\' from ma" +
                    "chine \'TestMachine\' on thread 1 dated \'09/21/1975 00:00:03\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 106
    testRunner.And("I have logged message processed from machine \'TestMachine\' on thread 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 107
    testRunner.When("I get all routes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 108
 testRunner.Then("there should only be 2 routes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("No log processed yet so no route")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LoggingMessages")]
        public virtual void NoLogProcessedYetSoNoRoute()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("No log processed yet so no route", ((string[])(null)));
#line 110
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 111
    testRunner.Given("I have logged command processing for the message \'root\' from machine \'TestMachine" +
                    "\' on thread 1 dated \'09/21/1975 00:00:01\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 112
    testRunner.When("I get all routes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 113
    testRunner.Then("there should only be one route", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 114
 testRunner.And("there should not be any messages for the route", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("log processed but no log processing so no route")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "LoggingMessages")]
        public virtual void LogProcessedButNoLogProcessingSoNoRoute()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("log processed but no log processing so no route", ((string[])(null)));
#line 116
this.ScenarioSetup(scenarioInfo);
#line 6
this.FeatureBackground();
#line 117
    testRunner.Given("I have logged message processed from machine \'TestMachine\' on thread 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 118
    testRunner.When("I get all routes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 119
    testRunner.Then("there should not be any routes", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
