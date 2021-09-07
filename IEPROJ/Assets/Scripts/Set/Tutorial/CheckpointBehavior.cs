using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBehavior : MonoBehaviour
{
    [SerializeField] GameObject player;
    public bool collided;
    // Start is called before the first frame update
    void Start()
    {
        this.collided = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, this.gameObject.transform.position)<= 1.1f)
        {
            Debug.Log($"Collided with {Vector3.Distance(player.transform.position, this.gameObject.transform.position)}");
            this.collided = true;
            this.gameObject.SetActive(false);
        }
        //Debug.Log($"Diatnce {Vector3.Distance(player.transform.position, this.gameObject.transform.position)}");

    }
}
