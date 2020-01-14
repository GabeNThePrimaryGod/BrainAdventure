using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject brain = null;
    [SerializeField] Transform playLocation = null;
    [SerializeField] Transform optionLocation = null;
    [SerializeField] Transform creditsLocation = null;
    [SerializeField] Transform quitLocation = null;

    int currentChoice = 0;
    int elementsCount = 4;

    void Update()
    {
        if (!brain || !playLocation || !optionLocation || !quitLocation || !creditsLocation)
            Debug.LogError("References not set");

        if (Input.GetKeyDown(KeyCode.UpArrow))
            currentChoice = currentChoice > 0 ? currentChoice - 1 : elementsCount - 1;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            currentChoice = (currentChoice + 1) % elementsCount;

        Debug.DrawRay(Camera.main.transform.position, Input.mousePosition, Color.red);
        Ray mouseRay = new Ray(Camera.main.transform.position, Input.mousePosition);

        RaycastHit test = new RaycastHit(mouseRay);

        switch (currentChoice)
        {
            case 0:
                brain.transform.position = playLocation.position;
                break;
            case 1:
                brain.transform.position = optionLocation.position;
                break;
            case 2:
                brain.transform.position = creditsLocation.position;
                break;
            case 3:
                brain.transform.position = quitLocation.position;
                break;
        }

    }
}
