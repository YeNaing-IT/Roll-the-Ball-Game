using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

namespace YeNaing
{
    public class PlayerController : MonoBehaviour
    {
        public float playerSpeed = 5.0f;
        private Rigidbody playerRb;
        private Vector3 movement;

        [SerializeField] InGameUIController inGameUIController;

        void Start()
        {
            playerRb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            MovePlayer();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Coin"))
            {
                inGameUIController.coinAmount++;
                Destroy(other.gameObject);
            }

            if (other.gameObject.CompareTag("GameWinTrigger"))
            {
                GameManager.instance.OnWin();
                inGameUIController.GameWin();
            }

        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                inGameUIController.GameLost();
                //GameManager.instance.OnLose();
                Destroy(gameObject);
            }
        }

        // Player Input
        public void OnMove(InputValue movementValue)
        {
            Vector2 movementVector = movementValue.Get<Vector2>();
            float xMovement = movementVector.x;
            float yMovement = movementVector.y;

            movement = new Vector3(xMovement, 0, yMovement);
        }

        private void MovePlayer()
        {
            playerRb.AddForce(movement * playerSpeed);
        }
    }
}