using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class RootGameManager : MonoBehaviour {

    public RootInsuranceService rootInsuranceService;
    public GameObject maleObject;
    public GameObject femaleObject;
    public GameObject smokerObject;
    public GameObject canvas;

    public bool gameover = false;

    void Start()
    {
        if (maleObject != null)
        {
            maleObject.GetComponent<PersonScript>().hideShadow();
            femaleObject.GetComponent<PersonScript>().hideShadow();
            smokerObject.GetComponent<PersonScript>().hideShadow();
        }

        canvas.SetActive(false);

    }

    // Update is called once per frame
    void Update() {

        if (canvas != null)
        {
            canvas.SetActive(gameover);
        }
        

        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit)
            {
                Debug.Log("Hit " + hitInfo.transform.gameObject.name);

                if (hitInfo.transform.gameObject.tag == "Male")
                {
                    Debug.Log("Male hit");
                    maleObject.GetComponent<PersonScript>().showShadow();
                    femaleObject.GetComponent<PersonScript>().hideShadow();
                    smokerObject.GetComponent<PersonScript>().hideShadow();
                    rootInsuranceService.CreateMaleQuote();

                } else if (hitInfo.transform.gameObject.tag == "Female")
                {
                    Debug.Log("Female hit");
                    maleObject.GetComponent<PersonScript>().hideShadow();
                    femaleObject.GetComponent<PersonScript>().showShadow();
                    smokerObject.GetComponent<PersonScript>().hideShadow();
                    rootInsuranceService.CreateFemaleQuote();

                }
                else if (hitInfo.transform.gameObject.tag == "Smoker")
                {
                    Debug.Log("Smoker hit");
                    maleObject.GetComponent<PersonScript>().hideShadow();
                    femaleObject.GetComponent<PersonScript>().hideShadow();
                    smokerObject.GetComponent<PersonScript>().showShadow();
                    rootInsuranceService.CreateSmokerQuote();

                }
                else
                {
                    Debug.Log("nopz");
                }
            }
            else
            {
                Debug.Log("No hit");
            }

        }


        //This function is used to exit the app on a mobile device
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    public void doAcceptMale()
    {
        SceneManager.LoadScene(1);
    }

    public void doAcceptFemale()
    {
        SceneManager.LoadScene(1);
    }

    public void doAcceptSmoker()
    {
        SceneManager.LoadScene(1);
    }
}
