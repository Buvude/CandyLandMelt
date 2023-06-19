using UnityEngine;

namespace Player
{
    public class PlayerCollisions : MonoBehaviour
    {
        [SerializeField] private string floorTag;
        [SerializeField] private string pickableTag;
        [SerializeField] private string citizenTag;
        [SerializeField] private HoldObject holdObject;
        [SerializeField] private Jump jump;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == pickableTag)
            {
                holdObject.GrabPickable(collision.gameObject);
            }
            
        }
        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.tag == floorTag)
            {
                if (collision.transform.position.y < this.transform.position.y)
                {
                    jump.SetJumpAvailable(true);
                }
            }
            if (collision.gameObject.tag == citizenTag)
            {
                if (holdObject.GetEnoughPickables())
                {
                    holdObject.SetInDeliverArea(true);
                    holdObject.SetCitizenToDeliver(collision.GetComponent<CitizenBehaviour>());
                    //holdObject.DestroyPickable();
                    //collision.GetComponent<CitizenBehaviour>().RecoverHealth();
                }
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.tag == citizenTag)
            {
                if (holdObject.GetEnoughPickables())
                {
                    holdObject.SetInDeliverArea(false);
                }
            }
        }
    }
}
