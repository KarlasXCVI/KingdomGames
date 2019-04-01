using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour {

    [SerializeField]
    public static int Maxhealth = 100;
    public static int Currenthealth = 100;
    public static int stamina = 100;
    public static int AttackDamage;
    public int score = 0;
    public int healthcost;
    public int Damagecost;
    public bool UpgradeMenuOn;

    public Text scoretext;
    public Text notificationtext;
    public Text CurrenthealthDisplay;
    public Text MaxhealthDisplay;
    public Slider CurrenthealthBar;
    public Slider StaminaBar;
    public GameObject gameoverMenuCanvas;

    private float timeBtwAttack;
    public float starttimeBTAttack;
    public Transform attackPos;
    public float attackRange;
    //public LayerMask Em

    ChestLoot ChestLootRef;
    UpgradeTrigger UpgradeRef;

    // Use this for initialization
    void Start ()
    {
        ChestLootRef = GameObject.FindGameObjectWithTag("Chest").GetComponent<ChestLoot>();
        UpgradeRef = GameObject.FindGameObjectWithTag("Player").GetComponent<UpgradeTrigger>();

        healthcost = 2;
        Damagecost = 3;
        AttackDamage = 20;
        UpgradeMenuOn = false;

        //Functions
        SettingUpUI();
        UpdateText();
        UpdateBlankText();
    }

    void Update()
    {
        UpdateText();
        CurrenthealthUpdate();     
        
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKey(KeyCode.Y))
            {
                Collider2D[] enemiestodamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, 0);
            }
            timeBtwAttack = starttimeBTAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
        
        //// is the player dead?
        if (Currenthealth <= 0)
        {
            Death();
        }
    }

    void ReduceCurrenthealth(float amount)
    {
        // take damage
        Currenthealth = Currenthealth - 20;
        CurrenthealthBar.value = Currenthealth;
        // is the player dead?
    }

    // Player take damage
    public void TakeDamage(float amount)
    {
        //// take damage
        //Currenthealth = Currenthealth - amount;
        if (Currenthealth < 0) Currenthealth = 0;
    }

    // enter trigger zone of something
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "OutOfBounds")
        {
            Currenthealth = 0;
            Death();
        }

        if (other.gameObject.tag == "UpdateTrigger")
        {

            notificationtext.text = "Press E to open the update panel";

            if (Input.GetKey(KeyCode.E))
            {

                UpgradeMenuOn = true;
                //UpgradeRef.SpawnPanel();
            }
        }

        if (other.gameObject.tag == "Chest")
        {
            UpdateOpenText();
     
            if (ChestLootRef.Ischestopen == false)
            {
                if (Input.GetKey(KeyCode.E))
                {
                    //Destroy(other.gameObject);
                    //other.gameObject.GetComponent<ChestLoot>().Ischestopen = true;
                    ChestLootRef.Ischestopen = true;
                    score++;
                    UpdateBlankText();
                }
            }
        }
    }

    // collided with something?
    void OnTriggerStay2D(Collider2D other)
    {

        //if (other.tag=="Fire")
        //{
        //    if (Time.time-damagetime>1)
        //    {
        //        TakeDamage(10);
        //        damagetime = Time.time;
        //    }
        //}
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // collectable
        if (other.gameObject.tag == "Chest")
        {
            UpdateBlankText();
        }
    }

    void SettingUpUI()
    {
        CurrenthealthDisplay = GameObject.Find("CurrentHealthDisplay").GetComponent<Text>();
        MaxhealthDisplay = GameObject.Find("MaxhealthDisplay").GetComponent<Text>();
        scoretext = GameObject.Find("ScoreText").GetComponent<Text>();
        notificationtext = GameObject.Find("notificationtext").GetComponent<Text>();
        CurrenthealthBar = GameObject.Find("HealthBar").GetComponent<Slider>();
        StaminaBar = GameObject.Find("StaminaBar").GetComponent<Slider>();
        gameoverMenuCanvas = GameObject.Find("Game Over").GetComponent<GameObject>();

        CurrenthealthBar.maxValue = Maxhealth;
        CurrenthealthBar.value = Currenthealth;
    }

    void CurrenthealthUpdate()
    {
        CurrenthealthBar.value = Currenthealth;
        CurrenthealthBar.maxValue = Maxhealth;
    }

    void UpdateText()
    {
        scoretext.text = score.ToString();
        CurrenthealthDisplay.text = Currenthealth.ToString();
        MaxhealthDisplay.text = Maxhealth.ToString();
    }

    public void UpdateOpenText()
    {
        notificationtext.text = "Press E to open the chest";
    }

    public void UpdateBlankText()
    {
        notificationtext.text = "";
    }

    void Death()
    {
        //Time.timeScale = 0f;
        gameoverMenuCanvas.SetActive(true);
        Destroy(gameObject, 2);
    }

    public void HealthUpgrade()
    {
        if (score >= healthcost)
        {
            Maxhealth = Maxhealth + 60;
            score= score - healthcost;
        }
    }

    public void AttackUpgrade()
    {
        if (score >= Damagecost)
        {
            AttackDamage = AttackDamage + 10;
            score = score - Damagecost;
        }
    }
}
