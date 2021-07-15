using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowShoot : MonoBehaviour {

    public Camera cam;
    public GameObject arrowPrefab;
    public Transform Barrel;
    public float shootForce = 20f;

    public AudioSource arrowSound;

    //Transform E_target;

    private void Awake()
    {
        //E_target = GameObject.FindWithTag("Enemy").transform;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            GameObject gObject = Instantiate(arrowPrefab, Barrel.position, Quaternion.identity);
            gObject.transform.position = transform.position + cam.transform.forward;
            Rigidbody rBody = gObject.GetComponent<Rigidbody>();
            rBody.velocity = cam.transform.forward * shootForce;

            arrowSound.Play();

            //Vector3 direction = (E_target.position - transform.position).normalized;
            //Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        }
		
	}
}
