using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    //Fazendo a vida extra ser ativada e alocando score para o item

    public int score;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Beetle")
        {
            col.gameObject.GetComponent<beetleship>().AddHealth();
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
            Destroy(gameObject);
        }

    }
}
