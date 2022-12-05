using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

[ExecuteInEditMode]
public class ForTest : MonoBehaviour
{
    [SerializeField] private GameObject BoxPrefab;
    [SerializeField] private GameObject Rim;
    [SerializeField] private Material MaterialA;
    [SerializeField] private Material MaterialB;
    [SerializeField] private Material TableTop;
    [SerializeField] private Material TableBottom;

    void Start()
    {
        string[] letters = new string[8] { "A", "B", "C", "D", "E", "F", "G", "H" };

        for (int x = -10; x < 20; x++)
        {
            for (int z = -10; z < 20; z++)
            {
                for (int y = -10; y < 20; y++)
                {
                    if (x == 0 && z > -1 && z < 10 && y == 19)
                    {
                        GameObject NewBox = Instantiate(Rim, new Vector3(x, y + 0.125f, z), Quaternion.identity, transform);
                        if (z == 0 || z == 9)
                        {
                            NewBox.GetComponentInChildren<Text>().text = "";
                        }
                        else
                        {
                            NewBox.GetComponentInChildren<Text>().text = z.ToString();
                        }
                    }
                    else if (x == 9 && z > -1 && z < 10 && y == 19)
                    {
                        GameObject NewBox = Instantiate(Rim, new Vector3(x, y + 0.125f, z), Quaternion.identity, transform);
                        if (z == 0 || z == 9)
                        {
                            NewBox.GetComponentInChildren<Text>().text = "";
                        }
                        else
                        {
                            NewBox.GetComponentInChildren<Text>().text = (9 - z).ToString();
                            NewBox.GetComponentInChildren<Canvas>().transform.rotation = Quaternion.Euler(90, 0, 180);
                        }
                    }
                    else if (z == 0 && x > -1 && x < 10 && y == 19)
                    {
                        GameObject NewBox = Instantiate(Rim, new Vector3(x, y + 0.125f, z), Quaternion.identity, transform);
                        NewBox.GetComponentInChildren<Text>().text = letters[x - 1];
                    }
                    else if (z == 9 && x > -1 && x < 10 && y == 19)
                    {
                        GameObject NewBox = Instantiate(Rim, new Vector3(x, y + 0.125f, z), Quaternion.identity, transform);
                        NewBox.GetComponentInChildren<Text>().text = letters[8 - x];
                        NewBox.GetComponentInChildren<Canvas>().transform.rotation = Quaternion.Euler(90, 0, 180);
                    }
                    else
                    {
                        if (x > -1 && x < 10 && z > -1 && z < 10 && y == 19)
                        {
                            GameObject NewBox = Instantiate(BoxPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
                            if (z % 2 == 0 && y == 19)
                            {
                                if (x % 2 == 0)
                                {
                                    NewBox.GetComponent<Renderer>().material = MaterialA;
                                }
                                else
                                {
                                    NewBox.GetComponent<Renderer>().material = MaterialB;
                                }
                            }
                            else
                            {
                                if (x % 2 != 0)
                                {
                                    NewBox.GetComponent<Renderer>().material = MaterialA;
                                }
                                else
                                {
                                    NewBox.GetComponent<Renderer>().material = MaterialB;
                                }
                            }
                        }
                    }

                    if (y == 18)
                    {
                        GameObject NewBox = Instantiate(BoxPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
                        NewBox.GetComponent<Renderer>().material = TableTop;
                    }
                    if (y > -10 && y < 18 && x > 3 && x < 6 && z > 3 && z < 6)
                    {
                        GameObject NewBox = Instantiate(BoxPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
                        NewBox.GetComponent<Renderer>().material = TableBottom;
                    }
                    if (y == -10 && x > -7 && x < 16 && z > 3 && z < 6)
                    {
                        GameObject NewBox = Instantiate(BoxPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
                        NewBox.GetComponent<Renderer>().material = TableBottom;
                    }
                    if (y == -10 && x > 3 && x < 6 && z > -7 && z < 16)
                    {
                        GameObject NewBox = Instantiate(BoxPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
                        NewBox.GetComponent<Renderer>().material = TableBottom;
                    }
                }
            }
        }
    }
}
