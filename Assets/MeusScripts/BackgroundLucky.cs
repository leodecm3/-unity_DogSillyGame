using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLucky : MonoBehaviour
{
    float alturaTela;
    float larguraTela;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3);
        SpriteRenderer grafico = GetComponent<SpriteRenderer>();

        float larguraImagem = grafico.sprite.bounds.size.x;
        float alturaImagem = grafico.sprite.bounds.size.y;

        //		print(larguraImagem);
        //		print(alturaImagem);

        alturaTela = Camera.main.orthographicSize * 2f;

        //		Camera's half-size when in orthographic mode.
        //		This is half of the vertical size of the viewing volume. 
        //		Horizontal viewing size varies depending on viewport's aspect ratio.

        larguraTela = alturaTela / Screen.height * Screen.width;
        //		The current height of the screen window in pixels

        Vector2 novaEscala = transform.localScale;
        novaEscala.x = larguraTela / larguraImagem;
        novaEscala.y = alturaTela / alturaImagem + 0.05f;
        transform.localScale = novaEscala;

        // Debug.Log("aqui " + alturaTela);
        // Debug.Log(transform.position);

        if (this.name == "BackgroundLuckyB")
        {
            // Debug.Log("aqui " + alturaTela);
            // Debug.Log(transform.position);
            this.transform.position = new Vector2(0f, -alturaTela);
            // Debug.Log(transform.position); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(this.name + " _ " + this.transform.position.y + " alturaTela: " + alturaTela);
        if (this.transform.position.y >= alturaTela)
        {
            transform.position = new Vector2(0f, -alturaTela);
        }
    }
}
