using Code.Interfaces.Models;
using UnityEngine;

namespace Code.Models
{
    internal sealed class PlayerModel : IPlayerModel
    {
        public CharacterController CharacterController { get; }
        public PlayerModel(CharacterController characterController)
        {
            CharacterController = characterController;
        }
    }
}