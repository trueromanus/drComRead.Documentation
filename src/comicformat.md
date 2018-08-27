## Format for sharing comic books in local networks and internet

### Full collection file

```
{
  "collector": "Alf" <-- Name of collector or collector team
  "team": [
    {
      "post": "Localizator", <-- What does this person do?
      "name": "Braniak" <-- Name or nickname of person
    }
  ],
  settings: {
    serverFiltering: true
  },
  timestamp: 1234134234, <-- full document last timestamp
  items: [ <-- items is either sequence or group comic books
    {
      "url": "http://test.com", <-- path to collection
      "title": "Pyromaniac", <-- Title of comic book
      "originalTitle": "", <-- Title on original language,
      "description": "", <-- Decription of comics
      "locale": "en-us", <-- Locale for comic book
      "coverUrl": "http://test.com/cover12.jpg", <-- Cover for comic book
      "timestamp": 23435345, <-- item timestamp
      "genres": ["romantic", "detective"], <-- ganres list,
      "tags": ["meat", "cyperpunk"], <-- user tags
      "finished": true, <-- optional Finished translate or orgignal series
      "id": "GUID here or something unique", <-- comic book identifier within collection
      "countPages": 100 <-- optional
    }
  ]
}
```

### Collection Item

```
{
  "title": "Full title of comic book",
  "authors": [
    {
      "name": "Alex matrosov", <-- name of author
      "post": "colorist" <-- post of author
    }
  ],
  "pages": [
    {      
      "order": 1,
      "url": "http://test.com/page1",
      "isCover": false,
      "rotate": "", <-- optional (none, angle90, angle180, angle270)
      "mirror": "", <-- optional (none, vertical, horizaontal, both)
    }
  ]
}
```
