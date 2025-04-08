namespace StepsMVC.ViewModels
{
    public class TraineeResultDegreeStatusViewModel
    {
        public string TraineeName { get; set; }
        public string CourseName { get; set; }
        public int Degree { get; set; }
        public string Status { get; set; } = "Fail";
        public string StyleColor { get; set; } = "bg-danger";
    }
}
