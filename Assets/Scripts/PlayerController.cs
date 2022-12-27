using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D playerRb;
    public int playerHp=5;
    public GameManager gameManager;
    private Grappling grappling;
    // Start is called before the first frame update
    void Start()
    {
        grappling=GetComponent<Grappling>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput=Input.GetAxis("Horizontal");
        float verticalInput=Input.GetAxis("Vertical");
        if(grappling.isGrappling){
            playerRb.AddForce(Vector2.right*horizontalInput*speed);
            playerRb.AddForce(Vector2.up*verticalInput*speed);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("BossBullet")){
            if(playerHp>0){
                gameManager.UpdatePlayerHpText();
            }
            
        }
    }
}
