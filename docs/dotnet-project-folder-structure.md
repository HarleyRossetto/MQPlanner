# .NET Project Folder Structure

- `.vscode` - Visual Studio Code configurations
- `artifacts` - Build outputs go here. Doing a buildcmd/build.sh generates artifacts here (nupkgs, dlls, pdbs, etc.)
- `build` - Build customizations (custom msbuild files/psake/fake/albacore/etc) scripts
- `docs` - Documentation stuff, markdown files, help files etc
- `libs` - Things that can NEVER exist in a NuGet Package
- `packages` - NuGet Packages
- `samples` - (optional) Sample Projects
- `src` - Main Projects (the product code)  
- `tests` - Test Projects
- `build.cmd` - Bootstrap build for windows 
- `build.sh` - Bootstrap build for *nix 