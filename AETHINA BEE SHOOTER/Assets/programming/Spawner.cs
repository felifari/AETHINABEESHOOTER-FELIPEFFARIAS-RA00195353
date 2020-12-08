using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float rate;
    public GameObject[] enemies;
    public int waves = 1;
    public int DelayAmount = 25;
    protected float Timer;

    //Cria inimigos 
    void Start()
    {
        InvokeRepeating("SpawnEnemy", rate, rate);

    }

    //Controla a quantidade e frequencia da criacao de inimigos
    void SpawnEnemy()
    {
        for (int i = 0; i < waves; i++)
            Instantiate(enemies[(int)Random.Range(0, enemies.Length)], new Vector3(Random.Range(-7.3f, 7.3f), 5, 0), Quaternion.identity);


    }

    //Aument a frequencia de inimigos com o passar do tempo
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer >= DelayAmount)
        {
            Timer = 0f;
            int i=(waves++);
        }
    }
}
