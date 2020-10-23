using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManagerBehavior : MonoBehaviour
{
	private Queue<GameObject> m_tile_pool;

	public int MAX_TILES = 10000;

	private void _BuildTilePool()
	{
		for (int c = 0; c < MAX_TILES; c++)
		{
			GameObject new_tile = TileFactory.Instance().CreateTile();

			new_tile.SetActive(false);

			m_tile_pool.Enqueue(new_tile);
		}
	}

	public GameObject GetTile()
	{
		if (m_tile_pool.Count > 0)
		{
			GameObject tmp = m_tile_pool.Dequeue();
			tmp.SetActive(true);

			return tmp;
		}
		else
			return null;
	}

	public void ReturnTile(GameObject tile)
	{
		tile.SetActive(false);
		m_tile_pool.Enqueue(tile);
	}

	public bool isEmpty()
	{
		return (m_tile_pool.Count == 0);
	}

	private void Awake()
	{
		m_tile_pool = new Queue<GameObject>();
		_BuildTilePool();
	}
}
