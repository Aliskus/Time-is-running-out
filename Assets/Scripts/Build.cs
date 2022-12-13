using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour
{
    GameObject kule1;
    public GameObject kule2;
    public GameObject kule3;
    public Player playerscript;
    public LayerMask whatStopsMovement;
    public int cost = 20;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     
    public void Building(int a)
    {   
        int x=0;
        int y=0;
        switch(a) 
				{
					case 1:
						x = -1;
                        y = 1;
						break;
					case 2:
						x = 0;
                        y = 1;
						break;
                    case 3:
						x = 1;
                        y = 1;
						break;
                    case 4:
						x = -1;
                        y = 0;
						break;
                    case 5:
						x = 1;
                        y = 0;
						break;
                    case 6:
						x = -1;
                        y = -1;
						break;
                    case 7:
						x = 0;
                        y = -1;
						break;
                    case 8:
						x = 1;
                        y =- 1;
						break;
        }

        if(playerscript.time-cost>=0)
        {
            if(!Physics2D.OverlapCircle(gameObject.transform.position+new Vector3(x , y , 0f), .2f,whatStopsMovement))
            {
                if(a==1)
                {
                    Instantiate(kule1,new Vector3(gameObject.transform.position.x-1,gameObject.transform.position.y+1,0),kule1.gameObject.transform.rotation);
                    playerscript.time -= cost;
                }
                if(a==2)
                {
                    Instantiate(kule1,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y+1,0),kule1.gameObject.transform.rotation);
                    playerscript.time -= cost;
                }
                if(a==3)
                {
                    Instantiate(kule1,new Vector3(gameObject.transform.position.x+1,gameObject.transform.position.y+1,0),kule1.gameObject.transform.rotation);
                    playerscript.time -= cost;
                }
                if(a==4)
                {
                    Instantiate(kule1,new Vector3(gameObject.transform.position.x-1,gameObject.transform.position.y,0),kule1.gameObject.transform.rotation);
                    playerscript.time -= cost;
                }
                if(a==5)
                {
                    Instantiate(kule1,new Vector3(gameObject.transform.position.x+1,gameObject.transform.position.y,0),kule1.gameObject.transform.rotation);
                    playerscript.time -= cost;
                }
                if(a==6)
                {
                    Instantiate(kule1,new Vector3(gameObject.transform.position.x-1,gameObject.transform.position.y-1,0),kule1.gameObject.transform.rotation);
                    playerscript.time -= cost;
                }
                if(a==7)
                {
                    Instantiate(kule1,new Vector3(gameObject.transform.position.x,gameObject.transform.position.y-1,0),kule1.gameObject.transform.rotation);
                    playerscript.time -= cost;
                }
                if(a==8)
                {
                    Instantiate(kule1,new Vector3(gameObject.transform.position.x+1,gameObject.transform.position.y-1,0),kule1.gameObject.transform.rotation);
                    playerscript.time -= cost;
                }
                
            }
        }
    }
    public void setTaunt()
    {
        kule1 = kule3;
        cost = 40;
    }
    public void setQuartz()
    {
        kule1 = kule2;
        cost = 20;
    }
}
