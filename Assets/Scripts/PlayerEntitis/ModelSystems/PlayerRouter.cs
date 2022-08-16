using System;
using System.Collections;
using System.Collections.Generic;
using EventSystem;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Zenject;

public class PlayerRouter : ITickable
{
    private Stack<Transform> _wayPoints;
    private NavMeshAgent _agent;

    public event UnityAction PlayerFinishWay;
    public event UnityAction PlayerReachedWayPoint;
    
    private bool IsDestinationReached() => 
        _agentGoesWay && 
        (_agent.pathEndPosition - _agent.transform.position).magnitude == 0f;
    
    private bool _agentGoesWay;

    private bool IsWayEnded() => _wayPoints.Count == 0;

    public PlayerRouter(Transform[] wayPoints, Player agent, EventManager eventManage)
    {
        _wayPoints = new Stack<Transform>(wayPoints);
        _agent = agent.GetComponent<NavMeshAgent>();
    }

    private void GoToNextPoint()
    {
        if (IsWayEnded())
            PlayerFinishWay?.Invoke();
        else
        {
            _agent.SetDestination(_wayPoints.Pop().position);
            _agentGoesWay = true;
        }
    }

    public void Tick()
    {
        Debug.Log("tick");
        if (IsDestinationReached())
        {
            PlayerReachedWayPoint?.Invoke();
            _agentGoesWay = false;
        }
    }
}
