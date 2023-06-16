using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerCollisions))]
    public class HoldObject : MonoBehaviour
    {
        [SerializeField] private Transform pickablesHolder;
        [SerializeField] private float distanceBetweenPickables;
        [SerializeField] private float maxPickablesToHold;
        private Stack<Transform> pickables;

        private void Start()
        {
            pickables = new Stack<Transform>();
        }
        public void GrabPickable(GameObject pickable)
        {   if(pickables.Count < maxPickablesToHold)
            {
                pickables.Push(pickable.transform);
                pickable.transform.parent = pickablesHolder;
                UpdatePickables();
            }
        }
        private void UpdatePickables()
        {
            Vector2 pickablePosition = Vector2.zero;
            foreach(Transform current in pickables)
            {
                pickablePosition = new Vector2(0, pickablePosition.y + distanceBetweenPickables);
                current.transform.localPosition = pickablePosition;
            }
        }
    }
}