using System;
using System.Collections.Generic;

namespace MOTHER3
{
    public class M3CC
    {
        public static int Entries = 35;
        public static CC[] cc = new CC[Entries];
        public static Dictionary<int, CC> CCLookup = new Dictionary<int, CC>();

        public static void Init()
        {
            for (int i = 0; i < Entries; i++)
            {
                cc[i] = new CC();
            }

            cc[0].value = 0xffff;
            cc[0].args = 0;
            cc[0].description = "Ends the text block";
            cc[0].tag = "end";

            cc[1].value = 0xff01;
            cc[1].args = 0;
            cc[1].description = "Line break";
            cc[1].tag = "break";

            cc[2].value = 0xff02;
            cc[2].args = 0;
            cc[2].description = "End choice selection";
            cc[2].tag = "endchoices";

            cc[3].value = 0xff03;
            cc[3].args = 1;
            cc[3].description = "Wait for player; XXXX is always 0xFF00";
            cc[3].tag = "wait";

            cc[4].value = 0xff04;
            cc[4].args = 1;
            cc[4].description = "Pause for XXXX frames";
            cc[4].tag = "pause";

            cc[5].value = 0xff05;
            cc[5].args = 1;
            cc[5].description = "Change text color; for XXXX, 0=normal, 3=blue";
            cc[5].tag = "color";

            cc[6].value = 0xff06;
            cc[6].args = 1;
            cc[6].description = "Begin choice menu of XXXX choices";
            cc[6].tag = "menu";

            cc[7].value = 0xff07;
            cc[7].args = 0;
            cc[7].description = "Event";
            cc[7].tag = "event";

            cc[8].value = 0xff08;
            cc[8].args = 1;
            cc[8].description = "Play sound XX";
            cc[8].tag = "sound";

            cc[9].value = 0xff0b;
            cc[9].args = 0;
            cc[9].description = "Alternate font between normal and Mr. Saturn";
            cc[9].tag = "alternatefont";

            cc[10].value = 0xff0c;
            cc[10].args = 1;
            cc[10].description = "Unknown";

            cc[11].value = 0xff21;
            cc[11].args = 1;
            cc[11].description = "Display name of item XXXX";
            cc[11].tag = "item";

            cc[12].value = 0xff22;
            cc[12].args = 1;
            cc[12].description = "Display character name XXXX";

            cc[13].value = 0xff23;
            cc[13].args = 1;
            cc[13].description = "Display character name XXXX";

            cc[14].value = 0xff24;
            cc[14].args = 1;
            cc[14].description = "Enemy name";
            cc[14].tag = "enemyname";

            cc[15].value = 0xff25;
            cc[15].args = 1;
            cc[15].description = "Unknown";

            cc[16].value = 0xff26;
            cc[16].args = 2;
            cc[16].description = "Display character name XXXX with YYYY amount of succeeding dashes";
            cc[16].tag = "ー";

            cc[17].value = 0xff42;
            cc[17].args = 1;
            cc[17].description = "Unknown";

            cc[18].value = 0xff45;
            cc[18].args = 0;
            cc[18].description = "Favorite Food";
            cc[18].tag = "favfood";

            cc[19].value = 0xff46;
            cc[19].args = 0;
            cc[19].description = "Favorite Thing";
            cc[19].tag = "favthing";

            cc[20].value = 0xff47;
            cc[20].args = 0;
            cc[20].description = "Player name";
            cc[20].tag = "playername";

            cc[21].value = 0xff48;
            cc[21].args = 0;
            cc[21].description = "Factory name";
            cc[21].tag = "factoryname";

            cc[22].value = 0xff80;
            cc[22].args = 1;
            cc[22].description = "Unknown";

            cc[23].value = 0xff81;
            cc[23].args = 0;// 1
            cc[23].description = "Unknown";

            cc[24].value = 0xff0a;
            cc[24].args = 0;
            cc[24].description = "Center (H)";
            cc[24].tag = "center";

            cc[25].value = 0xff09;
            cc[25].args = 0;
            cc[25].description = "Center (H + V)";

            cc[26].value = 0xff83;
            cc[26].args = 0;
            cc[26].description = "Unknown";

            cc[27].value = 0xff82;
            cc[27].args = 0;
            cc[27].description = "Amount";

            cc[28].value = 0xff84;
            cc[28].args = 0;
            cc[28].description = "Unknown";

            cc[29].value = 0xffe1;
            cc[29].args = 1;
            cc[29].description = "Display XXXX status icon";
            cc[29].tag = "icon";

            cc[30].value = 0xffa0;
            cc[30].args = 0;
            cc[30].description = "Unknown";

            cc[31].value = 0xffa1;
            cc[31].args = 0;
            cc[31].description = "Unknown";

            cc[32].value = 0xffa2;
            cc[32].args = 0;
            cc[32].description = "Unknown";

            cc[33].value = 0xffa3;
            cc[33].args = 0;
            cc[33].description = "Unknown";

            cc[34].value = 0xff44;
            cc[34].args = 0;
            cc[34].description = "Unknown";

            CCLookup.Clear();
            for (int i = 0; i < Entries; i++)
                CCLookup.Add(cc[i].value, cc[i]);
        }
    }

    public class CC
    {
        public int value = 0;
        public String description = "";
        public int args = 0;
        public string tag = "";
    }
}
