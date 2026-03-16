using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        transform.position = new Vector3(mousePos.x, transform.position.y, transform.position.z);


        WrapScreen();

    }

    public void WrapScreen()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x > Screen.width)
        {
            screenPos.x = 0;
        }
        else if (screenPos.x < 0)
        {
            screenPos.x = Screen.width;
        }

        transform.position = Camera.main.ScreenToWorldPoint(screenPos);
    }
}
