using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace N_Awakening.SWVR
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] Transform pool;
        [SerializeField] Transform target;
        [SerializeField] Transform spawnpos;
        [SerializeField] AudioSource clip;
        // Start is called before the first frame update
        void Start()
        {
            InvokeRepeating("Fire", 3f, 3f);
            Fire();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void Fire()
        {
            if (target.position.z > transform.position.z - 7 && target.position.z < transform.position.z + 7)
            {
                Debug.Log("entro");
                for (int i =0; i < pool.childCount; i++)
                {
                    if (!pool.GetChild(i).gameObject.activeSelf)
                    {
                        pool.GetChild(i).gameObject.SetActive(true);
                        pool.GetChild(i).transform.position = spawnpos.position;
                        pool.GetChild(i).transform.forward = target.position - spawnpos.position;
                        pool.GetChild(i).GetComponent<BulletBehaviour>().Fire((target.position - spawnpos.position).normalized);
                        clip.Play();
                        break;
                    }
                }
            }
        }
    }
}

