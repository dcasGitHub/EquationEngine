using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdderEquation : MonoBehaviour
{

    // make these a list of class objects
    private int numTest1 = 12;
    private int numTest2 = 3;
    private int answerTest = 0;
    public GameObject adderCube;  // Allows you to drag and drop to inspector
    public TMP_Text counter_text;
    // Start is called before the first frame update
    public List<GameObject> cubesList = new List<GameObject>();
    void Start()
    {
        answerTest = numTest1 / numTest2;

        StartCoroutine(ExampleCoroutine());


    }

    IEnumerator ExampleCoroutine()
    {

        for (int i = 0; i < answerTest; i++)
        {
            GameObject cube = Instantiate(adderCube, new Vector3(
                adderCube.transform.position.x,
                adderCube.transform.position.y + 5 + i * 5,
                adderCube.transform.position.z), Quaternion.identity);
            
            yield return new WaitForSeconds(0.3f);
            cubesList.Add(cube);
        }
        foreach (var cube in cubesList)
        {
            Rigidbody rb = cube.GetComponent<Rigidbody>();
            if (rb == null)
            {
                rb = cube.AddComponent<Rigidbody>();
            }
            yield return new WaitForSeconds(0.3f);
            rb.useGravity = true;
        }




            //yield on a new YieldInstruction that waits for 5 seconds.

        }
}
