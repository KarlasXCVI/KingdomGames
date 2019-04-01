using UnityEngine;
using UnityEngine.UI;

public class BossCall : MonoBehaviour {


    [SerializeField]
    public bool activated;

    public GameObject BossPrefab;
    public Transform SpawnPos;
    public GameObject AiCanvas;
    public AudioClip SummonSound;

    // Use this for initialization
    void Start () {

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
        //Destroy(SpawnPos, 1);
        //GetComponent<AudioSource>().PlayOneShot(SummonSound);
    }

}
