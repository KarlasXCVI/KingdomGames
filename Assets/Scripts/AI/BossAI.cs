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

    private float TimeToShoot;
    public float StartTimeToShoot;

    public Transform shootingPoint;
    public GameObject bulletPab;
    public GameObject KeyPab;

    void Awake()
    {
        BossCallRef = GameObject.Find("Boss Call").GetComponent<BossCall>();
        //SettingUpAIHealth();
        //SettingUpAIUI();
    }

    // Use this for initialization
    void Start() {

        StartTimeToShoot = 4;
        Aihealth = 250;
        MaxAIhealth = 500;
        SettingUpAIHealth();
    }

    // Update is called once per frame
    void Update() {

        BossShoot();

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

    void BossShoot()
    {
        if (TimeToShoot <= 0)
        {
            Instantiate(bulletPab, transform.position, transform.rotation);

            TimeToShoot = StartTimeToShoot;
        }
        else
        {
            TimeToShoot -= Time.deltaTime;
        }
    }

    void Death()
    {
        //Instantiate(bulletPab, shootingPoint.position, shootingPoint.rotation);
        BossCallRef.DeatciveBossUI();
        Instantiate(KeyPab, shootingPoint.position, shootingPoint.rotation);
        Destroy(this.gameObject);
    }
}
