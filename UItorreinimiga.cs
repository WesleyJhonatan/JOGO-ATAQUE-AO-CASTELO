using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UItorreinimiga : MonoBehaviour
{
    public RectTransform ImagemHP;
    public float HP;
    private Gerenciador GJ;
    public int recompensa = 0;
    private float tempo = 0;
    public GameObject Explosao2;
    public GameObject LocaoExplosao2;
    private bool paraMorte = true;

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
            ImagemHP.sizeDelta = new Vector2(HP, 5.381f);
            Morrer();
        }

        if(paraMorte == false)
        { 
            tempo += Time.deltaTime;
            if (tempo >= 0.2f)
            {
                GJ.RecebePontos(recompensa);
                Destroy(gameObject);
                tempo = 0;
            }
        }
        

    }

    public void Dano()
    {
        HP = HP - 10;
    }


    public void Morrer()
    {
        if(paraMorte == true)
        {
            if (HP <= 0)
            {
                paraMorte = false;
                GetComponent<MeshRenderer>().enabled = false;
                Instantiate(Explosao2, LocaoExplosao2.transform.position, Quaternion.identity);
               
            }
        }
       
    }

        private void OnTriggerEnter(Collider colisao)
    {
        if (colisao.gameObject.tag == "EspecialDanoA")
        {
            HP = HP = 0;
        }

        if (colisao.gameObject.tag == "EspecialDanoB")
        {
            HP = HP = 0;
        }

    }

}
