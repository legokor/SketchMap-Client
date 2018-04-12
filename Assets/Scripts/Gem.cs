using UnityEngine;

namespace SketchMap {
    public class Gem : MonoBehaviour {
        public float RotationSpeed = 30;

        Material SelfMaterial;

        Material GetMaterial() {
            return SelfMaterial ? SelfMaterial : SelfMaterial = GetComponentInChildren<Renderer>().material;
        }

        public Vector2 Position {
            get {
                return new Vector2(transform.localPosition.x * transform.parent.localScale.x,
                    transform.localPosition.y * transform.parent.localScale.y);
            }
            set {
                transform.localPosition = new Vector3(value.x / transform.parent.localScale.x,
                    value.y / transform.parent.localScale.y, -.5f / transform.parent.localScale.z);
            }
        }

        public Color GemColor {
            get {
                return GetMaterial().color;
            }
            set {
                GetMaterial().color = value;
            }
        }

        public static Gem CreateGem(Transform Parent, Vector2 Position, Color GemColor) {
            GameObject NewObject = Instantiate(MapStats.Instance.Gem);
            NewObject.transform.localRotation = Quaternion.Euler(45, Random.value * 360, 45);
            NewObject.transform.SetParent(Parent);
            Gem NewGem = NewObject.AddComponent<Gem>();
            NewGem.Position = Position;
            NewGem.GemColor = GemColor;
            return NewGem;
        }

        void Start() {
            ++MapStats.RemainingGems;
        }

        void OnCollisionEnter(Collision collision) {
            if (collision.gameObject.GetComponent<Player>()) {
                --MapStats.RemainingGems;
                Destroy(gameObject);
            }
        }

        void Update() {
            transform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime, Space.World);
        }
    }
}