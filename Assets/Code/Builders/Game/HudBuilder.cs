using System;
using Code.Interfaces.ViewModels;
using Code.Models;
using Code.ViewModel;
using Code.Views;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Builders.Game
{
    internal sealed class HudBuilder
    {
        private HudViewModel _hudViewModel;
        private HudView _hudView;
        
        public HudBuilder Create(GameObject prefab)
        {
            var gameObject = Object.Instantiate(prefab);
            if (!gameObject.TryGetComponent(out HudView hudView))
                throw new Exception("HudView не найден в префабе Hud'a игрока");

            _hudView = hudView;
            return this;
        }

        public HudBuilder Initialization(IPlayerViewModel playerViewModel)
        {
            if (_hudView == null)
                throw new Exception("Hud игрока не создан!");
            
            _hudViewModel = new HudViewModel(_hudView.gameObject);
            _hudViewModel.Initialize(playerViewModel);
            _hudView.Initialize(_hudViewModel);
            
            return this;
        }
        
        public static implicit operator HudView(HudBuilder player)
        {
            return player._hudView;
        }
        
        public static implicit operator HudViewModel(HudBuilder player)
        {
            return player._hudViewModel;
        }
    }
}