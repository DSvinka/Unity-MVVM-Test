using Code.Interfaces.Models;
using UnityEngine;

namespace Code.Models
{
    internal sealed class ViewModel: IViewModel
    {
        public GameObject GameObject { get; }
        public Transform Transform { get; }

        public ViewModel(GameObject gameObject, Transform transform)
        {
            GameObject = gameObject;
            Transform = transform;
        }
    }
}