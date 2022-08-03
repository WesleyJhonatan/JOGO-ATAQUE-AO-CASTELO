using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AjudanteAtaque : MonoBehaviour
{
    private NavMeshAgent Agente;
    private GameObject Inimigos;
    private Gerenciador GJ;

    public bool podeAndar = true;
    public float tempo = 0;
    public Animator Animador;


    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
        Agente = GetComponent<NavMeshAgent>();
        Inimigos = GameObject.FindGameObjectWithTag("AtacanteCastelo");
        Animador = GetComponent<Animator>();
    }


    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            Destroy(gameObject, 20);

            if(podeAndar == true)
            {
                float DistanciaInimigo = Vector3.Distance(transform.position, Inimigos.transform.position);
                if (DistanciaInimigo < 700 && DistanciaInimigo > 2)
                {
                   
                    Agente.speed = 15f;
                    Mover();
                    Animador.SetBool("Andar", true);
                    Animador.SetBool("Ataque", false);

                }

                else
                {
                    Agente.speed = 0;
                    Animador.SetBool("Andar", false);
                    Animador.SetBool("Ataque", false);
                }
            }
            

        }

    }

    private void Mover()
    {
        Agente.destination = Inimigos.transform.position;
    }


    void OnCollisionEnter(Collision collision)
    {
        
            if (collision.gameObject.tag == "AtacanteCastelo")
            {
                podeAndar = false;
                Animador.SetBool("Andar", false);
                Animador.SetBool("Ataque", true);
            }

    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.gameObject.tag == "AtacanteCastelo")
        {
            podeAndar = true;
            Animador.SetBool("Ataque", false);
        }
    }
}
