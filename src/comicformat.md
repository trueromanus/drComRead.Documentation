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
  timestamp: 1234134234, <-- full document last timestamp
  items: [ <-- items is either sequence or group comic books
    {
      "url": "http://test.com", <-- path to collection
      "title": "Pyromaniac", <-- Title of comic book
      "coverUrl": "http://test.com/cover12.jpg", <-- Cover for comic book
      "timestamp": 23435345, <-- item timestamp
      "id": "GUID here or something unique", <-- comic book identifier within collection
    }
  ]
}
```
