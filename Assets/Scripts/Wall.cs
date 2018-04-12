using UnityEngine;

namespace SketchMap {
    public class Wall : MonoBehaviour {
        Material SelfMaterial;

        Material GetMaterial() {
            return SelfMaterial ? SelfMaterial : SelfMaterial = GetComponent<Renderer>().material;
        }

        public Color WallColor {
            get {
                return GetMaterial().color;
            }
            set {
                GetMaterial().color = value;
            }
        }

        public static Wall CreateWall(Transform Parent, Vector2 Start, Vector2 End, Color WallColor) {
            GameObject NewObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            NewObject.transform.SetParent(Parent);
            Vector2 Direction = End - Start, Center = Start + Direction * .5f;
            NewObject.transform.localPosition = new Vector3(Center.x, Center.y, -.5f);
            NewObject.transform.localRotation = Quaternion.LookRotation(Direction, Vector3.back);
            NewObject.transform.localScale = new Vector3(.1f, .5f, Direction.magnitude);
            Wall NewWall = NewObject.AddComponent<Wall>();
            NewWall.WallColor = WallColor;
            return NewWall;
        }
    }
}