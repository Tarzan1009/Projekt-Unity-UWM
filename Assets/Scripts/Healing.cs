using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    public float healPerSecond;
    public GameObject healText;
    public GameObject healingText;
    public GameObject player;

    private bool closeEnough = false;
    private bool epressed = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            closeEnough = true;
            healText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            closeEnough = false;
            healText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            epressed = true;
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            epressed = false;
        }

        if (closeEnough && epressed)
        {
            healingText.SetActive(true);
            player.GetComponent<Health>().Heal(healPerSecond * Time.deltaTime);
        }
        else
        {
            healingText.SetActive(false);
        }
    }
}
