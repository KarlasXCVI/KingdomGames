using UnityEngine;

public class BossCall : MonoBehaviour {

    public GameObject BossPrefab;
    public Transform SpawnPos;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SpawnBoss();
        }
    }

    void SpawnBoss()
    {
        Instantiate(BossPrefab, SpawnPos.position, SpawnPos.rotation);
    }

}
