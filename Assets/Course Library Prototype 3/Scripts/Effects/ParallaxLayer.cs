using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ParallaxLayer : MonoBehaviour
{
  [SerializeField] private SpriteRenderer _renderer;
  public float Width => _renderer.bounds.size.x;
  public float Height => _renderer.bounds.size.y;
}