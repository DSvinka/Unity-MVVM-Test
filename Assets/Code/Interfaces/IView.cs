using Code.Interfaces.Models;

namespace Code.Interfaces
{

    public interface IView
    {
        void Show();
        void Hide();
    }
    
    public interface IView<in T> : IView where T : IViewModel
    {
        void Initialize(T viewModel);
    }
}
