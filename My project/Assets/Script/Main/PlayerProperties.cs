using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerProperties
{
    // private static string email="";
    // private static string password="";
    private static string token = "";
    private static bool OnLogin = false;
    private static string id = ""; 
    private static string nickname = "";
    private static bool in_room = false;
    private static int roomid = -1;
    private static int kill = 0;
    private static int death = 0;
    private static int score = 0;
    private static int win = 0;
    private static int lose = 0;



    //  public static string email_  {   get   {   return email;   }    set    {  email = value;  }  }
    //  public static string password_  {   get   {   return password;   }    set    {  password = value;  }  }

    public static string token_ { get { return token; } set { token = value; } }
    public static bool OnLogin_ { get { return OnLogin; } set { OnLogin = value; } }
    public static string id_ { get { return id; } set { id = value; } } 

    public static string nickname_ { get { return nickname; } set { nickname = value; } }
    public static int kill_ { get { return kill; } set { kill = value; } }
    public static int death_ { get { return death; } set { death = value; } }
    public static int score_ { get { return score; } set { score = value; } }
    public static bool in_room_ { get { return in_room; } set { in_room = value; } }
    public static int roomid_ { get { return roomid; } set { roomid = value; } }
    public static int win_ { get { return win; } set { win = value; } }
    public static int lose_ { get { return lose; } set { lose = value; } }

}