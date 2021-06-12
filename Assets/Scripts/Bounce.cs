using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    public AnimationCurve BounceCurve;
    public float BounceHeight = 1f;
    public float BouncePeriod = 1f;

    float BounceTime = 0f;
    Vector3 InitialPosition;

    // Start is called before the first frame update
    void Start()
    {
        // store my initial location
        InitialPosition = transform.position;

        Example(53, 1.234f, "Test");
        ExampleWithDefaults(42, 42.8f, "not default");
        ExampleWithDefaults(73, 52.8f);
    }

    // Update is called once per frame
    void Update()
    {
        //PerformBounce_Verbose();

        // Call/run/execute/invoke our function/method called PerformBounce_Concise
        PerformBounce_Concise();

        // Run our GetHeightOffset function and store the returned value in heightOffset
        float heightOffset = GetHeightOffset();
        if (heightOffset <= 0.01f)
            Debug.Log("Boinggggggg!");
    }

    void Example(int exampleInt, float exampleFloat, string exampleString)
    {
        Debug.Log(exampleInt);
        Debug.Log(exampleFloat);
        Debug.Log(exampleString);
    }

    void ExampleWithDefaults(int exampleInt, float exampleFloat, string exampleString = "default")
    {
        Debug.Log(exampleInt);
        Debug.Log(exampleFloat);
        Debug.Log(exampleString);
    }

    Vector3 CalculateNewPosition(float heightOffset)
    {
        return InitialPosition + new Vector3(0, heightOffset, 0);
    }

    float GetHeightOffset()
    {
        // get the current value of the bounce curve
        float curveOutput = BounceCurve.Evaluate(BounceTime / BouncePeriod);

        return curveOutput * BounceHeight;

        // the code below never runs because the return forces an immediate exit
        Debug.Log("This will never run!");
    }

    void PerformBounce_Verbose()
    {
        // Update the bounce time [Version 1 - Verbose version]
        BounceTime = BounceTime + Time.deltaTime;

        // Method 1 to keep BounceTime in range - conditional
        if (BounceTime >= BouncePeriod)
            BounceTime -= BouncePeriod;

        // get the current value of the bounce curve
        float curveOutput = BounceCurve.Evaluate(BounceTime / BouncePeriod);
        
        // update our position
        transform.position = InitialPosition + new Vector3(0, curveOutput * BounceHeight, 0);
    }

    void PerformBounce_Concise()
    {
        // Update the bounce time [Version 2 - Concise version]
        BounceTime += Time.deltaTime;

        // Method 2 to keep BounceTime in range - modulus operator
        BounceTime %= BouncePeriod;

        // get the current value of the bounce curve
        float curveOutput = BounceCurve.Evaluate(BounceTime / BouncePeriod);
        
        // update our position
        transform.position = CalculateNewPosition(curveOutput * BounceHeight);
    }
}
