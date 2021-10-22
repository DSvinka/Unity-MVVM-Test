using System;
using Code.Interfaces.Models;
using Code.Interfaces.ViewModels;
using Code.Interfaces.Views;
using Code.Managers;
using Code.ViewModel;
using UnityEngine;

namespace Code.Views
{
    internal sealed class PlayerView : MonoBehaviour, IView
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private int _maxAmmo;
        [SerializeField] private float _speed;

        public float Health => _maxHealth;
        public int Ammo => _maxAmmo;
        
        public IViewModel ViewModel { get; private set; }
        public IPlayerViewModel PlayerViewModel { get; private set; }

        private Vector3 _moveDirection;

        public void Initialize(IPlayerViewModel playerViewModel, IViewModel viewModel)
        {
            PlayerViewModel = playerViewModel;
            ViewModel = viewModel;

            _moveDirection.y = Physics.gravity.y;
        }

        private void Start()
        {
            PlayerViewModel.OnHealthChange += OnHealthChange;
        }

        private void OnDestroy()
        {
            PlayerViewModel.OnHealthChange -= OnHealthChange;
        }

        private void Update()
        {
            UpdateInput();
            PlayerViewModel.PlayerModel.CharacterController.Move(Time.deltaTime * _speed * _moveDirection);
        }

        private void OnHealthChange(float health)
        {
            if (PlayerViewModel.IsDead)
            {
                Debug.Log("Вы погибли!");
                Hide();
            }
        }

        private void UpdateInput()
        {
            _moveDirection.x = Input.GetAxis(AxisManager.Horizontal);
            _moveDirection.z = Input.GetAxis(AxisManager.Vertical);
            _moveDirection.y = Physics.gravity.y;
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}