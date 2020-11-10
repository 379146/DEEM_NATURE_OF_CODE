using UnityEngine;

public class IntroductionFig1NORMAL : MonoBehaviour
{
    //We need to create a walker
    introMover4 walker;

    // Start is called before the first frame update
    void Start()
    {
        walker = new introMover4();
    }

    // Update is called once per frame
    void FixedUpdate()
    {        //Have the walker choose a direction
        walker.step();
        walker.CheckEdges();
    }
}


public class introMover4
{
    // The basic properties of a mover class
    private Vector3 location3;

    // The window limits
    private Vector2 minimumPos, maximumPos;

    // Gives the class a GameObject to draw on the screen
    public GameObject mover = GameObject.CreatePrimitive(PrimitiveType.Sphere);

    public introMover4()
    {
        findWindowLimits();
        location3 = Vector2.zero;
        //We need to create a new material for WebGL
        Renderer r = mover.GetComponent<Renderer>();
        r.material = new Material(Shader.Find("Diffuse"));
    }

    public void step()
    {
        location3 = mover.transform.position;
        //Each frame choose a new Random number 0,1,2,3, 
        //If the number is equal to one of those values, take a step
        int choice = Random.Range(0, 4);

        float num = Random.Range(Random.Range(-3, 3), Random.Range(-3, 3));
        float sd = 20;
        float mean = 1;

        float x = sd * num + mean;


        if (choice == 0)
        {
            location3.x += x;

        }
        else if (choice == 1)
        {
            location3.x += x;
        }
        else if (choice == 3)
        {
            location3.y += x;
        }
        else if (choice == 2)
        {
            location3.y += x;
        }

        mover.transform.position += location3 * Time.deltaTime;
    }

    public void CheckEdges()
    {
        location3 = mover.transform.position;

        if (location3.x > maximumPos.x)
        {
            location3 = Vector2.zero;
        }
        else if (location3.x < minimumPos.x)
        {
            location3 = Vector2.zero;
        }
        if (location3.y > maximumPos.y)
        {
            location3 = Vector2.zero;
        }
        else if (location3.y < minimumPos.y)
        {
            location3 = Vector2.zero;
        }
        mover.transform.position = location3;
    }

    private void findWindowLimits()
    {
        // We want to start by setting the camera's projection to Orthographic mode
        Camera.main.orthographic = true;
        // Next we grab the minimum and maximum position for the screen
        minimumPos = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maximumPos = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }
}

