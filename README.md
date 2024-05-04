# 2024_K8S_Test

- build docker image
`docker build -t k8stest .`


- save docker image
`docker save k8stest -o d:\Lab\k8stest.tar`


- scp docker image file
`gcloud compute scp D:\Lab\k8stest.tar leozheng20240501@controller:/home/leozheng20240501/`