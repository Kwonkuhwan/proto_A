﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using static UIManager;
using static NetworkManager;

public class InteractionScript : MonoBehaviourPun
{
    public static InteractionScript IS;
    public enum Type { Customize, Mission, Item, Altar_Red, Altar_Green, Altar_Blue };
    public Type type;

    MinigameManager MM;
    // public static Item go;

    GameObject Line;
    public int curInteractionNum;

    public bool isAltarBox;
   

    void Start()
    {
        //	Line = transform.GetChild(0).gameObject;
        MM = GetComponent<MinigameManager>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.GetComponent<PhotonView>().IsMine)
        {
            if (type == Type.Customize)
            {
                //Line.SetActive(true);
                UM.SetInteractionBtn0(1, true);
            }

            else if (type == Type.Mission)
            {
                UM.curInteractionNum = curInteractionNum;
                //Line.SetActive(true);
                UM.SetInteractionBtn0(0, true);
            }

            //아이템 획득
            else if (type == Type.Item)
            {
                UM.SetInteractionBtn0(6, true);
            }

            else if (type == Type.Altar_Red)
            {
                UM.isRed = true;
                UM.curInteractionNum = curInteractionNum;
                UM.SetInteractionBtn0(2, true);
            }
            else if (type == Type.Altar_Green)
            {
                UM.isGreen = true;
                UM.curInteractionNum = curInteractionNum;
                UM.SetInteractionBtn0(3, true);
            }
            else if (type == Type.Altar_Blue)
            {
                UM.isBlue = true;
                UM.curInteractionNum = curInteractionNum;
                UM.SetInteractionBtn0(4, true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.GetComponent<PhotonView>().IsMine)
        {
            if (type == Type.Customize)
            {
                //Line.SetActive(false);
                UM.SetInteractionBtn0(0, false);
            }

            else if (type == Type.Mission)
            {
                //Line.SetActive(false);
                UM.SetInteractionBtn0(0, false);
            }

            //아이템 획득 Off
            else if (type == Type.Item)
            {
                UM.SetInteractionBtn0(6, false);
            }

            else if (type == Type.Altar_Red)
            {
                UM.isRed = false;
                UM.SetInteractionBtn0(2, false);
            }
            else if (type == Type.Altar_Green)
            {
                UM.isGreen = false;
                UM.SetInteractionBtn0(3, false);
            }
            else if (type == Type.Altar_Blue)
            {
                UM.isBlue = false;
                UM.SetInteractionBtn0(4, false);
            }
        }
    }

    public void StartMission()
    {
        throw new System.NotImplementedException();
    }

    public void CancelMission()
    {
        throw new System.NotImplementedException();
    }

    public void CompleteMission()
    {
        throw new System.NotImplementedException();
    }
}
