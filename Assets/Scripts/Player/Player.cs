using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour {

    private int Maxhealth = 5;
    private bool paused;

    [SerializeField]
    public bool Ishurt;
    public int Magic = 100;
    public int Currenthealth;
    public int score = 0;
    public int AttackDamage;
    public bool UpgradeMenuOn;
    public bool CollectedKey;

    //ChestLoot ChestLootRef;
    UpgradeTrigger UpgradeRef;

    private Text scoretext;
    public Text notificationtext;
    private Slider MagicBar;
    public GameObject gameoverMenuCanvas;
    public GameObject PauseMenuCanvas;
    private UpgradeTrigger UpgradeTRef;

    // Use this for initialization
    void Start ()
    {
        //ChestLootRef = GameObject.FindGameObjectWithTag("Chest").GetComponent<ChestLoot>();
        UpgradeRef = GameObject.FindGameObjectWithTag("Player").GetComponent<UpgradeTrigger>();

        Time.timeScale = 1f;

        if ((UpgradeTRef == null))
        {
            UpgradeTRef = GameObject.FindWithTag("UpgradeTRef").GetComponent<UpgradeTrigger>();
        }

        Currenthealth = Maxhealth;
        AttackDamage = 20;
        UpgradeMenuOn = false;
        paused = false;
        Ishurt = false;
        CollectedKey = false;

        //Functions
        SettingUpUI();
        UpdateText();
        UpdateBlankText();
    }

    void Update()
    {
        UpdateText();

        if (Input.GetKeyDown(KeyCode.Escape))
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

        //if (Input.GetKeyDown(KeyCode.U))
        //{

        //    Currenthealth--;
        //}

        if (Ishurt == true)
        {
            Invoke("Tookdamage", 2);
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
    }

    // enter trigger zone of something
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "OutOfBounds")
        {
            Currenthealth = 0;
            Death();
        }

        if (other.gameObject.tag == "UpgradeTRef")
        {
            notificationtext.text = "Press E to open the update panel";

            if (Input.GetKey(KeyCode.E))
            {
                UpgradeTRef.SpawnPanel();
            }
        }

        if (other.gameObject.tag == "EnemyBullet")
        {

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // collectable
        if (other.gameObject.tag == "Chest")
        {
            UpdateBlankText();
        }

        //if (other.gameObject.tag == "UpdateTrigger")
        //{
        //    UpdateBlankText();
        //}
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

    // A function that is used to update the player score on screen
    void UpdateText()
    {
        // score text equals the score int stored the player script that is convert to text by ToString
        scoretext.text = score.ToString();
    }

    void Tookdamage()
    {
        Ishurt = false;
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
        Time.timeScale = 0f;
        gameoverMenuCanvas.SetActive(true);
        //GameManager.KillPlayer(this);
        //Destroy(gameObject, 1);
    }
}
