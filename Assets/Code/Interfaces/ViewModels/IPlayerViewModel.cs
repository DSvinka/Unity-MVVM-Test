using System;
using Code.Interfaces.Models;

namespace Code.Interfaces.ViewModels
{
    public interface IPlayerViewModel: IHealthViewModel
    {
        IAmmoModel AmmoModel { get; }
        IPlayerModel PlayerModel { get; }
    }
}