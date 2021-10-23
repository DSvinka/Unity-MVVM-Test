using Code.Interfaces.ViewModels;
using Code.Managers;
using UnityEngine;

namespace Code.Views
{
    internal sealed class PlayerView : MonoBehaviour
    {
        [SerializeField] private float _maxHealth;
        [SerializeField] private int _maxAmmo;
        [SerializeField] private float _speed;
        [SerializeField] private float _damage;
        
        [SerializeField] private BulletView _bulletPrefab;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private Camera _camera;
        
        public float MaxHealth => _maxHealth;
        public int MaxAmmo => _maxAmmo;
        
        public IPlayerViewModel PlayerViewModel { get; private set; }

        private Vector3 _moveDirection;

        public void Initialize(IPlayerViewModel playerViewModel)
        {
            PlayerViewModel = playerViewModel;

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
            var playerModel = PlayerViewModel.PlayerModel;
            
            UpdateInput();
            playerModel.CharacterController.Move(Time.deltaTime * _speed * _moveDirection);

            if (Input.GetMouseButtonDown(0))
            {
                Shoot();
            }
        }

        private void OnHealthChange(float health)
        {
            if (PlayerViewModel.IsDead)
            {
                Debug.Log("Вы погибли!");
                gameObject.SetActive(false);
            }
        }
        
        private void Shoot()
        {
            Vector3 direction;
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hitCamera))
            {
                direction = hitCamera.point;
            }
            else return;

            var bullet = Instantiate(_bulletPrefab);
            bullet.Initialize(_damage);

            var bulletTransform = bullet.transform;
            bulletTransform.position = _shootPoint.position;
            
            bulletTransform.LookAt(direction);
            var rotation = bulletTransform.rotation;
            rotation.z = 0f;
            rotation.x = 0f;

            bulletTransform.rotation = rotation;
        }

        private void UpdateInput()
        {
            _moveDirection.x = Input.GetAxis(AxisManager.Horizontal);
            _moveDirection.z = Input.GetAxis(AxisManager.Vertical);
            _moveDirection.y = Physics.gravity.y;
        }
    }
}