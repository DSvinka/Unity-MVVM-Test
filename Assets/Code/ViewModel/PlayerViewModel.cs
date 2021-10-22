using System;
using Code.Interfaces.Models;
using Code.Interfaces.ViewModels;
using UnityEngine;

namespace Code.ViewModel
{
    internal sealed class PlayerViewModel : IPlayerViewModel
    {
        public event Action<float> OnHealthChange;
        
        public IHealthModel HealthModel { get; }
        public IAmmoModel AmmoModel { get; }
        public IPlayerModel PlayerModel { get; }

        public bool IsDead { get; private set; }

        public PlayerViewModel(IHealthModel healthModel, IAmmoModel ammoModel, IPlayerModel playerModel)
        {
            HealthModel = healthModel;
            AmmoModel = ammoModel;
            PlayerModel = playerModel;
        }

        public void AddDamage(float damage)
        {
            HealthModel.CurrentHealth -= damage;
            if (HealthModel.CurrentHealth <= 0)
            {
                IsDead = true;
            }
            
            OnHealthChange?.Invoke(HealthModel.CurrentHealth);
        }
    }
}