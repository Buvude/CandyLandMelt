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
        Score _score;

        private void Start()
        {
            pickables = new Stack<Transform>();
            _score = Score.Instance;
        }
        public void GrabPickable(GameObject pickable)
        {   if(pickables.Count < maxPickablesToHold)
            {
                pickable.GetComponent<Rigidbody2D>().isKinematic = true;
                pickable.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                pickable.GetComponentInChildren<Collider2D>().enabled = false;
                pickables.Push(pickable.transform);
                pickable.transform.parent = pickablesHolder;
                UpdatePickables();
            }
        }
        public void DestroyPickable()
        {
            if(pickables.Count > 0)
            {
                Transform toDelete = pickables.Pop();
                toDelete.GetComponent<Rigidbody2D>().isKinematic = false;
                toDelete.GetComponentInChildren<Collider2D>().enabled = true;
                toDelete.GetComponent<PoolObject>().Recycle();
                UpdatePickables();
                _score.AddScore(_score.GetRegularPointValue());
            }
        }
        public bool GetEnoughPickables()  { return (pickables.Count > 0); }
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