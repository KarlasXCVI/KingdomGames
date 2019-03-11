using UnityEngine;

public class UpdateMenu : MonoBehaviour {

    //Player MaxHealthRef;
    //Player MaxDamageRef;
    //Player MinDamageRef;
    Player PlayerRef;

    GameObject UpgradeCanvas;

    // Use this for initialization
    void Start () {

        //MaxHealthRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //MaxDamageRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        //MinDamageRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        PlayerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HealthUpgrade()
    {
        PlayerRef.HealthUpgrade();
    }

    public void AttackUpgrade()
    {
        PlayerRef.AttackUpgrade();
    }

    public void Exit()
    {
        this.UpgradeCanvas.SetActive(false);
    }

}
