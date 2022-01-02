namespace SingleResponsibility
{
    public class Bug
    {
        public Bug(string nameOfChange)
        {
            Name = nameOfChange;
        }
        
        public string Name { get; }
        
        public int DevelopmentHours { get; set; }
        
        public int TestHours { get; set; }

        public bool IsPlanned { get; set; }
        
        public bool IsDeveloped { get; set; }
        
        public bool IsTested { get; set; }
        
        public bool IsApproved { get; set; }
        
        public string Approver { get; set; }
        
        public bool IsReleased { get; set; }
    }
}