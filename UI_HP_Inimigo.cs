using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HP_Inimigo : MonoBehaviour
{
    public RectTransform ImagemHP;
    public float HP;
    public Animator Animador;
    public float tempo = 0;
    private Gerenciador GJ;
    public int recompensa4 = 0;
    private float tempo2 = 0;
    private float tempo3 = 0;
    private bool danoAjuda = true;

    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
        Animador = GetComponent<Animator>();
    }


    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            ImagemHP.sizeDelta = new Vector2(HP, 21.61f);
            Morrer();

            if (danoAjuda == false)
            {
                tempo3 += Time.deltaTime;
                if (tempo3 > 0.9f)
                {
                    tempo3 = 0;
                    danoAjuda = true;

                }
            }

        }
    }

    public void Dano()
    {
        HP = HP - 10;
        Animador.SetBool("DorMontro", true);
        Animador.SetBool("Andar", false);
        Animador.SetBool("Ataque", false);
        Animador.SetBool("Pedrada", false);
    }

    void Morrer()
    {
        if (HP <= 0)
        {
            GJ.RenasceInimigoNormal();
            Animador.SetTrigger("Morrer");
            Animador.SetBool("DorMontro", false);
            Animador.SetBool("Andar", false);
            Animador.SetBool("Ataque", false);
            Animador.SetBool("Pedrada", false);
            Destroy(gameObject, 2);
        }
    }

    public void ParaDor()
    {
        Animador.SetBool("DorMontro", false);
    }

    private void OnTriggerEnter(Collider colisao)
    {
        if (colisao.gameObject.tag == "EspecialDanoA")
        {
            HP = HP - 20;
            Animador.SetBool("DorMontro", true);
            Animador.SetBool("Andar", false);
            Animador.SetBool("Ataque", false);
            Animador.SetBool("Pedrada", false);
        }

        if (colisao.gameObject.tag == "EspecialDanoB")
        {
            HP = HP - 15;
            Animador.SetBool("DorMontro", true);
            Animador.SetBool("Andar", false);
            Animador.SetBool("Ataque", false);
            Animador.SetBool("Pedrada", false);
        }

    }

    void OnCollisionStay(Collision colisao)
    {

        if (colisao.gameObject.tag == "Ajudante")
        {
            if(danoAjuda == true)
            {
                tempo2 += Time.deltaTime;
                if (tempo2 > 0.5)
                {
                    danoAjuda = false;
                    tempo2 = 0;
                    Dano();
                }
            }
        }

    }

        public void ContaPonto()
    {
        GJ.RecebePontos4(recompensa4);
    }

}
