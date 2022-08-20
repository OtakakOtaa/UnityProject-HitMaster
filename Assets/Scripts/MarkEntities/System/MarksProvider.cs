using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace MarkEntities.System
{
    public class MarksProvider : MonoBehaviour
    {
        public Transform[] PlayerWayPoints { get; private set; }
        public Transform PlayerSpawnPoint { get; private set; }

        public event UnityAction MarkGathered;
    
        private void Start()
        {
            ObjectMark[] allMark = FindObjectsOfType<ObjectMark>();
        
            DetectPlayerSpawn(allMark);
            CollectPlayerWayPoint(allMark);
        
            MarkGathered?.Invoke();
        }

        private void DetectPlayerSpawn(ObjectMark[] allMark)
        {
            PlayerSpawnPoint = (
                from p in allMark
                where p.Type == MarksType.PlayerSpawn
                select p.transform).ToArray()?[0];
        }

        private void CollectPlayerWayPoint(ObjectMark[] allMark)
        {
            PlayerWayPoints = (
                from p in allMark
                where p.Type == MarksType.PlayerWayPoint
                orderby p.Priority descending
                select p.transform).ToArray();
        } 
    }
}