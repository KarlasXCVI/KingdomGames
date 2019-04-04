using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour {

    [SerializeField]
    public static int Maxhealth = 4;
    public static int Magic = 100;
    public int Currenthealth = 4;
    public int score = 0;
    public int healthcost;
    public int Damagecost;
    public int AttackDamage;
    public bool UpgradeMenuOn;
    private bool paused;

    ChestLoot ChestLootRef;
    UpgradeTrigger UpgradeRef;

    public Text scoretext;
    public Text notificationtext;
    public Slider MagicBar;
    public GameObject gameoverMenuCanvas;
    public GameObject PauseMenuCanvas;

    // Use this for initialization
    void Start ()
    {
        ChestLootRef = GameObject.FindGameObjectWithTag("Chest").GetComponent<ChestLoot>();
        UpgradeRef = GameObject.FindGameObjectWithTag("Player").GetComponent<UpgradeTrigger>();

        healthcost = 2;
        Damagecost = 3;
        AttackDamage = 20;
        UpgradeMenuOn = false;
        paused = false;

        //Functions
        SettingUpUI();
        UpdateText();
        UpdateBlankText();
    }

    void Update()
    {
        UpdateText();

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Time.timeScale = 0;

            if (paused == false)
            {
                paused = true;
                
                PauseMenuCanvas.SetActive(true);
            }
            else if (paused == true)
            {
                paused = false;
                //paused = !paused;
                Time.timeScale = 1;
                PauseMenuCanvas.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {

            Currenthealth--;
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
        Currenthealth = Currenthealth - 1;
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

        if (other.gameObject.tag == "UpdateTrigger" && Input.GetKey(KeyCode.R))
        {
            notificationtext.text = "Press E to open the update panel";
            UpgradeRef.SpawnPanel();
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
        scoretext = GameObject.Find("ScoreText").GetComponent<Text>();
        notificationtext = GameObject.Find("notificationtext").GetComponent<Text>();
        MagicBar = GameObject.Find("StaminaBar").GetComponent<Slider>();
        gameoverMenuCanvas = GameObject.Find("Game Over").GetComponent<GameObject>();

        MagicBar.maxValue = Magic;
        MagicBar.value = 0;
    }

    void UpdateText()
    {
        scoretext.text = score.ToString();
    }

    public void UpdateOpenText()
    {
        notificationtext.text = "Press E to open the chest";
    }

    public void UpdateBlankText()
    {
        notificationtext.text = " ";
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
            Maxhealth = Maxhealth + 1;
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
