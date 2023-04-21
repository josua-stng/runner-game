using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MovementPlayer : MonoBehaviour
{
    public float kecepatan;
    public float jumpForce;
    Rigidbody rb;
    Animator anim;

    public Transform playerPutaran;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Bergerak();
        Lompat();

    }

    void Bergerak()
    {
        float gerak = Input.GetAxis("Horizontal");
        float majuMundur = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(gerak * kecepatan, rb.velocity.y, majuMundur * kecepatan);
        anim.SetFloat("Kecepatan", Mathf.Abs(majuMundur), 0.1f, Time.deltaTime);
        playerPutaran.localEulerAngles = new Vector3(0, gerak * 90, 0);

        rb.AddForce(Vector3.down * 9.81f, ForceMode.Acceleration);

    }

    void Lompat()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButton("Jump"))
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }


    void Update()
    {
        if (transform.position.y < -15) // ganti nilai -10 dengan batas Y yang ingin digunakan
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}