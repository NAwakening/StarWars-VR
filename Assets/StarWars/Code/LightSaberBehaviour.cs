using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace N_Awakening.SWVR
{
    public class LightSaberBehaviour : MonoBehaviour
    {
        [SerializeField] ParticleSystem particles;
        [SerializeField] AudioSource deflect;
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bullet"))
            {
                other.gameObject.SetActive(false);
                particles.Play();
                deflect.Play();
            }
        }
    }
}

