using System;
using Code.Interfaces.ViewModels;
using UnityEngine;

namespace Code.ViewModel
{
    internal sealed class HudViewModel: IHudViewModel
    {
        public IPlayerViewModel PlayerViewModel { get; private set; }
        
        public GameObject GameObject { get; }
        public Transform Transform { get; }

        public HudViewModel(GameObject gameObject)
        {
            GameObject = gameObject;
            Transform = gameObject.transform;
        }
        
        public void Initialize(IPlayerViewModel playerViewModel)
        {
            PlayerViewModel = playerViewModel;
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