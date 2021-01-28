using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;

    private GameObject gun;
    private GameObject player;
    private float rof;
    private float timer;
    private Animation anim;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gun = transform.Find("EnemyGun").gameObject;
        anim = gun.gameObject.GetComponent<Animation>();
        audio = gun.gameObject.GetComponent<AudioSource>();

        System.Random rand = new System.Random();
        rof = (float)rand.Next(10, 121);

        timer = 60/rof;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        if(timer <= 0)
        {
            Vector3 rot = transform.rotation.eulerAngles;
            rot = new Vector3(rot.x + Random.Range(-2.0f, 2.0f), rot.y + Random.Range(-2.0f, 2.0f), rot.z);
            Instantiate(bullet, transform.position + Vector3.forward, Quaternion.Euler(rot));

            anim.Play("Shoot");
            audio.Play(0);
            timer = 60 / rof;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
