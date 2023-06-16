using UnityEngine;
namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jump : MonoBehaviour
    {
        [Range(1, 10)] public float jumpVelocity = 5;
        private Rigidbody2D rb;
        private bool _jumpAvailable = true;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        public void SetJumpAvailable(bool jumpAvailable)
        {
            _jumpAvailable = jumpAvailable;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _jumpAvailable)
            {
                rb.velocity = Vector2.up * jumpVelocity;
                _jumpAvailable = false;
            }
        }
    }
}