using UnityEngine;

namespace Code.Views
{
    [RequireComponent(typeof(Collider))]
    internal sealed class BulletView : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _timeToDestroy;

        private float _damage;
        private float _destroyTimer;

        public void Initialize(float damage)
        {
            _destroyTimer = _timeToDestroy;
            _damage = damage;
        }
        
        private void Update()
        {
            var deltaTime = Time.deltaTime;
            
            transform.position += deltaTime * _speed * transform.forward;
            
            if (_destroyTimer <= 0)
                Destroy(gameObject);
            
            _destroyTimer -= deltaTime;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out EnemyView enemyView))
            {
                enemyView.EnemyViewModel.AddDamage(_damage);
            }
            else if (other.gameObject.TryGetComponent(out PlayerView playerView))
            {
                return;
            }
            
            Destroy(gameObject);
        }
    }
}