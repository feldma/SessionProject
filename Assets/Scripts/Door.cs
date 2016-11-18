using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    [SerializeField]
    float smooth = 2.0f;

    [SerializeField]
    float DoorOpenAngle = 90.0f;
    private bool open;
    public bool enter { get; set; }

    private Vector3 defaultRot;
    private Vector3 openRot;
    private AudioSource source;

    void Start()
    {
        defaultRot = transform.eulerAngles;
        openRot = new Vector3(defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
        enter = false;
        source = GetComponent<AudioSource>();
    }

    //Main function
    void Update()
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

        if (Input.GetKeyDown("f") && enter)
        {
            open = !open;
            source.Play();
        }
    }

    void OnGUI()
    {
        if (enter)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 150, 30), "Press 'F' to open the door");
        }
    }

    //Activate the Main function when player is near the door
    void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.tag == "Player")
        //{
        //    enter = true;
        //}
    }

    //Deactivate the Main function when player is go away from door
    void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.tag == "Player")
        //{
        //    enter = false;
        //}
    }
}
