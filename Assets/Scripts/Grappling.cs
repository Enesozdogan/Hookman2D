using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    //[SerializeField] Transform target;
    [SerializeField] LineRenderer lr;
    [SerializeField] DistanceJoint2D dj;

    // Start is called before the first frame update
    void Start()
    {
        dj.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetMouseButtonDown(0))
    {   
     RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
 
    if(hit.collider != null)
    {
        Debug.Log("object clicked: "+hit.collider.tag);
    }

    }
    }

    void HookOn(){
        dj.enabled=true;
        lr.positionCount=2;
        //lr.SetPosition(0,)
    }
}
