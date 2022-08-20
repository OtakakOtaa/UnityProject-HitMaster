using System;
using UnityEngine.AI;

namespace GameScene.PlayerEntities.ModelSystems.Router
{
    public class AgentPathStateObserver
    {
        private NavMeshAgent _agent;
        
        public event Action AgentFinishPath;
        
        private bool IsDestinationReached() =>
            _agent.hasPath && IsAgentArrived; 
            
        public AgentPathStateObserver(NavMeshAgent agent)
        {
            _agent = agent;
        }
        
        public void Observe()
        {
            if (IsDestinationReached())
            {
                AgentFinishPath?.Invoke();
            }
        }

        private bool IsAgentArrived =>
            (_agent.pathEndPosition - _agent.transform.position).magnitude == 0f;
    }
}