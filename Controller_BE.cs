using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Slider;
using UnityEngine.SceneManagement;
using static System.Math;
using UnityEngine.Events;

public class contoller_BE : MonoBehaviour
{
    public int calon_1 = 0;
    public int calon_2 = 0;
    public int batal = 0;
    public int persen = 100;
    public int totalMasuk = 0;
    float red = 0;
    float green = 0;
    public Text calon1;
    public Text calon2;
    public Text bar_01;
    public Text bar_02;
    public Text total_masuk;
    public Text total_batal;
    public Text total;
    public Slider Slider_red;
    public Slider Slider_green;
    void Update()
    {
        //Berpindah Scene
        if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("BE HME FT-UH");
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("DM HME FT-UH");
        }
        //Penjumlahan
        if (Input.GetKeyDown(KeyCode.Q))
        {
            calon_1++;
            calon1.text = calon_1.ToString();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            calon_2++;
            calon2.text = calon_2.ToString();
        }
        //Pengurangan
        if (Input.GetKeyDown(KeyCode.A))
        {
            if(calon_1 > 0) calon_1--;
            calon1.text = calon_1.ToString();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if(calon_2 > 0) calon_2--;
            calon2.text = calon_2.ToString();
        }
        totalMasuk = calon_1 + calon_2;
        total_masuk.text = totalMasuk.ToString();
        if(totalMasuk == 0) {
            bar_01.text = "0%";
            bar_02.text = "0%";
        }
        else {
            bar_01.text = (Round((((float) calon_1 / totalMasuk) * persen), 2)).ToString() + " %";
            bar_02.text = (Round((((float) calon_2 / totalMasuk) * persen), 2)).ToString() + " %";
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            batal++;
            total_batal.text = batal.ToString();   
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            batal--;
            total_batal.text = batal.ToString();   
        }
        // int total_suara = totalMasuk + batal;
        // total.text = total_suara.ToString();

        //Progress Bar
        if (totalMasuk == 0)
        {
            Slider_red.value = 0;
            Slider_green.value = 0;
        }
        else {
            Slider_red.value = (float) calon_1/totalMasuk;
            Slider_green.value = (float) calon_2/totalMasuk;
        }
    }
    void Start() {
        //maximum
        Slider_red.maxValue = 1;
        Slider_green.maxValue = 1;
        //minimum
        Slider_red.minValue = 0;
        Slider_green.minValue = 0;
    }
}

