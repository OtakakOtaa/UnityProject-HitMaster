using GameScene.PlayerEntities.ModelSystems.Router;
using GameScene.PlayerEntities.View;
using MarkEntities.System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Zenject;

namespace GameScene.PlayerEntities
{
    public class PlayerService : ITickable
    {
        public event UnityAction InitializeEnd;
        
        private MarksProvider _marksProvider;
        private PlayerView _player;
        
        private PlayerRouter _playerRouter;

        public PlayerService(PlayerView player, MarksProvider marksProvider)
        {
            _marksProvider = marksProvider;
            _player = player;
            _marksProvider.MarkGathered += Initialize;
        }

        private void Initialize()
        {
            _player.transform.position = _marksProvider.PlayerSpawnPoint.position;
            _player.transform.rotation = Quaternion.Euler(14, 510, 0);
            _playerRouter = new PlayerRouter(_player.GetComponent<NavMeshAgent>(), _marksProvider.PlayerWayPoints);
            SetStartState();
            
            InitializeEnd?.Invoke();
        }
    
        public void Tick()
        {
            _playerRouter?.Update();
        }

        public void SetStartState()
        {
            _playerRouter.GoToNextPoint();
            _playerRouter.PlayerReachedWayPoint += _playerRouter.GoToNextPoint;
        }
    }
}
