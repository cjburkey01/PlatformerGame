using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour {
	
	public Texture2D textureMap;
	public Tile[] tiles;

	public void Awake() {
		LoadImage();
	}

	private void LoadImage() {
		int width = textureMap.width;
		int height = textureMap.height;

		Color32[] colors = textureMap.GetPixels32();

		for(int i = 0; i < colors.Length; i ++) {
			Color32 colorAt = colors[i];
			int x = i % width;
			int y = Mathf.FloorToInt((float) i / (float) width);
			Tile tile = getTile(colorAt);
			if(tile != null) {
				Vector3 pos = new Vector3(x, y - (width - 1), 0.0f);
				if(!tile.player) {
					Instantiate(tile.obj, pos, Quaternion.identity);
				} else {
					tile.obj.transform.position = pos;
				}
			}
		}

		/*for(int x = 0; x < width; x ++) {
			for(int y = 0; y < height; y ++) {
				Color color = textureMap.GetPixel(x, y);
				Tile tile = getTile(color);
				if(tile != null) {
					Vector3 pos = new Vector3(x, y - (width - 1), 0.0f);
					if(!tile.player) {
						Instantiate(tile.obj, pos, Quaternion.identity);
					} else {
						tile.obj.transform.position = pos;
					}
				}
			}
		}*/
	}

	private Tile getTile(Color32 color) {
		foreach(Tile tile in tiles) {
			if(tile.color.r == color.r && tile.color.g == color.g && tile.color.b == color.b && tile.color.a == color.a) {
				return tile;
			}
		}
		return null;
	}

	[System.Serializable]
	public class Tile {

		public Color32 color;
		public GameObject obj;
		public bool player;

	}

}