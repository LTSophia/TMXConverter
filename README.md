# TMX Converter
TMXConverter is a program designed to convert images to TMX. 

It does not currently allow you to convert files from TMX to another format.

## Usage
```
TMXConverter.exe imagefile(png, jpeg, bmp or tga)
	-o -output: sets name of file output
	-u -userid: sets user id of TMX (default: 1)
	-c -comment: sets user comment (defaults to filename)
	-ns -nosolidify: removes solidifying of texture edge
```
### imagefile:
TMXConverter takes most common image files, as well as Targa images (.tga).

If theres any image file I should add, open an issue and request it there.

The input image file needs to be the first argument to the program, it can not be put after any of the commands.

**Example:**
`TMXConverter.exe foobar.png`
Correct!

`TMXConverter.exe -ns foobar.png`
Incorrect!

### -output:
Sets the filename of the export, defaults to the same name as the input file as a .tmx.

**Example:**
`TMXConverter.exe foo.png -output bar.tmx`

### -userid:
Sets the User ID of the tmx file; 0 is for bustups, 1 is for all other textures. Defaults to 1.

**Example:**
`TMXConverter.exe foobar.png -userid 0`

### -comment:
Sets the User Comment of the tmx file. Basically the name that the file will show up as in Amicitia. 

**Example:**
`TMXConverter.exe foo.png -comment bar`

### -nosolidify:
Turns of the solidify effect that is used to get rid of halos on transparency. If your textures do not have transparency, use this to save time taken to process each file.

**Example:**
`TMXConverter.exe foobar.png -nosolidify`

## Testimonial
![Pixelguin Approved!](/Images/Testimonial.png)
Check out [Pixelguin's in-depth guide](https://gamebanana.com/tuts/15675) on this tool!
