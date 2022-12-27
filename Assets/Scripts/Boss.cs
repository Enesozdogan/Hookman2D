using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject playerPos;
    [SerializeField] float distance;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform turretPos;
    [SerializeField] Transform gunPos;
    [SerializeField] Camera mainCamera;
    [SerializeField] GameObject fireball;
    public GameManager gameManager;
    public int bossHp=100;
    void Start()
    {
        InvokeRepeating("spawnBullets",1f,1f);
        InvokeRepeating("spawnFireBalls",5,10);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(),playerPos.GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
            
            
            transform.position=Vector2.MoveTowards(transform.position,playerPos.transform.position,0.3f*Time.deltaTime);
            // transform.up=playerPos.position-transform.position; mermi icin iyi
            if(transform.position.x<playerPos.transform.position.x){
                // GetComponent<SpriteRenderer>().flipX=false;
                // GetComponentInChildren<SpriteRenderer>().flipX=false;
                transform.localScale = new Vector3(1,1,1);
                //gunPos.rotation=Quaternion.Euler(new Vector3(0,0,0));
            }
            if(transform.position.x>playerPos.transform.position.x){
                // GetComponent<SpriteRenderer>().flipX=true;
                // GetComponentInChildren<SpriteRenderer>().flipX=true;
                transform.localScale = new Vector3(-1,1,1);
                 //gunPos.rotation=Quaternion.Euler(new Vector3(0,180,0));
            }
                 Vector3 target=mainCamera.WorldToScreenPoint(playerPos.transform.position);
                 Vector3 gunposition=mainCamera.WorldToScreenPoint(gunPos.position);
                target.x=target.x-gunposition.x;
                target.y=target.y-gunposition.y;
                float gunAngle=Mathf.Atan2(target.y,target.x)*Mathf.Rad2Deg;
                if(playerPos.transform.position.x<gunPos.position.x){
                  gunPos.rotation=Quaternion.Euler(new Vector3(180f,0f,-gunAngle));
                 }
                else{
                    gunPos.rotation=Quaternion.Euler(new Vector3(0f,0f,gunAngle));
                }
                if(gameManager.isGameOver){
                    CancelInvoke("spawnBullets");
                    CancelInvoke("spawnFireBalls");
                }
   
       
           
    }
    void spawnBullets(){
        GameObject shoot = Instantiate(bullet,gunPos.position,gunPos.rotation);
       // GameObject shoot = Instantiate(bullet,gunPos.position,);
    }
    void spawnFireBalls(){
        float rangeX=8;
        for(int i=0;i<3;i++){
            float x=Random.Range(-rangeX,rangeX);
            Instantiate(fireball,new Vector2(x,4.0f),Quaternion.identity);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("playerBullet")){
            if(bossHp>0){
                gameManager.UpdateBossHpText();
            }
        }
    }
   
}
