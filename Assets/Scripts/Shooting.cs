using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    
    public Transform start;
    private Rigidbody2D playerRb;
    [SerializeField] float recoilForce;
    [SerializeField] bool canBlast=true;
    [SerializeField] bool isGrounded=false;
    [SerializeField] bool canShoot=true;
    [SerializeField] GameObject blastEffect;
    private void Start() {
        playerRb=GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
        Vector3 gunpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (gunpos.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
        }
        else
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
        }
        if (Input.GetMouseButtonDown(0)&& canShoot) 
        {
            shooting();
            StartCoroutine(FireRate(0));
        }
        if(Input.GetKeyDown(KeyCode.E)&& (isGrounded||canBlast)){
            jumpingBlast(gunpos);
            StartCoroutine(FireRate(1));
        }


    }
    void shooting()
    {
        canShoot=false;
        GameObject shoot = Instantiate(bullet, start.transform.position, start.transform.rotation);
        Physics2D.IgnoreCollision(shoot.GetComponent<Collider2D>(),GetComponent<Collider2D>());
        Vector2 forceDir= Camera.main.ScreenToWorldPoint(Input.mousePosition)-start.position;
        //playerRb.AddForce(-forceDir*recoilForce,ForceMode2D.Impulse);
        
    }
     void jumpingBlast(Vector3 pos){
        canBlast=false;
       var blast= Instantiate(blastEffect,start.position,start.transform.rotation);
        Destroy(blast,0.5f);
        Vector3 forceDir=start.position-pos;
        if(isGrounded){
            playerRb.AddForce(Vector2.up*recoilForce*20,ForceMode2D.Impulse);    
        }
        playerRb.AddForce(forceDir*recoilForce*6,ForceMode2D.Impulse);
      
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")){
            isGrounded=true;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.CompareTag("Ground")){
            isGrounded=false;
        }
    }
    IEnumerator FireRate(int choice){
        if(choice==0){
             yield return new WaitForSeconds(0.2f);
             canShoot=true;
        }
        else if(choice==1){
              yield return new WaitForSeconds(3);
              canBlast=true;
        }
    }
}
