using Code.Interfaces.Models;
using Code.ViewModel;
using Code.Views;
using UnityEngine;

namespace Code.Interfaces.ViewModels
{
    internal interface IEnemyViewModel: IHealthViewModel, IView<IPlayerViewModel>, IViewModel
    {
        IEnemyModel EnemyModel { get; }
        IPlayerViewModel PlayerViewModel { get; }
        
        Transform SpawnPoint { get; }
        void Reset();
    }
}