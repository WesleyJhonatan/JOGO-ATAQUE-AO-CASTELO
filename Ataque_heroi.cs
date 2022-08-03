using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque_heroi : MonoBehaviour
{
    public Animator AreaAtaque;
    public Animator PersonagemAtaque;

    public bool Atacando = false;
    public bool DeuDano = false;

    public GameObject TelaCinza;
    private Gerenciador GJ;

    public GameObject AtaqueSom;


    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
    }

   
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            if (Atacando == true)
            {
                Atacar();
            }

            else
            {
                if (Input.GetMouseButtonDown(1))
                {
                    AtaqueSom.SetActive(true);
                    Atacando = true;
                    DeuDano = false;
                    AreaAtaque.SetBool("Ataquei", true);
                    PersonagemAtaque.SetBool("Ataque", true);
                    TelaCinza.SetActive(true);
                }
            }
        }
           
        
    }

    public void Atacar()
    {
        if (Input.GetMouseButtonDown(1))
        {

           
            RaycastHit hit;

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 20))
            {
                if(DeuDano == false)
                {
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20, Color.red);

                    if(hit.collider.gameObject.tag == "inimigoNormal")
                    {
                        hit.collider.gameObject.GetComponent<UI_HP_Inimigo>().Dano();
                    }

                    if (hit.collider.gameObject.tag == "inimigoBomba")
                    {
                        hit.collider.gameObject.GetComponent<UIbomba>().Dano();
                    }

                    if (hit.collider.gameObject.tag == "Torreinimiga")
                    {
                        hit.collider.gameObject.GetComponent<UItorreinimiga>().Dano();
                    }

                    if (hit.collider.gameObject.tag == "Caixa")
                    {
                        hit.collider.gameObject.GetComponent<Caixa>().Dano();
                    }

                    if (hit.collider.gameObject.tag == "Castelo")
                    {
                        hit.collider.gameObject.GetComponent<UICasteloinimigo>().Dano();
                    }

                    if (hit.collider.gameObject.tag == "AtacanteCastelo")
                    {
                        hit.collider.gameObject.GetComponent<HPAtacanteCastelo>().Dano();
                    }


                    DeuDano = true;
                }
               
            }

            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20, Color.blue);
               
            }
        }

        
    }

    public void TerminouAtaque()
    {
        TelaCinza.SetActive(false);
        PersonagemAtaque.SetBool("Ataque", false);
        AreaAtaque.SetBool("Ataquei", false);
        Atacando = false;
        AtaqueSom.SetActive(false);
    }
}
