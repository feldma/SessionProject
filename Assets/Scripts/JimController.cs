using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JimController : MonoBehaviour {

    [SerializeField]
    Image img;

    [SerializeField]
    GUITexture text;

    [SerializeField]
    Texture2D fadeOutTexture;

    private float fadeSpeed = 0.1f;
    private float fadeDir = 1.0f;
    private bool isInside = false;
    private float alpha = 0.0f;
    private int drawDepth = -1000;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (alpha >= 0.9)
            Application.Quit();
    }

    private void OnTriggerEnter(Collider col)
    {
        isInside = true;
    }
    private void OnGUI()
    {
        if (isInside)
        {
            GUI.Label(new Rect(Screen.width / 2 - 75, Screen.height - 100, 230, 60), "Oh no ! Jim is dead !");
            alpha += fadeDir * fadeSpeed * Time.deltaTime;
            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
            GUI.depth = drawDepth;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
        }
    }

}
