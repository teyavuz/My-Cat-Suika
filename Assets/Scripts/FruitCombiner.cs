using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCombiner : MonoBehaviour
{
    private int _layerIndex;

    private FruitInfo _info;

    private void Awake() 
    {
        _info = GetComponent<FruitInfo>();
        _layerIndex = gameObject.layer;
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.layer == _layerIndex)
        {
            FruitInfo info = collision.gameObject.GetComponent<FruitInfo>();

            if (info != null)
            {
                if (info.FruitIndex == _info.FruitIndex)
                {
                    int thisID = gameObject.GetInstanceID();
                    int otherID = collision.gameObject.GetInstanceID();

                    if (thisID > otherID)
                    {
                        if (_info.FruitIndex == 1)
                        {
                            AudioManager.Instance.PlaySFX("1");
                        }
                        else if (1 < _info.FruitIndex && _info.FruitIndex <= 4)
                        {
                            AudioManager.Instance.PlaySFX("2_4");
                        }
                        else if (4 < _info.FruitIndex && _info.FruitIndex <= 7)
                        {
                            AudioManager.Instance.PlaySFX("5_7");
                        }
                        else if (7 < _info.FruitIndex && _info.FruitIndex <= 10)
                        {
                            AudioManager.Instance.PlaySFX("8_10");
                        }
                        else if (_info.FruitIndex == 11)
                        {
                            AudioManager.Instance.PlaySFX("11");
                        }


                        GameManager.Instance.UpdateScore(_info.PointsWhenAnnihilated);
                        if (_info.FruitIndex == FruitSelector.instance.Fruits.Length-1)
                        {
                            Destroy(collision.gameObject);
                            Destroy(gameObject);
                        }

                        else
                        {
                            Vector3 middlePosition = (transform.position + collision.transform.position) / 2f;
                            GameObject go = Instantiate(SpawnCombinedFruit(_info.FruitIndex), GameManager.Instance.transform);
                            go.transform.position = middlePosition;

                            ColliderInformer informer = go.GetComponent<ColliderInformer>();
                            if (informer != null)
                            {
                                informer.WasCombinedIn = true;
                            }

                            Destroy(collision.gameObject);
                            Destroy(gameObject);
                        }
                    }
                }
            }
        }
    }

    private GameObject SpawnCombinedFruit(int index)
    {
        GameObject go = FruitSelector.instance.Fruits[index + 1];
        return go;
    }
}
