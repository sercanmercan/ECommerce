namespace ECommerce.Domain.BaseEntity
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
    }
}
