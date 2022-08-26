using EventSystem;
using GameScene.Camera.Systems;
using GameScene.PlayerEntities.View;

namespace GameScene.Camera
{
   public class CameraRule
   {
      private CameraSwitcher _cameraSwitcher;
      private VCsTargetSetter _vCsTargetSetter;
      
      
      public CameraRule(EventManager eventManager, PlayerView target, CameraSwitcher cameraSwitcher, VCsTargetSetter setter)
      {
         _cameraSwitcher = cameraSwitcher;
         _vCsTargetSetter = setter;
         
         SetCameraCallBack(eventManager, target);
      }

      private void SetCameraCallBack(EventManager eventManager, PlayerView target)
      {
         eventManager.AddListener<StartGameEvent>(evt => 
         {
            _vCsTargetSetter.Set(target.transform);
            _cameraSwitcher.ToFitch();
         });
         eventManager.AddListener<StartFitchEvent>(evt => _cameraSwitcher.ToWalking());
      }
   }
}
