# Archiwizator: Roadmap

# FIXES/REFACTORS
* Move tooltip code someplace so:
  * XAML is less complex
  * Easier to update manual.md

# FEATURES

## Before options
* Pre-extract other formats

## During options
* Test after archiving
* Don't overwrite existing
* Always start one directory in
* Logging
* Metal soundtrack

## Cleanup options

## 7-Zip options
* Test archive
* Other 7-Zip options

## Source options
* Allow different dest

## Destination options (new)
* Allow different dest

## Other
* Settings
  * Presets (GOG, etc)

# CODE
* Before/after stats next to logo
* Clicking source/dest opens dialog
* Stop cmd from interuppting
* Progress updates while not having focus, etc.
* What's going on with the Archiziwate button when archiziwating?
* Version in title bar
* Skip files if they exist, or overwrite
* Verify that the source/dest textboxes validate correctly.
* Change lblProgressDetails to a TextBox/TextBlock
* Add ToolTipService.ShowOnDisabled="True" to all tooltips
* Add a tooltip delay
* Cleanup unused xaml tags
* Clean up help/tooltips
* Clean up the remove directories lists (i.e. quotes, *, etc)
* Tooltips can open the manual
* SHA hashes
* Get the EXE once