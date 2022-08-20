using GameScene.PlayerEntities.ModelSystems.Router;
using GameScene.PlayerEntities.View;
using MarkEntities.System;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace GameScene.PlayerEntities
{
    public class PlayerService : ITickable
    {
        private MarksProvider _marksProvider;
        private PlayerView _player;
        private PlayerRouter _playerRouter;

        public PlayerService(PlayerView player, MarksProvider marksProvider)
        {
            _marksProvider = marksProvider;
            _player = player;
        }

        public void Instantiate()
        {
            Debug.Log("Instantiate");
            _player.transform.position = _marksProvider.PlayerSpawnPoint.position;
            _playerRouter = new PlayerRouter(_player.GetComponent<NavMeshAgent>(), _marksProvider.PlayerWayPoints);
            SetStartState();
        }
    
        public void Tick()
        {
            _playerRouter?.Update();
        }

        private void SetStartState()
        {
            _playerRouter.GoToNextPoint();
        }
    }
}
