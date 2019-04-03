using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTrigger : MonoBehaviour {

    public GameObject UpgradeCanvas;
    Player PlayerRef;

    // Use this for initialization
    void Start() {

        PlayerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update() {


        if (PlayerRef.UpgradeMenuOn == true)
        {
            SpawnPanel();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerRef.notificationtext.text = "Press E to open the update panel";
            //SpawnPanel();


        }
    }

    public void SpawnPanel()
    {
        this.UpgradeCanvas.SetActive(true);
        //Time.timeScale = 0f;
    }

    public void RemovePanel()
    {
        this.UpgradeCanvas.SetActive(false);
        //Time.timeScale = 0f;
    }
}
