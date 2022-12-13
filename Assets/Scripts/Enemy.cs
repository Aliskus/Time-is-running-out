using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;

    public float Speed = 200f;
    public int Health = 2;
    public int Damage = 1;
    float timer = 0;
    float timer2 = 0;
    float timer3 =0;
    public float nextWaypointDistance=3f;
    Path path;
    int currentWaypoint;
    bool reachedEndOfPath = false;
    Animator animator;
    bool death=false;
    bool hurt=false;
    Rigidbody2D rb;
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(death)
        {
            timer2 += Time.deltaTime;
        }
        if(timer2>=0.75f)
        {
            Destroy(gameObject);
        }
        if(hurt)
        {
            timer3 += Time.deltaTime;
        }
        if(timer3>=0.6f)
        {
            hurt = false;
            timer3 = 0;
            animator.SetInteger("Hurt1", 0);
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    public void Dealtdamage(int a)
    {
        Health -= a;
        animator.SetInteger("Hurt1", 1);
        hurt = true;
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        if(Health<=0)
        {
            
            Die();
        }
    }
    void Die()
    {
        animator.SetInteger("Death1", 1);
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        death = true;
    }
     void OnCollisionStay2D(Collision2D other)
    {
        
        AIDestinationSetter script = gameObject.GetComponent<AIDestinationSetter>();
        if(script.target.gameObject==other.gameObject)
        {   
            if(timer>=4)
                {
                Kule script2 = other.gameObject.GetComponent<Kule>();
                script2.Dealtdamage(Damage);
                timer = 0;
                }
        }
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        AIDestinationSetter script = gameObject.GetComponent<AIDestinationSetter>();
        if(script.target.gameObject==other.gameObject)
        {
            animator.SetInteger("Alper", 1);
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            
        }
    }
    private void OnCollisionExit2D(Collision2D other) 
    {
        AIDestinationSetter script = gameObject.GetComponent<AIDestinationSetter>();
        if(script.target.gameObject==other.gameObject)
        {
            animator.SetInteger("Alper", 0);
            Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            
        }
    }
}
