using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    public float range = 7.0f;
    void Start()
    {
        
        transform.localScale = Vector3.one * 1.3f;

        InvokeRepeating("ChangeValuesRandomly", 0, 1.5f);
    }

    private void ChangeValuesRandomly()
    {
        //These values are used to change color randomly.
        float colorValueR = Random.Range(0, 1.0f);
        float colorValueG = Random.Range(0, 1.0f);
        float colorValueB = Random.Range(0, 1.0f);

        //This value is for the change of opacity.
        float colorValueA = Random.Range(0, 1.0f);
        Material material = Renderer.material;

        material.color = new Color(colorValueR, colorValueG, colorValueB, colorValueA);
        
        transform.position = new Vector3(Random.Range(-range, range), transform.position.y, Random.Range(-range, range));
    }

    void Update()
    {
        transform.Rotate(15.0f * Time.deltaTime, 13.0f * Time.deltaTime, 0.0f);
        //Here, the object grows over time and resets when it reaches a certain size.
        transform.localScale += Vector3.one * 0.1f*Time.deltaTime;
        if (transform.localScale.x > 2.3f)
        {
            transform.localScale = Vector3.one;
        }
    }
}
