using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMode : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject weapon;


    private PlayerSprite farmingMovement;
    private FirePointController fightingMovement;

    Animator animator;
    Shooting shooting;

    public bool isFarming = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
        shooting = this.gameObject.GetComponent<Shooting>();
        isFarming = true;
        farmingMovement = player.GetComponent<PlayerSprite>();
        fightingMovement = weapon.GetComponent<FirePointController>();
    }

    // Update is called once per frame
    void Update()
    {
        checkMode();

        if (isFarming == true)
        {
            Debug.Log("farm");
            farmingMovement.enabled = true;
            fightingMovement.enabled = false;
            animator.enabled = false;
            shooting.enabled = false;

        }
        else 
        {
            Debug.Log("fight");

            animator.enabled = true;
            shooting.enabled = true;

            farmingMovement.enabled = false;
            fightingMovement.enabled = true;
        }
    }

    public void checkMode()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isFarming = false;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            isFarming = true;
        }
    }
}
