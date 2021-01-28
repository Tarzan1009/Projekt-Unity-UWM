using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public bool player;

    private GameObject gameOver;
    private GameObject enemiesCounter;


    public float health;

    // Start is called before the first frame update
    void Start()
    {
        GameObject parentGameOver = GameObject.Find("UICanvas");
        gameOver = parentGameOver.transform.Find("GameOver").gameObject;
        health = maxHealth;
        enemiesCounter = GameObject.Find("EnemiesCounter");
    }

    public void Damage(float damage)
    {
        health -= damage;
        Debug.Log(health);
        if(health <= 0)
        {
            if (player)
            {
                gameOver.SetActive(true);
            }
            else
            {
                Destroy(gameObject);
                enemiesCounter.GetComponent<EnemiesCounter>().Kill();
            }
        }
    }

    public void Heal(float heal)
    {
        health += heal;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
