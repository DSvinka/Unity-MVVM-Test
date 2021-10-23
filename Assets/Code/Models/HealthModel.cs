using Code.Interfaces.Models;

namespace Code.Models
{
    internal sealed class HealthModel : IHealthModel
    {
        public float MaxHealth { get; }
        public float CurrentHealth { get; set; }
        
        public HealthModel(float maxHp)
        {
            MaxHealth = maxHp;
            CurrentHealth = MaxHealth;
        }
    }
}
