using System;
using Code.Builders.Game;
using Code.Markers;
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
        
        public static PlayerView CreatePlayer(GameObject prefab, Transform spawnPoint)
        {
            var playerBuilder = new PlayerBuilder();
            PlayerView playerView = playerBuilder.Create(prefab, spawnPoint).Initialization();
            return playerView;
        }
        
        public static EnemyView CreateEnemy(GameObject prefab, PlayerView playerView, Transform spawnPoint)
        {
            var enemyBuilder = new EnemyBuilder();
            EnemyView enemyView = enemyBuilder.Create(prefab, spawnPoint).Initialization(playerView);
            return enemyView;
        }
    }
}