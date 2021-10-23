using System;
using Code.Interfaces.Models;

namespace Code.Interfaces.ViewModels
{
    public interface IPlayerViewModel: IHealthViewModel, IView, IViewModel
    {
        event Action<int> OnScoreChange;
        
        IAmmoModel AmmoModel { get; }
        IPlayerModel PlayerModel { get; }

        void AddScore(int score);
    }
}