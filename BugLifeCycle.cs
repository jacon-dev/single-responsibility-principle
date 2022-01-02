using System;

namespace SingleResponsibility
{
    public class BugLifeCycle
    {
        public Bug Bug { get; private set; }

        public void CustomerReportsTheBug()
        {
            Bug = new Bug("Single Responsibility Principle Bug");
        }

        public void ProductPlansTheWork()
        {
            if (Bug != null && string.IsNullOrEmpty(Bug.Name) == false)
            {
                Bug.TestHours = 4;
                Bug.DevelopmentHours = 6;
                Bug.IsPlanned = true;
            }
        }

        public void DeveloperFixesTheBug()
        {
            if (Bug != null && Bug.IsPlanned)
            {
                Console.WriteLine("Doing some coding...");
                Bug.IsDeveloped = true;
            }
        }

        public void TesterDoesTheTesting()
        {
            if (Bug != null && Bug.IsDeveloped)
            {
                Console.WriteLine("Doing some testing...");
                Bug.IsTested = true;
            }
        }

        public void ApproveTheBug()
        {
            if (Bug != null && Bug.IsDeveloped && Bug.IsTested)
            {
                Bug.Approver = "JC#";
                Bug.IsApproved = true;
            }
        }

        public void ReleaseTheFix()
        {
            if (Bug != null && Bug.IsApproved)
            {
                Console.WriteLine($"Releasing the fix for bug {Bug.Name} approved by {Bug.Approver}");
                Bug.IsReleased = true;
            }
        }
    }
}