# 2024_K8S_Test

- build docker image
`docker build -t asia-east1-docker.pkg.dev/round-center-422013-u2/leo-k8s-demo/k8stest .`


## Image �s���ɮש߰e�ܻ��ݾ���
```cmd
# save docker image
docker save k8stest -o d:\Lab\k8stest.tar

# scp docker image file
gcloud compute scp D:\Lab\k8stest.tar leozheng20240501@controller:/home/leozheng20240501/
```

## ���e Images �� GAR

```cmd
gclou auth login
gcloud auth configure-docker asia1-east1-docker.pkg.dev
```

## �覡1 ���o Token (�u��60�����ɮ�)
```cmd
gcloud auth print-access-token

docker login -u oauth2accesstoken -p "ya29.a.." https://asia-east1-docker.pkg.dev

docker push asia-east1-docker.pkg.dev/round-center-422013-u2/leo-k8s-demo/k8stest
```

## �覡2 �z�L�A�ȱb�����_

```cmd
(Get-Content D:\Lab\leo-gar.json) | docker login  -u _json_key --password-stdin https://asia-east1-docker.pkg.dev

docker push asia-east1-docker.pkg.dev/round-center-422013-u2/leo-k8s-demo/k8stest
```



SSH �]�w

VM

ed -i '51d' /etc/ssh/sshd_config
echo PasswordAuthentication yes >> /etc/ssh/sshd_config
service ssh restart


�إ� SSH �p�_
ssh-keygen -f C:\Users\Administrator\.ssh\controller -C leozheng20240501

�s�W controller.pub �� VM ���~��� ssh key

ssh -i C:\Users\Administrator\.ssh\controller leozheng20240501@34.81.245.26