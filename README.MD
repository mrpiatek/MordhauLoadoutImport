# MordhauLoadoutImport
> Easily share your Mordhau Loadouts.

## Warning
This is experimental software and is most likely to contain bugs. The program backs up your _Game.ini_ file at startup to _Game.backup.ini_ (only if no backup file is present). If 
anything goes wrong you can restore the backup. The files are at _%LocalAppData%\Mordhau\Saved\Config\WindowsClient_. Also armor names were scraped manually therefore
may not display proper armor names for imported loadouts so purchase them cautiously. If you encounter any issue or improper armor names please report it.

**Author of this software does not take responsibility for damaged Game.ini file nor for wrong hints on loadout armor leading to bad purchases**

## Usage
### Importing Loadouts

1. Click on _Import_ button; import dialog should appear,
2. Paste loadout code into the text box (it will also accept plain text loadout),
3. Choose name for the new loadout,
4. Click _Import_ button.
5. Once you run the game, steam may show cloud sync conflict. **Do not** download files from the cloud as this will revert all the changes.

> Once valid loadout is pasted you can see *Armor* section that will hint what armor pieces are required for this loadout. The game will strip
any cosmetics/weapons you do not own from the loadout when you try to edit it or use it ingame (it will be showing all cosmetics at mercenary preview in the menu though)
Currenly only Head, Torso and Legs wearables hints are supported.
You will need to work out rest of the cosmetics on your own for now.

### Exporting Loadouts

1. Click on the loadout you wish to export,
2. Click on _Export_ button (alternatively double click the loadout); export dialog should appear,
3. Copy the code from the text box and share it.

> *Note on export formats*: by default exported loadouts will be encoded and it is recommended way of sharing your loadouts. However in order to import such loadout a person who
you are sharing with also needs to have this program installed. If they wish to install the loadout manually using notepad you may export it as plain text.
