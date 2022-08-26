using EventSystem;
using GameScene.PlayerEntities;
using Zenject;

namespace GameScene.SceneService
{
    public class GameSceneStartGate
    {
        private EventManager _eventManager;

        [Inject] private PlayerService _playerService;
        private bool _playerInstalled = false;
        
        public GameSceneStartGate(EventManager eventManager, PlayerService playerService)
        {
            _eventManager = eventManager;
            _playerService = playerService;
            SubscribeToPendingServices();
        }
    
        private void SubscribeToPendingServices()
        {
            _playerService.InitializeEnd += () =>
            {
                _playerInstalled = true;
                TryStartGame();
            };
        }

        private void TryStartGame()
        {
            if (_playerInstalled)
                _eventManager.Broadcast(_eventManager.GlobalEventsList.startGameEvent);
        }
    }
}