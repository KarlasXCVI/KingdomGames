using System;
using UnityEngine;

public class BasicAI : MonoBehaviour {

    //health
    private int AIhealth;
    //shooting
    private float TimeToShoot;
    public float StartTimeToShoot;
    public Transform shootingPoint;
    //bullet
    public GameObject bulletPab;
    // player script
    Player PlayerRef;
    Rigidbody2D rb;


    public Transform left;
    public Transform right;

    public Transform[] patrolPoints;
    public float speed;
    Transform currentPatrolPoints;
    int currentPatrolIndex;


    // Use this for initialization
    void Start () {
        AIhealth = 100;
        StartTimeToShoot = 4;
        rb = GetComponent<Rigidbody2D>();
        currentPatrolIndex = 0;
        currentPatrolPoints = patrolPoints[currentPatrolIndex];
        speed = 3;
        PlayerRef = GameObject.FindWithTag("PlayerRef").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update () {

        float leftdist = Vector3.Distance(transform.position, left.position);
        float rightdist = Vector3.Distance(transform.position, right.position);

        if (leftdist == 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (rightdist == 0)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Vector3.Distance (transform.position, currentPatrolPoints.position) < 1f)
        {
            if (currentPatrolIndex + 1 < patrolPoints.Length)
            {
                currentPatrolIndex++;
            }
            else
            {
                currentPatrolIndex = 0;
            }
            currentPatrolPoints = patrolPoints[currentPatrolIndex];
        }

        AIShoot();
    }

    private void Flip()
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void FixedUpdate()
    {

    }

    void AIShoot()
    {
        if (TimeToShoot <= 0)
        {
            Instantiate(bulletPab, transform.position, transform.rotation);

            TimeToShoot = StartTimeToShoot;
        }
        else
        {
            TimeToShoot -= Time.deltaTime;
        }
    }

    public void takedamage(int damage)
    {
        AIhealth -= damage;
        if (AIhealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        //Instantiate(bulletPab, shootingPoint.position, shootingPoint.rotation);
        Destroy(this.gameObject);
    }
}
