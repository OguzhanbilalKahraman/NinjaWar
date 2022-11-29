using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pausemenu : MonoBehaviour
{

    
    
    // Start is called before the first frame update
    void Start()
    {
                    transform.position=new Vector3(transform.position.x,transform.position.y,-20f);

        
    }

    // Update is called once per frame
    void Update()
    {


        
         if(Input.GetKeyDown(KeyCode.Escape)){
             print("ahmetr");
             transform.position=new Vector3(transform.position.x,transform.position.y,-8f);
            
         }
         if(Input.GetKeyUp(KeyCode.Escape)){
            transform.position=new Vector3(transform.position.x,transform.position.y,20f);
         }
    }
}

