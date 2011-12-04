@echo off
FOR /R %%X in (*.bo) DO (
    echo %%X
    extractor %%X
)
