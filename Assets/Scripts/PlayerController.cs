using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    float rotationSpeed = 100.0f;

    [SerializeField]
    float moveSpeed = 10.0f;

    [SerializeField]
    float pickUpDist = 1f;

    private Rigidbody rb;
    private Transform carriedObject = null;
    private int pickUpLayer;


	//test Anto
	public GameObject prefab;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        pickUpLayer = 1 << LayerMask.NameToLayer("PickUp");
    }
	
	// Update is called once per frame
	void Update () {
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(0, 0, move);
        transform.Rotate(0, rotation, 0);

        if (Input.GetKeyDown("e"))
        {
            if (carriedObject != null)
            {
                Drop();
            }
            else
                PickUp();
        }
		if (Input.GetKeyDown("k")) {
				GameObject go = Instantiate(Resources.Load("default"), new Vector3(0, 50, 0), Quaternion.identity) as GameObject;
		}
	}

    private void Drop()
    {
        carriedObject.parent = null;
        carriedObject.gameObject.AddComponent(typeof(Rigidbody));
        carriedObject = null;
    }

    private void PickUp()
    {
        Collider[] pickups = Physics.OverlapSphere(transform.position, pickUpDist, pickUpLayer);

        float dist = Mathf.Infinity;
        for (int i = 0; i < pickups.Length; i++)
        {
            float newDist = (transform.position - pickups[i].transform.position).sqrMagnitude;
            if (newDist < dist)
            {
                carriedObject = pickups[i].transform;
                dist = newDist;
            }
        }
        if (carriedObject != null)
        {
            Destroy(carriedObject.GetComponent<Rigidbody>());
            carriedObject.parent = transform;
            carriedObject.localPosition = new Vector3(0, 1f, 1f);
        }
    }
}
