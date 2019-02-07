# Blazor Spreadsheet


This repo contains spreadsheet protopype for Blazor.

[live demo](https://lupblazordemos.z13.web.core.windows.net/SpreadsheetPage)

You can set values to any cell, also set formulas for basic arithmetic calculations.

In formula can be included another cells using their addresses, when you select cell all referenced cells get highlighted.

Calculations are made using **recursion** because there can be multiple level dependencies, any **circuit references** are detected and restricted.



Any PRs are welcome.


![image](https://raw.githubusercontent.com/Lupusa87/BlazorSpreadsheet/master/spreadsheet.png)





