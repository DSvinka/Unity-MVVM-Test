using System;
using Code.Interfaces.ViewModels;
using Code.Models;
using Code.ViewModel;
using Code.Views;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Builders.Game
{
    internal sealed class PlayerBuilder
    {
        private PlayerViewModel _playerViewModel;
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
            
            var healthModel = new HealthModel(_playerView.MaxHealth);
            var ammoModel = new AmmoModel(_playerView.MaxAmmo);
            var playerModel = new PlayerModel(characterController);

            var playerViewModel = new PlayerViewModel(_playerView.gameObject, healthModel, ammoModel, playerModel);
            _playerView.Initialize(playerViewModel);
            _playerViewModel = playerViewModel;
            
            return this;
        }
        
        public static implicit operator PlayerView(PlayerBuilder player)
        {
            return player._playerView;
        }
        
        public static implicit operator PlayerViewModel(PlayerBuilder player)
        {
            return player._playerViewModel;
        }
    }
}