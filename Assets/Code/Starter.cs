using Code.Services;
using UnityEngine;

namespace Code
{
    internal sealed class Starter : MonoBehaviour
    {
        [Header("Объекты")]
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _enemyPrefab;
        
        private void Start()
        {
            var (playerSpawn, enemySpawns) = GameService.GetSpawns();
            var playerView = GameService.CreatePlayer(_playerPrefab, playerSpawn);

            foreach (var enemySpawn in enemySpawns)
            {
                GameService.CreateEnemy(_enemyPrefab, playerView, enemySpawn.transform);
            }
        }

        
    }
}
