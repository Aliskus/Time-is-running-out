using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Speed=5;
    public Transform movepoint;

    public LayerMask whatStopsMovement;
    
    public int time=100;
    public RectTransform Panel;
    public Text timetext;
    public GameObject canvas;
    // Start is called before the first frame update
    void Start()
    {
        movepoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        timetext.text = time.ToString();
        transform.position = Vector3.MoveTowards(transform.position,movepoint.position,Speed*Time.deltaTime);

        if(Vector3.Distance(transform.position,movepoint.position)<=0.05f && time-5>=0)
        {


        
        if(Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
        {
            if(!Physics2D.OverlapCircle(movepoint.position+new Vector3(Input.GetAxisRaw("Horizontal") , 0f , 0f), .2f, whatStopsMovement))
            {
            movepoint.position += new Vector3(Input.GetAxisRaw("Horizontal") , 0f , 0f);
            Panel.position += new Vector3(Input.GetAxisRaw("Horizontal") , 0f , 0f)*50.85f;
            time -= 5;
                if(Input.GetAxisRaw("Horizontal")<0)
                {
                    transform.rotation = new Quaternion(0,180,0,0);
                }
                else
                {
                    transform.rotation = new Quaternion(0,0,0,0);
                }
            }
        }
        else if(Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f )
        {
            if(!Physics2D.OverlapCircle(movepoint.position+new Vector3(0f ,Input.GetAxisRaw("Vertical") , 0f), .2f,whatStopsMovement))
            {
            movepoint.position += new Vector3(0f ,Input.GetAxisRaw("Vertical") , 0f);
            Panel.position += new Vector3(0f ,Input.GetAxisRaw("Vertical") , 0f)*50.85f;
            time -= 5;
            }
        }
        }
        if (time <= 0)
        {
            canvas.gameObject.SetActive(false);
        }
    }
    public void timeset0()
    {
        time = 0;
    }
}
