using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField] float speed=5f;
    [SerializeField] Transform playerPos;
    [SerializeField] GameObject boss;
    [SerializeField] Transform gunPos;
   private void Start() {
    
   }
    void Update()
    {
        
        transform.Translate(Vector2.right*speed*Time.deltaTime,Space.Self);
        Physics2D.IgnoreLayerCollision(7,8);
        
    }
     private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
