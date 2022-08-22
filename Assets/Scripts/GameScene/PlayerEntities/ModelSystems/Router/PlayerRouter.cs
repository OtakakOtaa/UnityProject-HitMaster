using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace GameScene.PlayerEntities.ModelSystems.Router
{
    public class PlayerRouter
    {
        private Stack<Transform> _wayPoints;
        private NavMeshAgent _agent;
        private AgentPathStateObserver _agentPathState;
    
        public event UnityAction PlayerFinishWay;
        public event UnityAction PlayerReachedWayPoint;
    
        public PlayerRouter(NavMeshAgent agent, Transform[] wayPoints)
        {
            var agentComponent = agent.GetComponent<NavMeshAgent>();
            _agent = agentComponent;
            _agentPathState = new AgentPathStateObserver(agentComponent);
            _agentPathState.AgentFinishPath += () => PlayerReachedWayPoint?.Invoke();
            
            _wayPoints = new Stack<Transform>(wayPoints);
        }
    
        public void GoToNextPoint()
        {
            if (IsWayEnded())
                PlayerFinishWay?.Invoke();
            else
            {
                _agent.SetDestination(_wayPoints.Pop().position);
            }
        }

        public void Update()
        {
            _agentPathState.Observe();
        }
    
        private bool IsWayEnded() => _wayPoints.Count == 0;
    }
}
