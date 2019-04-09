using UnityEngine;
using UnityEngine.UI;

public class UpdateMenu : MonoBehaviour {

    public Text Htext;
    public Text Dtext;
    public Text panelscoretext;
    public GameObject UpgradeCanvas;

    //GameObject player;
    private Player PlayerRef;

    private int healthcost;
    private int Damagecost;

    // Use this for initialization
    void Start () {
        FindingComponents();

        healthcost = 2;
        Damagecost = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (UpgradeCanvas == null)
        {
            UpgradeCanvas = GameObject.Find("Update Panel").GetComponent<GameObject>();
        }

        if ((PlayerRef == null))
        {
            PlayerRef = GameObject.FindWithTag("PlayerRef").GetComponent<Player>();
        }

        Htext.text = "Cost  " + healthcost;
        Dtext.text = "Cost  " + Damagecost;
        panelscoretext.text = "" + PlayerRef.score;
    }

    void FindingComponents()
    {

        if (UpgradeCanvas == null)
        {
            UpgradeCanvas = GameObject.Find("Update Panel").GetComponent<GameObject>();
        }

        if ((PlayerRef == null))
        {
            PlayerRef = GameObject.FindWithTag("PlayerRef").GetComponent<Player>();
        }

        Htext = GameObject.Find("healthcost").GetComponent<Text>();
        Dtext = GameObject.Find("damagecost").GetComponent<Text>();
        panelscoretext = GameObject.Find("PanelScoreText").GetComponent<Text>();
        //player = GameObject.Find("Player");
    }

    public void HealthUpgrade()
    {
        // The HealthUpgrade function will only work if the player score is equal or greater than the cost to improve health
        if (PlayerRef.score >= healthcost)
        {
            // add a live when the improve health by 1 button is pressed
            PlayerRef.Currenthealth++;
            // Player score is equal to the player score subtract the cost to improve health
            PlayerRef.score = PlayerRef.score - healthcost;
        }
    }

    public void AttackUpgrade()
    {
        // The HealthUpgrade function will only work if the player score is equal or greater than the cost to improve damage
        if (PlayerRef.score >= Damagecost)
        {
            // add a live when the improve damage by 10 button is pressed
            PlayerRef.AttackDamage = PlayerRef.AttackDamage + 10;
            // Player score is equal to the player score subtract the cost to improve damage
            PlayerRef.score = PlayerRef.score - Damagecost;
        }
    }

    public void Exit()
    {
        // when exit is pressed removes the upgrade menu
        UpgradeCanvas.SetActive(false);
        // unpauses the game
        Time.timeScale = 1f;
    }
}
