using EventSystem;
using MarkEntities.System;
using Zenject;

namespace GameScene
{
    public class GameSceneStartGate
    {
        private EventManager _eventManager;

        [Inject] private MarksProvider _marksProvider;
        private bool _marksProviderFulfilled = false;
        
        public GameSceneStartGate(EventManager eventManager, MarksProvider marksProvider)
        {
            _eventManager = eventManager;
            SubscribeToPendingServices();
        }
    
        private void SubscribeToPendingServices()
        {
            _marksProvider.MarkGathered += () =>
            {
                _marksProviderFulfilled = true;
                TryStartGame();
            };
        }

        private void TryStartGame()
        {
            if (_marksProviderFulfilled)
                _eventManager.Broadcast(_eventManager.GlobalEventsList.startGameEvent);
        }
    }
}