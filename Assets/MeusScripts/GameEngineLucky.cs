using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEngineLucky : MonoBehaviour
{
    float alturaTela;
    float larguraTela;

    public Slider mainSlider;
    public GameObject Player;
    public GameObject Cookie;
    public GameObject InimigoCao;
    public Text textoScore;
    int pontuacao;
    bool iniciou;

    // Start is called before the first frame update
    void Start()
    {

        alturaTela = Camera.main.orthographicSize * 2f;
        larguraTela = alturaTela / Screen.height * Screen.width;
        Debug.Log("larguraTela: " + larguraTela + " / alturaTela: " + alturaTela);
        Debug.Log("Screen.width px: " + Screen.width + " / Screen.height px: " + Screen.height);





        //min e maximo no slider que move o lucky  
        mainSlider.minValue = -(larguraTela / 2) * 0.9f;
        mainSlider.maxValue = (larguraTela / 2) * 0.9f;
        //nao funcinou  // mainSlider.transform.position.y = (-alturaTela/2) + (alturaTela/4) ;  //e posicao


        //texto
        textoScore.text = "Clique para iniciar";


    }

    public void Pontua(int pontos)
    {
        if (pontos == -1)
        {
            textoScore.text = "FINAL SCORE: " + pontuacao + "\n\n            AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
            CancelInvoke("CriaPersonagem");
            Invoke("RecarregaCena", 2);
        }
        else
        {

            pontuacao += pontos;
            textoScore.text = "SCORE: " + pontuacao;
        }
    }

    void CriaPersonagem()
    {
        //range do aleatorio
        float _temp;
        _temp = larguraTela * 0.9f; // tiro 10% 
        _temp = _temp / 2; //distancia ao ponto 00
        float larguraAleatoria = Random.Range(-_temp, _temp);


        //50% de chance de instanciar um ou outro
        if (Random.value > 0.5f)
        {
            //instancia inimigo
            Instantiate(InimigoCao, new Vector3(larguraAleatoria, (-alturaTela / 2f), 0f), Quaternion.Euler(0, 0, 0));
        }
        else
        {
            //instancia potion
            Instantiate(Cookie, new Vector3(larguraAleatoria, (-alturaTela / 2f), 0f), Quaternion.Euler(0, 0, 0));

        }

    }


    void RecarregaCena()
    {
        SceneManager.LoadScene("LuckyScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (iniciou == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                // inicia o jogo

                iniciou = true;

                //zera pontuacao
                Pontua(0);

                //posicao inicial em y do lucky
                Player.transform.position = new Vector2(0.0f, (alturaTela / 2) - (alturaTela * 0.20f)); //na extremidade superior da tela (a tela tem 10 ou seja do ponto 00 que ta no meio, eh meia tela 5) menos 20%

                //a cada seg cria um personagem
                InvokeRepeating("CriaPersonagem", 1, 1.5f); // #pendente mudar o primeiro para 0
            }
        }
    }
}
