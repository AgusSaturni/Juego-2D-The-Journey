using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;

public class Platform : MonoBehaviour
{

    private PlatformEffector2D effector;

    public float startWaitTime;

    private float waitedTime;

    public bool esPersonaje = false;


    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            esPersonaje = true;
        }
    }


 
    void Update()
    {
        
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            waitedTime = startWaitTime;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && esPersonaje)
        {
          
                effector.rotationalOffset = 180f;
                detenerAsync();
           
        }

    }

    public async Task detenerAsync()
    {
        await Task.Delay(200);
        effector.rotationalOffset = 0f;
    }
}
