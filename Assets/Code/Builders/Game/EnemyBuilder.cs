using System;
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
        
        public EnemyBuilder Create(GameObject prefab, Transform playerSpawn)
        {
            var enemyGameObject = Object.Instantiate(prefab, playerSpawn);
            enemyGameObject.transform.SetParent(null);

            if (!enemyGameObject.TryGetComponent(out EnemyView enemyView))
                throw new Exception("EnemyView не найден в префабе противника");

            _enemyView = enemyView;
            return this;
        }

        public EnemyBuilder Initialization(PlayerView playerView)
        {
            if (_enemyView == null)
                throw new Exception("Противник не создан!");
            
            if (!_enemyView.TryGetComponent(out NavMeshAgent navMeshAgent))
                throw new Exception("У противника не найден компонент NavMeshAgent.");
            
            var healthModel = new HealthModel(25);
            var enemyModel = new EnemyModel(navMeshAgent);
            var viewModel = new Models.ViewModel(_enemyView.gameObject, _enemyView.transform);

            var enemyViewModel = new EnemyViewModel(enemyModel, playerView, healthModel);
            _enemyView.Initialize(viewModel, enemyViewModel);
            
            return this;
        }
        
        public static implicit operator EnemyView(EnemyBuilder enemy)
        {
            return enemy._enemyView;
        }
    }
}