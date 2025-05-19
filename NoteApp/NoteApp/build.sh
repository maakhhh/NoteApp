dotnet publish -c Release -o ./publish
tar -czf noteapp.tar.gz -C ./publish .