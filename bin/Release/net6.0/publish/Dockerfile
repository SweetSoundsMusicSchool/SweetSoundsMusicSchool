FROM microsoft/dotnet:1.0.1-runtime
COPY --from=build /app .
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080
ENTRYPOINT ["dotnet", "Capstone1.dll"]