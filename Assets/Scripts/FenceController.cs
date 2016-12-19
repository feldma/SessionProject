using UnityEngine;
using System.Collections;

public class FenceController : MonoBehaviour {

    [SerializeField]
    float DoorOpenAngle = 90.0f;

    [SerializeField]
    float smooth = 2.0f;

    [SerializeField]
    PlayerController player;

    private bool open = false;
    private Vector3 defaultRot;
    private Vector3 openRot;
    private bool isInside = false;
    private bool hasOpened = false;

    // Use this for initialization
    void Start () {
        defaultRot = transform.eulerAngles;
        openRot = new Vector3(defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
    }

    // Update is called once per frame
    void Update () {
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

        if (Input.GetKeyDown("f") && isInside && player.hasKey)
        {
            open = !open;
            hasOpened = true;
            player.hasKey = false;
        }
    }

    void OnTriggerEnter(Collider c)
    {
        isInside = true;
    }

    void OnTriggerExit(Collider c)
    {
        isInside = false;
    }

    private void OnGUI()
    {
        if (isInside && !hasOpened && !player.hasKey)
        GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 230, 40), "Maybe I could get the key of the fence or try something else");
    }

    public bool getHasOpened()
    {
        return hasOpened;
    }
}
