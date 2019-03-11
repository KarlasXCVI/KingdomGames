using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour {

    [SerializeField]
    public static int Maxhealth = 100;
    public static int Currenthealth = 100;
    public static int stamina = 100;
    public static int AttackDamage;
    public static int MaxDamage;
    public static int MinDamage;
    public int score = 0;

    public Text scoretext;
    public Text notificationtext;
    public Text CurrenthealthDisplay;
    public Text MaxhealthDisplay;
    public Slider CurrenthealthBar;
    public Slider StaminaBar;
    public GameObject gameoverMenuCanvas;

    float damagetime = 0;

	// Use this for initialization
	void Start ()
    {
        MaxDamage = 20;
        MinDamage = 9;

        SettingUpUI();
        UpdateText();
        UpdateBlankText();
    }

    void Update()
    {
        UpdateText();
        CurrenthealthUpdate();        
        
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
        if (other.gameObject.tag == "Coin")
        {
            Destroy(other.gameObject, 3);
            score++;
        }

        if (other.gameObject.tag == "OutOfBounds")
        {
            Currenthealth = 0;
            Death();
        }


        if (other.gameObject.tag == "OutOfBounds")
        {
            AttackDamage = Random.Range(MinDamage, MaxDamage);
        }


        // collectable
        if (other.gameObject.tag == "Chest")
        {
            UpdateOpenText();

            if (Input.GetKey(KeyCode.E))
            {
                Destroy(other.gameObject);
                score++;
                UpdateBlankText();
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
        CurrenthealthBar = GameObject.Find("CurrenthealthBar").GetComponent<Slider>();
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

    void UpdateOpenText()
    {
        notificationtext.text = "Press E to open the chest";
    }

    void UpdateBlankText()
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
        Maxhealth = Maxhealth + 60;
    }

    public void AttackUpgrade()
    {
        MaxDamage = MaxDamage + 10;
        MinDamage = MinDamage + 10;
    }
}
