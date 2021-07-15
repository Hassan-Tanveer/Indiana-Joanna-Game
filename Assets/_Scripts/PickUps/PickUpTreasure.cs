using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUpTreasure : MonoBehaviour
{
    private InventoryUI inventory;
    public GameObject icon;
    public Image treasureIcon;
    public AudioSource treasureCollectedSound;


    public GameObject ObjectiveUI;

    // Start is called before the first frame update
    private void Start()
    {
        inventory = GameObject.FindWithTag("Player").GetComponent<InventoryUI>();
        treasureCollectedSound.GetComponent<AudioSource>();
    }

    public void Update()
    {
        //rotates treasue
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if(inventory.isFull[i] == false)
                {
                    //Item added to the inventory
                    inventory.isFull[i] = true;
                    Instantiate(icon, inventory.slots[i].transform, false);
                    Debug.Log("TREASURE COLLECTED");
                    treasureIcon.enabled = true;
                    treasureCollectedSound.Play();

                    ObjectiveUI.SetActive(false);
                    Destroy(gameObject);
                    break;
                }

            }
        }
    }
}
