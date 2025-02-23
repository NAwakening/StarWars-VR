using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace N_Awakening.SWVR
{
    public class Player : MonoBehaviour
    {
        [SerializeField] int life, maxLife;
        [SerializeField] GameObject[] lifeMeter;
        [SerializeField] AudioSource hurt;
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                StopAllCoroutines();
                life--;
                hurt.Play();
                if (life == 0)
                {
                    ReloadScene();
                }
                HPShow();
                StartCoroutine(LongRecovery());
            }
            else if (collision.gameObject.CompareTag("DeathBarrier"))
            {
                ReloadScene();
            }
        }

        protected void ReloadScene()
        {
            SceneManager.LoadScene(0);
        }

        protected void HPShow()
        {
            switch (life)
            {
                case 1:
                    DeactivatePanels();
                    lifeMeter[0].SetActive(true);
                    break;
                case 2:
                    DeactivatePanels();
                    lifeMeter[1].SetActive(true);
                    break;
                case 3:
                    DeactivatePanels();
                    lifeMeter[2].SetActive(true);
                    break;
                case 4:
                    DeactivatePanels();
                    lifeMeter[3].SetActive(true);
                    break;
                case 5:
                    DeactivatePanels();
                    break;
            }
        }
        protected void DeactivatePanels()
        {
            for (int i = 0; i < lifeMeter.Length; i++)
            {
                lifeMeter[i].SetActive(false);
            }
        }

        IEnumerator LongRecovery()
        {
            yield return new WaitForSeconds(7);
            if (life < maxLife)
            {
                life++;
                HPShow();
                if (life < maxLife)
                {
                    StartCoroutine(ShortRecovery());
                }
            }
        }
        IEnumerator ShortRecovery()
        {
            yield return new WaitForSeconds(2);
            if (life < maxLife)
            {
                life++;
                HPShow();
                if (life < maxLife)
                {
                    StartCoroutine(ShortRecovery());
                }
            }
        }
    }
}