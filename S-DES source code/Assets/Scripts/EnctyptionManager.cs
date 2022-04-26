using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnctyptionManager : MonoBehaviour
{
    public bool encryption = true;

    public TMP_InputField inputField;
    public TMP_InputField keyField;

    public TextMeshProUGUI finalTextObj;

    public string inputText;
    public string keyText;

    public string p10Key;
    public string ls1Left;
    public string ls1Right;
    public string key1;
    public string ls2Left;
    public string ls2Right;
    public string key2;


    public string ip;

    public string l1;
    public string r1;
    public string r1EP;
    public string r1EPXor;
    public string xorLeft_1;
    public string xorRight_1;
    public string s0_1;
    public string s1_1;
    public string p4_1;

    public string l2;
    public string r2;
    public string r2EP;
    public string r2EPXor;
    public string xorLeft_2;
    public string xorRight_2;
    public string s0_2;
    public string s1_2;
    public string p4_2;

    public string lastString;

    public string ip_inverse;

    public string[,] sbox0 = new string[4, 4] { { "01", "00", "11", "10" }, { "11", "10", "01", "00" }, { "00", "10", "01", "11" }, { "11", "01", "11", "10" } };
    public string[,] sbox1 = new string[4, 4] { { "00", "01", "10", "11" }, { "10", "00", "01", "11" }, { "11", "00", "01", "00" }, { "10", "01", "00", "11" } };

    public GameObject processButton;


    public TextMeshProUGUI page1_keyinput;
    public TextMeshProUGUI page1_p10key;
    public TextMeshProUGUI page1_ls1Left;
    public TextMeshProUGUI page1_ls1Right;
    public TextMeshProUGUI page1_key1;
    public TextMeshProUGUI page1_ls2Left;
    public TextMeshProUGUI page1_ls2Right;
    public TextMeshProUGUI page1_key2;

    public TextMeshProUGUI page2_first_key_text;
    public TextMeshProUGUI page2_firstkey;
    public TextMeshProUGUI page2_plaintext;
    public TextMeshProUGUI page2_ip;
    public TextMeshProUGUI page2_l1;
    public TextMeshProUGUI page2_r1;
    public TextMeshProUGUI page2_r1EP;
    public TextMeshProUGUI page2_r1EPXor;
    public TextMeshProUGUI page2_xorLeft_1;
    public TextMeshProUGUI page2_xorRight_1;
    public TextMeshProUGUI page2_s0_1;
    public TextMeshProUGUI page2_s1_1;
    public TextMeshProUGUI page2_p4_1;
    public TextMeshProUGUI page2_l2;
    public TextMeshProUGUI page2_r2;

    public TextMeshProUGUI page3_second_key_text;
    public TextMeshProUGUI page3_secondkey;
    public TextMeshProUGUI page3_l2;
    public TextMeshProUGUI page3_r2;
    public TextMeshProUGUI page3_r2EP;
    public TextMeshProUGUI page3_r2EPXor;
    public TextMeshProUGUI page3_xorLeft_2;
    public TextMeshProUGUI page3_xorRight_2;
    public TextMeshProUGUI page3_s0_2;
    public TextMeshProUGUI page3_s1_2;
    public TextMeshProUGUI page3_p4_2;
    public TextMeshProUGUI page3_ip_inverse;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Encrypt()
    {
        inputText = inputField.text;
        keyText = keyField.text;
        bool dataCorrect = true;
        if(inputText.Length == 8 && keyText.Length == 10)
        {
            for(int i = 0; i < 8; i++)
            {
                if(!(inputText[i] == '1' || inputText[i] == '0'))
                {
                    dataCorrect = false;
                    break;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (!(keyText[i] == '1' || keyText[i] == '0'))
                {
                    dataCorrect = false;
                    break;
                }
            }

            if (dataCorrect == true)
            {
                int row, column;

                //2 4 1 6 3 9 0 8 7 5
                p10Key = "";
                p10Key += keyText[2];
                p10Key += keyText[4];
                p10Key += keyText[1];
                p10Key += keyText[6];
                p10Key += keyText[3];
                p10Key += keyText[9];
                p10Key += keyText[0];
                p10Key += keyText[8];
                p10Key += keyText[7];
                p10Key += keyText[5];

                ls1Left = "";
                ls1Left += p10Key[1];
                ls1Left += p10Key[2];
                ls1Left += p10Key[3];
                ls1Left += p10Key[4];
                ls1Left += p10Key[0];

                ls1Right = "";
                ls1Right += p10Key[6];
                ls1Right += p10Key[7];
                ls1Right += p10Key[8];
                ls1Right += p10Key[9];
                ls1Right += p10Key[5];

                //5 2 6 3 7 4 9 8 
                key1 = "";
                key1 += ls1Right[0];
                key1 += ls1Left[2];
                key1 += ls1Right[1];
                key1 += ls1Left[3];
                key1 += ls1Right[2];
                key1 += ls1Left[4];
                key1 += ls1Right[4];
                key1 += ls1Right[3];

                ls2Left = "";
                ls2Left += ls1Left[2];
                ls2Left += ls1Left[3];
                ls2Left += ls1Left[4];
                ls2Left += ls1Left[0];
                ls2Left += ls1Left[1];

                ls2Right = "";
                ls2Right += ls1Right[2];
                ls2Right += ls1Right[3];
                ls2Right += ls1Right[4];
                ls2Right += ls1Right[0];
                ls2Right += ls1Right[1];

                //5 2 6 3 7 4 9 8 
                key2 = "";
                key2 += ls2Right[0];
                key2 += ls2Left[2];
                key2 += ls2Right[1];
                key2 += ls2Left[3];
                key2 += ls2Right[2];
                key2 += ls2Left[4];
                key2 += ls2Right[4];
                key2 += ls2Right[3];

                //1 5 2 0 3 7 4 6
                ip = "";
                ip += inputText[1];
                ip += inputText[5];
                ip += inputText[2];
                ip += inputText[0];
                ip += inputText[3];
                ip += inputText[7];
                ip += inputText[4];
                ip += inputText[6];

                l1 = "";
                l1 += ip[0];
                l1 += ip[1];
                l1 += ip[2];
                l1 += ip[3];

                r1 = "";
                r1 += ip[4];
                r1 += ip[5];
                r1 += ip[6];
                r1 += ip[7];

                //3 0 1 2 1 2 3 0
                r1EP = "";
                r1EP += r1[3];
                r1EP += r1[0];
                r1EP += r1[1];
                r1EP += r1[2];
                r1EP += r1[1];
                r1EP += r1[2];
                r1EP += r1[3];
                r1EP += r1[0];

                r1EPXor = "";
                for(int i = 0; i < 8; i++)
                {
                    if(r1EP[i] == '0' && key1[i] == '0')
                    {
                        r1EPXor += '0';
                    }
                    if (r1EP[i] == '0' && key1[i] == '1')
                    {
                        r1EPXor += '1';
                    }
                    if (r1EP[i] == '1' && key1[i] == '0')
                    {
                        r1EPXor += '1';
                    }
                    if (r1EP[i] == '1' && key1[i] == '1')
                    {
                        r1EPXor += '0';
                    }
                }

                xorLeft_1 = "";
                xorLeft_1 += r1EPXor[0];
                xorLeft_1 += r1EPXor[1];
                xorLeft_1 += r1EPXor[2];
                xorLeft_1 += r1EPXor[3];

                xorRight_1 = "";
                xorRight_1 += r1EPXor[4];
                xorRight_1 += r1EPXor[5];
                xorRight_1 += r1EPXor[6];
                xorRight_1 += r1EPXor[7];

                row = 0;
                if(xorLeft_1[3] == '1')
                {
                    row += 1;
                }
                if (xorLeft_1[0] == '1')
                {
                    row += 2;
                }

                column = 0;
                if (xorLeft_1[2] == '1')
                {
                    column += 1;
                }
                if (xorLeft_1[1] == '1')
                {
                    column += 2;
                }
                s0_1 = sbox0[row, column];

                row = 0;
                if (xorRight_1[3] == '1')
                {
                    row += 1;
                }
                if (xorRight_1[0] == '1')
                {
                    row += 2;
                }

                column = 0;
                if (xorRight_1[2] == '1')
                {
                    column += 1;
                }
                if (xorRight_1[1] == '1')
                {
                    column += 2;
                }
                s1_1 = sbox1[row, column];

                //1 3 2 0
                p4_1 = "";
                p4_1 += s0_1[1];
                p4_1 += s1_1[1];
                p4_1 += s1_1[0];
                p4_1 += s0_1[0];

                l2 = r1;

                r2 = "";
                for(int i = 0; i < 4; i++)
                {
                    if (p4_1[i] == '0' && l1[i] == '0')
                    {
                        r2 += '0';
                    }
                    if (p4_1[i] == '0' && l1[i] == '1')
                    {
                        r2 += '1';
                    }
                    if (p4_1[i] == '1' && l1[i] == '0')
                    {
                        r2 += '1';
                    }
                    if (p4_1[i] == '1' && l1[i] == '1')
                    {
                        r2 += '0';
                    }
                }


                //3 0 1 2 1 2 3 0
                r2EP = "";
                r2EP += r2[3];
                r2EP += r2[0];
                r2EP += r2[1];
                r2EP += r2[2];
                r2EP += r2[1];
                r2EP += r2[2];
                r2EP += r2[3];
                r2EP += r2[0];

                r2EPXor = "";
                for (int i = 0; i < 8; i++)
                {
                    if (r2EP[i] == '0' && key2[i] == '0')
                    {
                        r2EPXor += '0';
                    }
                    if (r2EP[i] == '0' && key2[i] == '1')
                    {
                        r2EPXor += '1';
                    }
                    if (r2EP[i] == '1' && key2[i] == '0')
                    {
                        r2EPXor += '1';
                    }
                    if (r2EP[i] == '1' && key2[i] == '1')
                    {
                        r2EPXor += '0';
                    }
                }

                xorLeft_2 = "";
                xorLeft_2 += r2EPXor[0];
                xorLeft_2 += r2EPXor[1];
                xorLeft_2 += r2EPXor[2];
                xorLeft_2 += r2EPXor[3];

                xorRight_2 = "";
                xorRight_2 += r2EPXor[4];
                xorRight_2 += r2EPXor[5];
                xorRight_2 += r2EPXor[6];
                xorRight_2 += r2EPXor[7];

                row = 0;
                if (xorLeft_2[3] == '1')
                {
                    row += 1;
                }
                if (xorLeft_2[0] == '1')
                {
                    row += 2;
                }

                column = 0;
                if (xorLeft_2[2] == '1')
                {
                    column += 1;
                }
                if (xorLeft_2[1] == '1')
                {
                    column += 2;
                }
                s0_2 = sbox0[row, column];

                row = 0;
                if (xorRight_2[3] == '1')
                {
                    row += 1;
                }
                if (xorRight_2[0] == '1')
                {
                    row += 2;
                }

                column = 0;
                if (xorRight_2[2] == '1')
                {
                    column += 1;
                }
                if (xorRight_2[1] == '1')
                {
                    column += 2;
                }
                s1_2 = sbox1[row, column];

                //1 3 2 0
                p4_2 = "";
                p4_2 += s0_2[1];
                p4_2 += s1_2[1];
                p4_2 += s1_2[0];
                p4_2 += s0_2[0];

                lastString = "";
                for (int i = 0; i < 4; i++)
                {
                    if (p4_2[i] == '0' && l2[i] == '0')
                    {
                        lastString += '0';
                    }
                    if (p4_2[i] == '0' && l2[i] == '1')
                    {
                        lastString += '1';
                    }
                    if (p4_2[i] == '1' && l2[i] == '0')
                    {
                        lastString += '1';
                    }
                    if (p4_2[i] == '1' && l2[i] == '1')
                    {
                        lastString += '0';
                    }
                }

                lastString += r2;

                ip_inverse = "";
                ip_inverse += lastString[3];
                ip_inverse += lastString[0];
                ip_inverse += lastString[2];
                ip_inverse += lastString[4];
                ip_inverse += lastString[6];
                ip_inverse += lastString[1];
                ip_inverse += lastString[7];
                ip_inverse += lastString[5];

                finalTextObj.text = ip_inverse;
                processButton.SetActive(true);

                page1_keyinput.text = keyText;
                page1_p10key.text = p10Key;
                page1_ls1Left.text = ls1Left;
                page1_ls1Right.text = ls1Right;
                page1_key1.text = key1;
                page1_ls2Left.text = ls2Left;
                page1_ls2Right.text = ls2Right;
                page1_key2.text = key2;

                page2_first_key_text.text = "k1";
                page2_firstkey.text = key1;
                page2_plaintext.text = inputText;
                page2_ip.text = ip;
                page2_l1.text = l1;
                page2_r1.text = r1;
                page2_r1EP.text = r1EP;
                page2_r1EPXor.text = r1EPXor;
                page2_xorLeft_1.text = xorLeft_1;
                page2_xorRight_1.text = xorRight_1;
                page2_s0_1.text = s0_1;
                page2_s1_1.text = s1_1;
                page2_p4_1.text = p4_1;
                page2_l2.text = l2;
                page2_r2.text = r2;

                page3_second_key_text.text = "k2";
                page3_secondkey.text = key2;
                page3_l2.text = l2;
                page3_r2.text = r2;
                page3_r2EP.text = r2EP;
                page3_r2EPXor.text = r2EPXor;
                page3_xorLeft_2.text = xorLeft_2;
                page3_xorRight_2.text = xorRight_2;
                page3_s0_2.text = s0_2;
                page3_s1_2.text = s1_2;
                page3_p4_2.text = p4_2;
                page3_ip_inverse.text = ip_inverse;
            }
            else
            {
                finalTextObj.text = "Input Error!";
            }
        }
        else
        {
            finalTextObj.text = "Input Error!";
        }
        

    }

    public void Decrypt()
    {
        inputText = inputField.text;
        keyText = keyField.text;
        bool dataCorrect = true;
        if (inputText.Length == 8 && keyText.Length == 10)
        {
            for (int i = 0; i < 8; i++)
            {
                if (!(inputText[i] == '1' || inputText[i] == '0'))
                {
                    dataCorrect = false;
                    break;
                }
            }
            for (int i = 0; i < 10; i++)
            {
                if (!(keyText[i] == '1' || keyText[i] == '0'))
                {
                    dataCorrect = false;
                    break;
                }
            }

            if (dataCorrect == true)
            {
                int row, column;

                //2 4 1 6 3 9 0 8 7 5
                p10Key = "";
                p10Key += keyText[2];
                p10Key += keyText[4];
                p10Key += keyText[1];
                p10Key += keyText[6];
                p10Key += keyText[3];
                p10Key += keyText[9];
                p10Key += keyText[0];
                p10Key += keyText[8];
                p10Key += keyText[7];
                p10Key += keyText[5];

                ls1Left = "";
                ls1Left += p10Key[1];
                ls1Left += p10Key[2];
                ls1Left += p10Key[3];
                ls1Left += p10Key[4];
                ls1Left += p10Key[0];

                ls1Right = "";
                ls1Right += p10Key[6];
                ls1Right += p10Key[7];
                ls1Right += p10Key[8];
                ls1Right += p10Key[9];
                ls1Right += p10Key[5];

                //5 2 6 3 7 4 9 8 
                key1 = "";
                key1 += ls1Right[0];
                key1 += ls1Left[2];
                key1 += ls1Right[1];
                key1 += ls1Left[3];
                key1 += ls1Right[2];
                key1 += ls1Left[4];
                key1 += ls1Right[4];
                key1 += ls1Right[3];

                ls2Left = "";
                ls2Left += ls1Left[2];
                ls2Left += ls1Left[3];
                ls2Left += ls1Left[4];
                ls2Left += ls1Left[0];
                ls2Left += ls1Left[1];

                ls2Right = "";
                ls2Right += ls1Right[2];
                ls2Right += ls1Right[3];
                ls2Right += ls1Right[4];
                ls2Right += ls1Right[0];
                ls2Right += ls1Right[1];

                //5 2 6 3 7 4 9 8 
                key2 = "";
                key2 += ls2Right[0];
                key2 += ls2Left[2];
                key2 += ls2Right[1];
                key2 += ls2Left[3];
                key2 += ls2Right[2];
                key2 += ls2Left[4];
                key2 += ls2Right[4];
                key2 += ls2Right[3];

                //1 5 2 0 3 7 4 6
                ip = "";
                ip += inputText[1];
                ip += inputText[5];
                ip += inputText[2];
                ip += inputText[0];
                ip += inputText[3];
                ip += inputText[7];
                ip += inputText[4];
                ip += inputText[6];

                l1 = "";
                l1 += ip[0];
                l1 += ip[1];
                l1 += ip[2];
                l1 += ip[3];

                r1 = "";
                r1 += ip[4];
                r1 += ip[5];
                r1 += ip[6];
                r1 += ip[7];

                //3 0 1 2 1 2 3 0
                r1EP = "";
                r1EP += r1[3];
                r1EP += r1[0];
                r1EP += r1[1];
                r1EP += r1[2];
                r1EP += r1[1];
                r1EP += r1[2];
                r1EP += r1[3];
                r1EP += r1[0];

                r1EPXor = "";
                for (int i = 0; i < 8; i++)
                {
                    if (r1EP[i] == '0' && key2[i] == '0')
                    {
                        r1EPXor += '0';
                    }
                    if (r1EP[i] == '0' && key2[i] == '1')
                    {
                        r1EPXor += '1';
                    }
                    if (r1EP[i] == '1' && key2[i] == '0')
                    {
                        r1EPXor += '1';
                    }
                    if (r1EP[i] == '1' && key2[i] == '1')
                    {
                        r1EPXor += '0';
                    }
                }

                xorLeft_1 = "";
                xorLeft_1 += r1EPXor[0];
                xorLeft_1 += r1EPXor[1];
                xorLeft_1 += r1EPXor[2];
                xorLeft_1 += r1EPXor[3];

                xorRight_1 = "";
                xorRight_1 += r1EPXor[4];
                xorRight_1 += r1EPXor[5];
                xorRight_1 += r1EPXor[6];
                xorRight_1 += r1EPXor[7];

                row = 0;
                if (xorLeft_1[3] == '1')
                {
                    row += 1;
                }
                if (xorLeft_1[0] == '1')
                {
                    row += 2;
                }

                column = 0;
                if (xorLeft_1[2] == '1')
                {
                    column += 1;
                }
                if (xorLeft_1[1] == '1')
                {
                    column += 2;
                }
                s0_1 = sbox0[row, column];

                row = 0;
                if (xorRight_1[3] == '1')
                {
                    row += 1;
                }
                if (xorRight_1[0] == '1')
                {
                    row += 2;
                }

                column = 0;
                if (xorRight_1[2] == '1')
                {
                    column += 1;
                }
                if (xorRight_1[1] == '1')
                {
                    column += 2;
                }
                s1_1 = sbox1[row, column];

                //1 3 2 0
                p4_1 = "";
                p4_1 += s0_1[1];
                p4_1 += s1_1[1];
                p4_1 += s1_1[0];
                p4_1 += s0_1[0];

                l2 = r1;

                r2 = "";
                for (int i = 0; i < 4; i++)
                {
                    if (p4_1[i] == '0' && l1[i] == '0')
                    {
                        r2 += '0';
                    }
                    if (p4_1[i] == '0' && l1[i] == '1')
                    {
                        r2 += '1';
                    }
                    if (p4_1[i] == '1' && l1[i] == '0')
                    {
                        r2 += '1';
                    }
                    if (p4_1[i] == '1' && l1[i] == '1')
                    {
                        r2 += '0';
                    }
                }


                //3 0 1 2 1 2 3 0
                r2EP = "";
                r2EP += r2[3];
                r2EP += r2[0];
                r2EP += r2[1];
                r2EP += r2[2];
                r2EP += r2[1];
                r2EP += r2[2];
                r2EP += r2[3];
                r2EP += r2[0];

                r2EPXor = "";
                for (int i = 0; i < 8; i++)
                {
                    if (r2EP[i] == '0' && key1[i] == '0')
                    {
                        r2EPXor += '0';
                    }
                    if (r2EP[i] == '0' && key1[i] == '1')
                    {
                        r2EPXor += '1';
                    }
                    if (r2EP[i] == '1' && key1[i] == '0')
                    {
                        r2EPXor += '1';
                    }
                    if (r2EP[i] == '1' && key1[i] == '1')
                    {
                        r2EPXor += '0';
                    }
                }

                xorLeft_2 = "";
                xorLeft_2 += r2EPXor[0];
                xorLeft_2 += r2EPXor[1];
                xorLeft_2 += r2EPXor[2];
                xorLeft_2 += r2EPXor[3];

                xorRight_2 = "";
                xorRight_2 += r2EPXor[4];
                xorRight_2 += r2EPXor[5];
                xorRight_2 += r2EPXor[6];
                xorRight_2 += r2EPXor[7];

                row = 0;
                if (xorLeft_2[3] == '1')
                {
                    row += 1;
                }
                if (xorLeft_2[0] == '1')
                {
                    row += 2;
                }

                column = 0;
                if (xorLeft_2[2] == '1')
                {
                    column += 1;
                }
                if (xorLeft_2[1] == '1')
                {
                    column += 2;
                }
                s0_2 = sbox0[row, column];

                row = 0;
                if (xorRight_2[3] == '1')
                {
                    row += 1;
                }
                if (xorRight_2[0] == '1')
                {
                    row += 2;
                }

                column = 0;
                if (xorRight_2[2] == '1')
                {
                    column += 1;
                }
                if (xorRight_2[1] == '1')
                {
                    column += 2;
                }
                s1_2 = sbox1[row, column];

                //1 3 2 0
                p4_2 = "";
                p4_2 += s0_2[1];
                p4_2 += s1_2[1];
                p4_2 += s1_2[0];
                p4_2 += s0_2[0];

                lastString = "";
                for (int i = 0; i < 4; i++)
                {
                    if (p4_2[i] == '0' && l2[i] == '0')
                    {
                        lastString += '0';
                    }
                    if (p4_2[i] == '0' && l2[i] == '1')
                    {
                        lastString += '1';
                    }
                    if (p4_2[i] == '1' && l2[i] == '0')
                    {
                        lastString += '1';
                    }
                    if (p4_2[i] == '1' && l2[i] == '1')
                    {
                        lastString += '0';
                    }
                }

                lastString += r2;

                ip_inverse = "";
                ip_inverse += lastString[3];
                ip_inverse += lastString[0];
                ip_inverse += lastString[2];
                ip_inverse += lastString[4];
                ip_inverse += lastString[6];
                ip_inverse += lastString[1];
                ip_inverse += lastString[7];
                ip_inverse += lastString[5];

                finalTextObj.text = ip_inverse;
                processButton.SetActive(true);

                page1_keyinput.text = keyText;
                page1_p10key.text = p10Key;
                page1_ls1Left.text = ls1Left;
                page1_ls1Right.text = ls1Right;
                page1_key1.text = key1;
                page1_ls2Left.text = ls2Left;
                page1_ls2Right.text = ls2Right;
                page1_key2.text = key2;

                page2_first_key_text.text = "k2";
                page2_firstkey.text = key2;
                page2_plaintext.text = inputText;
                page2_ip.text = ip;
                page2_l1.text = l1;
                page2_r1.text = r1;
                page2_r1EP.text = r1EP;
                page2_r1EPXor.text = r1EPXor;
                page2_xorLeft_1.text = xorLeft_1;
                page2_xorRight_1.text = xorRight_1;
                page2_s0_1.text = s0_1;
                page2_s1_1.text = s1_1;
                page2_p4_1.text = p4_1;
                page2_l2.text = l2;
                page2_r2.text = r2;

                page3_second_key_text.text = "k1";
                page3_secondkey.text = key1;
                page3_l2.text = l2;
                page3_r2.text = r2;
                page3_r2EP.text = r2EP;
                page3_r2EPXor.text = r2EPXor;
                page3_xorLeft_2.text = xorLeft_2;
                page3_xorRight_2.text = xorRight_2;
                page3_s0_2.text = s0_2;
                page3_s1_2.text = s1_2;
                page3_p4_2.text = p4_2;
                page3_ip_inverse.text = ip_inverse;
            }   
            else
            {
                finalTextObj.text = "Input Error!";
            }
        }
        else
        {
            finalTextObj.text = "Input Error!";
        }
    }
}
