using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class TutorialScript : MonoBehaviour
{
    [SerializeField] Text Title;
    [SerializeField] Text Description;
    [SerializeField] GameObject ContinueText;

    [SerializeField] GameObject CoverPanel;
    [SerializeField] GameObject TutorialPanel;

    [SerializeField] List<GameObject> CheckpointList;
    [SerializeField] GameObject CheckPoints;

    [SerializeField] GameObject soil;
    [SerializeField] GameObject box;

    [SerializeField] GameObject Spawner;


    private int InstructionNum = 1;

    bool Hoe = false;
    bool Seed = false;
    bool Can = false;
    bool Hand = false;
    bool Gun = false;
    bool Machete = false;

    float timer = 0;


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        this.CoverPanel.SetActive(true);
        UpdateSteps();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ContinueText.activeInHierarchy)
        {
            Time.timeScale = 1;
            TriggerTask();
        }
        CheckPlayerInput();
        
        
    }

    public void UpdateSteps()
    {
        CoverPanel.SetActive(true);
        switch(InstructionNum)
        {
            case 1: Title.text = "TUTORIAL 1: PLAYER MOVEMENT";
                    Description.text = " You can move your player by pressing W, A, S, D and left button click to use tools and weapon.  Now try moving around by collecting the scattered red seeds";
                    break;

            case 2: Title.text = "TUTORIAL 2: SWITCHING EQUIPMENT";
                    Description.text = " Located on the top right is the equipment currently equiped by your character. You can change equipments by pressing NUM KEY 1-5: [1] Hoe, [2] Seed, [3] Watering can, [4] Hand, [5] Gun and [6] Machete. \n ";
                    break;

            case 3: Title.text = "TUTORIAL 3: TILLING THE SOIL";
                    Description.text = " Using a hoe [KEY NUM 1], you can till the a plot of soil making it suitable for cultivating plants. Why dont you try this out?\n ";
                    break;
      
            case 4: Title.text = "TUTORIAL 4: PLANTING SEED";
                    Description.text = " Now that the soil is tilled, you may now plant a seed. To do this, you need to access the seed from your inventory by pressing [KEY NUM 2] and plant it by pressing the left mouse button \n ";
                    break;

            case 5:
                Title.text = "TUTORIAL 5: WATERING THE PLANT";
                    Description.text = " Seeds does grow on a whim. Try watering it using the watering can [KEY NUM 3] in your inventory \n ";
                    break;

            case 6:
                    Title.text = "TUTORIAL 6: HARVESTING";
                    Description.text = "Great! You can now harvest your plant. Press [KEY NUM 4] to use your hands to harvest \n ";
                    break;

            case 7:
                Title.text = "TUTORIAL 7: DEFENDING FROM ENEMIES";
                Description.text = "Every night, various monsters are known to invade farms. In any case that this happens, be ready to defend yourself by equiping weapons such as guns [KEY NUM 5] and machete [KEY NUM 6] \n ";
                break;


            case 8:
                Title.text = "FINISHED TUTORIAL";
                Description.text = " Great Job! Now that you know the basics, you can now start with your adventure \n ";
                break;



        }
    }

    public void CheckPlayerInput()
    {
        if (InstructionNum == 1)
        {
            for (int i = 0; i < CheckpointList.Count; i++)
            {
                if (CheckpointList[i].GetComponent<CheckpointBehavior>().collided == true)
                {
                    CheckpointList[i].SetActive(false);
                    CheckpointList.Remove(CheckpointList[i]);
                }
            }

            if (CheckpointList.Count == 0)
            {
                timer += Time.deltaTime;

                if (timer >= 2)
                {
                    InstructionNum++;
                    Time.timeScale = 0;
                    timer = 0;
                    UpdateSteps();

                }
            }
        }
        else if (InstructionNum == 2)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Hoe = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Seed = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Can = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                Hand = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                Gun = true;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                Machete = true;
            }

            if (Hoe && Seed && Can && Hand && Gun && Machete)
            {
                InstructionNum++;
                Time.timeScale = 0;
                UpdateSteps();
            }
        }
        else if (InstructionNum == 3)
        {
            if (soil.GetComponent<Soil>().state == "Tilled")
            {
                timer += Time.deltaTime;
                box.SetActive(false);

                if (timer >= 2)
                {
                    InstructionNum++;
                    Time.timeScale = 0;
                    timer = 0;
                    UpdateSteps();

                }
            }
        }
        else if (InstructionNum == 4)
        {
            if (soil.GetComponent<Soil>().occupied)
            {
                timer += Time.deltaTime;

                if (timer >= 2)
                {
                    InstructionNum++;
                    Time.timeScale = 0;
                    timer = 0;
                    UpdateSteps();

                }
            }
        }

        else if (InstructionNum == 5)
        {
            
            GameObject plant = soil.gameObject.transform.GetChild(0).gameObject;
            if (plant.GetComponent<SpriteRenderer>().sprite.texture.name == "Rose_Dagger")
            {
                timer += Time.deltaTime;
            }

            if (timer >= 5)
            {
                InstructionNum++;
                Time.timeScale = 0;
                timer = 0;
           
                UpdateSteps();

            }
        }
        else if (InstructionNum == 6)
        {

            if (soil.GetComponent<Soil>().occupied == false)
            {
                timer += Time.deltaTime;
            }
            if (timer >= 2)
            {
                InstructionNum++;
                Time.timeScale = 0;
                timer = 0;
                UpdateSteps();

            }
        }
        else if (InstructionNum == 7)
        {
            Spawner.gameObject.SetActive(true);
            timer += Time.deltaTime;

            if (timer >= 30)
            {
                if (Spawner.activeInHierarchy)
                Spawner.SetActive(false);

            }
            if (timer >= 40)
            {
                InstructionNum++;
                Time.timeScale = 0;
                timer = 0;
                UpdateSteps();
            }
        }
    }


    public void TriggerTask()
    {
        CoverPanel.SetActive(false);


        if (InstructionNum == 1)
        {
            CheckPoints.SetActive(true);
        }
        if (InstructionNum ==3)
        {
            soil.SetActive(true);
            box.SetActive(true);
        }

        if (InstructionNum == 8)
        {
            SceneManager.LoadScene("Game");
        }




    }
}
