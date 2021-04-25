
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ChangeTheGun : MonoBehaviour
    {
        public GameObject[] weapons;
        private List<GameObject> alweapons=new List<GameObject>();
        private int i;
        // Start is called before the first frame update
        void Start()
        {
            i = 0;
            for(int j = 0; j < weapons.Length; j++)
            {
                GameObject wea = Instantiate(weapons[j], transform.position, transform.rotation);
                alweapons.Add(wea);
            }
            Cutgun(i);
        }
    
        // Update is called once per frame
        void Update()
        {
            if(Input.GetAxis("Mouse ScrollWheel") > 0)
            {
                i++;
                if (i > alweapons.Count-1)
                {
                    i = 0;
                }
                Cutgun(i);
            }
            else if(Input.GetAxis("Mouse ScrollWheel") < 0)
            {
                i--;
                if (i <0)
                {
                    i = alweapons.Count-1;
                }
                Cutgun(i);
            }
        }
        private void Cutgun(int num)
        {
            foreach (GameObject s in alweapons)
            {
                s.SetActive(false);
            }

            for (int k = 0; k < weapons.Length; k++)
            {
                if (k != num)
                {
                    /*alweapons[num].GetComponent<Transform>().position = alweapons[k].GetComponent<Transform>().position;
                    alweapons[num].GetComponent<Transform>().rotation = alweapons[k].GetComponent<Transform>().rotation;*/
                }
            }

            alweapons[num].SetActive(true);
        }
    }