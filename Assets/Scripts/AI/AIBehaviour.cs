using UnityEngine;

public class AIBehaviour : MonoBehaviour {

    public float Speed;
    public float stoppingDistance;
    public float retrearDistance;
    public float startTimebtwshots;

    private float timebtwshots;
    public GameObject projectile;
    public Transform s;
    public Transform player;

    // Use this for initialization
    void Start () {

        Speed = 10;
        stoppingDistance = 20;
        retrearDistance = 10;
        startTimebtwshots = 10;
        timebtwshots = startTimebtwshots;
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update () {

        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);
        } else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retrearDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) <  retrearDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, Speed - Time.deltaTime);
        }

        if (timebtwshots <=0)
        {
            //Instantiate((projectile, 
            timebtwshots = startTimebtwshots;
        }else
        {
            timebtwshots -= Time.deltaTime;
        }

    }
}
