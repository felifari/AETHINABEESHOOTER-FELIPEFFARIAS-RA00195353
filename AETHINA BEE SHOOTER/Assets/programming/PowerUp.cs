using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int score;

    //Faz o PowerUp ser ativado e alocando score para o item

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Beetle")
        {
            col.gameObject.GetComponent<beetleship>().AddPower();
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
            Destroy(gameObject);
        }

    }
}
