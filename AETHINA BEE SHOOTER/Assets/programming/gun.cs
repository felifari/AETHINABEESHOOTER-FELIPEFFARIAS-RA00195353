using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    //Controlador de tiros do jogador e do inimigo

    Rigidbody2D rb;
    int dir = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void ChangeDirection()
    {
        dir *= -1;

    }

    void Update()
    {
        rb.velocity = new Vector2(0, 12 * dir);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (dir == 1)
        {
            if (col.gameObject.tag == "Enemy")
            {
                col.gameObject.GetComponent<Enemybee>().Damage();
                Destroy(gameObject);
            }
        }
        else
        {
            if (col.gameObject.tag == "Beetle")
            {
                col.gameObject.GetComponent<beetleship>().Damage();
                Destroy(gameObject);
            }
        }


    }
   

    
        
    }




