using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchTest : MonoBehaviour
{
    [SerializeField]int touchCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Began && touchCount < 4)
        {
            touchCount++;
            print("TOUCH");
            print(Input.GetTouch(0));
        }
    }
}
