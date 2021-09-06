using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Item : MonoBehaviour
{
    Sprite gun;
    Sprite knife;
    Sprite can;
    Sprite hoe;

    // Start is called before the first frame update
    void Start()
    {
        gun = Resources.Load<Sprite>("Pistol");
        knife = Resources.Load<Sprite>("Machete");
        can = Resources.Load<Sprite>("Watering Can");
        hoe = Resources.Load<Sprite>("Hoe");
        this.GetComponent<Image>().sprite = gun;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            this.transform.GetComponent<Image>().sprite = hoe;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            this.transform.GetComponent<Image>().sprite = can;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            this.transform.GetComponent<Image>().sprite = gun;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            this.transform.GetComponent<Image>().sprite = knife;
        }
    }
}
