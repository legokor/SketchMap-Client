using UnityEngine;

namespace SketchMap {
    public class Player : MonoBehaviour {
        public static Player CreatePlayer(Transform Parent, Vector2 Position) {
            GameObject NewObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            NewObject.transform.localScale = new Vector3(.5f, .5f, .5f);
            NewObject.transform.position = Parent.position + Parent.rotation *
                new Vector3(Position.x / Parent.localScale.x, Position.y / Parent.localScale.y, -.5f / Parent.localScale.z);
            NewObject.GetComponent<Renderer>().material.color = Color.black;
            NewObject.AddComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            return NewObject.AddComponent<Player>();
        }
    }
}