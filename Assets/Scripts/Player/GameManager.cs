using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public Player PlayerRef;

    public Transform player;
    public Transform spawnPoint;
    public float spawnDelay = 2f;

    public Transform spawnPrefab;

    public bool gameover;
    public bool youwin;
    public Text youwintext;
    public static GameObject gameoverMenuCanvas;

    // This is a C# property - the code below isn't using it
    // as it is accessing the private static instance directly.
    // Use this property from other classes.
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }

    private static GameManager instance = null;

    void Awake()
    {
        if (instance)
        {
            Debug.Log("already an instance so destroying new one");
            DestroyImmediate(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        if ((PlayerRef == null))
        {
            PlayerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        }

        if ((gameoverMenuCanvas == null))
        {
            gameoverMenuCanvas = GameObject.Find("Game Over").GetComponent<GameObject>();
        }
        if (gm == null)
            gm = GetComponent<GameManager>();
    }

    void Start()
    {
        gameover = false;
        youwin = false;
    }

    public IEnumerator RespawnPlayer()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(player, spawnPoint.position, spawnPoint.rotation);
        Transform clone = (Transform)Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation);

        Destroy(clone.gameObject, 3f);
    }

    public static void KillPlayer(Player player)
    {
        Destroy(player.gameObject);
        Time.timeScale = 0f;
        gameoverMenuCanvas.SetActive(true);
        gm.StartCoroutine(gm.RespawnPlayer());
    }


    public static void Create(GameOverMenu GameOverMenu)
    {
        //gameoverMenuCanvas.SetActive(true);
        gm.StartCoroutine(gm.RespawnPlayer());
    }

    public void SetYouWin()
    {
        youwintext.text = "You Win";
        youwin = true;
    }

    void Death()
    {
        if (PlayerRef.Currenthealth <= 0)
        {
            Time.timeScale = 0f;
            gameoverMenuCanvas.SetActive(true);
            Destroy(gameObject, 2);
        }
    }
}
