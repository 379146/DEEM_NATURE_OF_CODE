using UnityEngine;

public class IntroductionFig1PEARL : MonoBehaviour
{
    //We need to create a walker
    introMover5 walker;

    // Start is called before the first frame update
    void Start()
    {
        walker = new introMover5();
    }

    // Update is called once per frame
    void FixedUpdate()
    {        //Have the walker choose a direction
        walker.step();
        walker.CheckEdges();
    }
}


public class introMover5
{
    // The basic properties of a mover class
    private Vector3 location7;

    // The window limits
    private Vector2 minimumPos, maximumPos;

    // Gives the class a GameObject to draw on the screen
    public GameObject mover = GameObject.CreatePrimitive(PrimitiveType.Sphere);

    public introMover5()
    {
        findWindowLimits();
        location7 = Vector2.zero;
        //We need to create a new material for WebGL
        Renderer r = mover.GetComponent<Renderer>();
        r.material = new Material(Shader.Find("Diffuse"));
    }

    public void step()
    {
        location7 = mover.transform.position;
        //Each frame choose a new Random number 0,1,2,3, 
        //If the number is equal to one of those values, take a step
        int choice = Random.Range(0, 4);

        float x = 0.1f * Mathf.PerlinNoise(Time.time * .2f, 0.0f);


        if (choice == 0)
        {
            location7.x += x;

        }
        else if (choice == 1)
        {
            location7.x += x;
        }
        else if (choice == 3)
        {
            location7.y += x;
        }
        else if (choice == 2)
        {
            location7.y += x;
        }

        mover.transform.position += location7 * Time.deltaTime;
    }

    public void CheckEdges()
    {
        location7 = mover.transform.position;

        if (location7.x > maximumPos.x)
        {
            location7 = Vector2.zero;
        }
        else if (location7.x < minimumPos.x)
        {
            location7 = Vector2.zero;
        }
        if (location7.y > maximumPos.y)
        {
            location7 = Vector2.zero;
        }
        else if (location7.y < minimumPos.y)
        {
            location7 = Vector2.zero;
        }
        mover.transform.position = location7;
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

