using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorwayTriggerController : MonoBehaviour
{

    public LevelController levelController;

    // Use this for initialization
    void Start()
    {
 
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.tag == "Player")
        {
        levelController.EndLevel();
        }
    }
}
