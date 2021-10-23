using UnityEngine.AI;

namespace Code.Interfaces.Models
{
    public interface IEnemyModel
    {
        NavMeshAgent NavMeshAgent { get; }
        float AttackCooldown { get; set; }
    }
}