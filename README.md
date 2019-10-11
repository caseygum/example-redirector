# example-redirector
Example Redirector app - C#, .NetCore 3.0, WEB API

### Build and run the app (from the output directory) with the follwing command lines:
```
export ASPNETCORE_URLS=http://0.0.0.0:5080/     
dotnet ./Redirector.dll ./mapping.json
```

### Mapping File (mapping.json)
```
{
  "defaultDestination": "https://www.google.com?q=Default+Destination",
  "mappings": {
    "/docs/DOC-12345": "https://www.google.com?q=Destination of DOC-12345",
    "/docs/DOC-54321": "https://www.google.com?q=Destination of DOC-54321"
  }
}
```

If the incoming request matches a path defined in **mappings**, it will 301 redirect to that location, otherwise, it will 302 redirect to **defaultDestination**.


### Testing it out

After running the app, navigate to:    
- http://localhost:5080/docs/DOC-12345
- http://localhost:5080/docs/DOC-54321
- http://localhost:5080/some-other-path
