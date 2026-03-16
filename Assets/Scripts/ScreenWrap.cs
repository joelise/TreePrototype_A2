using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        //A new position to wrap to
        Vector2 newScreenPos = screenPos;

        if (screenPos.x < 0)     //if we move off the left hand side
        {
            newScreenPos.x = Screen.width;
        }
        else if (screenPos.x > Screen.width) //Moved off the right hand side
        {
            newScreenPos.x = 0;
        }

        if(newScreenPos != screenPos)
        {
            Vector2 newWorldPos = Camera.main.ScreenToWorldPoint(newScreenPos);
            transform.position = newWorldPos;
        }
    }
}
