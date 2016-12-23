Copy, paste, and run the command below to register the host with Rancher:

sudo docker run -e CATTLE_AGENT_IP="172.17.0.2"  -d --privileged -v /var/run/docker.sock:/var/run/docker.sock -v /var/lib/rancher:/var/lib/rancher rancher/agent:v1.1.2 http://localhost:8082/v1/scripts/52C37F7A621055181B79:1482523200000:QPwh70PTr3supuoT90T7h8xHUSg

docker run -e CATTLE_AGENT_IP="172.17.0.2"  -d --privileged -v d:\vm\rancher\docker.sock:/var/run/docker.sock -v d:\vm\rancher\rancher:/var/lib/rancher rancher/agent:v1.1.2 http://localhost:8082/v1/scripts/52C37F7A621055181B79:1482523200000:QPwh70PTr3supuoT90T7h8xHUSg
