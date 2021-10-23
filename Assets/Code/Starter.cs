using Code.Services;
using UnityEngine;

namespace Code
{
    internal sealed class Starter : MonoBehaviour
    {
        [Header("Объекты")]
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private GameObject _hudPrefab;
        
        private void Start()
        {
            var (playerSpawn, enemySpawns) = GameService.GetSpawns();
            var playerViewModel = GameService.CreatePlayer(_playerPrefab, playerSpawn);
            var hudViewModel = GameService.CreateHud(_hudPrefab, playerViewModel);

            foreach (var enemySpawn in enemySpawns)
            {
                GameService.CreateEnemy(_enemyPrefab, playerViewModel, enemySpawn.transform);
            }
        }

        
    }
}
