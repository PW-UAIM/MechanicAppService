docker login -u majumi -p uaimrzadzi

docker rmi majumi/mechanicappservice:appservice

docker build -f ../majumi.CarService.MechanicsAppService.Rest/Dockerfile.prod -t majumi/mechanicappservice:appservice ..

docker logout

pause