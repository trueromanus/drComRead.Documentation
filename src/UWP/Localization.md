Localization file contains data for all languages supported at application.

File content basic on JSON structure.

[
  {
    "locale":"ru-Ru",
    "texts":[],
    "images":[],
    "vectors":[],
    "objects":[]
  }
]

Images (images property in basic structure) contain object set has follow structure:

{
  "id",
  "content":"<image data in base64 encoding>",
  "metadata":{}
}

Vectors (vector property in basic structure) containt set vector shapes and has follow structure:

{
  "id",
  "path":"<geometry in short SVG format>",
  "metadata":{}
}

Text

{
  "id",
  "text":"<message for UI>",
  "metadata":{}
}

Markdown

vector://<id>
image://<id>
object://<id>
