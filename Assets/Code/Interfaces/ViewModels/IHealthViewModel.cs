using System;
using Code.Interfaces.Models;

namespace Code.Interfaces.ViewModels
{
    public interface IHealthViewModel
    {
        event Action<float> OnHealthChange;
        
        IHealthModel HealthModel { get; }
        bool IsDead { get; }

        void AddDamage(float damage);
    }
}