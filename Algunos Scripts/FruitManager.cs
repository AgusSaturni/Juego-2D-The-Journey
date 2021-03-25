using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour
{
    public Text levelCleared;
    public GameObject transition;
    public int cero= 0;

    public Text totalFruits;

    public Text fruitsCollected;

    private int totalFruitsInLevel;

    private void Start()
    {
        totalFruitsInLevel = transform.childCount;

    }

    public void Update()
    {
        AllFruitsCollected();
        totalFruits.text = totalFruitsInLevel.ToString();
        fruitsCollected.text = (totalFruitsInLevel - transform.childCount).ToString();
        if (transform.childCount == totalFruitsInLevel)
        {
            fruitsCollected.text = cero.ToString();
        }
        if (transform.childCount == 0)
        {
            fruitsCollected.text = totalFruitsInLevel.ToString();
        }
    }


    public void AllFruitsCollected()
    {

        if (transform.childCount == 0)
        {
            Debug.Log("No quedan frutas. VICTORIA");
           levelCleared.gameObject.SetActive(true);
            transition.SetActive(true);
            Invoke("ChangeEscene", 0.9f);  // el 1 lo retarda para que salga el texto
        }
    }
    void ChangeEscene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //avanza la escena
    }

}
