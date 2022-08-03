using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIbomba : MonoBehaviour
{
    public RectTransform ImagemHP;
    public float HP;
    public Animator Animador;
    private bool podeMorre = false;
    private float tempo = 0;
    public GameObject AreaDano;
    private Gerenciador GJ;
    public int recompensa3 = 0;

    private float tempo2 = 0;
    private float tempo3 = 0;
    private bool danoAjuda = true;

    // Start is called before the first frame update
    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
        Animador = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            ImagemHP.sizeDelta = new Vector2(HP, 20);

            if (podeMorre == true)
            {
                tempo += Time.deltaTime;
                if (tempo >= 0.5f)
                {
                    Animador.SetBool("Ataque", true);
                    Animador.SetBool("Morrer", false);
                    Animador.SetBool("Andar", true);
                }


            }


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
        HP = HP = 0;
        Animador.SetBool("Morrer", true);
        podeMorre = true;
    }

   
    public void Morrer()
    {
          
           GJ.RecebePontos3(recompensa3);
           Destroy(gameObject);
        
        
    }

    
        private void OnTriggerEnter(Collider colisao)
        {
        if (colisao.gameObject.tag == "EspecialDanoA")
        {
            Dano();
        }

        if (colisao.gameObject.tag == "EspecialDanoB")
        {
            Dano();
        }

        }

    void OnCollisionStay(Collision colisao)
    {

        if (colisao.gameObject.tag == "Ajudante")
        {
            if (danoAjuda == true)
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

    public void AtivaDano()
    {
        HP = HP = 0;
        AreaDano.SetActive(true);
    }

   
}
