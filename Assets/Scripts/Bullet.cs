using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float startSpeed;
    public float decel;
    public float maxTime;
    public float damage;
    public float force;
    public bool barrett;

    private float timer;
    private float speed;
    private float gravSpeed;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        speed = startSpeed;
        gravSpeed = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Map")
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Obstacle" && !barrett)
        {
            Destroy(gameObject);
        }

        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Health>().Damage(damage);

            Vector3 otherDirection = (transform.position = other.gameObject.transform.position).normalized;
            Vector3 forceDirection = (otherDirection + Vector3.up * 0.5f).normalized;
            other.gameObject.GetComponent<Rigidbody>().AddForce(forceDirection * force);
        }

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= maxTime)
        {
            Destroy(gameObject);
        }

        speed -= decel * Time.deltaTime;
        gravSpeed += 10 * Time.deltaTime;

        transform.Translate(speed * Vector3.forward * Time.deltaTime, Space.Self);
        transform.Translate(Vector3.down * gravSpeed * Time.deltaTime, Space.World);

    }
}
