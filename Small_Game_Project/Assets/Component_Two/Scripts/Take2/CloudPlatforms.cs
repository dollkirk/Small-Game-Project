using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudPlatforms : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject cloudPrefab;
    public Transform spawnPos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject clone;

            clone = Instantiate(cloudPrefab, spawnPos.position, spawnPos.rotation);
        }
    }

}
