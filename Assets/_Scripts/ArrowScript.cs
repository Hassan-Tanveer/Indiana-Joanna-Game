using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    Rigidbody arrowBody;
    private float lifeTime = 2f;
    private float timer;
    private bool arrowHit = false;

    public static int ArrowDamage = 5;

    // Use this for initialization
    void Start()
    {
        arrowBody = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(arrowBody.velocity);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= lifeTime)
        {
            Destroy(gameObject);
        }

        if (!arrowHit)
        {
            transform.rotation = Quaternion.LookRotation(arrowBody.velocity);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag != "Arrow")
        {
        arrowHit = true;
        Stick();
        }

    }
    
    private void Stick()
    {
        arrowBody.constraints = RigidbodyConstraints.FreezeAll;
    }
}
