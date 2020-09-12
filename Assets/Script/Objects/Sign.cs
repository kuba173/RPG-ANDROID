using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : interiactive
{



    public Joystick joystick;
    public GameObject dialogBox;
    public Text dialogText;
    public string dialog;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange)
        {dialogBox.SetActive(true);
           
                

           
            
            
        }
        else
        dialogBox.SetActive(false);
    }



    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player") && !other.isTrigger)
        {
            context.Raise();

            playerInRange = false;
            dialogBox.SetActive(false);

        }

    }

}
