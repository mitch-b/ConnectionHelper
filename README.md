# ConnectionHelper

Playing around with:

* .NET 9 solution
* Microsoft OpenApi library
* Scalar OpenAPI viewer

## Running

```
docker run --rm -p 8080:8080 ghcr.io/mitch-b/connectionhelper:main
```

Or, Docker Compose:

```yml
version: '3.9'
services:
  connectionhelper:
    image: ghcr.io/mitch-b/connectionhelper:main
    ports:
      - 8080:8080
```

Then, open browser to view: 

* Scalar OpenAPI viewer: <a href="http://localhost:8080/scalar/v1">http://localhost:8080/scalar/v1</a>
* Connection info API endpoint: <a href="http://localhost:8080/info">http://localhost:8080/info</a>

## Building

To build locally, download source and enter root directory:

```bash
docker build -f .\ConnectionHelper\Dockerfile -t connectionhelper:local .
docker run --rm -p 8080:8080 connectionhelper:local
```

To use Visual Studio to build & debug, you'll need the latest Visual Studio 2022 Preview as this project uses .NET 9 preview and the new `.slnx` format.