using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Inimigo : MonoBehaviour
{
    private NavMeshAgent Agente;
    private GameObject Heroi;
    public Animator Animador;
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
            if (DistanciaHeroi < 30 && DistanciaHeroi > 2)
            {
                Agente.speed = 15;
                MoverInimigo();
                Animador.SetBool("Andar", true);

            }

            else
            {
                Agente.speed = 0;
                Animador.SetBool("Andar", false);

            }

            if (DistanciaHeroi < 8)
            {
                Animador.SetBool("Ataque", true);
                Animador.SetBool("Andar", false);
                //Destroy(gameObject, 1f);
            }

        }
           
    }

    private void MoverInimigo()
    {
        Agente.destination = Heroi.transform.position;
    }

    
}
