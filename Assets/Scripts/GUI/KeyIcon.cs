using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyIcon : MonoBehaviour {

    private Player PlayerRef;
    public GameObject keyIcon;

    void Awake()
    {
        if ((PlayerRef == null))
        {
            PlayerRef = GameObject.FindWithTag("PlayerRef").GetComponent<Player>();
        }

        if ((keyIcon == null))
        {
            keyIcon = GameObject.Find("Key Image");
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        UpdateKeyIcon();
    }


    void UpdateKeyIcon()
    {
        // if the player has collected the key, the PlayerRef.CollectedKey will become true
        if (PlayerRef.CollectedKey == true)
        {
            // Show the key icon if the PlayerRef.CollectedKey is true
            this.keyIcon.SetActive(true);
        }

        // if the player hasn't collected the key, the PlayerRef.CollectedKey will be false
        if (PlayerRef.CollectedKey == false)
        {
            // Hides the key icon if the PlayerRef.CollectedKey is false
            this.keyIcon.SetActive(false);
        }
    }
}
