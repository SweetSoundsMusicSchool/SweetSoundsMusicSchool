FROM microsoft/dontnet:1.0.1-runtime
COPY . /app
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000
ENTRYPOINT ["dotnet", "Capstone1.dll"]