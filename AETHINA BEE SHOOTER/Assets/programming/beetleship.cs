using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beetleship : MonoBehaviour
{
    int delay = 0;
    GameObject a;
    Rigidbody2D rb;
    public float speed;
    public int health;
    public float PowerUp;
    public GameObject shot, Explosion, shotT;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        a = transform.Find("a").gameObject;
    }

    //Controla as vidas do jogador
    void Start()
    {
        PlayerPrefs.SetInt("Health", health);
    }


    //Controla os tiros do jogador, checa se o power up esta ou nao esta ativo
    void Shoot()
    {
        if (PowerUp == 0)
        {
            Instantiate(shot, a.transform.position, Quaternion.identity);
            delay = 0;
            SoundManager.PlaySound("BeetleShot");
        }
        else
        {
            Instantiate(shotT, a.transform.position, Quaternion.identity);
            delay = 0;
            SoundManager.PlaySound("BeetleShot");
        }




    }

    void Update()
    {
        rb.AddForce(new Vector2(Input.GetAxis("Horizontal") * speed, 0));
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * speed));

        if (Input.GetKey(KeyCode.Space) && delay > 10)
            Shoot();

        delay++;
    }

    //Faz o jogador tomar dano, diminui a vida, mata o jogador se nao ha mais vidas, faz ele piscar vermelho quando toma dano
    public void Damage()
    {
        health--;
        PlayerPrefs.SetInt("Health", health);
        SoundManager.PlaySound("BeetleHit");
        StartCoroutine(Blink());
        if (health == 0)
        {
            SoundManager.PlaySound("BeetleDeath");
            Instantiate(Explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }


    }

    //Faz ele piscar vermelho
    IEnumerator Blink()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
    }

    //Faz o jogador adquirir a vida extra
    public void AddHealth()
    {
        health++;
        SoundManager.PlaySound("JellyGet");
        PlayerPrefs.SetInt("Health", health);
    }

    //Faz o jogador adquirir o power up
    public void AddPower()
    {
        PowerUp++;
        SoundManager.PlaySound("JellyGet");
        StartCoroutine(ResetPower());
    }

    //Faz com que o power up acabe depois de certo tempo
    private IEnumerator ResetPower()
    {
        if (PowerUp > 0)
        {
            yield return new WaitForSeconds(9f);
            PowerUp--;
        }


    }


}
