using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICasteloinimigo : MonoBehaviour
{
    public RectTransform ImagemHP;
    public float HP;
    private Gerenciador GJ;
    public int recompensa2 = 0;

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
            ImagemHP.sizeDelta = new Vector2(HP, 51.72f);
            Morrer();
        }
        
    }

    public void Dano()
    {
        HP = HP - 3;
    }


    public void Morrer()
    {
        if (HP <= 0)
        {
            GJ.RecebePontos2(recompensa2);
            Destroy(gameObject);
            
        }
    }


    private void OnTriggerEnter(Collider colisao)
    {
        if (colisao.gameObject.tag == "EspecialDanoA")
        {
            HP = HP - 5;
        }

        if (colisao.gameObject.tag == "EspecialDanoB")
        {
            HP = HP - 5;
        }

    }

}
