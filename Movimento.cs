using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Movimento : MonoBehaviour
{
    public NavMeshAgent Corpo;
    public float DistanciaDestino;
    public Animator Animador;
    private Gerenciador GJ;
    public bool podeir = false;

    public float forcaPulo;
    public bool podepular = true;

    public Rigidbody Corpo2;

    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
        Corpo = GetComponent<NavMeshAgent>();
        Corpo2 = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            Mover();
            Parar();


            if (podepular == true)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    podepular = false;
                    Animador.SetBool("Pular", true);
                    Animador.SetBool("Correr", false);
                    Animador.SetBool("Dor", false);
                    Animador.SetBool("Ataque", false);
                    Animador.SetBool("EspecialA", false);
                    Animador.SetBool("EspecialB", false);
                }
            }
        }
          
    }

    void Mover()
    {
       if(podeir == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 500))
                {

                    Corpo.destination = hit.point;

                }
            }
        }
        

       
    }

        void Parar()
    {
        DistanciaDestino = Vector3.Distance(transform.position, Corpo.destination);
        if (DistanciaDestino < 3)
        {
            Corpo.speed = 0;
            Animador.SetBool("Correr", false);
        }

        else
        {
            Corpo.speed = 20;
            Animador.SetBool("Correr", true);
        }
    }

    private void OnCollisionEnter(Collision colidiu)
    {
        if (colidiu.gameObject.tag == "Chao")
        {
            Animador.SetBool("Pular", false);
            podepular = true;
        }

    }


}
