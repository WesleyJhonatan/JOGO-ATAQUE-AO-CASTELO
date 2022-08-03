using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caixa : MonoBehaviour
{
    public Animator Animator;
    public RectTransform ImagemHP;
    public float HP;
    private float tempo = 0;
    public GameObject Desativa;
    private bool Ativa = false;
    private float tempo2 = 0;
    private Gerenciador GJ;
    public GameObject ITEM;



    // Start is called before the first frame update
    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            //Animator.SetBool("Quebrar", false);
            ImagemHP.sizeDelta = new Vector2(HP, 5.381f);
            Morrer();

            if (Ativa == true)
            {

                tempo2 += Time.deltaTime;
                if (tempo2 >= 15f)
                {
                    ITEM.SetActive(false);
                    Desativa.SetActive(true);
                    Animator.SetBool("Quebrar", false);
                    Ativa = false;
                    tempo2 = 0;
                }
            }
        }
           
    }

    public void Dano()
    {
        HP = HP - 10;
    }


    public void Morrer()
    {
        if(Ativa == false)
        {
            if (HP <= 0)
            {
                Animator.SetBool("Quebrar", true);
                ITEM.SetActive(true);

                tempo += Time.deltaTime;
                if (tempo >= 1f)
                {
                    HP = HP = 30;
                    Animator.SetBool("Quebrar", false);
                    Desativa.SetActive(false);
                    Ativa = true;
                    tempo = 0;
                }

            }

        }
       
    }


    private void OnTriggerEnter(Collider colisao)
    {
        if (colisao.gameObject.tag == "EspecialDanoA")
        {
            if(Ativa == false)
            {
                HP = HP = 0;
            }
            
        }

        if (colisao.gameObject.tag == "EspecialDanoB")
        {
            if (Ativa == false)
            {
                HP = HP = 0;
            }
        }
    }
}
