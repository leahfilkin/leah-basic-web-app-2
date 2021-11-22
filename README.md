# leah-basic-web-app-2

## Background
[Kata requirements and expectations](https://github.com/MYOB-Technology/General_Developer/blob/main/katas/kata-phase-2/kata-basic-web-application.md)

## Endpoints
All endpoints are documented where [the API](https://leah-filkin-app.svc.platform.myobdev.com) is hosted

## Running and deploying
### Run tests
```bash
docker-compose run --rm tests
```

### Build API image and push to Cloudsmith
```bash
./scripts/build.sh ${BUILDKITE_BUILD_NUMBER}
```

## Deploy API to Jupiter
```bash
# deploy to preprod
./scripts/deploy.sh preprod ${BUILDKITE_BUILD_NUMBER}
# deploy to prod
./scripts/deploy.sh prod ${BUILDKITE_BUILD_NUMBER}
```



