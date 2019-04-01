using UnityEngine;
using UnityEngine.UI;

public class BossAI : MonoBehaviour {

    [SerializeField]
    public int AIhealth = 100;
    public int MaxAIhealth = 100;
    BossCall BossCallRef;

    public Text Ainametext;
    public Slider HealthBar;
    public GameObject FoundAiCanvas;

    void Awake()
    {
        BossCallRef = GameObject.Find("Boss Call").GetComponent<BossCall>();

        //SettingUpAIHealth();
        //SettingUpAIUI();
    }

    // Use this for initialization
    void Start () {

        SettingUpAIHealth();
    }
	
	// Update is called once per frame
	void Update () {

        SettingUpAIUI();
    }

    void SettingUpAIUI()
    {
        if (FoundAiCanvas == null)
        {
            FoundAiCanvas = BossCallRef.AiCanvas;
        }

        if (HealthBar == null)
        {
            HealthBar = GameObject.Find("Boss HealthBar").GetComponent<Slider>();
        }

        if (Ainametext == null)
        {
            Ainametext = GameObject.Find("AinameText").GetComponent<Text>();
        }

        Ainametext.text = "BIG Boss";
    }

    void SettingUpAIHealth()
    {
        HealthBar.value = AIhealth;
        HealthBar.maxValue = MaxAIhealth;
    }
}
