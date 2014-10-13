retrosheet-import-ids
=====================

This is a .NET console app that downloads and parses Retrosheet IDs from here: http://www.retrosheet.org/retroID.htm 
It will create a .csv file in C:\retrosheet\ids, which can be imported into the table created by the .sql script in the project root directory.

Retrosheet event data can be downloaded and parsed using this project: https://github.com/mbents/retrosheet-download-dotnet and imported using this project: https://github.com/mbents/retrosheet-import
