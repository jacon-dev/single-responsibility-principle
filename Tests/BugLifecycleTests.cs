using NUnit.Framework;
using SingleResponsibility.Classes;

namespace SingleResponsibility.Tests
{
    [TestFixture]
    public class BugLifecycleTests
    {
        private BugLifeCycle _sut;
        private const string ExpectedBugName = "Single Responsibility Principle Bug";
        private const string ExpectedApprover = "JC#";

        [SetUp]
        public void Setup()
        {
            _sut = new BugLifeCycle();
        }
        
        [Test]
        public void TestThatBugIsCreatedWithExpectedName()
        {
            _sut.CustomerReportsTheBug();
            
            Assert.AreEqual(ExpectedBugName, _sut.Bug.Name);
        }

        [Test]
        public void TestThatProductCannotPlanBugUnlessBugIsReported()
        {
            _sut.ProductPlansTheWork();
            
            Assert.AreEqual(null, _sut.Bug);
        }

        [Test]
        public void TestThatBugIsPlanned()
        {
            _sut.CustomerReportsTheBug();
            _sut.ProductPlansTheWork();
            
            Assert.IsTrue(_sut.Bug.IsPlanned);
            Assert.AreEqual(6, _sut.Bug.DevelopmentHours);
            Assert.AreEqual(4, _sut.Bug.TestHours);
        }

        [Test]
        public void TestThatDevelopmentCannotHappenUntilBugIsPlanned()
        {
            _sut.CustomerReportsTheBug();
            _sut.DeveloperFixesTheBug();
            
            Assert.IsFalse(_sut.Bug.IsDeveloped);
        }

        [Test]
        public void TestThatDevelopmentIsSuccessfulWhenBugIsPlanned()
        {
            _sut.CustomerReportsTheBug();
            _sut.ProductPlansTheWork();
            _sut.DeveloperFixesTheBug();
            
            Assert.IsTrue(_sut.Bug.IsDeveloped);
        }

        [Test]
        public void TestThatBugCannotBeTestedUntilDeveloped()
        {
            _sut.CustomerReportsTheBug();
            _sut.ProductPlansTheWork();
            _sut.TesterDoesTheTesting();
            
            Assert.IsFalse(_sut.Bug.IsTested);
        }

        [Test]
        public void TestThatBugIsTestedAfterDevelopmentIsCompleted()
        {
            _sut.CustomerReportsTheBug();
            _sut.ProductPlansTheWork();
            _sut.DeveloperFixesTheBug();
            _sut.TesterDoesTheTesting();
            
            Assert.IsTrue(_sut.Bug.IsTested);
        }

        [Test]
        [TestCase("Development")]
        [TestCase("Testing")]
        public void TestThatBugCannotBeApprovedWithoutEitherDevelopmentOrTesting(string activity)
        {
            _sut.CustomerReportsTheBug();
            _sut.ProductPlansTheWork();

            switch (activity)
            {
                case "Development" : _sut.DeveloperFixesTheBug();
                    break;
                case "Testing" : _sut.TesterDoesTheTesting();
                    break;
            }
            
            Assert.IsFalse(_sut.Bug.IsApproved);
        }

        [Test]
        public void TestThatBugIsApproved()
        {
            _sut.CustomerReportsTheBug();
            _sut.ProductPlansTheWork();
            _sut.DeveloperFixesTheBug();
            _sut.TesterDoesTheTesting();
            _sut.ApproveTheBug();

            Assert.AreEqual(ExpectedApprover, _sut.Bug.Approver);
            Assert.IsTrue(_sut.Bug.IsApproved);
        }

        [Test]
        public void TestThatEverythingWorksEndToEndAndBugIsReleased()
        {
            _sut.CustomerReportsTheBug();
            _sut.ProductPlansTheWork();
            _sut.DeveloperFixesTheBug();
            _sut.TesterDoesTheTesting();
            _sut.ApproveTheBug();
            _sut.ReleaseTheFix();
            
            Assert.IsTrue(_sut.Bug.IsReleased);
            Assert.AreEqual(ExpectedApprover, _sut.Bug.Approver);
            Assert.IsTrue(_sut.Bug.IsApproved);
            Assert.IsTrue(_sut.Bug.IsTested);
            Assert.IsTrue(_sut.Bug.IsDeveloped);
            Assert.IsTrue(_sut.Bug.IsPlanned);
            Assert.AreEqual(6, _sut.Bug.DevelopmentHours);
            Assert.AreEqual(4, _sut.Bug.TestHours);
            Assert.AreEqual(ExpectedBugName, _sut.Bug.Name);
        }
    }
}