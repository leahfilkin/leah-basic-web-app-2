ktmpl -f "jupiter/${env}.yml" -p imageTag "${imageTag}" jupiter/template.yml | kubectl apply -f -