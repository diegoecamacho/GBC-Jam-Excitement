using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GBCJam.PlayerInput
{

    public struct TouchPos
    {
        public Vector2 beginPos;
        public Vector2 endPos;
        public Vector2 Dir;
        public float magnitude;

        public TouchPos(int a)
        {
            beginPos = Vector2.zero;
            endPos = Vector2.zero;
            Dir = Vector2.zero;
            magnitude = 0.0f;
        }

        public TouchPos(Vector2 _beginPos)
        {
            beginPos = _beginPos;
            endPos = Vector2.zero;
            Dir = Vector2.zero;
            magnitude = 0.0f;

        }



        public void SetEndPos(Vector2 pos)
        {
            endPos = pos;

        }

        public Vector2 CalcDir()
        {
            Vector2 dir = endPos - beginPos;
            magnitude = dir.magnitude;
            return dir.normalized;
        }

        public float GetDirMag()
        {
            return magnitude;
        }
    }

    public class TouchHandle : MonoBehaviour
    {
        [SerializeField] LayerMask layerMask;

        Vector2 beginPos;
        Vector2 endPos;
        Vector2 Dir;

        List<Touch> Activetouches;
        TouchPos[] Pos = new TouchPos[10];

        // Update is called once per frame
        void Update()
        {
            //if (Input.touchCount <= 0)
            //{
            //    Debug.Log("NO TOUCHES");
            //}
            RaycastHit hit = new RaycastHit();

            for (int i = 0; i < Input.touchCount; i++) {
                Touch currTouch = Input.GetTouch(i);
                
                if (currTouch.phase == TouchPhase.Began)
                {
                    Debug.Log("BeginTouch");
                    Ray ray = Camera.main.ScreenPointToRay(currTouch.position);
                    
                    if (Physics.Raycast(ray, out hit, layerMask))
                    {
                        //Activetouches.Add(currTouch);
                        TouchPos pos = new TouchPos(currTouch.position);
                        Pos[i] = pos;
                    }
                }
                if (currTouch.phase == TouchPhase.Ended)
                {
                    Debug.Log("UnityTouchEnded");
                    Pos[i].SetEndPos(currTouch.position);

                    hit.collider.GetComponent<ColorBlockScript>().ThrowCube(Pos[i].CalcDir(), Pos[i].GetDirMag());
                }
            }

            if (Input.touchCount != 0)
            {
                for (int i = 0; i < Input.touchCount; i++)
                {
                    Debug.Log("TouchPos" + i + " Begin" + i+ Pos[i].beginPos + "End " + Pos[i].endPos);

                }
            }
            
        }
    }
}

        //    Ray ray = Camera.main.ScreenPointToRay(touch.position);
        //    if (Physics.Raycast(ray, layerMask))
        //    {
        //        beginPos = touch.position;
        //        cubeTouch = true;
        //        Debug.Log("UnityBeginTouch :" + beginPos);
        //    }
        //}
        //        if (touch.phase == TouchPhase.Stationary ||touch.phase == TouchPhase.Moved)
        //        {
        //            Debug.Log("Screen Touch : " + true);
        //        }
        //        if (touch.phase == TouchPhase.Ended)
        //        {
        //            if (cubeTouch == true)
        //            {
        //                endPos = touch.position;
        //                Dir = endPos - beginPos;
        //                Debug.Log("UnityTouchPosDir : " + Dir.normalized);
        //                cubeTouch = false;
        //            }
                   
        //        }
        //    }
        //}
