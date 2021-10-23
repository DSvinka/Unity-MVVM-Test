using UnityEngine;

namespace Code.Interfaces.Models
{
    public interface IViewModel
    {
        GameObject GameObject { get; }
        Transform Transform { get; }
    }
}
