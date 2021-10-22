using Code.Interfaces.Models;

namespace Code.Interfaces.Views
{

    public interface IView
    {
        IViewModel ViewModel { get; }
        void Show();
        void Hide();
    }
}
