using Code.Interfaces.Models;
using UnityEngine.AI;

namespace Code.Models
{
    internal sealed class EnemyModel: IEnemyModel
    {
        public NavMeshAgent NavMeshAgent { get; }
        public float AttackCooldown { get; set; }

        public EnemyModel(NavMeshAgent navMeshAgent)
        {
            NavMeshAgent = navMeshAgent;
        }
    }
}