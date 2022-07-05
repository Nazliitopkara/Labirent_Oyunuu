using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopKontrol3 : MonoBehaviour
{
    public GameObject cancan,cancan1; // ek can
    public GameObject zamzaman, zamzaman1; // ek zaman
    public UnityEngine.UI.Button buton,buton2;
    public UnityEngine.UI.Text zaman, can, durum,tebrik;
    private Rigidbody rg;
    public float hiz = 1.78f;
    public float zamansayaci = 60;
    int cansayaci = 5;
    bool oyundevam = true;
    bool pauseGame = false;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (oyundevam)
        {
            zamansayaci -= Time.deltaTime;
            zaman.text = (int)zamansayaci + "";
        }
        else
        {
            durum.text = "BAÞARISIZ";
            buton.gameObject.SetActive(true);
            buton2.gameObject.SetActive(true);
        }

        if (zamansayaci < 0)
        {
            oyundevam = false;
        }
    }
    private void FixedUpdate()
    {

        if (oyundevam)
        {
            float yatay = Input.GetAxis("Horizontal");
            float dikey = Input.GetAxis("Vertical");
            Vector3 kuvvet = new Vector3(yatay, 0, dikey);
            rg.AddForce(kuvvet * hiz);
        }
        else
        {
            rg.velocity = Vector3.zero; // oyun bittiðinde hýzý sýfýrla
            rg.angularVelocity = Vector3.zero;//top oyun bitince dönmesin
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        string objeisim = collision.gameObject.name;

        
        if (objeisim.Equals("Bitis"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        if (objeisim.Equals("Bitis1"))
        {
            pauseGame = !pauseGame;

            if (pauseGame == true)
            {
                Time.timeScale = 0.0f;
                tebrik.gameObject.SetActive(true);
            }
            
        }

        else if (objeisim.Equals("ZamanPanel"))
        {
            zamansayaci += 5;
            zaman.text = (int)zamansayaci + "";
            zamzaman.SetActive(false);
        }

        else if (objeisim.Equals("ZamanPanel1"))
        {
            zamansayaci += 5;
            zaman.text = (int)zamansayaci + "";
            zamzaman1.SetActive(false);
        }

        else if (objeisim.Equals("CanPanel"))
        {
            cansayaci += 1;
            can.text = cansayaci + "";
            cancan.SetActive(false);
        }

        else if (objeisim.Equals("CanPanel1"))
        {
            cansayaci += 1;
            can.text = cansayaci + "";
            cancan1.SetActive(false);
        }

        else if (!objeisim.Equals("Zemin"))
        {
            cansayaci -= 1;
            can.text = cansayaci + "";

            if (cansayaci == 0)
            {
                oyundevam = false;
            }
        }
    }
}
