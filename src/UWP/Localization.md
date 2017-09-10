## Localization file format
version 1.0  
##### Localization file contains data for all languages supported at application.  
File content basic on JSON structure.  

```json
[
  {
    "locale":"ru-Ru",
    "texts":[],
    "images":[],
    "vectors":[],
    "objects":[]
  }
]
```

locale - Language culture name (based on ISO 639)  
texts - Array of text objects described in section Texts  
images - Array of image resources described in section Images  
vectors - Array of vector shapes described in section Vectors  
objects - Array of custom object (for custom specified resource type)  

#### Images (images property in basic structure) contain object set has follow structure:

```json
{
  "id",
  "content":"<image data in base64 encoding>",
  "metadata":{}
}
```

id - any value but must be unique in bounds all array  
content - image content encoded in base64 (PNG, JPEG and GIF must be supported)  
metadata - optional field for storing user data  

#### Vectors (vector property in basic structure) containt set vector shapes and has follow structure:

```json
{
  "id",
  "path":"<geometry as SVG Path>",
  "metadata":{}
}
```
id - any value but must be unique in bounds all array  
path - vector shape described as SVG Path  
metadata - optional field for storing user data  

#### Texts

```json
{
  "id",
  "text":"<message for UI>",
  "metadata":{}
}
```

id - any value but must be unique in bounds all array  
text - Text which be displayed in application (supported Markdown formatting and special uri described below)  
metadata - optional field for storing user data  

Special Uri

**<id>** need replace on resource id within one from resource sets (images, vectors, texts, objects)  
  
**vector://<id>** will be replaced on vector geometry from **vectors** property  

**image://<id>** will be replaced on image from **images** property  

**object://<id>** will be replaced on custom content from **objects** property  
