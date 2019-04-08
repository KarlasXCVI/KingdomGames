using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTrigger : MonoBehaviour {

    public GameObject UpgradeCanvas;
    private Player PlayerRef;
    public bool showtext;

    // Use this for initialization
    void Start() {

        showtext = false;
        if ((PlayerRef == null))
        {
            PlayerRef = GameObject.FindWithTag("PlayerRef").GetComponent<Player>();
        }
    }

    // Update is called once per frame
    void Update() {

        //if (showtext == true)
        //{
        //    SpawnPanel();
        //    Time.timeScale = 0;
        //}
        //else
        //{
        //    Time.timeScale = 1;
        //}

        if (PlayerRef.UpgradeMenuOn == true)
        {
            SpawnPanel();
        }
        else { }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerRef.notificationtext.text = "Press E to open the update panel";
            SpawnPanel();
            Invoke("PauseToRead", 1);
            Invoke("Clear", 1);
                
            if (Input.GetKeyDown(KeyCode.E))
            {
                //PlayerRef.UpgradeMenuOn = true;
                SpawnPanel();
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerRef.UpdateBlankText();
        }
    }

    public void SpawnPanel()
    {
        this.UpgradeCanvas.SetActive(true);
        showtext = true;
    }

    void PauseToRead()
    {
        Time.timeScale = 0;
    }

    private void Clear()
    {
        PlayerRef.UpdateBlankText();
    }
}
