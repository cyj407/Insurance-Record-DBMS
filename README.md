# Insurance-Record Database System
![](https://i.imgur.com/6zhDKb8.png)
- An *Chinese* Insurance Database Application can handle search, insertion, update, deletion, etc.
- Handle two kinds of input, button input and directly type the SQL code.
- Used to save owner, vehicle, warranty, dealer and fee information.
- Supported to do nested queries and aggregation function search.

## Features
- Search section
    - You can show data of the certain month.
    - There are five useful selection search which is used nested queries, such as IN, NOT IN, EXISTS, NOT EXISTS.
    - It is supported to do MAX, MIN, AVG, COUNT, SUM, HAVING operation. 
- Input section
    - There are two tab pages can switch. You can directly type the SQL command or simply fill in the data according to the needs.
    - You can update data only when double-clicking data from the list part.
- Buttons
    - Five useful buttons are put in the right side of the input section.
        - 清除輸入 can clear the current input on the form.
        - 插入 can insert new data when finishing filling requirement in the input.
        - 更新 can update data which is currently selected.
        - 進階 can do aggregation function.
![](https://i.imgur.com/zOLJtZE.png)
        - 刪除 can delete the selected data showed in the output section.
- Output section
    - Show results after the operation.
    - You can double-click to copy the current data or click once to delete data.

## Database Schema
### ER Diagram
![](https://i.imgur.com/GgprBKq.png)
### Relational Schema (3NF)
![](https://i.imgur.com/ntYp9Hx.png)

## Environment
- C# in [Visual Studio 2017](https://docs.microsoft.com/zh-tw/visualstudio/releasenotes/vs2017-relnotes)
- [MySQL](https://www.mysql.com/) and use [MYSQL WORKBENCH](https://www.mysql.com/products/workbench/) to assist.

## Reference
- [C# MySQL Tutorial](https://www.youtube.com/watch?v=deRSq-Fb2BM)
