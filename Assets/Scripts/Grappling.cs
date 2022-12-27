using UnityEngine;
using System.Collections;

public class Grappling : MonoBehaviour {


    [SerializeField] LayerMask grapplableMask;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
   public Camera mainCamera;
   public bool isGrappling=false;
    public LineRenderer _lineRenderer;
    public DistanceJoint2D dj;
    Vector2 speedVec;

    // Start is called before the first frame update
    void Start()
    {
        dj.enabled = false;
        speedVec=new Vector2(speed,speed);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1)&& !isGrappling)
        {
            Vector2 direction = mainCamera.ScreenToWorldPoint(Input.mousePosition)-transform.position;
            Vector2 mousePos=mainCamera.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 20, grapplableMask);

            if (hit.collider != null) {
                isGrappling=true;
                _lineRenderer.SetPosition(0, mousePos);
                _lineRenderer.SetPosition(1, transform.position);
                dj.connectedAnchor = mousePos;
                dj.enabled = true;
                _lineRenderer.enabled = true;
                Vector2 direction2=mousePos-(Vector2)transform.position;
                //StartCoroutine(get_close(mousePos));
                if(Vector2.Distance(transform.position,mousePos)>10){
                     
                     rb.AddForce(direction2*100000,ForceMode2D.Impulse);
                }
                
                
            
            }
            
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1) && isGrappling)
        {
           isGrappling=false;
            dj.enabled = false;
            _lineRenderer.enabled = false;
        }
        if (dj.enabled) 
        {
            _lineRenderer.SetPosition(1, transform.position);
        }
    }

    IEnumerator get_close(Vector2 mousePos){
        Vector3 direction=(Vector3)mousePos-transform.position;
        while(Vector2.Distance(transform.position,mousePos)>3){
            rb.AddForce(direction*100*Time.deltaTime,ForceMode2D.Impulse);
            yield return null;
        }
        
    }
}
