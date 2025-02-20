using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace N_Awakening.SWVR
{
    public class BulletBehaviour : MonoBehaviour
    {
        [SerializeField] Rigidbody rb;
        [SerializeField] float velocity;
        private void OnCollisionEnter(Collision collision)
        {
            Invoke("DeactivateBullet", 0.1f);
        }

        private void DeactivateBullet()
        {
            gameObject.SetActive(false);
        }

        public void Fire(Vector3 direction)
        {
            rb.AddForce(direction * velocity, ForceMode.Impulse);
        }
    }
}