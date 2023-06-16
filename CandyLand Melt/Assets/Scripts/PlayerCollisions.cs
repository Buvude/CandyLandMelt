using UnityEngine;

namespace Player
{
    public class PlayerCollisions : MonoBehaviour
    {
        [SerializeField] private string floorTag;
        [SerializeField] private string pickableTag;
        [SerializeField] private HoldObject holdObject;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == pickableTag)
            {
                holdObject.GrabPickable(collision.gameObject);
            }
        }
    }
}
