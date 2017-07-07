using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public int[] columns = new int[6];

    void Start () {
		
	}

    public void inColumn(float x)
    {
        SpawningBricks SBscript = GameObject.Find("GameController").GetComponent<SpawningBricks>();
        float i = (x - SBscript.leftEdge) / SBscript.sizeofBrick - 0.5f;
        int j = (int)i;
        columns[j]++;
        if (columns[j] == 10)
            SceneManager.LoadScene("Test");
        Debug.Log("Kolumna nr " + j + " ma juz " + columns[j]);
        bool flag = true;
        for (j = 0; j < 6; j++)
        {
            if (columns[j] == 0)
                flag = false;
        }
        if (flag)
        {
            completeRow();
            for (j = 0; j < 6; j++)
                columns[j]--;
        }
    }
    void completeRow()
    {
        SpawningBricks SBscript = GameObject.Find("GameController").GetComponent<SpawningBricks>();
        GameObject[] tab = GameObject.FindGameObjectsWithTag("Brick");
        for (int i = 0; i < tab.Length; i++)
        {
            if (tab[i].transform.position.y == SBscript.bottomY + 0.5f * SBscript.sizeofBrick)
                Destroy(tab[i]);
            else
                tab[i].transform.position -= new Vector3(0,SBscript.sizeofBrick);
        }
    }
}
