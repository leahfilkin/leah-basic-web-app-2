#!/usr/bin/env bash
set -euo pipefail

if [[ "$#" -ne 2 ]]; then
  echo "usage: deploy <env> <image_tag> (eg. where env: [preprod|prod])";
  exit 1;
fi

# deploy...
env="${1}"
imageTag="${2}"

ktmpl -f "jupiter/${env}.yml" -p imageTag "${imageTag}" jupiter/template.yml | kubectl apply -f -