using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int highscore = 1000;

    public bool gameover = false;
    public GameObject gameoverMenuCanvas;
    public bool youwin = false;
    public Text youwintext;

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
    }

    void Start()
    {
    }

    // game over
    public bool isYouwin()
    {
        return youwin;
    }

    public void SetYouWin()
    {
        youwintext.text = "You Win";
        youwin = true;
    }

    //void gameover()
    //{
    //    gameoverMenuCanvas.SetActive(true);
    //    Time.timeScale = 0f;
    //}

}
