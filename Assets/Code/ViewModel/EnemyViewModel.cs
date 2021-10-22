using System;
using Code.Interfaces.Models;
using Code.Interfaces.ViewModels;
using Code.Views;
using UnityEngine;

namespace Code.ViewModel
{
    internal sealed class EnemyViewModel: IEnemyViewModel
    {
        public event Action<float> OnHealthChange;
        
        public IHealthModel HealthModel { get; }
        
        public IEnemyModel EnemyModel { get; }
        public PlayerView PlayerView { get; }
        
        public bool IsDead { get; private set; }

        public EnemyViewModel(IEnemyModel enemyModel, PlayerView playerView, IHealthModel healthModel)
        {
            EnemyModel = enemyModel;
            HealthModel = healthModel;
            PlayerView = playerView;
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