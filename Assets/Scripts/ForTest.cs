using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ForTest : MonoBehaviour
{
    [SerializeField] private float _spawnRate = 0.01f;
    [SerializeField] private float _coroutineSwitchingTime = 3f;
    [SerializeField] private GameObject _boxPrefab;
    [SerializeField] private GameObject _rim;
    [SerializeField] private Material _materialA;
    [SerializeField] private Material _materialB;
    [SerializeField] private Material _tableTop;
    [SerializeField] private Material _tableBottom;
    private List<GameObject> _gameObjects = new List<GameObject>();

    private void Start()
    {
        StartCoroutine(StartSpawnProcess());
    }

    private IEnumerator StartSpawnProcess()
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
                        GameObject NewBox = Instantiate(_rim, new Vector3(x, y + 0.125f, z), Quaternion.identity, transform);
                        if (z == 0 || z == 9)
                        {
                            NewBox.GetComponentInChildren<Text>().text = "";
                        }
                        else
                        {
                            NewBox.GetComponentInChildren<Text>().text = z.ToString();
                        }
                        _gameObjects.Add(NewBox);
                        yield return new WaitForSeconds(_spawnRate);
                    }
                    else if (x == 9 && z > -1 && z < 10 && y == 19)
                    {
                        GameObject NewBox = Instantiate(_rim, new Vector3(x, y + 0.125f, z), Quaternion.identity, transform);
                        if (z == 0 || z == 9)
                        {
                            NewBox.GetComponentInChildren<Text>().text = "";
                        }
                        else
                        {
                            NewBox.GetComponentInChildren<Text>().text = (9 - z).ToString();
                            NewBox.GetComponentInChildren<Canvas>().transform.rotation = Quaternion.Euler(90, 0, 180);
                        }
                        _gameObjects.Add(NewBox);
                        yield return new WaitForSeconds(_spawnRate);
                    }
                    else if (z == 0 && x > -1 && x < 10 && y == 19)
                    {
                        GameObject NewBox = Instantiate(_rim, new Vector3(x, y + 0.125f, z), Quaternion.identity, transform);
                        NewBox.GetComponentInChildren<Text>().text = letters[x - 1];
                        _gameObjects.Add(NewBox);
                        yield return new WaitForSeconds(_spawnRate);
                    }
                    else if (z == 9 && x > -1 && x < 10 && y == 19)
                    {
                        GameObject NewBox = Instantiate(_rim, new Vector3(x, y + 0.125f, z), Quaternion.identity, transform);
                        NewBox.GetComponentInChildren<Text>().text = letters[8 - x];
                        NewBox.GetComponentInChildren<Canvas>().transform.rotation = Quaternion.Euler(90, 0, 180);
                        _gameObjects.Add(NewBox);
                        yield return new WaitForSeconds(_spawnRate);
                    }
                    else
                    {
                        if (x > -1 && x < 10 && z > -1 && z < 10 && y == 19)
                        {
                            GameObject NewBox = Instantiate(_boxPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
                            _gameObjects.Add(NewBox);
                            yield return new WaitForSeconds(_spawnRate);
                            if (z % 2 == 0 && y == 19)
                            {
                                if (x % 2 == 0)
                                {
                                    NewBox.GetComponent<Renderer>().material = _materialA;
                                }
                                else
                                {
                                    NewBox.GetComponent<Renderer>().material = _materialB;
                                }
                            }
                            else
                            {
                                if (x % 2 != 0)
                                {
                                    NewBox.GetComponent<Renderer>().material = _materialA;
                                }
                                else
                                {
                                    NewBox.GetComponent<Renderer>().material = _materialB;
                                }
                            }
                        }
                    }

                    if (y == 18)
                    {
                        GameObject NewBox = Instantiate(_boxPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
                        NewBox.GetComponent<Renderer>().material = _tableTop;
                        _gameObjects.Add(NewBox);
                        yield return new WaitForSeconds(_spawnRate);
                    }
                    if (y > -10 && y < 18 && x > 3 && x < 6 && z > 3 && z < 6)
                    {
                        GameObject NewBox = Instantiate(_boxPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
                        NewBox.GetComponent<Renderer>().material = _tableBottom;
                        _gameObjects.Add(NewBox);
                        yield return new WaitForSeconds(_spawnRate);
                    }
                    if (y == -10 && x > -7 && x < 16 && z > 3 && z < 6)
                    {
                        GameObject NewBox = Instantiate(_boxPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
                        NewBox.GetComponent<Renderer>().material = _tableBottom;
                        _gameObjects.Add(NewBox);
                        yield return new WaitForSeconds(_spawnRate);
                    }
                    if (y == -10 && x > 3 && x < 6 && z > -7 && z < 16)
                    {
                        GameObject NewBox = Instantiate(_boxPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
                        NewBox.GetComponent<Renderer>().material = _tableBottom;
                        _gameObjects.Add(NewBox);
                        yield return new WaitForSeconds(_spawnRate);
                    }
                }
            }
        }

        yield return new WaitForSeconds(_coroutineSwitchingTime);
        StartCoroutine(StartDespawnProcess());
    }

    private IEnumerator StartDespawnProcess()
    {
        while (_gameObjects.Count > 0)
        {
            Destroy(_gameObjects[0].gameObject);
            _gameObjects.RemoveAt(0);
            yield return new WaitForSeconds(_spawnRate);
        }

        yield return new WaitForSeconds(_coroutineSwitchingTime);
        StartCoroutine(StartSpawnProcess());
    }

    [ContextMenu("TestSpawn")]
    private void TestSpawn()
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
                        GameObject NewBox = Instantiate(_rim, new Vector3(x, y + 0.125f, z), Quaternion.identity, transform);
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
                        GameObject NewBox = Instantiate(_rim, new Vector3(x, y + 0.125f, z), Quaternion.identity, transform);
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
                        GameObject NewBox = Instantiate(_rim, new Vector3(x, y + 0.125f, z), Quaternion.identity, transform);
                        NewBox.GetComponentInChildren<Text>().text = letters[x - 1];
                    }
                    else if (z == 9 && x > -1 && x < 10 && y == 19)
                    {
                        GameObject NewBox = Instantiate(_rim, new Vector3(x, y + 0.125f, z), Quaternion.identity, transform);
                        NewBox.GetComponentInChildren<Text>().text = letters[8 - x];
                        NewBox.GetComponentInChildren<Canvas>().transform.rotation = Quaternion.Euler(90, 0, 180);
                    }
                    else
                    {
                        if (x > -1 && x < 10 && z > -1 && z < 10 && y == 19)
                        {
                            GameObject NewBox = Instantiate(_boxPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
                            if (z % 2 == 0 && y == 19)
                            {
                                if (x % 2 == 0)
                                {
                                    NewBox.GetComponent<Renderer>().material = _materialA;
                                }
                                else
                                {
                                    NewBox.GetComponent<Renderer>().material = _materialB;
                                }
                            }
                            else
                            {
                                if (x % 2 != 0)
                                {
                                    NewBox.GetComponent<Renderer>().material = _materialA;
                                }
                                else
                                {
                                    NewBox.GetComponent<Renderer>().material = _materialB;
                                }
                            }
                        }
                    }

                    if (y == 18)
                    {
                        GameObject NewBox = Instantiate(_boxPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
                        NewBox.GetComponent<Renderer>().material = _tableTop;
                    }
                    if (y > -10 && y < 18 && x > 3 && x < 6 && z > 3 && z < 6)
                    {
                        GameObject NewBox = Instantiate(_boxPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
                        NewBox.GetComponent<Renderer>().material = _tableBottom;
                    }
                    if (y == -10 && x > -7 && x < 16 && z > 3 && z < 6)
                    {
                        GameObject NewBox = Instantiate(_boxPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
                        NewBox.GetComponent<Renderer>().material = _tableBottom;
                    }
                    if (y == -10 && x > 3 && x < 6 && z > -7 && z < 16)
                    {
                        GameObject NewBox = Instantiate(_boxPrefab, new Vector3(x, y, z), Quaternion.identity, transform);
                        NewBox.GetComponent<Renderer>().material = _tableBottom;
                    }
                }
            }
        }
    }

    [ContextMenu("CleanChildren")]
    public void CleanChildren()
    {
        int childrenCount = transform.childCount;

        for (int i = 0; i < childrenCount; i++)
        {
            DestroyImmediate(GetComponentInChildren<BoxCollider>().gameObject);
        }
    }
}
