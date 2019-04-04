using UnityEngine;
using UnityEngine.UI;

public class UpdateMenu : MonoBehaviour {

    [SerializeField]
    Player PlayerRef;
    public Text Htext;
    public Text Dtext;
    public Text panelscoretext;
    public GameObject UpgradeCanvas;

    GameObject player;

    // Use this for initialization
    void Start () {
        FindingComponents();
    }

    // Update is called once per frame
    void Update()
    {
        if (UpgradeCanvas == null)
        {
            UpgradeCanvas = GameObject.Find("Update Panel").GetComponent<GameObject>();
        }

        Htext.text = "Cost" + PlayerRef.healthcost;
        Dtext.text = "Cost" + PlayerRef.Damagecost;
        panelscoretext.text = "" + PlayerRef.score;
    }

    void FindingComponents()
    {
        PlayerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Htext = GameObject.Find("healthcost").GetComponent<Text>();
        Dtext = GameObject.Find("damagecost").GetComponent<Text>();
        panelscoretext = GameObject.Find("PanelScoreText").GetComponent<Text>();
        UpgradeCanvas = GameObject.Find("Update Panel").GetComponent<GameObject>();
        player = GameObject.Find("Player");
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
        UpgradeCanvas.SetActive(false);
        //Time.timeScale = 1f;
        player.GetComponent<PlayerMovement>().enabled = true;
    }
}
