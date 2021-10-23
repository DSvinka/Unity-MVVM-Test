using Code.Interfaces;
using Code.Interfaces.Models;
using Code.Interfaces.ViewModels;
using Code.Utils;
using Code.ViewModel;
using TMPro;
using UnityEngine;

namespace Code.Views
{
    internal sealed class HudView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _healthText;
        [SerializeField] private TMP_Text _scoreText;

        public IHudViewModel HudViewModel { get; private set; }
        
        public void Initialize(IHudViewModel hudViewModel)
        {
            HudViewModel = hudViewModel;
            OnHealthChange(HudViewModel.PlayerViewModel.HealthModel.CurrentHealth);
        }
        
        private void Start()
        {
            HudViewModel.PlayerViewModel.OnScoreChange += OnScoreChange;
            HudViewModel.PlayerViewModel.OnHealthChange += OnHealthChange;
        }
        private void OnDestroy()
        {
            HudViewModel.PlayerViewModel.OnScoreChange -= OnScoreChange;
            HudViewModel.PlayerViewModel.OnHealthChange -= OnHealthChange;
        }

        private void OnScoreChange(int score)
        {
            _scoreText.text = FormatNumbers.Cut(score);
        }
        private void OnHealthChange(float health)
        {
            _healthText.text = FormatNumbers.Cut((int) health);
        }
    }
}