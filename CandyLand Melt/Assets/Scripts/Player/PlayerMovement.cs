using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 2f;
        private Rigidbody2D rb;
        private Vector2 movementDirection;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            movementDirection = new Vector2(Input.GetAxis("Horizontal"), 0);
        }
        private void FixedUpdate()
        {
            rb.velocity = new Vector2(movementDirection.x * movementSpeed, rb.velocity.y);
        }
    }

}