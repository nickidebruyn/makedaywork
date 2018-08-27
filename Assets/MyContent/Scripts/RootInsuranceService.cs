using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RootInsuranceService : MonoBehaviour {

    /* Create a Root Object to store the returned json data in */
    [System.Serializable]
    public class Quotes
    {
        public Quote[] values;

    }

    [System.Serializable]
    public class Quote
    {
        public string package_name;
        public string sum_assured;
        public int base_premium;
        public string suggested_premium;
        public string created_at;
        public string quote_package_id;
        public QuoteModule module;
    }

    [System.Serializable]
    public class QuoteModule
    {
        public string type;
        public string make;
        public string model;
    }

    [Serializable]
    public class Param
    {
        public Param(string _key, string _value)
        {
            key = _key;
            value = _value;
        }
        public string key;
        public string value;
    }

    public string api_key = "";
    public TextMesh malePremium;
    public TextMesh femalePremium;
    public TextMesh smokerPremium;

    private void Start()
    {
        // CreateQuote("iPhone 6S 64GB LTE");

    }

    public void CreateMaleQuote()
    {
        List<Param> parameters = new List<Param>();
        parameters.Add(new Param("type", "root_term"));
        parameters.Add(new Param("cover_amount", "100000000"));
        parameters.Add(new Param("cover_period", "1_year"));
        parameters.Add(new Param("basic_income_per_month", "4000000"));
        parameters.Add(new Param("education_status", "professional_degree"));
        parameters.Add(new Param("smoker", "false"));
        parameters.Add(new Param("gender", "male"));
        parameters.Add(new Param("age", "38"));

        StartCoroutine(CallAPICoroutine("https://sandbox.root.co.za/v1/insurance/quotes", parameters, 0));
    }

    public void CreateFemaleQuote()
    {
        List<Param> parameters = new List<Param>();
        parameters.Add(new Param("type", "root_term"));
        parameters.Add(new Param("cover_amount", "100000000"));
        parameters.Add(new Param("cover_period", "1_year"));
        parameters.Add(new Param("basic_income_per_month", "4000000"));
        parameters.Add(new Param("education_status", "grade_12_matric"));
        parameters.Add(new Param("smoker", "false"));
        parameters.Add(new Param("gender", "female"));
        parameters.Add(new Param("age", "32"));

        StartCoroutine(CallAPICoroutine("https://sandbox.root.co.za/v1/insurance/quotes", parameters, 1));
    }

    public void CreateSmokerQuote()
    {
        List<Param> parameters = new List<Param>();
        parameters.Add(new Param("type", "root_term"));
        parameters.Add(new Param("cover_amount", "100000000"));
        parameters.Add(new Param("cover_period", "1_year"));
        parameters.Add(new Param("basic_income_per_month", "4000000"));
        parameters.Add(new Param("education_status", "grade_12_no_matric"));
        parameters.Add(new Param("smoker", "true"));
        parameters.Add(new Param("gender", "male"));
        parameters.Add(new Param("age", "60"));

        StartCoroutine(CallAPICoroutine("https://sandbox.root.co.za/v1/insurance/quotes", parameters, 2));
    }


    IEnumerator CallAPICoroutine(string url, List<Param> parameters, int gender)
    {

        string auth = api_key + ":";
        auth = System.Convert.ToBase64String(System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(auth));
        auth = "Basic " + auth;

        WWWForm form = new WWWForm();

        foreach (var param in parameters)
        {
            form.AddField(param.key, param.value);
        }

        UnityWebRequest www = UnityWebRequest.Post(url, form);
        www.SetRequestHeader("AUTHORIZATION", auth);
        yield return www.Send();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.downloadHandler.text);

        }
        else
        {
            Quotes json = JsonUtility.FromJson<Quotes>("{\"values\":" + www.downloadHandler.text + "}");

            String text = "Make: " + json.values[0].module.make + "\nPremium: R" + (json.values[0].base_premium / 100);
            Debug.Log("Form upload complete!");
            Debug.Log(text);

            if (gender == 0)
            {
                malePremium.text = text;
            }
            if (gender == 1)
            {
                femalePremium.text = text;
            }
            if (gender == 2)
            {
                smokerPremium.text = text;
            }

        }

        yield return true;
    }
}
