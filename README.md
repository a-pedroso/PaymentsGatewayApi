## Run Application
Tested on Windows 11 with .NET 6 SDK
<br/>
On Visual Studio, hit Run from Docker Compose Project
Or at Solution Folder, on your shell of your choice type
```text
docker-compose up
```

## Sample JSON to create a payment
```json
{
  "source": {
    "type": "Card",
    "expiryMonth": 12,
    "expiryYear": 2022,
    "cardNumber": 1234567890123456,
    "cvv": 456
  },
  "amount": 40,
  "currency": "USD",
  "reference": "REF_A",
  "metadata": {
    "udf1": "235g",
    "couponCode": "CCDD343",
    "partnerId": 30
  }
}
```

## Useful Links after running docker compose up
execute some actions on API in order to have some metrics, logs and tracing.

| WebPage       | Link          | Login         | Password      |
| ------------- |---------------|:-------------:|:-------------:|
| API - Swagger | https://localhost:5001/swagger/index.html | m2m | secret |
| API - Metrics | https://localhost:5001/metrics      | - | - |
| API - Health | https://localhost:5001/health       | - | - |
| Grafana       | http://localhost:3000/ | admin | admin |
| Grafana - Metrics Dashboard       | http://localhost:3000/d/zyAf4i4Zz2/prometheus-net | - | - |
| Grafana - Loki Logs      | [here](http://localhost:3000/explore?orgId=1&left=%7B%22datasource%22:%22Loki%22,%22queries%22:%5B%7B%22refId%22:%22A%22,%22expr%22:%22%7BApplicationName%3D%5C%22payments-gateway-webapi%5C%22%7D%22,%22queryType%22:%22range%22%7D%5D,%22range%22:%7B%22from%22:%22now-1h%22,%22to%22:%22now%22%7D%7D) | - | - |
| Jaeger        | http://localhost:16686/ | - | - |
| Prometheus    | http://localhost:9090/ | - | - |
| Seq           | http://localhost:5341/ | - | - |
| Redis-Commander | http://localhost:8081/ | root | qwerty |

## Technologies
* .NET 6.0
* ASP.NET Core 6.0
* Entity Framework Core 6.0
* Swagger
* Serilog
* CQRS with MediatR
* Fluent Validation
* Problem Details RFC
* Health Checks
* Prometheus-net
* OpenTelemetry
* Docker


## Improvements
* at Domain layer, move away from primitive obsession and follow cko documentation to improve it
* validate use string instead long for card number

## License
This project is licensed with the [MIT license](LICENSE).