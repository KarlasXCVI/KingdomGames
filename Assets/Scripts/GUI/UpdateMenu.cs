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
        if (PlayerRef.score >= healthcost)
        {
            PlayerRef.Currenthealth++;
            PlayerRef.score = PlayerRef.score - healthcost;
        }
    }

    public void AttackUpgrade()
    {
        if (PlayerRef.score >= Damagecost)
        {
            PlayerRef.AttackDamage = PlayerRef.AttackDamage + 10;
            PlayerRef.score = PlayerRef.score - Damagecost;
        }
    }

    public void Exit()
    {
        UpgradeCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
}
