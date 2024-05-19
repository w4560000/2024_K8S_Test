# 2024_K8S_Test

- build docker image
`docker build -t asia-east1-docker.pkg.dev/round-center-422013-u2/leo-k8s-demo/k8stest .`


## Image 存成檔案拋送至遠端機器
```cmd
# save docker image
docker save k8stest -o d:\Lab\k8stest.tar

# scp docker image file
gcloud compute scp D:\Lab\k8stest.tar leozheng20240501@controller:/home/leozheng20240501/
```

## 推送 Images 至 GAR

```cmd
gclou auth login
gcloud auth configure-docker asia1-east1-docker.pkg.dev
```

## 方式1 取得 Token (只有60分鐘時效)
```cmd
gcloud auth print-access-token

docker login -u oauth2accesstoken -p "ya29.a.." https://asia-east1-docker.pkg.dev

docker push asia-east1-docker.pkg.dev/round-center-422013-u2/leo-k8s-demo/k8stest
```

## 方式2 透過服務帳號金鑰

```cmd
(Get-Content D:\Lab\leo-gar.json) | docker login  -u _json_key --password-stdin https://asia-east1-docker.pkg.dev

docker push asia-east1-docker.pkg.dev/round-center-422013-u2/leo-k8s-demo/k8stest
```