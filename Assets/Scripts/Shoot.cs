using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public bool auto;
    public bool shotgun;
    public GameObject bullet;
    public float rof;
    public int maxAmmo;
    public int ammo;
    public int pellets;
    public AudioClip shotSound;
    public AudioClip reloadSound;

    private Animation anim;
    private AudioSource audio;
    private bool firing;
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
        firing = false;
        anim = gameObject.GetComponent<Animation>();
        audio = gameObject.GetComponent<AudioSource>();
        ammo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(rofTimer <= 0 && ammo > 0)
            {
                if (shotgun)
                {
                    for (int i = 0; i < pellets; i++)
                    {
                        Vector3 rot = transform.rotation.eulerAngles;
                        rot = new Vector3(rot.x + Random.Range(-5.0f, 5.0f), rot.y + Random.Range(-5.0f, 5.0f), rot.z);
                        Instantiate(bullet, transform.position, Quaternion.Euler(rot));
                    }
                    audio.PlayOneShot(shotSound, 0.7F);
                    audio.PlayOneShot(reloadSound, 0.7F);
                    anim.Play("Reload");
                    rofTimer = 60 / rof;
                    ammo--;
                }
                else
                {
                    Instantiate(bullet, transform.position, transform.rotation);
                    anim.Play("Shoot");
                    audio.Play(0);
                    rofTimer = 60 / rof;
                    ammo--;
                }
            }

            if (auto)
            {
                firing = true;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (auto)
            {
                firing = false;
            }
        }

        if(firing && rofTimer <= 0 && ammo > 0)
        {
            if (shotgun)
            {
                for (int i = 0; i < pellets; i++)
                {
                    Vector3 rot = transform.rotation.eulerAngles;
                    rot = new Vector3(rot.x + Random.Range(-5.0f, 5.0f), rot.y + Random.Range(-5.0f, 5.0f), rot.z);
                    Instantiate(bullet, transform.position, Quaternion.Euler(rot));
                }
                audio.PlayOneShot(shotSound, 0.7F);
                audio.PlayOneShot(reloadSound, 0.7F);
                anim.Play("Reload");
                rofTimer = 60 / rof;
                ammo--;
            }
            else
            {
                Instantiate(bullet, transform.position, transform.rotation);
                anim.Play("Shoot");
                audio.Play(0);
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
