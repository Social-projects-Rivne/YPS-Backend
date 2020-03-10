namespace YPS.Domain.Entities
{
    public class TeacherToDiscipline
    {
        public long DisciplineId { get; set; }
        public Discipline Discipline { get; set; }

        public long TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
