using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateMoreInstances());
        Physics2D.IgnoreLayerCollision(7,8);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
    IEnumerator CreateMoreInstances(){
        yield return new WaitForSeconds(0.5f);
        Instantiate(gameObject,transform.position+Vector3.right,Quaternion.identity);
        Instantiate(gameObject,transform.position+Vector3.left,Quaternion.identity);

    }
}
