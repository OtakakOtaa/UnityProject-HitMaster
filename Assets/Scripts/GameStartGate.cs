using EventSystem;

public class GameStartGate
{
    private PlayerFactory _playerFactory;
    private bool _playerCreationIsFinish = false; 
    
    private EventManager _eventManager;
    
    public GameStartGate(PlayerFactory playerFactory, EventManager eventManager)
    {
        _eventManager = eventManager;
        _playerFactory = playerFactory;

        ActivateInstallersCallBack();
    }

    private void TryStartGameScene()
    {
        if (_playerCreationIsFinish)
        {
            _eventManager.Broadcast(_eventManager.GlobalEventsList.startGameEvent);
        }
    }

    private void ActivateInstallersCallBack()
    {
        _playerFactory.CreationFinished += () =>
        {
            _playerCreationIsFinish = true;
            TryStartGameScene();
        };
    }
    
}
