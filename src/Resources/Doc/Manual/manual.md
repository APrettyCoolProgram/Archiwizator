<!--
  Software manual template (b210104)
  https://github.com/APrettyCoolProgram/my-development-environment/tree/master/templates/documentation
-->

<h1 align="center">

  <img src="Image/archiwizator-logo.png" alt="Archiwizator logo" width="575">
  <br>
  MANUAL
  <br>

</h1>

<h4 align="center">

  Archiwizator v0.905-beta&nbsp;&bull;&nbsp;Last updated January 4, 2021

</h4>

***

<!-- The HTML indentations have to stay this way to work. -->
<table>
<tr>
<td img src="RepositoryData/Asset/Image/Document/README/spacer.png" alt="blank-spacer" width="1000" height="1">

  ### CONTENTS
  [ABOUT ARCHIWIZATOR](#about-archiwizator)<br>
  [THE MAIN WINDOW](#the-main-window)<br>
  &nbsp;&nbsp;&nbsp;&nbsp;[ARCHIWIZATOR OPTIONS](#1-archiwizator-options)<br>

</td>
</tr>
</table>

# ABOUT ARCHIWIZATOR

### What
Archiwizator is a GUI for 7-Zip.

### Why
I couldn't find anything that did this.

### How
Uses [7-Zip](URL)

# THE MAIN WINDOW
When Archiwizator starts, you the main window will be displayed:

<h3 align="center">

  <img src="Image/main-window-shaded-numbered.png" alt="Archiwizator main window" width="600">

</h3>

The main window is comprised of:

1. [Archiwizator options](#1-archiwizator-options)
2. [7-Zip options](#7zip-options)
3. [Source options](#source-options)
4. [The Archiwizate button](#the-archiwizate-button)
5. [Progress overview display](#progress-overview-display)
6. [Progress details display](#progress-details-display)

# 1. ARCHIWIZATOR OPTIONS
Archiwizator options are divided into three categories:
* [Preparation](#preparation)
* [During compression](#during-compression)
* [Cleanup](#cleanup)

## PREPARATION
These options take place prior to Archiwizator doing any compression.

### Extract existing root directories
Extracts all archive files in the source directory, then deletes the original archive files.

Enable this option if there are archive files in the source directory that you want to re-archive using Archiwizator.

EXAMPLE
The following archives:
```
../SourcePath/compressed-file-01.zip
../SourcePath/compressed-file-02.zip
..
```
would be extracted to individual sub-directories:
```
../SourcePath/compressed-file-01/
../SourcePath/compressed-file-02/
..
```
The newly created sub-directories would then be archived by Archiwizator.

#### NOTES
* Only .zip files will be extracted.

### Extract existing archives in the target
Extracts any archive files in all sub-directories of the source directory, then deletes the original archive files.

Enable this option if there are archive files in the sub-directories of the source directory that you want to re-archive using Archiwizator.

EXAMPLE
The following archives:
```
../SourcePath/SubDirectory01/compressed-file-01.zip
../SourcePath/SubDirectory01/compressed-file-02.zip
..
../SourcePath/SubDirectory99/compressed-file-03.zip
../SourcePath/SubDirectory99/compressed-file-04.zip
..
..
```
would be extracted to individual sub-directories:
```
../SourcePath/SubDirectory01/compressed-file-01/
../SourcePath/SubDirectory01/compressed-file-02/
..
../SourcePath/SubDirectory99/compressed-file-03/
../SourcePath/SubDirectory99/compressed-file-04/
```
The newly created sub-directories would then be included in the partent when archived by Archiwizator.

#### NOTES
* Only .zip files will be extracted
* Only goes down one level

#### Remove sub-directories named
Remove sub-directories with specific names.

Enable this option if there are specific sub-directories that you don't want included when using Archiwizator.

EXAMPLE
If the provided list is:
```
!Temp, old, do-not-archive
```
the following directories would not be archived:
```
../SourcePath/temporary/
../SourcePath/old_data/
../SourcePath/ignore-this-folder/
```
The remaining sub-directories would then be archived by Archiwizator.

#### NOTES
* Use caution with this option!

## DURING COMPRESSION

### Prepend datestamp
Adds a `_YYMMDD` datestamp to the end of an archive filename.

Enable this option if you want to be able to easily determine when an archive was created.

EXAMPLE
An archive created on December 29th, 2020 with a prepended datestamp will have a filename like this:
```
../SourcePath/compressed-file-01_201229.7z
```

## CLEANUP



# 2. 7-ZIP OPTIONS
7-Zip options are divided into three categories:

## COMPRESSION
These options