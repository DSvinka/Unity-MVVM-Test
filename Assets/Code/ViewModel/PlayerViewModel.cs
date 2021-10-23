using System;
using Code.Interfaces.Models;
using Code.Interfaces.ViewModels;
using UnityEngine;

namespace Code.ViewModel
{
    internal sealed class PlayerViewModel : IPlayerViewModel
    {
        public event Action<float> OnHealthChange = delegate(float health) {  };
        public event Action<int> OnScoreChange = delegate(int score) {  };
        
        public IHealthModel HealthModel { get; }
        public IAmmoModel AmmoModel { get; }
        public IPlayerModel PlayerModel { get; }

        public GameObject GameObject { get; }
        public Transform Transform { get; }

        public bool IsDead { get; private set; }
        public int Score { get; private set; }

        public PlayerViewModel(GameObject gameObject, IHealthModel healthModel, IAmmoModel ammoModel, IPlayerModel playerModel)
        {
            HealthModel = healthModel;
            AmmoModel = ammoModel;
            PlayerModel = playerModel;
            
            GameObject = gameObject;
            Transform = gameObject.transform;
        }

        public void AddDamage(float damage)
        {
            HealthModel.CurrentHealth -= damage;
            if (HealthModel.CurrentHealth <= 0)
            {
                IsDead = true;
            }
            
            OnHealthChange.Invoke(HealthModel.CurrentHealth);
        }
        
        public void AddScore(int score)
        {
            Score += score;
            OnScoreChange.Invoke(Score);
        }

        public void Show()
        {
            GameObject.SetActive(true);
        }

        public void Hide()
        {
            GameObject.SetActive(false);
        }
    }
}