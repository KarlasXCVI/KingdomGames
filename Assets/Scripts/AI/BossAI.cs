using UnityEngine;
using UnityEngine.UI;

public class BossAI : MonoBehaviour {

    [SerializeField]
    private int Aihealth;
    private int MaxAIhealth;
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
    void Start() {

        Aihealth = 500;
        MaxAIhealth = 500;
        SettingUpAIHealth();
    }

    // Update is called once per frame
    void Update() {

        SettingUpAIUI();

        SettingUpAIHealth();
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
        HealthBar.value = Aihealth;
        HealthBar.maxValue = MaxAIhealth;
    }

    public void takedamage(int damage)
    {
        Aihealth -= damage;
        if (Aihealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        //Instantiate(bulletPab, shootingPoint.position, shootingPoint.rotation);
        BossCallRef.DeatciveBossUI();
        Destroy(this.gameObject);
    }
}
