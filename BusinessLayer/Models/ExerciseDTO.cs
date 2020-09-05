namespace BusinessLayer.Models
{
    public class ExerciseDTO
    {
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long LastUsedTime { get; set; }
        public string ImageUri { get; set; }
        public bool IsChosen { get; set; }
    }

}
