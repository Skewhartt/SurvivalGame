using UnityEngine;

public class PickupItem : MonoBehaviour
{
    [SerializeField]
    private float pickupRange = 2.6f;

    [SerializeField]
    private Inventory inventory;

    public PickupBehaviour playerPickupBehaviour;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.forward, out hit, pickupRange))
        {
            if (hit.transform.CompareTag("Item"))
            {
                // Debug.Log("Il y a un item");

                if (Input.GetKeyDown(KeyCode.E) && inventory.GetContentCount() < inventory.GetInventorySlotCount())
                {
                    playerPickupBehaviour.DoPickup(hit.transform.gameObject.GetComponent<Item>());
                }
            }
        }
    }
}
