using Code.Interfaces.Models;
using Code.Views;

namespace Code.Interfaces.ViewModels
{
    internal interface IEnemyViewModel: IHealthViewModel
    {
        IEnemyModel EnemyModel { get; }
        PlayerView PlayerView { get; }
    }
}