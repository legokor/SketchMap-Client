using UnityEngine;

namespace SketchMap {
    public class Gem : MonoBehaviour {
        Material SelfMaterial;

        Material GetMaterial() {
            return SelfMaterial ? SelfMaterial : SelfMaterial = GetComponent<Renderer>().material;
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
            GameObject NewObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            NewObject.transform.localScale = new Vector3(.5f, .5f, .5f);
            NewObject.transform.SetParent(Parent);
            Gem NewGem = NewObject.AddComponent<Gem>();
            NewGem.Position = Position;
            NewGem.GemColor = GemColor;
            return NewGem;
        }
    }
}