using System;
using Code.Models;
using Code.ViewModel;
using Code.Views;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Builders.Game
{
    internal sealed class PlayerBuilder
    {
        private PlayerView _playerView;
        
        public PlayerBuilder Create(GameObject prefab, Transform playerSpawn)
        {
            var player = Object.Instantiate(prefab, playerSpawn);
            player.transform.SetParent(null);

            if (!player.TryGetComponent(out PlayerView playerView))
                throw new Exception("PlayerView не найден в префабе игрока");

            _playerView = playerView;
            return this;
        }

        public PlayerBuilder Initialization()
        {
            if (_playerView == null)
                throw new Exception("Игрок не создан!");
            
            if (!_playerView.TryGetComponent(out CharacterController characterController))
                throw new Exception("У игрока не найден компонент CharacterController.");
            
            var healthModel = new HealthModel(_playerView.Health);
            var ammoModel = new AmmoModel(_playerView.Ammo);
            var playerModel = new PlayerModel(characterController);
            var viewModel = new Models.ViewModel(_playerView.gameObject, _playerView.transform);

            var playerViewModel = new PlayerViewModel(healthModel, ammoModel, playerModel);
            _playerView.Initialize(playerViewModel, viewModel);
            
            return this;
        }
        
        public static implicit operator PlayerView(PlayerBuilder player)
        {
            return player._playerView;
        }
    }
}