#!/usr/bin/env bash

if [[ "$#" -ne 2 ]]; then
  echo "usage: deploy <env> <image_tag>";
  exit 1;
fi

# deploy...
env="${1}"
imageTag="${2}"

if [[ $env == "prod" ]]
then
    deployment="leah-filkin-app"
elif [[ $env -eq "preprod" ]]
then
    deployment="leah-filkin-app-preprod"
fi

ktmpl -f "jupiter/${env}.yml" -p imageTag "${imageTag}" jupiter/template.yml | kubectl apply -f -
