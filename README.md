# RomReader
Reads Rom Metadata

## Overview 
This project was designed to categorize and read metadata of various types of roms for game consoles. Many of these file types appear similar but vary in how they store data and by extension how they are read by various emulators. This project was a test to myself to see if I could write a program to interpret this data properly depending on its file type without simply using the file extension.

## How it works
As of now the program can only recognize two different rom types and file types - Z64 Nintendo 64 files and WBFS Nintedo Wii files. These file types are detected by reading their magic numbers rather than their file extensions. The list of magic numbers for files can be found in the section below. Once the file type has been identified a child class object of the RomFile class (which is a series of classes that correspond to various consoles) is inserted into a list. When this is done, the offset to the title of the game is used to read the title from memory, however, not all rom types have the same endiannes so sometimes these strings appear backwards or byteswapped in a hex editor. This is the reason the empty RomFile child classes exist  - if any extra interpretation is needed.

## Magic Numbers List

Nintendo 64
- z64
  - 0x80, 0x37, 0x12, 0x40
  
Nintendo Wii
- WBFS
  - 0x57, 0x42, 0x46, 0x53
