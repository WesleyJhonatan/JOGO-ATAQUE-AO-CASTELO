using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Animacoes : MonoBehaviour
{
    public Animator Animador;
  
    private bool podeW = true;
    private bool podeQ = true;
    private bool podeE = true;
    private Gerenciador GJ;

    public GameObject EspecialBoj;
    public Animator AreadeEspecial;

    public RectTransform ImagemCinzaQ;
    public float CinzaQ;
    private bool podeCinzaQ = false;
    private float tempoCinzaQ = 0;

    public RectTransform ImagemCinzaW;
    public float CinzaW;
    private bool podeCinzaW = false;
    private float tempoCinzaW = 0;

    public RectTransform ImagemCinzaE;
    public float CinzaE;
    private bool podeCinzaE = false;
    private float tempoCinzaE = 0;

    public GameObject SomW;
    public GameObject SomQ;
    public GameObject SomE;

    public GameObject Suport1;
    public GameObject LocalSaida1;

    public GameObject Suport2;
    public GameObject LocalSaida2;

    public GameObject Explosao;
    public GameObject LocaoExplosao;

    public GameObject Explosao2;
    public GameObject LocaoExplosao2;

    private bool Nasce = false;
    private float tempoNasce = 0;

    public LançaEspecial PodewLanca;

    public Movimento podep;

    void Start()
    {
        CinzaQ = 0;
        CinzaW = 0;
        CinzaE = 0;
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
    }


    void Update()
    {
       // private Gerenciador GJ;
        if (GJ.EstadoDoJogo() == true)

        {
            ImagemCinzaQ.sizeDelta = new Vector2(CinzaQ, CinzaQ);
            ImagemCinzaW.sizeDelta = new Vector2(CinzaW, CinzaW);
            ImagemCinzaE.sizeDelta = new Vector2(CinzaE, CinzaE);

            if (Nasce == true)
            {
                tempoNasce += Time.deltaTime;
                if (tempoNasce >= 0.3)
                {
                    Instantiate(Suport2, LocalSaida1.transform.position, Quaternion.identity);
                    Instantiate(Suport2, LocalSaida2.transform.position, Quaternion.identity);
                    Nasce = false;
                    tempoNasce = 0;
                }
            }

            if (podeCinzaQ == true)
            {
                tempoCinzaQ += Time.deltaTime;
                if (tempoCinzaQ >= 0.3)
                {
                    CinzaQ = CinzaQ - 1;
                    tempoCinzaQ = 0;
                }
            }

            if (podeCinzaW == true)
            {
                tempoCinzaW += Time.deltaTime;
                if (tempoCinzaW >= 0.3)
                {
                    CinzaW = CinzaW - 1;
                    tempoCinzaW = 0;
                }
            }

            if (podeCinzaE == true)
            {
                tempoCinzaE += Time.deltaTime;
                if (tempoCinzaE >= 0.3)
                {
                    CinzaE = CinzaE - 1;
                    tempoCinzaE = 0;
                }
            }

            if (podeE == true)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    podeE = false;
                    podeCinzaE = true;
                    CinzaE = 115;
                    SomE.SetActive(true);
                    Animador.SetBool("Pose", true);
                    Animador.SetBool("EspecialA", false);
                    Animador.SetBool("Pular", false);
                    Animador.SetBool("Correr", false);
                    Animador.SetBool("Dor", false);
                    Animador.SetBool("Ataque", false);
                    Animador.SetBool("EspecialB", false);
                    Nasce = true;
                    Instantiate(Explosao, LocaoExplosao.transform.position, Quaternion.identity);
                    Instantiate(Explosao2, LocaoExplosao2.transform.position, Quaternion.identity);


                }
            }

            if (CinzaE == 0)
            {
                podeCinzaE = false;
                SomE.SetActive(false);
                podeE = true;
                
            }

            if (podeW == true)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    PodewLanca.podeW = true;
                    SomW.SetActive(true);
                    podeCinzaW = true;
                    CinzaW = 115;
                    Animador.SetBool("EspecialA", true);
                    Animador.SetBool("Pular", false);
                    Animador.SetBool("Correr", false);
                    Animador.SetBool("Dor", false);
                    Animador.SetBool("Ataque", false);
                    Animador.SetBool("EspecialB", false);
                    podeW = false;

                }
            }

            if (CinzaW == 0)
            {
                podeCinzaW = false;
                podeW = true;
            }

            if (podeQ == true)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    SomQ.SetActive(true);
                    podeCinzaQ = true;
                    CinzaQ = 115;
                    Animador.SetBool("EspecialB", true);
                    Animador.SetBool("EspecialA", false);
                    Animador.SetBool("Pular", false);
                    Animador.SetBool("Correr", false);
                    Animador.SetBool("Dor", false);
                    Animador.SetBool("Ataque", false);
                    EspecialBoj.SetActive(true);
                    AreadeEspecial.SetBool("EspecialQ", true);
                    podeQ = false;

                }

            }

            if (CinzaQ == 0)
            {
                podeCinzaQ = false;
                podeQ = true;
            }

        }
    }
       
       

    public void DesativaEspecial()
    {
        Animador.SetBool("EspecialA", false);
        SomW.SetActive(false);
    }
    public void DesativaEspecialB()
    {
        Animador.SetBool("EspecialB", false);
        SomQ.SetActive(false);
    }

    public void DesativaEspecialE()
    {
        Animador.SetBool("Pose", false);
    }
    public void DesativaQ()
    {
        AreadeEspecial.SetBool("EspecialQ", false);
        EspecialBoj.SetActive(false);
    }

    public void PulaFalse()
    {
        podep.podepular = true;
        Animador.SetBool("Pular", false);
    }

  
}
