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
        if (PlayerRef.CollectedKey == true)
        {
            this.keyIcon.SetActive(true);
        }

        if (PlayerRef.CollectedKey == false)
        {
            this.keyIcon.SetActive(false);
        }
    }
}
