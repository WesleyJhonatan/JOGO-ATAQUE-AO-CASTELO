using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigo_Troll : MonoBehaviour
{
    private NavMeshAgent Agente;
    private GameObject Heroi;
    public bool atacando = false;
    public float tempo = 0;
    public Animator Animador;
    public bool podeAndar = true;
    public float tempoB = 0;
    private Gerenciador GJ;

    // Start is called before the first frame update
    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
        Animador = GetComponent<Animator>();
        Agente = GetComponent<NavMeshAgent>();
        Heroi = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            float DistanciaHeroi = Vector3.Distance(transform.position, Heroi.transform.position);
            if (DistanciaHeroi < 20 && DistanciaHeroi > 2)
            {
                Agente.speed = 15;
                MoverInimigo();

                if (podeAndar == true)
                {
                    Animador.SetBool("Ataque", false);
                    Animador.SetBool("Andar", true);
                }



            }

            else
            {
                Agente.speed = 0;
                Animador.SetBool("Andar", false);

            }

            if (DistanciaHeroi < 10 && atacando == false)
            {

                atacando = true;
                Animador.SetBool("Ataque", true);

                podeAndar = false;
            }

            if (podeAndar == false)
            {
                tempoB += Time.deltaTime;
                if (tempoB > 3)
                {

                    podeAndar = true;
                }
            }

            if (atacando == true)
            {
                DelayAtaque();
            }

        }

    }

    private void MoverInimigo()
    {
        Agente.destination = Heroi.transform.position;
    }

    void DelayAtaque()
    {
        tempo += Time.deltaTime;
        if (tempo > 1)
        {
            atacando = false;
            tempo = 0;
        }
    }
}
