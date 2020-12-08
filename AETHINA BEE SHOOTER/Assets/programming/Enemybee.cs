using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemybee : MonoBehaviour

{
    //Controlador dos inimigos

    Rigidbody2D rb;

    public GameObject Gun, Jelly, Explosion, Egg;

    public float ySpeed, xSpeed;

    public int score;
    public bool canShoot;
    public float fireRate;
    public int health;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        if (canShoot)
        {
            InvokeRepeating("Shoot", fireRate, fireRate);
        }
    }

    // Controla a velocidade do inimigo

    void Update()
    {
        rb.velocity = new Vector2(xSpeed, ySpeed * -1);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Beetle")
        {
            col.gameObject.GetComponent<beetleship>().Damage();
            Die();
        }
    }


    //Mata o inimigo e determina ramdomicamente se ele deixa uma vida extra, um power up ou nada quando morre
    void Die()
    {
        if (Random.Range(0, 4) == 0)
            Instantiate(Jelly, transform.position, Quaternion.identity);
        else if (Random.Range(0, 8) == 3)
            Instantiate(Egg, transform.position, Quaternion.identity);



        Instantiate(Explosion, transform.position, Quaternion.identity);
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + score);
        Destroy(gameObject);

    }

    //Remove vida do inimmigo, ativa o estado de morte e faz ele piscar vermelho quando toma dano
    public void Damage()
    {
        health--;
        StartCoroutine(Blink());
        SoundManager.PlaySound("EnemyHit");
        if (health == 0)
        {
            SoundManager.PlaySound("EnemyDeath");
            Die();
        }
    }

    //Controla a frequencia dos tiros do inimigo
    void Shoot()
    {
        GameObject temp = (GameObject)Instantiate(Gun, transform.position, Quaternion.identity);
        temp.GetComponent<gun>().ChangeDirection();
        SoundManager.PlaySound("EnemyShot");
    }

    //Faz o inimigo piscar vermelho
    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }




}
