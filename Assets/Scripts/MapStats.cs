using UnityEngine;
using UnityEngine.UI;

using LeapVR;

namespace SketchMap {
    public class MapStats : MonoBehaviour {
        public GameObject Table;
        public GameObject Gem;
        public Text GemCount;
        public KeyCode MoveKey = KeyCode.F1;
        public Toggle Move;
        public KeyCode RotateKey = KeyCode.F2;
        public Toggle Rotate;
        public KeyCode ScaleKey = KeyCode.F3;
        public Toggle Scale;

        static Text _GemCount;
        static int _RemainingGems;

        static GameObject GameTable;
        static Player ActivePlayer;
        static ObjectTransformer Transformer;

        public static int RemainingGems {
            get {
                return _RemainingGems;
            }
            set {
                _RemainingGems = value;
                if (_GemCount)
                    _GemCount.text = value.ToString();
            }
        }

        public static MapStats Instance { get; private set; }

        void Awake() {
            Instance = this;
            _GemCount = GemCount;
        }

        public void RandomizePlayerPos() {
            if (ActivePlayer)
                ActivePlayer.RandomizePosition();
        }

        public void ResetBoardTransform() {
            if (GameTable) {
                GameTable.transform.position = Table.transform.position;
                GameTable.transform.rotation = Table.transform.rotation;
                GameTable.transform.localScale = Table.transform.localScale;
            }
        }

        public GameObject Reload() {
            if (GameTable)
                Destroy(GameTable);
            RemainingGems = 0;
            GameTable = Instantiate(Table);
            ActivePlayer = Player.CreatePlayer(GameTable.transform, new Vector2(0, 0));
            Transformer = GameTable.GetComponent<ObjectTransformer>();
            Move.isOn = Transformer.EnableMovement;
            Rotate.isOn = Transformer.EnableRotation;
            Scale.isOn = Transformer.EnableScaling;
            return GameTable;
        }

        void Update() {
            if (!Transformer)
                return;
            if (Input.GetKeyDown(MoveKey))
                ToggleMove(!Transformer.EnableMovement);
            if (Input.GetKeyDown(RotateKey))
                ToggleRotation(!Transformer.EnableRotation);
            if (Input.GetKeyDown(ScaleKey))
                ToggleScale(!Transformer.EnableScaling);
        }

        public void ToggleMove(bool IsOn) {
            Move.isOn = Transformer.EnableMovement = IsOn;
        }

        public void ToggleRotation(bool IsOn) {
            Rotate.isOn = Transformer.EnableRotation = IsOn;
        }

        public void ToggleScale(bool IsOn) {
            Scale.isOn = Transformer.EnableScaling = IsOn;
        }
    }
}