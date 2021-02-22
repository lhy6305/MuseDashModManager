using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;
using Assets.Scripts.PeroTools.Commons;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Assets.Scripts.GameCore;
using GameLogic;

namespace MuseDashModManager
{
	public class EntryPoint
	{

		private static bool hasInited = false;
		//system prewarm exec code
		public static void InitManager()
		{
			if (hasInited) return;

			MuseDashModManager.CustomMaps.Util.Init();
			// 安装 Patch
			MuseDashModManager.Patch.InstallPatches();
			hasInited = true;
		}

		public static object LoadCustomAssetProxy(string name)
		{
			if(name == null) {
				return null;
			}

			if(MuseDashModManager.Global.CustomAssetsList.ContainsKey(name))
			{
				return MuseDashModManager.Global.CustomAssetsList[name];
			}

			if(MuseDashModManager.Global.CustomAssetsListEx.ContainsKey(name))
			{
				return MuseDashModManager.Global.CustomAssetsListEx[name]();
			}

			//return null to let LoadStageInfo() load.
			if(name.EndsWith(".json1")){
				return null;
			}else if(name.EndsWith(".json2")){
				return null;
			}else if(name.EndsWith(".json3")){
				return null;
			}
			string name1 = name;

			if(name1.EndsWith(".json")){
				//Console.WriteLine("[MuseDashModManager]Asset " + MuseDashModManager.CustomMaps.Global.AssetsDirectory + "/" + name1 + " should be loaded with LoadJson().");
				return null;
			}
			if(name1.EndsWith(".png")){
				if(File.Exists(MuseDashModManager.CustomMaps.Global.AssetsDirectory + "/" + name1)){
					//Console.WriteLine("[MuseDashModManager]Asset " + MuseDashModManager.CustomMaps.Global.AssetsDirectory + "/" + name1 + " loaded as Spirte successfully.");
					return MuseDashModManager.Util.LoadSpirteFromFile(MuseDashModManager.CustomMaps.Global.AssetsDirectory + "/" + name1, 440, 440);
				}
			}
			if(name.EndsWith("_music")){
				name1 = name + ".wav";
			}
			if(name1.EndsWith(".wav")){
				//Console.WriteLine("[MuseDashModManager-ac]Asset " + MuseDashModManager.CustomMaps.Global.AssetsDirectory + "/" + name1 + " is loading as AudioClip.");
				if(File.Exists(MuseDashModManager.CustomMaps.Global.AssetsDirectory + "/" + name1)){
					//Console.WriteLine("[MuseDashModManager]Asset " + MuseDashModManager.CustomMaps.Global.AssetsDirectory + "/" + name1 + " loaded as AudioClip successfully.");
					return MuseDashModManager.Util.LoadAudioClipFromFile(MuseDashModManager.CustomMaps.Global.AssetsDirectory + "/" + name1);
				}
			}

			Console.WriteLine("[MuseDashModManager]Asset " + MuseDashModManager.CustomMaps.Global.AssetsDirectory + "/" + name1 + " is not found.");
			throw new System.IO.IOException();

		}

		public static JArray LoadJson(string name)
		{
			string name1 = name;
			if(!name.EndsWith(".json")){
				name1 = name + ".json";
			}
			byte[] binary = MuseDashModManager.Util.LoadBinaryFromFile(MuseDashModManager.CustomMaps.Global.AssetsDirectory + "/" + name1);
			string str = System.Text.Encoding.ASCII.GetString(binary);
			if (str.Length != 0){
				JArray json = Assets.Scripts.PeroTools.Commons.JsonUtils.ToArray(str);
				//Console.WriteLine("[MuseDashModManager]Asset " + MuseDashModManager.CustomMaps.Global.AssetsDirectory + "/" + name1 + " loaded as JSON successfully.");
				return json;	
			}
			Console.WriteLine("[MuseDashModManager]Asset " + MuseDashModManager.CustomMaps.Global.MapDirectory + "/" + name1 + " is not found.");
			throw new System.IO.IOException();
		}

		public static StageInfo LoadStageInfo(string name)
		{
			string name1=name;
			if(name.EndsWith(".json1")){
				name1=name.BeginBefore('.') + "1";
			}else if(name.EndsWith(".json2")){
				name1=name.BeginBefore('.') + "2";
			}else if(name.EndsWith(".json3")){
				name1=name.BeginBefore('.') + "3";
			}
			//Console.WriteLine("[MuseDashModManager]Asset " + MuseDashModManager.CustomMaps.Global.AssetsDirectory + "/" + name1 + " loaded as StageInfo successfully.");
			return MuseDashModManager.CustomMaps.Util.LoadAndCreateStageInfo(name1).StageInfo;
		}
	}
}
