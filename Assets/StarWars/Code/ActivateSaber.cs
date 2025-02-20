using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace N_Awakening.SWVR
{
    public class ActivateSaber : MonoBehaviour
    {
        [SerializeField] GameObject blade;
        [SerializeField] AudioSource activate, deactivate;
        
        public void Activate()
        {
            if (blade.activeSelf)
            {
                blade.SetActive(false);
                deactivate.Play();
            }
            else
            {
                blade.SetActive(true);
                activate.Play();
            }
        }
    }
}