using UnityEngine;
using UnityEngine.UI;

namespace SketchMap {
    public class MapStats : MonoBehaviour {
        public GameObject Table;
        public GameObject Gem;
        public Text GemCount;

        static Text _GemCount;
        static int _RemainingGems;

        static GameObject GameTable;
        static Player ActivePlayer;

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
            return GameTable;
        }
    }
}