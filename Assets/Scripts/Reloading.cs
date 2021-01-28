using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reloading : MonoBehaviour
{
    public GameObject weaponContainer;
    public GameObject reloadText;
    public GameObject reloadingText;
    public float timeToReload;

    private float timer;

    private bool closeEnough = false;
    private bool epressed = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = timeToReload;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            closeEnough = true;
            reloadText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            closeEnough = false;
            reloadText.SetActive(false);
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

        if(closeEnough && epressed)
        {
            reloadingText.SetActive(true);
            if(timer <= 0)
            {
                epressed = false;
                timer = timeToReload;
                for (int i = 0; i < weaponContainer.transform.childCount; ++i)
                {
                    weaponContainer.transform.GetChild(i).gameObject.GetComponent<Shoot>().Reload();
                }
            }
            else
            {
                timer -= Time.deltaTime;
                reloadingText.GetComponent<UnityEngine.UI.Text>().text = "Reloading... " + timer.ToString("0.00") + "s left";
            }
        }
        else
        {
            timer = timeToReload;
            reloadingText.SetActive(false);
        }
    }
}
