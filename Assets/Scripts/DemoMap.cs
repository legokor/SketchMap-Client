using UnityEngine;

namespace SketchMap {
    public class DemoMap : MonoBehaviour {
        void Start() {
            Transform Map = MapStats.Instance.Reload().transform;
            Wall.CreateWall(Map, new Vector2(-5, -5), new Vector2(5, -5), Color.black);
            Wall.CreateWall(Map, new Vector2(-5, 5), new Vector2(5, 5), Color.black);
            Wall.CreateWall(Map, new Vector2(5, 5), new Vector2(5, -5), Color.black);
            Wall.CreateWall(Map, new Vector2(-5, 5), new Vector2(-5, -5), Color.black);
            Wall.CreateWall(Map, new Vector2(-5, 0), new Vector2(2, -2), Color.black);
            Wall.CreateWall(Map, new Vector2(-5, 0), new Vector2(2, 2), Color.black);
            Wall.CreateWall(Map, new Vector2(-5, 2), new Vector2(2, 4), Color.black);
            Gem.CreateGem(Map, new Vector2(-2, -4), Color.red);
            Gem.CreateGem(Map, new Vector2(0, 2), Color.green);
            Gem.CreateGem(Map, new Vector2(-1, 4), Color.blue);
            Gem.CreateGem(Map, new Vector2(2, 0), Color.yellow);
        }
    }
}