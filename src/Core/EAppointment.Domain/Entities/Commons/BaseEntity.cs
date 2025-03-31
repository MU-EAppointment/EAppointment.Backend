namespace EAppointment.Domain.Entities.Commons
{
    public abstract class BaseEntity : IUpdated, ICreated, IIsActive
    {
        protected BaseEntity() => Id = Guid.NewGuid();
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
