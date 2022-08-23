using EventSystem;
using GameScene.PlayerEntities.View;
using Zenject;

namespace GameScene.PlayerEntities
{
    public class PlayerEventRule
    {
        private EventManager _eventManager;

        private PlayerView _playerView;
        private PlayerService _playerService;
        
        public PlayerEventRule(EventManager eventManager, PlayerView playerView, PlayerService playerService)
        {
            _eventManager = eventManager;
            _playerView = playerView;
            _playerService = playerService;

            SetCallBack();
        }
        
        private void SetCallBack()
        {
        }
    }
}