build:
	dotnet publish TrackTagger.csproj -o out
	cp LICENSE COPYRIGHT NOTICE README.md out/

format:
	dotnet format TrackTagger.csproj --verbosity diag --severity info --include-generated
