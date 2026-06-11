using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParallaxManager : MonoBehaviour
{
  [SerializeField] private float _speed;
  public float Speed => _speed;

  [SerializeField] private ParallaxLayer _layerPrefab;

  private float _movedDistance;
  private ParallaxLayer _lastLayer;

  private void Start()
  {
    if (_layerPrefab == null) return;

    for (int i = 0; i < 3; i++)
    {
      InsertBack();
    }

    _movedDistance = 0f;
  }

  private void Update()
  {
    transform.Translate(Vector3.left * Time.deltaTime * _speed);

    _movedDistance += Time.deltaTime * _speed;
    float width = _layerPrefab.Width;

    if (_movedDistance >= width)
    {
      _movedDistance = 0f;
      InsertBack();
    }
  }

  private float GetNextLayerPositionX()
  {
    if (_lastLayer == null)
    {
      return transform.position.x;
    }
    return _lastLayer.transform.position.x + _lastLayer.Width;
  }

  private void InsertBack()
  {
    var width = _layerPrefab.Width;
    var offset = width * 0.5f;

    var newLayer = Instantiate(_layerPrefab, transform).GetComponent<ParallaxLayer>();
    newLayer.transform.position = new Vector3(GetNextLayerPositionX(), transform.position.y, transform.position.z);

    _lastLayer = newLayer;
  }
}