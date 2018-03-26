using UnityEngine;

namespace SketchMap {
    public class Wall : MonoBehaviour {
        Material SelfMaterial;

        Material GetMaterial() {
            return SelfMaterial ? SelfMaterial : SelfMaterial = GetComponent<Renderer>().material;
        }

        public Rect Position {
            set {
                float xScale = 1 / transform.parent.localScale.x, yScale = 1 / transform.parent.localScale.y, zScale = .5f / transform.parent.localScale.z;
                transform.localPosition = new Vector3((value.x + value.width * .5f) * xScale, (value.y + value.height * .5f) * yScale, -zScale);
                transform.localScale = new Vector3(value.width * xScale, value.height * yScale, zScale);
            }
        }

        public Color WallColor {
            get {
                return GetMaterial().color;
            }
            set {
                GetMaterial().color = value;
            }
        }

        public static Wall CreateWall(Transform Parent, Rect Position, Color WallColor) {
            GameObject NewObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            NewObject.transform.SetParent(Parent);
            NewObject.transform.localRotation = Quaternion.identity;
            Wall NewWall = NewObject.AddComponent<Wall>();
            NewWall.Position = Position;
            NewWall.WallColor = WallColor;
            return NewWall;
        }
    }
}