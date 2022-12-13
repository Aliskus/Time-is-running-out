using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    float timer=0;
    float timer2=0;
    int a =0;
    public GameObject Cre1;
    public GameObject Cre2;
    public float interval=0.3f;
    public Player playerscript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerscript.time==0)
        {
        timer += Time.deltaTime;
        timer2 += Time.deltaTime;
        if(timer>=interval && a==0 && timer2 < 40)
        {
            Instantiate(Cre1,new Vector3(transform.position.x,transform.position.y,transform.position.z),transform.rotation);
            timer = 0;
            a=1;
        }
        if(timer>=interval && a==1 && timer2 < 40)
        {
            Instantiate(Cre2,new Vector3(transform.position.x,transform.position.y,transform.position.z),transform.rotation);
            timer = 0;
            a=0;
        }
        }
    }
}
