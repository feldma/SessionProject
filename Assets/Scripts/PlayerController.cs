using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float rotationSpeed;

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    float pickUpDist;

    [SerializeField]
    float karma;

    private string onTheGround = "Ground";
    private Transform carriedObject = null;
    private int pickUpLayer;
    private FootStepController footStepController;

    private bool hasTaken = false;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        rotationSpeed = 300.0f;
        moveSpeed = 10.0f;
        karma = 2.00f;
        pickUpLayer = 1 << LayerMask.NameToLayer("PickUp");

        footStepController = GetComponent<FootStepController>();
    }

    // Update is called once per frame
    void Update()
    {
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        float move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Translate(0, 0, move);
        transform.Rotate(0, rotation, 0);

        if (Input.GetKeyDown("e"))
        {
            if (carriedObject != null)
                Drop();
            else
                PickUp();
            hasTaken = true;
        }

        if (Input.GetButton("Vertical"))
        {
            footStepController.play(onTheGround);
        }
        if (Input.GetKeyDown("space"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 250.0f);
        }
        if (Input.GetKeyDown("escape"))
            Application.Quit();
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();

        style.fontSize = 30;
        if (!hasTaken)
            GUI.Label(new Rect(Screen.width / 2 - 300, Screen.height - 100, 160, 30), "Press 'E' to take an object", style);
        else
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 30), "");
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

    public float getKarma()
    {
        return karma;
    }

    public void setKarma(float value)
    {
        karma = value;
    }

    void OnCollisionStay(Collision collision)
    {
        onTheGround = collision.gameObject.tag;
    }

    public void modifyKarma(float value)
    {
        karma += value;
    }
}
