 using UnityEngine;
 using UnityEngine.Events;
 using Zenject;

 public class PlayerFactory
 {
     private DiContainer _diContainer;
     private MarksProvider _marksProvider;
     
     private const string _playerPrefabPath = "Player";

     public event UnityAction CreationFinished;
     
     [Inject]
     public PlayerFactory(DiContainer diContainer, MarksProvider marksProvider)
     {
         _diContainer = diContainer;
         _marksProvider = marksProvider;
         marksProvider.MarkGathered += CreatePlayer;
     }
     
     private void CreatePlayer()
     {
         
     }

     private void BindPlayerSystem(Player playerComponent)
     {
     }
 }
