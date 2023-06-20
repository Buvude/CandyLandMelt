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
        [SerializeField] private Canvas keyCanvas;
        [SerializeField] private Animator anim;
        private CitizenBehaviour _citizenToDeliver;
        private Stack<Transform> pickables;
        private bool _inDeliverArea = false;
        private Score _score;

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
        public void SetInDeliverArea(bool inDeliverArea)  { _inDeliverArea = inDeliverArea; }
        public void SetCitizenToDeliver(CitizenBehaviour citizenToDeliver) { _citizenToDeliver = citizenToDeliver; }
        private void UpdatePickables()
        {
            Vector2 pickablePosition = Vector2.zero;
            foreach(Transform current in pickables)
            {
                pickablePosition = new Vector2(0, pickablePosition.y + distanceBetweenPickables);
                current.transform.localPosition = pickablePosition;
            }
        }
        private void Update()
        {
            if ((Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift)) && _inDeliverArea && _citizenToDeliver != null)
            {
                _citizenToDeliver.RecoverHealth();
                DestroyPickable();
                if (pickables.Count <= 0)
                    keyCanvas.gameObject.SetActive(false);
            }
            if (pickables.Count > 0)
                anim.SetBool("Holding", true);
            else
                anim.SetBool("Holding", false);
        }
    }
}