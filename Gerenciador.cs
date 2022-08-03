using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gerenciador : MonoBehaviour
{

    // verifica se o jogo esta ligado ou não
    public bool GameLigado = false;
    private Gerenciador GJ;

    //  tela menu
    public GameObject TelaMenu;

    public GameObject TelaPause;

    public GameObject TelaGameOver;

    public GameObject TelaVencedor;

    public int pontos;
    public int pontos2;
    public int pontos3;
    public int pontos4;


    public GameObject Mostro;
    public GameObject LocalSaida2;

    public GameObject Mostro3;
    public GameObject LocalSaida3;

    private bool PodeNascer = false;
    private bool PodeNascer2 = false;
    private float tempo = 0;
    private float tempo2 = 0;

    public GameObject Jogo;
    public GameObject Inicial;



    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();

        //Pausa o Script
        GameLigado = false;
        //Pausa fisica do Jogo
        Time.timeScale = 0;
    }

  
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TelaPause.SetActive(true);
                GameLigado = false;
                Time.timeScale = 0;

            }

            if (PodeNascer == true)
            {
                tempo += Time.deltaTime;
                if (tempo > 40)
                {
                    
                    Instantiate(Mostro, LocalSaida2.transform.position, Quaternion.identity);
                    PodeNascer = false;
                    tempo = 0;
                }
            }

            if (PodeNascer2 == true)
            {
                tempo2 += Time.deltaTime;
                if (tempo2 > 40)
                {
                    Instantiate(Mostro3, LocalSaida3.transform.position, Quaternion.identity);
                    PodeNascer2 = false;
                    tempo2 = 0;
                }
            }

            if(pontos2 >= 1)
            {
                TelaVenceu();
            }

            if (pontos >= 50 && pontos3 >= 50 && pontos4 >= 10)
            {
                TelaVenceu();
            }
        }

        
    }

    public bool EstadoDoJogo()
    {

        return GameLigado;

    }

    public void LigarJogo()

    {
        Jogo.SetActive(true);
        Inicial.SetActive(false);

        Cursor.visible = false;
        GameLigado = true;
        Time.timeScale = 1;

    }

    public void BTSair()
    {
        Application.Quit();

    }

    public void BTVoltarMenu()
    {
        SceneManager.LoadScene(0);
        GameLigado = false;
        Time.timeScale = 0;
        TelaMenu.SetActive(true);

        Jogo.SetActive(false);
        Inicial.SetActive(true);

    }

    public void TiraPausaJogo()

    {
        GameLigado = true;
        Time.timeScale = 1;
        TelaPause.SetActive(false);

    }

    public void RecebePontos(int ponto)
    {
        pontos = pontos + ponto;
    }

    public void RecebePontos2(int ponto2)
    {
        pontos2 = pontos2 + ponto2;

        
    }

    public void RecebePontos3(int ponto3)
    {
        pontos3 = pontos3 + ponto3;


    }

    public void RecebePontos4(int ponto4)
    {
        pontos4 = pontos4 + ponto4;


    }

    public int RetornaPontos()
    {
        return pontos;
    }

    public int RetornaPontos2()
    {
        return pontos2;
    }

    public int RetornaPontos3()
    {
        return pontos3;
    }
    public int RetornaPontos4()
    {
        return pontos4;
    }


    public void RenasceAtirador()

    {
        PodeNascer = true;
    }
    
     public void RenasceInimigoNormal()

     {
        PodeNascer2 = true;
     }

    public void TelaPerdeu()
    {
        GameLigado = false;
        Time.timeScale = 0;
        TelaGameOver.SetActive(true);
    }

    public void TelaVenceu()
    {
        GameLigado = false;
        Time.timeScale = 0;
        TelaVencedor.SetActive(true);
    }


}
