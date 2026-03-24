using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        Plane plane = new Plane(Vector3.up, Vector3.zero);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;

        if (plane.Raycast(ray, out distance))
       {
           Vector3 worldPos = ray.GetPoint(distance);
            transform.position = new Vector3(worldPos.x, transform.position.y, transform.position.z);
        }
       
        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        

        //transform.position = new Vector3(mousePos.x, transform.position.y, transform.position.z);


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

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Leaf"))
        {
            gameManager.CaughtLeaf(other.gameObject);
            Debug.Log("Caught");

        }
    }
}
