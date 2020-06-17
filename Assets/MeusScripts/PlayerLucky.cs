using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLucky : MonoBehaviour
{

    public GameObject GameEngine;

    // Start is called before the first frame update
    void Start()
    {

        // GetComponent<Collider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }



    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Enemy")
        {
            GameEngine.SendMessage("Pontua", -1);
            // collision.gameObject.GetComponent<Collider2D>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 0));
            collision.gameObject.GetComponent<Rigidbody2D>().AddTorque(300f);

            collision.gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 0f, 0f, 1f);

            Debug.Log("colidiu com Enemy");

            // collision.gameObject.SendMessage("ApplyDamage", 10);
        }
        else if (collision.gameObject.tag == "Potion")
        {
            GameEngine.SendMessage("Pontua", 1);
            Destroy(collision.gameObject);
            Debug.Log("colidiu com Potion");
            // collision.gameObject.SendMessage("ApplyDamage", 10);
        }
    }



    // void OnCollisionEnter2D()
    // {
    //     Debug.Log("Colidiu");
    //     // GetComponent<Collider2D>().enabled = false; 
    //     // GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    //     // GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 0));
    //     // GetComponent<Rigidbody2D>().AddTorque(300f);
    //     // GetComponent<SpriteRenderer>().color = new Color(1f, 0.75f, 0.75f, 1.0f);
    //     // Invoke("FimDejogo", 1);
    // }

    public void ControlaPosicao(float posicao)
    {
        //nao altera o y original, so o x
        this.transform.position = new Vector2(posicao, this.transform.position.y);
    }

}
