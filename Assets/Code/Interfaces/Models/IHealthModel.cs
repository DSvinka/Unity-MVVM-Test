namespace Code.Interfaces.Models
{
    public interface IHealthModel
    {
        float MaxHealth { get; }
        float CurrentHealth { get; set; }
    }
}
