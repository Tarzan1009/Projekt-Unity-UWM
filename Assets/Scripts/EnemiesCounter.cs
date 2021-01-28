using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesCounter : MonoBehaviour
{
    public int enemiesKilled;
    // Start is called before the first frame update
    void Start()
    {
        enemiesKilled = 0;
    }

    public void Kill()
    {
        enemiesKilled++;
        gameObject.GetComponent<UnityEngine.UI.Text>().text = enemiesKilled.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
