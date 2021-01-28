using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootShotgun : MonoBehaviour
{
    public GameObject bullet;
    public int pellets;
    public float rof;
    public int maxAmmo;
    public int ammo;
    public AudioClip shotSound;
    public AudioClip reloadSound;

    private Animation anim;
    private AudioSource audio;
    private float rofTimer;
    private GameObject insPellet;

    public void Reload()
    {
        ammo = maxAmmo;
    }

    // Start is called before the first frame update
    void Start()
    {
        rofTimer = 0;
        anim = gameObject.GetComponent<Animation>();
        audio = gameObject.GetComponent<AudioSource>();
        ammo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (rofTimer <= 0 && ammo > 0)
            {
                for(int i = 0; i < pellets; i++)
                {
                    insPellet = Instantiate(bullet, transform.position, transform.rotation);
                    insPellet.transform.Rotate(Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), Random.Range(-5.0f, 5.0f), Space.Self);
                }
                audio.PlayOneShot(shotSound, 0.7F);
                audio.PlayOneShot(reloadSound, 0.7F);
                anim.Play("Reload");
                rofTimer = 60 / rof;
                ammo--;
            }
        }

        if (rofTimer > 0)
        {
            rofTimer -= Time.deltaTime;
        }
    }
}