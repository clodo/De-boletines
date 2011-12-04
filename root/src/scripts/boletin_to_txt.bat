@echo off
FOR /R %%X in (*.pdf) DO (
    java -jar pdfbox-app-1.6.0.jar ExtractText -encoding UTF-8 %%X %%~nX.tmp
)

