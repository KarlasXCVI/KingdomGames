using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.UI;

public class CreatureAi : MonoBehaviour
{
    public float patrolSpeed = 3f;// The nav mesh agent's speed when patrolling.
    public float chaseSpeed = 3f;// The nav mesh agent's speed when chasing.
    public float patrolWaitTime = 1f;// The amount of time to wait when the patrol way point is reached.
    public Transform[] patrolWayPoints;// An array of transforms for the patrol route.
    public float patrolTimer;// A timer for the patrolWaitTime.
    public int wayPointIndex;// A counter for the way point array.

    Animator anim;          // ref to the animator
    //Text spiderstatetext;   // the info spider state text
    NavMeshAgent na;        // ref to the navmesh agent

    public Transform target;        // target of the spider
    public float enemydist;         // distance to target

    int damage = 0;               // spider is taking damage
    float lastspiderdamagetime;     // last time spider took damage
    float lastenemydamagetime;      // last time enemy took damage

    Player player;      // player script

    // Get the references
    void Start()
    {
        anim = GetComponent<Animator>();
        na = GetComponent<NavMeshAgent>();
        //spiderstatetext = GameObject.Find("SpiderStateText").GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Run the AI 
    void Update()
    {
        // Is it game over
        //if (GameManager.Instance.isGameOver()) return;

        // Detect the player
        enemydist = Vector3.Distance(target.transform.position,
            transform.position);
        anim.SetFloat("enemydist", enemydist);

        // Update the spider text
       // if (name == "spider1")
            //spiderstatetext.text = "Spider: dist_to_player: " + enemydist + " health: " + anim.GetFloat("health");
    
        // Take damage?
        if ((damage > 0) && (Time.time > lastspiderdamagetime + 0.05f))
        {
            float health = anim.GetFloat("health");
            health = health - damage;
            Debug.Log("taking damage " + damage);
            damage = 0;
            if (health < 0) health = 0;
            anim.SetFloat("health", health);

            // let game manager know a spider is killed
            //if (health <= 0) GameManager.Instance.CreatureDown();
        }

        // Determine which state spider is in
        AnimatorStateInfo asi = anim.GetCurrentAnimatorStateInfo(0);

        // If is in patrol state
        if (asi.IsName("patrol"))
        {
           // if (name == "spider1")
               // spiderstatetext.text += " PATROL";

            Patrolling();
        }

        // If is in attack state
        if (asi.IsName("attack"))
        {
            //if (name == "spider1")
               // spiderstatetext.text += " ATTACK";
            na.SetDestination(target.position);

            if (Time.time > lastenemydamagetime + 1)
            {
                lastenemydamagetime = Time.time;
                player.TakeDamage(5);
            }
        }

        // If is in chase state
        if (asi.IsName("chase"))
        {
         //   if (name == "spider1")
              //  spiderstatetext.text += " CHASE";
            na.SetDestination(target.position);
        }

        // If is in idle state
        // restore health slowly (but only when in idle state)
        if (asi.IsName("idle") && (damage == 0) && (Time.time > lastspiderdamagetime + 1))
        {
            float health = anim.GetFloat("health");
            health = health + 1;
            if (health > 100) health = 100;
            anim.SetFloat("health", health);
            lastspiderdamagetime = Time.time;
        }

        // Transitions

        // These conditions are true only during a state change (transition)
        // Transitions to walk
        if (
        anim.IsInTransition(0) &&
        anim.GetNextAnimatorStateInfo(0).IsName("chase"))
        {
            na.isStopped = false;   // spider can move
            na.speed = chaseSpeed;  // with this speed
            na.SetDestination(target.position); // to the target
        }

        // Transitions to idle
        if (
        anim.IsInTransition(0) &&
        anim.GetNextAnimatorStateInfo(0).IsName("idle"))
        {
            na.isStopped = true;    // spider should stop on idle
        }

        // Transitions to patrol
        if (
        anim.IsInTransition(0) &&
        anim.GetNextAnimatorStateInfo(0).IsName("patrol"))
        {
            na.isStopped = false;   // spider should move when patrolling
        }

        // Transitions to attack
        if (
        anim.IsInTransition(0) &&
        anim.GetNextAnimatorStateInfo(0).IsName("attack"))
        {
            na.isStopped = false;   // spider should move when attacking
        }

        // Transitions to die
        if (
        anim.IsInTransition(0) &&
        anim.GetNextAnimatorStateInfo(0).IsName("die"))
        {
            Debug.Log("die");
            na.isStopped = true;   // spider should not move when dead
        }

        // Transitions to flee
        if (
        anim.IsInTransition(0) &&
        anim.GetNextAnimatorStateInfo(0).IsName("flee"))
        {
            na.isStopped = false;   // spider should move when fleeing
            na.speed = chaseSpeed;  // with this speed

            Vector3 pos = transform.position + 100 * Vector3.right;
            na.SetDestination(pos);     // somewhere away from the target
        }
    }

    // What is the spider sensing below it?
    void OnTriggerStay(Collider other)
    {
  
        if (other.tag == "Fire")
        {
            // fire causes more damage
            if (damage == 0)
            {
                damage = 10;
                lastspiderdamagetime = Time.time;
            }
        }

    }

    // spider is patrolling, so follow the waypoints
    void Patrolling()
    {
        // Set an appropriate speed for the NavMeshAgent.
        na.speed = patrolSpeed;
        // If near the next waypoint or there is no destination...
        if (na.remainingDistance < na.stoppingDistance)
        {
            // ... increment the timer.
            patrolTimer += Time.deltaTime;
            // If the timer exceeds the wait time...
            if (patrolTimer >= patrolWaitTime)
            {
                // ... increment the wayPointIndex.
                if (wayPointIndex == patrolWayPoints.Length - 1)
                    wayPointIndex = 0;
                else
                    wayPointIndex++;
                // Reset the timer.
                patrolTimer = 0;
            }
        }
        else
            // If not near a destination, reset the timer.
            patrolTimer = 0;
        // Set the destination to the patrolWayPoint.
        na.destination = patrolWayPoints[wayPointIndex].position;
    }

    // stop the spider
    public void Stop()
    {
        na.isStopped = true;
    }

    // is dead?
    public bool isdead()
    {
        return (anim.GetFloat("health") <= 0.0f);
    }
}

