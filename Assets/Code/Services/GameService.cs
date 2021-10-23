using System;
using Code.Builders.Game;
using Code.Interfaces.ViewModels;
using Code.Markers;
using Code.ViewModel;
using Code.Views;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Services
{
    internal static class GameService
    {
        public static (Transform playerSpawn, EnemySpawn[] enemySpawns) GetSpawns()
        {
            var playerSpawn = Object.FindObjectOfType<PlayerSpawn>();
            if (playerSpawn == null)
                throw new Exception("Спавн игрока (PlayerSpawn) не найден на сцене.");
            
            var enemySpawns = Object.FindObjectsOfType<EnemySpawn>();

            return (playerSpawn.transform, enemySpawns);
        }
        
        public static IPlayerViewModel CreatePlayer(GameObject prefab, Transform spawnPoint)
        {
            var playerBuilder = new PlayerBuilder();
            PlayerViewModel playerViewModel = playerBuilder.Create(prefab, spawnPoint).Initialization();
            return playerViewModel;
        }
        
        public static IEnemyViewModel CreateEnemy(GameObject prefab, IPlayerViewModel playerViewModel, Transform spawnPoint)
        {
            var enemyBuilder = new EnemyBuilder();
            EnemyViewModel enemyViewModel = enemyBuilder.Create(prefab, spawnPoint).Initialization(playerViewModel);
            return enemyViewModel;
        }
        
        public static IHudViewModel CreateHud(GameObject prefab, IPlayerViewModel playerViewModel)
        {
            var hudBuilder = new HudBuilder();
            HudViewModel hudViewModel = hudBuilder.Create(prefab).Initialization(playerViewModel);
            return hudViewModel;
        }
    }
}