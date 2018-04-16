using LeapVR;
using UnityEngine;

namespace SketchMap {
    [RequireComponent(typeof(Rigidbody))]
    public class Player : MonoBehaviour {
        Vector3 LastPosition = Vector3.zero;
        Rigidbody Body;

        public static Player CreatePlayer(Transform Parent, Vector2 Position) {
            GameObject NewObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            NewObject.transform.parent = Parent;
            NewObject.transform.localScale = new Vector3(.5f, .5f, .5f);
            NewObject.transform.position = Parent.position + Parent.rotation *
                new Vector3(Position.x / Parent.localScale.x, Position.y / Parent.localScale.y, -.5f / Parent.localScale.z);
            NewObject.GetComponent<Renderer>().material.color = Color.black;
            Player NewPlayer = NewObject.AddComponent<Player>();
            KeyHandler Resetter = NewObject.AddComponent<KeyHandler>();
            Resetter.Key = KeyCode.R;
            Resetter.Event = new UnityEngine.Events.UnityEvent();
            Resetter.Event.AddListener(NewPlayer.RandomizePosition);
            return NewPlayer;
        }

        public void RandomizePosition() {
            Vector3 Board = transform.parent.Find("Board").localScale * .5f;
            transform.localPosition = new Vector3(Random.Range(-Board.x, Board.x), Random.Range(-Board.y, Board.y), transform.localPosition.z);
        }

        void Start() {
            Body = GetComponent<Rigidbody>();
            Body.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }

        void Update() {
            if (LastPosition != Vector3.zero) {
                Vector3 Delta = LastPosition - transform.position;
                Body.AddForce(-Delta);
            }
            LastPosition = transform.position;
        }
    }
}