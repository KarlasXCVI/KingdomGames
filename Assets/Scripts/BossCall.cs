using UnityEngine;
using UnityEngine.UI;

public class BossCall : MonoBehaviour {


    [SerializeField]
    public bool activated;
    public bool BossAlive;

    public GameObject BossPrefab;
    public Transform SpawnPos;
    public GameObject AiCanvas;
    public AudioClip SummonSound;

    // Use this for initialization
    void Start () {
        activated = false;
        BossAlive = false;
    }

    // Update is called once per frame
    void Update () {


            
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && activated == false)
        {
            SpawnBoss();
            activated = true;
        }
    }

    void SpawnBoss()
    {
        Instantiate(BossPrefab, SpawnPos.position, SpawnPos.rotation);
        AiCanvas.SetActive(true);
        //GetComponent<AudioSource>().PlayOneShot(SummonSound);
    }

    public void DeatciveBossUI()
    {
        AiCanvas.SetActive(false);
    }

}
