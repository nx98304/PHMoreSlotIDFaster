# PHMoreSlotIDFaster v1.0

## Current Status

- Vastly speed up PH's game initialization. Vastly speed up PH's chara maker initialization.

- Benchmark (7200rpm HDD) **BEFORE** patch: 
  - start up game right after computer reboot (*cold start*): 65 to 70 seconds (not counting HoneyPot)
  - first time loading into chara maker after cold start: 90 to 95 seconds. 
  - close the game and relaunch it immediately: 10 seconds (not counting HoneyPot)
  - first time loading into chara maker after relaunch the game: 15 seconds. 
  
- Benchmark (7200rpm HDD) **AFTER** patch:
  - start up game right after computer reboot (*cold start*): **20** seconds (not counting HoneyPot)
  - first time loading into chara maker after cold start up: **12** seconds.
  - close the game and relaunch it immediately: **5** seconds (not counting HoneyPot)
  - first time loading into chara maker after relaunch the game: **5** seconds. 

### Requirements & Installation

- **BepInEx 5.x** environment needed.

- ***Your Assembly-CSharp.dlls (both main game and studio) CANNOT BE hard patched by PHMoreSlotID.exe***

- [Download & extract the package](https://github.com/nx98304/PHMoreSlotIDFaster/releases) into PH root folder. Overwrite everything. Done.

### How to Use

- One additional speed up is running **PH/PHListSeparator/PHListSeparator.exe**, so that all PH vanilla lists are separated into individual txt files. **You only have to do this once**, unless you later installed new mods that uses internal embedded lists. The extracted list files will be placed into the correct lists folder automatically, and you don't have to anything additional. They are named like `cf_top_hsad_list.txt`, which entirely rely on their own filename and filepath to match up with corresponding abdatas. **Do not confuse them with Mlist.txt**, they are slightly different in that Mlist's first line can assign the abdata at arbitrary location within `PH/abdata` folder.

## "Non-Issues"

- **It's normal** to have lowered FPS for a few seconds to possibly a couple minutes after you load into chara maker, depending on if the files that the chara maker is trying to read is in the operating system cache or not. We have no control over it -- but the point is you can start chara maker VERY QUICKLY and starting using it without waiting for a minute or more for all the thumbnails to load.

- **It's normal** when you open up clothing and accessories list menus that no thumbnails are loaded. They will gradually become loaded. 

## Known Issues

- Some thumbnails on the chara maker button toggle will not refresh after thumbnails are loaded in the background. Switching away from the tab and back usually fixes it. 

- **Running PHListSeparator may create a few big swap files that you will need to remove manually**.

## Technical Details

- Modded the existing `PHMoreSlotID.dll` and `PHMoreSlotIDPatchContainer.dll` (BepInEx version), so that they: 
  - Prioritizes `abdata/thumbnail`'s packaged dds thumbnails assetbundles folder over `abdata/thumbnail_R`, because individual PNGs are slow to load and unpack. 
  - `AssetBundleController.LoadAsset` function modified so that it determines the `AssetBundle.LoadFromFile` call, which effectively delays loading any assetbundles as late as possible. 
  - Removed the need of writing out to a temp file when loading Mlist.txts.
- The game's `AssetBundleController.OpenFromFile` no longer calls LoadFromFile, which is patched inside `PHMoreSlotIDFaster.dll`. 
- Patched `EditMode.CreateData` functions so that it doesn't load any thumbnail during initialization phase. 
  - Instead, the task of loading thumbnails will be queued and consumed in `EditMode.Update`.
  - Further create a timer to gradually update the thumbnails on the menu, if the menu happens to be opened at the moment. 

## Possible Roadmap

- Possibly no? 


