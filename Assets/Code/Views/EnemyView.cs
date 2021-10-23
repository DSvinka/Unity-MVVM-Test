using Code.Interfaces.ViewModels;
using UnityEngine;

namespace Code.Views
{
    internal sealed class EnemyView : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private float _damage;
        [SerializeField] private int _scoreOnKill;
        
        [SerializeField] private float _attackRate;
        [SerializeField] private float _attackDistance;
        
        [SerializeField] private Transform _attackPoint;

        public int ScoreOnKill => _scoreOnKill;
        public float MaxHealth => _maxHealth;
        public IEnemyViewModel EnemyViewModel { get; private set; }

        public void Initialize(IEnemyViewModel enemyViewModel)
        {
            EnemyViewModel = enemyViewModel;
        }
        
        private void Start()
        {
            EnemyViewModel.OnHealthChange += OnHealthChange;
        }

        private void OnDestroy()
        {
            EnemyViewModel.OnHealthChange -= OnHealthChange;
        }

        private void Update()
        {
            Move(EnemyViewModel.PlayerViewModel.Transform.position);
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
        
        private void OnHealthChange(float health)
        {
            if (EnemyViewModel.IsDead)
            {
                EnemyViewModel.Reset();
            }
        }
    }
}