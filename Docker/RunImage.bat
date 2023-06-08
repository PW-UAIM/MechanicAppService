docker login -u majumi -p uaimrzadzi

docker stop mechanicappservice

docker pull majumi/mechanicappservice:appservice

docker run --name mechanicappservice -p 5011:5011 -it majumi/mechanicappservice:appservice

pause

docker stop mechanicappservice

docker rm mechanicappservice

pause