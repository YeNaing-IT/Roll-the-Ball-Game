using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using YeNaing;

namespace YeNaing
{
    public class ElevatorController : MonoBehaviour
    {

        [SerializeField] private Animator elevatorAnimationController;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                elevatorAnimationController.SetBool("moveElevator", true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                elevatorAnimationController.SetBool("moveElevator", false);
            }
        }
    }
}
