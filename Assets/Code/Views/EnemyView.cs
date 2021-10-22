using Code.Interfaces.Models;
using Code.Interfaces.ViewModels;
using Code.Interfaces.Views;
using UnityEngine;

namespace Code.Views
{
    internal sealed class EnemyView : MonoBehaviour, IView
    {
        [SerializeField] private float _health;
        [SerializeField] private float _damage;
        [SerializeField] private float _attackRate;
        [SerializeField] private float _attackDistance;
        
        [SerializeField] private Transform _attackPoint;

        public IViewModel ViewModel { get; private set; }
        public IEnemyViewModel EnemyViewModel { get; private set; }

        public void Initialize(IViewModel viewModel, IEnemyViewModel enemyViewModel)
        {
            ViewModel = viewModel;
            EnemyViewModel = enemyViewModel;
        }

        private void Update()
        {
            Move(EnemyViewModel.PlayerView.ViewModel.Transform.position);
            Attack(Time.deltaTime);
        }

        private void Move(Vector3 position)
        {
            if (Time.frameCount % 2 != 0) 
                return;
            
            EnemyViewModel.EnemyModel.NavMeshAgent.SetDestination(position);
        }
        
        private void Attack(float deltaTime)
        {
            EnemyViewModel.EnemyModel.AttackCooldown -= deltaTime * 2;
            if (EnemyViewModel.EnemyModel.AttackCooldown >= 0)
                return;

            var position = _attackPoint.position;
            var forward = _attackPoint.forward;

            if (Physics.Raycast(position, forward, out var raycastHit, _attackDistance))
            {
                if (!raycastHit.collider.gameObject.TryGetComponent(out PlayerView playerView)) 
                    return;
                
                playerView.PlayerViewModel.AddDamage(_damage);
                EnemyViewModel.EnemyModel.AttackCooldown = _attackRate;
            }
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