using System;

namespace SingleResponsibility
{
    public class BugLifeCycle
    {
        private Bug _bug;

        public void CustomerReportsTheBug()
        {
            _bug = new Bug("Single Responsibility Principle Bug");
        }

        public void ProductPlansTheWork()
        {
            if (_bug != null && string.IsNullOrEmpty(_bug.Name) == false)
            {
                _bug.TestHours = 4;
                _bug.DevelopmentHours = 6;
                _bug.IsPlanned = true;
            }
        }

        public void DeveloperFixesTheBug()
        {
            if (_bug != null && _bug.IsPlanned)
            {
                Console.WriteLine("Doing some coding...");
                _bug.IsDeveloped = true;
            }
        }

        public void TesterDoesTheTesting()
        {
            if (_bug != null && _bug.IsDeveloped)
            {
                Console.WriteLine("Doing some testing...");
                _bug.IsTested = true;
            }
        }

        public void ApproveTheBug()
        {
            if (_bug != null && _bug.IsDeveloped && _bug.IsTested)
            {
                _bug.Approver = "JC#";
                _bug.IsApproved = true;
            }
        }

        public void ReleaseTheFix()
        {
            if (_bug != null && _bug.IsApproved)
            {
                Console.WriteLine($"Releasing the fix for bug {_bug.Name} approved by {_bug.Approver}");
                _bug.IsReleased = true;
            }
        }
    }
}