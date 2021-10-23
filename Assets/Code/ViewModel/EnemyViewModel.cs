using System;
using Code.Interfaces.Models;
using Code.Interfaces.ViewModels;
using UnityEngine;

namespace Code.ViewModel
{
    internal sealed class EnemyViewModel: IEnemyViewModel
    {
        public event Action<float> OnHealthChange = delegate(float health) {  };
        
        public IHealthModel HealthModel { get; }
        
        public IEnemyModel EnemyModel { get; }
        public IPlayerViewModel PlayerViewModel { get; private set; }

        public GameObject GameObject { get; }
        public Transform Transform { get; }
        public Transform SpawnPoint { get; }
        
        public int ScoreOnKill { get; }
        
        public void Initialize(IPlayerViewModel viewModel)
        {
            PlayerViewModel = viewModel;
        }

        public bool IsDead { get; private set; }

        public EnemyViewModel(GameObject gameObject, IEnemyModel enemyModel, IHealthModel healthModel, Transform spawnPoint, int scoreOnKill)
        {
            EnemyModel = enemyModel;
            HealthModel = healthModel;
            SpawnPoint = spawnPoint;

            ScoreOnKill = scoreOnKill;
            
            Transform = gameObject.transform;
            GameObject = gameObject;
        }

        public void AddDamage(float damage)
        {
            HealthModel.CurrentHealth -= damage;
            if (HealthModel.CurrentHealth <= 0)
            {
                PlayerViewModel.AddScore(ScoreOnKill);
                IsDead = true;
            }
            OnHealthChange.Invoke(HealthModel.CurrentHealth);
        }

        public void Reset()
        {
            Transform.position = SpawnPoint.position;
            Transform.rotation = SpawnPoint.rotation;

            HealthModel.CurrentHealth = HealthModel.MaxHealth;
            IsDead = false;
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