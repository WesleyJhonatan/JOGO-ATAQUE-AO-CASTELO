using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICasteloAmigo : MonoBehaviour
{
    public RectTransform ImagemHP;
    public RectTransform ImagemHP2;
    public float HP;
    private Gerenciador GJ;
    public GameObject Coracaoo;
    private float tempo = 0;

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
            ImagemHP2.sizeDelta = new Vector2(HP, 13.3f);
            Morrer();
        }

        if(HP < 281)
        {
            Coracaoo.SetActive(true);
            tempo += Time.deltaTime;
            if (tempo >= 7f)
            {
                HP = HP + 2;
                tempo = 0;
                if (HP >= 281)
                {
                    HP = 281;
                    tempo = 0;
                    Coracaoo.SetActive(false);
                }
            }
        }
    }

    public void Dano()
    {
        HP = HP - 5;
    }


    public void Morrer()
    {
        if (HP <= 0)
        {
            GJ.TelaPerdeu();
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider colisao)
    {
        if (colisao.gameObject.tag == "Explosao")
        {
            //HP = HP - 3;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PedraP")
        {
            HP = HP - 5;
        }
    }

}
