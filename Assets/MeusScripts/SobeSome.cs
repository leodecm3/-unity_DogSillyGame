using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SobeSome : MonoBehaviour
{
    Text textoScore;

    float alturaTela;

    GameObject objetoPlayer;
    bool marcouPonto;
    void Start()
    {

        alturaTela = Camera.main.orthographicSize * 2f;
        // GetComponent<Collider2D>().enabled = true; 
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 4f);
        // GetComponent<Collider2D>().enabled = false;
        // objetoPlayer = GameObject.FindGameObjectWithTag("Player");

    }

    // void OnCollisionEnter2D()
    // {
    //     Debug.Log("Colidiu");

    // }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y > (alturaTela * 0.5f * 1.2f))
        {
            // Debug.Log("deleta obj da scene");
            Destroy(this.gameObject);
        }

    }


}
