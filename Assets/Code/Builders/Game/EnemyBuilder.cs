using System;
using Code.Interfaces.ViewModels;
using Code.Models;
using Code.ViewModel;
using Code.Views;
using UnityEngine;
using UnityEngine.AI;
using Object = UnityEngine.Object;

namespace Code.Builders.Game
{
    internal sealed class EnemyBuilder
    {
        private EnemyView _enemyView;
        private EnemyViewModel _enemyViewModel;
        
        private Transform _spawnPoint;
        
        public EnemyBuilder Create(GameObject prefab, Transform spawnPoint)
        {
            _spawnPoint = spawnPoint;
            var enemyGameObject = Object.Instantiate(prefab, spawnPoint);
            enemyGameObject.transform.SetParent(null);

            if (!enemyGameObject.TryGetComponent(out EnemyView enemyView))
                throw new Exception("EnemyView не найден в префабе противника");

            _enemyView = enemyView;
            return this;
        }

        public EnemyBuilder Initialization(IPlayerViewModel playerViewModel)
        {
            if (_enemyView == null)
                throw new Exception("Противник не создан!");
            
            if (!_enemyView.TryGetComponent(out NavMeshAgent navMeshAgent))
                throw new Exception("У противника не найден компонент NavMeshAgent.");
            
            var healthModel = new HealthModel(_enemyView.MaxHealth);
            var enemyModel = new EnemyModel(navMeshAgent);

            var enemyViewModel = new EnemyViewModel(_enemyView.gameObject, enemyModel, healthModel, _spawnPoint, _enemyView.ScoreOnKill);
            enemyViewModel.Initialize(playerViewModel);
            _enemyView.Initialize(enemyViewModel);
            _enemyViewModel = enemyViewModel;
            
            return this;
        }
        
        public static implicit operator EnemyView(EnemyBuilder enemy)
        {
            return enemy._enemyView;
        }
        public static implicit operator EnemyViewModel(EnemyBuilder enemy)
        {
            return enemy._enemyViewModel;
        }
    }
}