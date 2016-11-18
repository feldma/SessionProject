using UnityEngine;
using System.Collections;

public class FenceController : MonoBehaviour {

    [SerializeField]
    float DoorOpenAngle = 90.0f;

    [SerializeField]
    float smooth = 2.0f;

    private bool open = false;
    private Vector3 defaultRot;
    private Vector3 openRot;

    // Use this for initialization
    void Start () {
        defaultRot = transform.eulerAngles;
        openRot = new Vector3(defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
    }

    // Update is called once per frame
    void Update () {
	
	}

    void OnTriggerEnter(Collider c)
    {
        if (Input.GetKeyDown("f"))
        {
            if (open)
            {
                //Open door
                transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
            }
            else
            {
                //Close door
                transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
            }
            open = !open;
        }
    }
}
