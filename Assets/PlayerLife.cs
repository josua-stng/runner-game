using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    bool dead = false;
    public AudioSource classic_hurt;

    private void Update()
    {
        if (transform.position.y < -15f && !dead)
        {
             classic_hurt.UnPause();
             Invoke("Die", 0.5f);
            //Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Body") && !dead)
        {
            classic_hurt.UnPause();
            Invoke("Die", 0.5f);
            //classic_hurt.Play();
            // classic_hurt.UnPause();
           // Die();

        }
    }

    void Die()
    {
        //classic_hurt.UnPause();
        //classic_hurt.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        dead = true;
    }

    private void Start()
    {
        classic_hurt = GetComponent<AudioSource>();
       classic_hurt.Play();
       classic_hurt.Pause();
    }
}
