# Set your working directory to the root of your .NET C# repository
#Set-Location -Path "C:\path\to\your\repository"

# Install DocFX as a .NET global tool if it's not already installed
if (!(Get-Command -Name "docfx" -ErrorAction SilentlyContinue)) {
    dotnet tool install --global docfx
}

# Assumption: There is a ./docs/docfx.json file present already.

# Generate metadata from the source code
docfx metadata

# Build the site using DocFX and output the generated content to the "docs" directory
docfx build -o ./docs

# Optional: Remove the "obj" and "_site" folders created by DocFX
Remove-Item -Path "./obj" -Recurse -Force
Remove-Item -Path "./_site" -Recurse -Force
