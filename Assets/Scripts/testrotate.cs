using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testrotate : MonoBehaviour
{
    [SerializeField] private Vector3 speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = transform.rotation * Quaternion.Euler(speed * Time.deltaTime);
    }
}
