using Code.Interfaces.Models;

namespace Code.Interfaces.ViewModels
{
    public interface IHudViewModel: IView<IPlayerViewModel>, IViewModel
    {
        IPlayerViewModel PlayerViewModel { get; }
    }
}