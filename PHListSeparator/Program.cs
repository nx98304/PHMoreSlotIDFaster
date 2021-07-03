using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using Microsoft.CSharp.RuntimeBinder;
using UnityPlugin;

namespace PHListSeparator
{
	// Token: 0x02000002 RID: 2
	internal class Program
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002090 File Offset: 0x00000290
		private static void Main(string[] args)
		{
            Console.WriteLine("Hello World!"+exePath);
            string target_PH_rootpath = LocatePHRoot(exePath);
            string data_path = target_PH_rootpath + "/abdata";

            FindAllLists(data_path);
		}

        private static void FindAllLists(string data_path)
        {
            SearchForList(data_path, "custommaterial/cf_m_face_*");
            SearchForList(data_path, "custommaterial/cm_m_face_*");
            SearchForList(data_path, "customtexture/cf_t_detail_f_*");
            SearchForList(data_path, "customtexture/cm_t_detail_f_*");
            SearchForList(data_path, "custommaterial/cf_m_eyebrow_*");
            SearchForList(data_path, "custommaterial/cm_m_eyebrow_*");
            SearchForList(data_path, "custommaterial/cf_m_eyelashes_*");
            SearchForList(data_path, "custommaterial/cf_m_eye_*");
            SearchForList(data_path, "custommaterial/cm_m_eye_*");
            SearchForList(data_path, "custommaterial/cf_m_eyehi_*");
            SearchForList(data_path, "custommaterial/cm_m_beard_*");
            SearchForList(data_path, "customtexture/cf_t_tattoo_f_*");
            SearchForList(data_path, "customtexture/cm_t_tattoo_f_*");
            SearchForList(data_path, "customtexture/cf_t_cheek_*");
            SearchForList(data_path, "customtexture/cf_t_eyeshadow_*");
            SearchForList(data_path, "customtexture/cf_t_lip_*");
            SearchForList(data_path, "customtexture/cf_t_mole_*");
            SearchForList(data_path, "custommaterial/cf_m_body_*");
            SearchForList(data_path, "custommaterial/cm_m_body_*");
            SearchForList(data_path, "customtexture/cm_t_detail_b_*");
            SearchForList(data_path, "customtexture/cm_t_detail_b_*");
            SearchForList(data_path, "custommaterial/cf_m_nip_*");
            SearchForList(data_path, "custommaterial/cf_m_underhair_*");
            SearchForList(data_path, "customtexture/cf_t_sunburn_*");
            SearchForList(data_path, "customtexture/cm_t_sunburn_*");
            SearchForList(data_path, "customtexture/cf_t_tattoo_b_*");
            SearchForList(data_path, "customtexture/cm_t_tattoo_b_*");
            SearchForList(data_path, "hair/cf_hair_b*");
            SearchForList(data_path, "hair/cf_hair_f*");
            SearchForList(data_path, "hair/cf_hair_s*");
            SearchForList(data_path, "hair/cm_hair_*");
            string[] array3 = new string[]
            {
                "wear/cf_top_*",
                "wear/cf_bot_*",
                "wear/cf_bra_*",
                "wear/cf_shorts_*",
                "wear/cf_swim_*",
                "wear/cf_swimtop_*",
                "wear/cf_swimbot_*",
                "wear/cf_gloves_*",
                "wear/cf_panst_*",
                "wear/cf_socks_*",
                "wear/cf_shoes_*"
            };
            for (int j = 0; j < array3.Length; j++)
            {
                SearchForList(data_path, array3[j]);
            }
            string[] array4 = new string[]
            {
                "wear/cm_body_*",
                "wear/cm_shoes_*"
            };
            for (int k = 0; k < array4.Length; k++)
            {
                SearchForList(data_path, array4[k]);
            }
            string[] array5 = new string[]
            {
                "accessory/ca_head_*",
                "accessory/ca_ear_*",
                "accessory/ca_megane_*",
                "accessory/ca_face_*",
                "accessory/ca_neck_*",
                "accessory/ca_shoulder_*",
                "accessory/ca_breast_*",
                "accessory/ca_waist_*",
                "accessory/ca_back_*",
                "accessory/ca_arm_*",
                "accessory/ca_hand_*",
                "accessory/ca_leg_*"
            };
            for (int l = 0; l < array5.Length; l++)
            {
                SearchForList(data_path, array5[l]);
            }
            string[] array6 = new string[]
            {
                "ca_head_ph00",
                "ca_ear_ph00",
                "ca_megane_ph00",
                "ca_face_ph00",
                "ca_neck_ph00",
                "ca_shoulder_ph00",
                "ca_breast_ph00",
                "ca_waist_ph00",
                "ca_back_ph00",
                "ca_arm_ph00",
                "ca_hand_ph00",
                "ca_leg_ph00"
            };
            for (int m = 0; m < array6.Length; m++)
            {
                SearchForList(data_path, array6[m]);
            }
            SearchForList(data_path, "wearliquid/cf_liquid*");
        }

        private static string LocatePHRoot(string exePath)
        {
            string target_PH_rootpath = exePath;
            while (File.Exists(target_PH_rootpath + "\\PlayHome.ico") != true && target_PH_rootpath.Length > 3)
            {
                target_PH_rootpath = target_PH_rootpath.Remove(target_PH_rootpath.LastIndexOf('\\'));
            }
            if (target_PH_rootpath.Length <= 3)
            {
                Console.WriteLine("Error: PH root folder not found.");
                return "";
            }
            else
            {
                Console.WriteLine("PH root target: " + target_PH_rootpath);
                return target_PH_rootpath;
            }
        }

        public static void SearchForList(string abdata_path, string search_pattern)
        {
            string subfolder_path = string.Empty;
            int num = search_pattern.LastIndexOf("/");
            if (num != -1)
            {
                subfolder_path = search_pattern.Substring(0, num);
                search_pattern = search_pattern.Remove(0, num + 1);
            }
            string[] files = Directory.GetFiles(abdata_path + "/" + subfolder_path, search_pattern, SearchOption.TopDirectoryOnly);
            Array.Sort<string>(files);
            foreach (string path in files)
            {
                if (Path.GetExtension(path).Length == 0)
                {
                    string bundle_name = Path.GetFileNameWithoutExtension(path);
                    string subfolder_path_plus_bundle_name = String.Empty; 
                    if (subfolder_path.Length > 0)
                    {
                        subfolder_path_plus_bundle_name = subfolder_path + "/" + bundle_name;
                    }
                    if (File.Exists(abdata_path + "/" + subfolder_path_plus_bundle_name))
                    {
                        ProcessingList(abdata_path, subfolder_path_plus_bundle_name, bundle_name);
                    }
                }
            }
        }

        private static void ProcessingList(string bundle_path, string subfolder_path_plus_bundle_name, string bundle_name)
        {
            string list_path = bundle_path + "/list/" + subfolder_path_plus_bundle_name + "_list.txt";
            if (File.Exists(list_path))
            {
                Console.WriteLine("Standalone list file already exists, skipping: " + bundle_name);
                return;
            }
            UnityParser unityParser = new UnityParser(bundle_path + "/" + subfolder_path_plus_bundle_name);
            if ( unityParser == null )
            {
                Console.WriteLine("Failed to open abdata: " + bundle_name);
                return;
            }
            int count = unityParser.Cabinet.Components.Count;
            bool found = false;
            for (int i = 0; i < count; i++)
            {
                switch (unityParser.Cabinet.Components[i].classID())
                {
                    case UnityClassID.TextAsset:
                        TextAsset ta = unityParser.Cabinet.LoadComponent(unityParser.Cabinet.Components[i].pathID);
                        if( ta.m_Name == bundle_name + "_list" )
                        {
                            found = true;
                            Console.WriteLine("list TextAsset found, processing: " + bundle_name);
                            StreamWriter writer = new StreamWriter(list_path, false, Encoding.GetEncoding("UTF-8"));
                            writer.WriteLine(ta.m_Script);
                            writer.Close();
                        }
                        break;
                }
                if (found) break;
            }
            if (!found)
            {
                Console.WriteLine("list TextAsset not found, ignored: " + bundle_name);
            }
        }

		private static string exePath = AppDomain.CurrentDomain.BaseDirectory;
    }
}
