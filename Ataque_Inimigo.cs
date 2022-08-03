using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque_Inimigo : MonoBehaviour
{
    public bool DeuDano = false;
    public Animator Animador;
    private Gerenciador GJ;

    // Start is called before the first frame update
    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
        //Animador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            InimigoAtaque();
        }
           
    }

    public void InimigoAtaque()
    {
        RaycastHit hit;
       
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 5))
        {
            if (DeuDano == false)
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5, Color.red);

                if (hit.collider.gameObject.tag == "Player")
                {
                   
                    hit.collider.gameObject.GetComponent<UI_HP_Heroi>().Dano();
                    DeuDano = true;
                }
            }

        }

        else
        {
           
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 5, Color.blue);

        }
    }

    public void PodeAtaca()
    {
        DeuDano = false;
    }

    
}
