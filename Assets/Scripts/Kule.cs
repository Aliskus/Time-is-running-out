using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kule : MonoBehaviour
{   
    public int Health=8;
    public int Damage=1;
    public LayerMask creatures;
    GameObject target;
    public float Interval;
    float hittimer=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] targetsInRange = Physics2D.OverlapCircleAll(transform.position, 4, creatures);
        List<Collider2D> Final = new List<Collider2D>();
        for(int i=0;i<targetsInRange.Length;i++)
			{
                if(targetsInRange[i].gameObject.tag == "Creature")
                    Final.Add(targetsInRange[i]);
            }
        if(Final.Count>0)
			{
				Transform closest = Final[0].transform;
				if(Final.Count>1)
				{
					for(int i=1;i<Final.Count;i++)
					{
						float distance1 = Vector3.Distance(closest.position,transform.position);
						float distance2 = Vector3.Distance(Final[i].transform.position,transform.position);
						if(Mathf.Abs(distance1)>Mathf.Abs(distance2))
						{
							closest = Final[i].transform;
							
						}
							

					}
				}
			target = closest.gameObject;
            if(hittimer>=Interval)
                {
                    Enemy script = target.GetComponent<Enemy>();
                    script.Dealtdamage(Damage);
                    hittimer = 0;
                }
			}
        hittimer+=Time.deltaTime;
        
    }
    public void Dealtdamage(int a)
    {
        Health -= a;
        if(Health<=0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
