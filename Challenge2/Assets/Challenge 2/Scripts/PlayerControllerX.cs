using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    float createTime=2f;
    // Update is called once per frame
    void Update()
    {
        createTime += Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space)&& createTime>3)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            createTime = 0;
        }
    }
}
