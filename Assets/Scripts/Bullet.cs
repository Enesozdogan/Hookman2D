using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed=5f;
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody2D playerRb;
    [SerializeField] float recoilForce;
   private void Start() {
    
   }
    void Update()
    {
        transform.Translate(Vector2.right*speed*Time.deltaTime,Space.Self);
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(),GetComponent<Collider2D>());
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
