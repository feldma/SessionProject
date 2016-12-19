using UnityEngine;
using System.Collections;

public class GardenOutsideController : MonoBehaviour {

    private FenceController fence;
    private PlayerController player;

    private bool isInside = false;

    // Use this for initialization
    void Start () {
        fence = GameObject.FindGameObjectWithTag("Fence").GetComponent<FenceController>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update () {
	
	}

    private void OnTriggerEnter(Collider c)
    {
        /*
        if (fence.getHasOpened())
            player.modifyKarma(0.5f);
        else
            player.modifyKarma(-0.5f);
            */
        isInside = true;
    }

    private void OnTriggerExit(Collider c)
    {
        isInside = false;
    }

    private void OnGUI()
    {
        if (isInside)
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 230, 60), "Yay i'm out ! Maybe I could go see my old friend Jim");
    }
}
