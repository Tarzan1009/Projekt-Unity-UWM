using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject weaponContainer;
    public GameObject player;
    private UnityEngine.UI.Button resetButton;

    void OnEnable()
    {
        weaponContainer.SetActive(false);
        player.GetComponent<UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Reset()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    // Start is called before the first frame update
    void Start()
    {
        resetButton = transform.Find("ResetButton").gameObject.GetComponent<UnityEngine.UI.Button>();
        resetButton.onClick.AddListener(Reset);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
