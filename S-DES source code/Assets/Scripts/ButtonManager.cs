using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonManager : MonoBehaviour
{
    public EnctyptionManager manager;
    public Image encryptionBox;
    public Image decryptionBox;
    public Sprite onBox;
    public Sprite offBox;

    public TextMeshProUGUI inputText;
    public TextMeshProUGUI finalText;
    public TextMeshProUGUI resultText;

    public Image lockIcon;
    public Sprite lockImg;
    public Sprite unlockImg;

    public GameObject processButton;
    public GameObject processWindow;

    public bool openWindow = false;

    public int page = 1;
    public GameObject page1;
    public GameObject page2;
    public GameObject page3;
    public TextMeshProUGUI pageNum;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeToEncryption()
    {
        manager.encryption = true;
        encryptionBox.sprite = onBox;
        decryptionBox.sprite = offBox;
        inputText.text = "plaintext:";
        finalText.text = "ciphertext:";
        lockIcon.sprite = lockImg;
        resultText.text = "";
        processButton.SetActive(false);
    }

    public void ChangeToDecryption()
    {
        manager.encryption = false;
        encryptionBox.sprite = offBox;
        decryptionBox.sprite = onBox;
        inputText.text = "ciphertext:";
        finalText.text = "plaintext:";
        lockIcon.sprite = unlockImg;
        resultText.text = "";
        processButton.SetActive(false);
    }

    public void calculate()
    {
        if(manager.encryption == true)
        {
            manager.Encrypt();
        }
        else
        {
            manager.Decrypt();
        }
    }

    public void showProcessWindow()
    {
        openWindow = !openWindow;
        if(openWindow == true)
        {
            processWindow.SetActive(true);
            page = 1;
            pageNum.text = page.ToString() + "/3";
            page1.SetActive(true);
            page2.SetActive(false);
            page3.SetActive(false);
        }
        else
        {
            processWindow.SetActive(false);
        }
        
    }

    public void nextPage()
    {
        if(page < 3)
        {
            page++;
        }

        pageNum.text = page.ToString()+"/3";

        if (page == 1)
        {
            page1.SetActive(true);
            page2.SetActive(false);
            page3.SetActive(false);
        }
        else if (page == 2)
        {
            page1.SetActive(false);
            page2.SetActive(true);
            page3.SetActive(false);
        }
        else if (page == 3)
        {
            page1.SetActive(false);
            page2.SetActive(false);
            page3.SetActive(true);
        }

    }

    public void previousPage()
    {
        if(page > 1)
        {
            page--;
        }
        pageNum.text = page.ToString() + "/3";

        if (page == 1)
        {
            page1.SetActive(true);
            page2.SetActive(false);
            page3.SetActive(false);
        }
        else if (page == 2)
        {
            page1.SetActive(false);
            page2.SetActive(true);
            page3.SetActive(false);
        }
        else if (page == 3)
        {
            page1.SetActive(false);
            page2.SetActive(false);
            page3.SetActive(true);
        }
    }
}
