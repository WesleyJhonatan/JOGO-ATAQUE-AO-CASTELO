using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HP_Heroi : MonoBehaviour
{
    public RectTransform ImagemHP;
    public float HP;
    public Animator Animador;
    private Gerenciador GJ;


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
            ImagemHP.sizeDelta = new Vector2(HP, 10);
            Morrer();

            if (HP > 100)
            {
                HP = 100;
            }
        }
        
      
    }

    public void Dano()
    {
        //quanto de vida tira do personagem
        HP = HP - 3;
        Animador.SetBool("Dor", true);
        Animador.SetBool("Correr", false);
        Animador.SetBool("Ataque", false);
        Animador.SetBool("Pular", false);
        Animador.SetBool("EspecialA", false);
        Animador.SetBool("EspecialB", false);
    }

    public void DanoFalse()
    {
        Animador.SetBool("Dor", false);
    }

    void Morrer()
    {
        if (HP <= 0)
        {
            Animador.SetTrigger("Morte");
            Animador.SetBool("Dor", false);
            Animador.SetBool("Correr", false);
            Animador.SetBool("Ataque", false);
            Animador.SetBool("Pular", false);
            Animador.SetBool("EspecialA", false);
            Animador.SetBool("EspecialB", false);
        }
    }

    public void TelaGameOver()
    {
        GJ.TelaPerdeu();
        Time.timeScale = 0;
    }


    private void OnTriggerEnter(Collider colisao)
    {
        if (colisao.gameObject.tag == "Explosao")
        {
            HP = HP - 7;
            Animador.SetBool("Dor", true);
            Animador.SetBool("Correr", false);
            Animador.SetBool("Ataque", false);
            Animador.SetBool("Pular", false);
            Animador.SetBool("EspecialA", false);
            Animador.SetBool("EspecialB", false);
        }

        if (colisao.gameObject.tag == "DanoBombinha")
        {
           
            HP = HP - 3;
            Animador.SetBool("Dor", true);
            Animador.SetBool("Correr", false);
            Animador.SetBool("Ataque", false);
            Animador.SetBool("Pular", false);
            Animador.SetBool("EspecialA", false);
            Animador.SetBool("EspecialB", false);
        }

        if (colisao.gameObject.tag == "RecargaVida")
        {
            HP = HP + 20;
        }
        
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PedraP")
        {
            HP = HP - 3;
            Animador.SetBool("Dor", true);
            Animador.SetBool("Correr", false);
            Animador.SetBool("Ataque", false);
            Animador.SetBool("Pular", false);
            Animador.SetBool("EspecialA", false);
            Animador.SetBool("EspecialB", false);
        }
    }
}
