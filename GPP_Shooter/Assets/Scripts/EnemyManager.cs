using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SubclassSandbox;

namespace Managers {

    public class EnemyManager
    {
        private int wavNum;
      
        private List<Enemy> enemies = new List<Enemy>();
        public List<Enemy> flaggedForDeletion = new List<Enemy>();

        Vector2 widthRange = new Vector2(-15, 15);
        Vector2 heightRange = new Vector2(-8, 8);

        public void Init(){
            CreateWave();
            
        }
        public void EnemyUpdate(){

            if (enemies.Count == 0){
                CreateWave();
                wavNum++;
            }

            foreach (Enemy e in enemies){
                if (e.health <= 0){
                    flaggedForDeletion.Add(e);
                    enemies.Remove(e);
                }
            }
        }


        public void RemoveDestroyed()
        {
            if (flaggedForDeletion.Count > 0){
                for (int i = 0; i < flaggedForDeletion.Count; ++i){

                    //Destroy(flaggedForDeletion[i].gameObject);
                }
            }
        }


       void SpawnEnemy<T>(Vector3 pos, string name) where T : Enemy {
            
            string path = "Meshs/" + name;
            GameObject eneGO = new GameObject("Enemy" + enemies.Count.ToString());

            eneGO.AddComponent<MeshFilter>();
            eneGO.AddComponent<MeshRenderer>();
            eneGO.AddComponent<T>();

            eneGO.transform.position = pos;

            eneGO.GetComponent<MeshFilter>().mesh = (Mesh)Resources.Load(path, typeof(Mesh));
            eneGO.GetComponent<MeshRenderer>().material = (Material)Resources.Load(path, typeof(Material));

            enemies.Add(eneGO.GetComponent<T>());
        }

        void CreateWave(){

            for (int i = 0; i < wavNum + 1; ++i){
                float hor = Random.Range (widthRange.x, widthRange.y);
                Vector3 wallFlowerPos = new Vector3 (hor, 0, heightRange.y * (hor / Mathf.Abs (hor))); 
                SpawnEnemy<Wallflower>(wallFlowerPos, "Wallflower");
            }

            for (int j = 0; j < wavNum + 3; ++j){
                Vector3 stalkerPos = new Vector3 (Random.Range (widthRange.x, widthRange.y), 0, Random.Range (heightRange.x, heightRange.y)); 
                SpawnEnemy<Stalker>(stalkerPos, "Stalker");
            }
        }
    }
}
