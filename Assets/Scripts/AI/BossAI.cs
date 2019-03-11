using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BossAI : MonoBehaviour {

    [SerializeField]
    public int AIhealth = 100;
    public int MaxAIhealth = 100;

    public Text Ainametext;
    public Slider HealthBar;
    public GameObject AiCanvas;

    void Awake()
    {
        SettingUpAIHealth();
    }

    // Use this for initialization
    void Start () {

        SettingUpAIUI();
        SettingUpAIHealth();
    }
	
	// Update is called once per frame
	void Update () {
        SettingUpAIUI();
    }

    void SettingUpAIUI()
    {

        AiCanvas.SetActive(true);

        if (HealthBar == null)
        {
            HealthBar = GameObject.Find("BossHealthBar").GetComponent<Slider>();
        }
        if (AiCanvas == null)
        {
            AiCanvas = GameObject.Find("Canvas").GetComponent<GameObject>();
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
