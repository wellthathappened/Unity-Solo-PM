using UnityEngine;
using UnityEngine.AI;
public class BasicEnemyController : MonoBehaviour
{
    PlayerController player;
    Animator myAnim;

    [Header("Logic")]
    NavMeshAgent agent;
    public bool isFollowing = false;

    [Header("Enemy Stats")]
    public int health = 5;
    public int maxHealth = 5;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myAnim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        else
        {
            if (isFollowing)
            {
                agent.isStopped = false;
                agent.destination = player.transform.position;
                myAnim.SetBool("isAttacking", true);
            }
            else
            {
                agent.isStopped = true;
                myAnim.SetBool("isAttacking", false);
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "proj")
        {
            health--;
            Destroy(collision.gameObject);
        }
    }

    
}
