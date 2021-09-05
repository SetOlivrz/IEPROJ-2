using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item : MonoBehaviour
{
    Sprite gun;
    Sprite knife;

    // Start is called before the first frame update
    void Start()
    {
        gun = Resources.Load<Sprite>("Pistol");
        knife = Resources.Load<Sprite>("Machete");
        this.GetComponent<Image>().sprite = gun;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log("Gun");
            this.transform.GetComponent<Image>().sprite = gun;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            this.transform.GetComponent<Image>().sprite = knife;
        }
    }
}
