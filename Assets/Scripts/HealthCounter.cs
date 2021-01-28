using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = System.Math.Ceiling(player.GetComponent<Health>().health) + "/" + player.GetComponent<Health>().maxHealth;
    }
}
