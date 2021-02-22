# MuseDashModManager  
  
这个项目源自[Lyt99/MuseDashModManager](https://github.com/Lyt99/MuseDashModManager)，适用版本为Muse Dash pc v2021.02.07  
操作步骤详见原项目地址  
  
文件夹 **MuseDashModManager** 是原文件的修改，也是这个项目的源码  
文件夹 **custom_assets** 和 **custom_maps** 分别是资源文件夹和地图文件夹，具体用法请看代码或自行摸索  
文件夹 **demo** 是文件夹包含关系示例  
  
请自行补充缺失的音频，现在只支持wav格式（使用NAudio加载）
  
## 制作bms提示：  
* 自定义bms文件的 \#WAVxx 标识含义可从 **notedata.bms** 得到  
* 键位提示  
  * A4\(14\)：空中  
  * A5\(15\)：地面  
  * A6\(16\)：特效（算作地面）  
  
## 制作bms注意事项
1. bms文件头的 **\#GENRE** 要填场景名称（例 `scene_01` ），不填会报错
2. Muse Dash 的 **过关时间** 是歌曲时长，但 **Full Combo** 在bms的所有note结束后就会判定并出现。请适当裁剪音频过长的部分  
  
  
## 已知问题：  
 * 游玩自定义谱面过程中点重新开始会报错  
 * 第一次游玩自定义谱面后所属的音乐包会改变  
